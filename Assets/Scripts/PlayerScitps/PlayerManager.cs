using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //[field: SerializeField] public List<Player> playerList { get; private set; }
    [field: SerializeField] public PlayerController[] playerArray { get; private set; }
    [field: SerializeField] public PlayerController _currentPlayer { get; private set; }

    private PlayerChanger _playerChanger;

    private void Start()
    {
        _playerChanger = GetComponent<PlayerChanger>();
        _playerChanger.OnPlayerChange += PlayerActive;
        PlayerActive(_currentPlayer);

    }
    private void OnDisable()
    {
        _playerChanger.OnPlayerChange -= PlayerActive;
    }

    private void PlayerActive(PlayerController activePlayerController)
    {
        if (activePlayerController != null)
        {
            _currentPlayer = activePlayerController;
            _currentPlayer.enabled = true;
            foreach (var player in playerArray)
            {
                if (player != _currentPlayer)
                    player.enabled = false;
            }
            //Debug.Log($"{_currentPlayer.playerData.playerName} activated");
        }
    }
}
