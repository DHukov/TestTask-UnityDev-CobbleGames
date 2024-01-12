using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        _dataHandler = new FileDataHandler(Application.persistentDataPath, _fileName);
        _dataPersistances = FindAllDataPersistanceObjects();

        if (loadSavesAtStartGame)
            LoadGame();
    }

    public void NewGame()
    {
        _gameData = new GameData();
    }

    public void LoadGame()
    {
        if (_gameData == null)
            NewGame();

        _gameData = _dataHandler.Load();

        foreach (var dataPersistanceObject in _dataPersistances)
            dataPersistanceObject.LoadData(_gameData);
    }

    public void SaveGame()
    {
        if (_gameData == null)
            return;

        _dataPersistances = FindAllDataPersistanceObjects(); // repeat finding and save all objects

        foreach (var dataPersistanceObject in _dataPersistances)
            dataPersistanceObject.SaveData(ref _gameData);

        _dataHandler.Save(_gameData);
    }
    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistances);
    }
}

