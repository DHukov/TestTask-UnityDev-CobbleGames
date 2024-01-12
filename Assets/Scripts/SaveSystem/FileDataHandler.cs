using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string _dataDirectionPath = "";
    private string _dataFileName = "";

    public FileDataHandler(string dataDirectionPath, string dataFileName)
    {
        _dataDirectionPath = dataDirectionPath;
        _dataFileName = dataFileName;
    }

    /// <summary>
    /// Getting GameData from created JSON file
    /// </summary>
    /// <returns>Returns GameData from JSON</returns>
    public GameData Load()
    {
        string fullPath = Path.Combine(_dataDirectionPath, _dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = string.Empty;
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                        dataToLoad = reader.ReadToEnd();

                }
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
                Debug.Log("Game Loaded");
            }
            catch (Exception e)
            {
                Debug.Log("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    /// <summary>
    /// Setting data to generated JSON file from GameData object
    /// </summary>
    /// <param name="data">Saved data from game</param>
    public void Save(GameData data)
    {
        string fullPath = Path.Combine(_dataDirectionPath, _dataFileName); 
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));  

            string dataToStore = JsonUtility.ToJson(data, true); 
            using (FileStream stream = new FileStream(fullPath, FileMode.Create)) 
            {
                using (StreamWriter writer = new StreamWriter(stream)) 
                    writer.Write(dataToStore);

            }
            Debug.Log("Game Saved");
        }
        catch (Exception e)
        {
            Debug.Log("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }
}