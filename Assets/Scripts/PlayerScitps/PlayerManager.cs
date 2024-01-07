using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [field: SerializeField] public PlayerController[] playerArray { get; private set; }
    public static PlayerController currentPlayer { get; private set; }
    private List<IPlayerChanger> _playerChangers;
    private UIPlayerChanger changer;

    private void Awake()
    {
        changer = GetComponent<UIPlayerChanger>();
        _playerChangers = FindAllPlayerChangers();
        currentPlayer = playerArray[0];

    }

    private void Start()
    {
        changer.OnPlayerChange += PlayerActive;
        PlayerActive(currentPlayer); 
    }

    private void Update()
    {
        foreach (var playerChanger in _playerChangers)
            playerChanger.PlayerSwitch(currentPlayer);
    }
    private void OnDisable()
    {
        changer.OnPlayerChange -= PlayerActive;
    }

    private void PlayerActive(PlayerController activePlayerController)
    {
        if (activePlayerController != null)
            currentPlayer = activePlayerController;
    }

    private List<IPlayerChanger> FindAllPlayerChangers()
    {
        IEnumerable<IPlayerChanger> _playerChanger = FindObjectsOfType<MonoBehaviour>().OfType<IPlayerChanger>();
        return new List<IPlayerChanger>(_playerChanger);
    }
}
