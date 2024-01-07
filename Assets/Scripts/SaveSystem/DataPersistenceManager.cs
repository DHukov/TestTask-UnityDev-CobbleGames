using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO.Enumeration;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File storage Config")]
    [SerializeField] private string _fileName;
    [SerializeField] public bool loadSavesAtStartGame = false;
    public static DataPersistenceManager Instance { get; private set; }

    private GameData _gameData;
    private List<IDataPersistance> _dataPersistances;
    private FileDataHandler _dataHandler;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Found more than one Data Persistance Manager");
            Destroy(gameObject);
        }
        Instance = this;
    }
    private void Start()
    {
        _dataHandler = new FileDataHandler(Application.persistentDataPath, _fileName);
        _dataPersistances = FindAllDataPersistanceObjects();
        if(_gameData != null)
        {
            if (loadSavesAtStartGame)
            {
                LoadGame();
                Debug.Log("Load at start");
            }
        }
    }

    public void NewGame()
    {
        _gameData = new GameData();
        Debug.Log("New game created");
    }
    public void LoadGame()
    {
        if (_gameData == null)
            NewGame();

        _gameData = _dataHandler.Load();

        foreach (var dataPersistanceObject in _dataPersistances)
            dataPersistanceObject.LoadData(_gameData);

        Debug.Log("Game loaded");
    }
    public void SaveGame()
    {
        if (_gameData == null)
            return;

        _dataPersistances = FindAllDataPersistanceObjects(); // repeat finding and save everything also with new objects

        foreach (var dataPersistanceObject in _dataPersistances)
            dataPersistanceObject.SaveData(ref _gameData);

        _dataHandler.Save(_gameData);
        Debug.Log("Game Saved");
    }
    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistances);
    }
}

