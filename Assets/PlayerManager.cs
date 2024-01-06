using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [field: SerializeField] public List<PlayerController> playerList { get; private set; }
    [SerializeField] private PlayerChanger playerChanger;
    [SerializeField] private PlayerController currentPlayer;
    public int[] MyProperty { get; set; }
    private void Start()
    {
        playerChanger = GetComponent<PlayerChanger>();

    }
    private void OnEnable()
    {
        playerChanger.OnPlayerChange += ActivePlayer;
    }
    private void OnDisable()
    {
        playerChanger.OnPlayerChange -= ActivePlayer;

    }

    private void ActivePlayer(PlayerController activePlayerController)
    {
        currentPlayer = activePlayerController;
        Debug.Log(currentPlayer.playerData.playerName);

    }
}
