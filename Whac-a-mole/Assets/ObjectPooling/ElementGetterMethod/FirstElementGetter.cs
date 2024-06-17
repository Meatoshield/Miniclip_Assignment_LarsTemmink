using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstElementGetter<T> : IElementGetter<T>
{
    public T GetFreeInstance(ref T[] pPool, ref int pFreeObjectAmount)
    {
        //Switch the first free instance with the last free instance
        T firstFreeInstance = pPool[0];
        T lastFreeInstance = pPool[pFreeObjectAmount - 1];
        pPool[pFreeObjectAmount - 1] = firstFreeInstance;
        pPool[0] = lastFreeInstance;

        //Lock firstFreeItem which was switched with the lastFreeItem
        pFreeObjectAmount--;

        return firstFreeInstance;
    }
}
