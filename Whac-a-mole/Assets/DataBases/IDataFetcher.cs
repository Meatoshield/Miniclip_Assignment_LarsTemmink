
public interface IDataFetcher
{
    public bool FetchData<T>(out T pDataObject, string pFolderName, string pFileName);
}
