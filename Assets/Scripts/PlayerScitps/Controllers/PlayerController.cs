using UnityEngine;

public class PlayerController : MonoBehaviour, IDataPersistance
{
    private IMoveController _moveController;
    private Injector _injector;
    public static int PlayerCount { get; private set; } = -1;
    [SerializeField] private int _playerIndex;

    [SerializeField] private ControllType _controllType;
    #region Player Data
    [field: SerializeField] public PlayerData playerData { get; private set; }
    private int _playerHealth;
    private int _playerSpeed;
    private int _playerRotationSpeed;
    private int _playerId;
    private string _playerName;
    #endregion
    private void Awake()
    {
        _injector = new Injector();
        PlayerCount++;
        _playerIndex = PlayerCount;
        Debug.Log(PlayerCount);
    }
    private void Start()
    {

        _playerHealth = playerData.playerHealth;
        _playerSpeed = playerData.playerSpeed;
        _playerRotationSpeed = playerData.playerRotationSpeed;
        _playerName = playerData.playerName;
    }

    private void Update()
    {
        _moveController = _injector.Init(_controllType);
        _moveController.Move(this, _playerSpeed);
    }
    public void LoadData(GameData gameData)
    {
        transform.position = new Vector3(gameData.playerPosX[_playerIndex], gameData.playerPosY[_playerIndex], gameData.playerPosZ[_playerIndex]);
        Debug.Log(transform.position);
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.playerPosX[_playerIndex] = transform.position.x;
        gameData.playerPosY[_playerIndex] = transform.position.y;
        gameData.playerPosZ[_playerIndex] = transform.position.z;
    }
}

