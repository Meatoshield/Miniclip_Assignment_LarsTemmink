using System;
using System.IO;
using System.Text;
using UnityEngine;

public class PersistantDataPathPusher : IDataPusher
{
    public bool PushData<T>(T DataObject, string pFolderName, string pFileName)
    {
        string jsonData = JsonUtility.ToJson(DataObject);
        byte[] byteData = Encoding.ASCII.GetBytes(jsonData);

        string filePath = Path.Combine(Application.persistentDataPath, ("Data/" + pFolderName), (pFileName + ".txt"));

        // Create the file if it doesn't already exsist
        if (Directory.Exists(Path.GetDirectoryName(filePath)) == false)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        try
        {
            File.WriteAllBytes(filePath, byteData);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save data to: {filePath}");
            Debug.LogError($"Error {e.Message}");
            return false;
        }

        return true;
    }
}
