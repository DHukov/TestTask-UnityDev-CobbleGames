using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public PlayerData playerData { get; private set; }
    private int playerHealth;
    private int playerSpeed;
    private int playerRotationSpeed;
    private int playerId;
    private string playerName;
    private void Start()
    {
        playerHealth = playerData.playerHealth;
        playerSpeed = playerData.playerSpeed;
        playerRotationSpeed = playerData.playerRotationSpeed;
        playerName = playerData.playerName;
    }



}
