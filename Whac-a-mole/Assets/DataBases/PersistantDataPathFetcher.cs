using System;
using System.IO;
using System.Text;
using UnityEngine;

public class PersistantDataPathFetcher : IDataFetcher
{
    public bool FetchData<T>(out T pDataObject, string pFolderName, string pFileName)
    {
        pDataObject = default;

        string filePath = Path.Combine(Application.persistentDataPath, ("Data/" + pFolderName), (pFileName + ".txt"));

        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Debug.LogWarning($"File at Path: {filePath} does not exist!");
            return false;
        }

        byte[] byteData = null;

        try
        {
            byteData = File.ReadAllBytes(filePath);
        }
        catch (Exception e)
        {
            Debug.LogWarning($"Failed to load data from: {filePath}");
            Debug.LogWarning($"Error: {e.Message}");
            return false;
        }

        if (byteData == null)
        {
            return false;
        }

        string jsonData = Encoding.ASCII.GetString(byteData);
        pDataObject = JsonUtility.FromJson<T>(jsonData);
        return true;
    }
}
