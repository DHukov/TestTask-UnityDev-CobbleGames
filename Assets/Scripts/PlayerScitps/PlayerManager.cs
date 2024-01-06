using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [field: SerializeField] public List<Player> playerList { get; private set; }
    [field: SerializeField] public Player _currentPlayer { get; private set; }

    private PlayerChanger _playerChanger;

    private void Start()
    {
        _playerChanger = GetComponent<PlayerChanger>();
        _playerChanger.OnPlayerChange += PlayerActive;
        PlayerActive(_currentPlayer);

    }
    private void OnEnable()
    {
    }
    private void OnDisable()
    {
        _playerChanger.OnPlayerChange -= PlayerActive;

    }
    private void Update()
    {

    }

    private void PlayerActive(Player activePlayerController)
    {
        if (activePlayerController != null)
        {
            _currentPlayer = activePlayerController;
            _currentPlayer.enabled = true;
            foreach (var player in playerList)
            {
                if (player != _currentPlayer)
                    player.enabled = false;
            }
            Debug.Log($"{_currentPlayer.playerData.playerName} activated");
        }
    }
}
