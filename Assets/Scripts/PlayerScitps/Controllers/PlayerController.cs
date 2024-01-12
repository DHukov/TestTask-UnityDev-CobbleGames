using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour, IDataPersistance
{
    #region Player Components and References
    private IMoveController _moveController;
    private ControllerInjector _injector;
    private NavMeshAgent _agent;
    #endregion 

    [SerializeField] private ControllType _controllType;

    #region Player Variables
    [field: SerializeField] public PlayerData playerData { get; private set; }
    private int _playerIndex;
    public static int PlayerCount { get; private set; } = -1;
    public int _playerHealth { get; private set; }
    public int _playerSpeed { get; private set; }
    public int _playerRotationSpeed { get; private set; }

    #endregion

    private void Awake()
    {
        _injector = new ControllerInjector();
        _agent = GetComponent<NavMeshAgent>();
        
        PlayerCount++;       
            _playerIndex = PlayerCount; //set index for Player in count order

        _playerHealth = playerData.playerHealth;
        _playerSpeed = playerData.playerSpeed;
        _playerRotationSpeed = playerData.playerRotationSpeed;

        _agent.angularSpeed = _playerRotationSpeed;
        _agent.speed = _playerSpeed;
    }

    private void OnEnable()
    {
        PlayerManager.onPlayerChange += SetControlTypeByCurrentPlayer;
    }

    private void OnDisable()
    {
        PlayerManager.onPlayerChange -= SetControlTypeByCurrentPlayer;
    }

    private void Update()
    {
        _moveController = _injector.Init(_controllType);
        _moveController.Move(this);
    }

    private void SetControlTypeByCurrentPlayer(PlayerController playerController)
    {
        if (this == playerController)
            _controllType = ControllType.MouseNavMesh;
        else
            _controllType = ControllType.AIFollower;
    }

    public void LoadData(GameData gameData)
    {
        transform.position = new Vector3(gameData.playerPosX[_playerIndex], gameData.playerPosY[_playerIndex], gameData.playerPosZ[_playerIndex]);
        GetComponent<NavMeshAgent>().isStopped = true;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.playerPosX[_playerIndex] = transform.position.x;
        gameData.playerPosY[_playerIndex] = transform.position.y;
        gameData.playerPosZ[_playerIndex] = transform.position.z;
    }
}

