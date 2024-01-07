using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine.UIElements;

[System.Serializable]
public class GameData
{
    Player player;

    public float[] playerPosX;
    public float[] playerPosY;
    public float[] playerPosZ;

    public GameData()
    {
        //player = new Player();
        playerPosX = new float[PlayerController.PlayerCount + 1];
        playerPosY = new float[PlayerController.PlayerCount + 1];
        playerPosZ = new float[PlayerController.PlayerCount + 1];

    }
}

struct Player
{
    PlayerController _playerController;
    //Vector3 playerPosition;
    public Player(PlayerController playerController)
    {
        _playerController = playerController;

    }
}
