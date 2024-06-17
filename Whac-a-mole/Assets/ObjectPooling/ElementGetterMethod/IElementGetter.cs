
public interface IElementGetter<T>
{
    public T GetFreeInstance(ref T[] pPool, ref int pFreeObjectAmount);
}
