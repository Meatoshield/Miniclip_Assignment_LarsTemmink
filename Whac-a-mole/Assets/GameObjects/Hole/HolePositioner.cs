using System.Collections;
using UnityEngine;

public static class HolePositioner
{
    public static void PositionHoles(GameObject[] pHoles)
    {
        for (int i = 0; i < pHoles.Length; i++)
        {
            pHoles[i].transform.position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-4.0f, 4.0f));
        }
    }

    private static IEnumerable NudgeHoles()
    {
        yield return new WaitForSeconds(1);
    }
}
