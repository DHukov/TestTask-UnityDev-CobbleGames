[System.Serializable]
public class GameData
{
    public float[] playerPosX;
    public float[] playerPosY;
    public float[] playerPosZ;
    public int currentPlayerIndex;

    public GameData()
    {
        playerPosX = new float[PlayerController.PlayerCount + 1];
        playerPosY = new float[PlayerController.PlayerCount + 1];
        playerPosZ = new float[PlayerController.PlayerCount + 1];
    }
}


