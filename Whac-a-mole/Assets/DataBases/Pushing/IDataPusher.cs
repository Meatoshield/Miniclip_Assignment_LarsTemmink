public interface IDataPusher
{
    public bool PushData<T>(T pByteData, string pFolderName, string pFileName);
}
