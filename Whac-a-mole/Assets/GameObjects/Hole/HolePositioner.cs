using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HoleSpawner
{
    public static void PositionHoles(GameObjectPool pPool)
    {
        Object[] holes = pPool.GetAllInstances();

        for (int i = 0; i < holes.Length; i++)
        {
            ((GameObject)holes[i]).transform.position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-4.0f, 4.0f));
        }
    }

    private static IEnumerable NudgeHoles()
    {
        yield return new WaitForSeconds(1);
    }
}
