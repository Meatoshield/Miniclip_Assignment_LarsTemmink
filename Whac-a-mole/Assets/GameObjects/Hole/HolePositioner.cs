using UnityEngine;

/// <summary>
/// Class responsible for positioning the holes so they don't overlap.
/// The holes are first randomly placed on the screen.
/// Then the algorithm moves the holes away from each other in a interative process.
/// </summary>
public static class HolePositioner
{
    private static float _maxRepelDistance = 2.0f;

    private static float _repelStepScaler = 0.1f;

    private static int _steps = 25;

    public static void PositionHoles(GameObject[] pHoles)
    {
        Vector2[] newPositions = GetPositions(pHoles.Length);

        for (int i = 0; i < pHoles.Length; i++)
        {
            pHoles[i].transform.position = newPositions[i];
        }
    }

    private static Vector2[] GetPositions(int pAmount)
    {
        Vector2[] newPositions = new Vector2[pAmount];

        for (int i = 0; i < pAmount; i++)
        {
            newPositions[i] = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-4.0f, 4.0f));
        }

        RepelHoles(ref newPositions);

        return newPositions;
    }

    private static void RepelHoles(ref Vector2[] pPositions)
    {
        Vector2[] repelDirections = new Vector2[pPositions.Length];

        for (int i = 0; i < _steps; i++) //iterative steps, moving holes away from each other
        {
            for (int j = 0; j < pPositions.Length; j++)
            {
                repelDirections[j] = CalculateRepelDirection(j, pPositions);
            }

            //Apply the repel
            for (int j = 0; j < pPositions.Length; j++)
            {
                Vector2 position = pPositions[j];

                position += repelDirections[j];
                position = ClampPosition(position);

                pPositions[j] = position;
            }
        }
    }

    private static Vector3 CalculateRepelDirection(int pHoleIndex, Vector2[] pAllPositions)
    {
        Vector2 repelDirection = Vector3.zero;

        for (int i = 0; i < pAllPositions.Length; i++)
        {
            if (i == pHoleIndex)
            {
                continue;
            }

            //Get direction away from other hole
            Vector2 deltaPos = pAllPositions[pHoleIndex] - pAllPositions[i];
            float magnitude = deltaPos.magnitude;

            if (magnitude > _maxRepelDistance)//Other hole not in zone of influence 
            {
                continue;
            }
            //Inverse the strength of the repel, futher = less effect, closer = more effect
            repelDirection += deltaPos.normalized * (1 - magnitude / _maxRepelDistance);
        }

        //Small pull towards (0,0) => middle of the screen
        repelDirection -= pAllPositions[pHoleIndex].normalized * _repelStepScaler;

        //mulitply with scaler so we don't make massive jumps, algorithm relies on many small interations
        return repelDirection * _repelStepScaler;
    }

    private static Vector2 ClampPosition(Vector2 pPosition)
    {
        return new Vector2(Mathf.Clamp(pPosition.x, -10, 10), Mathf.Clamp(pPosition.y, -4, 4));
    }
}
