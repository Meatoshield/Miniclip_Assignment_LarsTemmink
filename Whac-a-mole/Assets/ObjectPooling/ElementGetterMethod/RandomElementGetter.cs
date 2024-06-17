using UnityEngine;

/// <summary>
/// functionality that returns a random free element from the pool.
/// </summary>
/// <typeparam name="T"></typeparam>
public class RandomElementGetter<T> : IElementGetter<T>
{
    public T GetFreeInstance(ref T[] pPool, ref int pFreeObjectAmount)
    {
        int elementIndex = Random.Range(0, pFreeObjectAmount);

        //Switch the random free instance with the last free instance
        T randomFreeInstance = pPool[elementIndex];
        T lastFreeInstance = pPool[pFreeObjectAmount - 1];
        pPool[pFreeObjectAmount - 1] = randomFreeInstance;
        pPool[elementIndex] = lastFreeInstance;

        //Lock randomFreeItem which was switched with the lastFreeItem
        pFreeObjectAmount--;

        return randomFreeInstance;
    }
}
