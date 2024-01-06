using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public enum ControllType
{
    MouseAStar,
    Keyborad,
    NonControll
}

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    private Injector injector;
    [field: SerializeField] public PlayerData playerData { get; private set; }
    private IMoveController _moveController;
    [SerializeField] private ControllType _controllType;
    private int _playerHealth;
    private int _playerSpeed;
    private int _playerRotationSpeed;
    private int _playerId;
    private string _playerName;

    private void Awake()
    {
        injector = new Injector();
        characterController = GetComponent<CharacterController>();

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
        _moveController = injector.Init(_controllType);
        _moveController.Move(this, characterController, _playerSpeed);
    }
}
