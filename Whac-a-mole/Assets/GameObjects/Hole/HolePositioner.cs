using System.Collections;
using UnityEngine;

public static class HolePositioner
{
    private static float _maxRepelDistance = 2.0f;

    private static float _repelStepScaler = 0.1f;

    private static int _steps = 25;

    public static void PositionHoles(GameObject[] pHoles)
    {
        for (int i = 0; i < pHoles.Length; i++)
        {
            pHoles[i].transform.position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-4.0f, 4.0f));
        }

        RepelHoles(pHoles);
    }

    private static void RepelHoles(GameObject[] pHoles)
    {
        for(int i = 0; i < _steps; i++)
        {
            Vector3[] repelDirections = new Vector3[pHoles.Length]; 

            for(int j = 0; j < pHoles.Length; j++)
            {
                repelDirections[j] = CalculateRepelDirection(j, pHoles);
            }

            //Apply the repel
            for (int j = 0; j < pHoles.Length; j++)
            {
                Vector3 position = pHoles[j].transform.position;

                position += repelDirections[j];
                position = ClampPosition(position);

                pHoles[j].transform.position = position;
            }
        }  
    }

    private static Vector3 CalculateRepelDirection(int pHoleIndex, GameObject[] pAllHoles)
    {
        Vector3 repelDirection = Vector3.zero;

        for (int i = 0; i < pAllHoles.Length; i++)
        {
            if(i == pHoleIndex)
            {
                continue;
            }

            //Get direction away from other hole
            Vector3 deltaPos = pAllHoles[pHoleIndex].transform.position - pAllHoles[i].transform.position;
            float magnitude = deltaPos.magnitude;

            if (magnitude > _maxRepelDistance)//Other hole not in zone of influence 
            {
                continue;
            }
            //Inverse the strength of the repel, futher = less effect, closer = more effect
            repelDirection += deltaPos.normalized * (1 - magnitude / _maxRepelDistance);
        }

        //Small pull towards (0,0) => middle of the screen
        repelDirection -= pAllHoles[pHoleIndex].transform.position.normalized * _repelStepScaler;

        //mulitply with scaler so we don't make massive jumps, algorithm relies on many small interations
        return repelDirection * _repelStepScaler; 
    }

    private static Vector2 ClampPosition(Vector2 pPosition)
    {
        return new Vector2(Mathf.Clamp(pPosition.x, -10, 10), Mathf.Clamp(pPosition.y, -4, 4));
    }
}
