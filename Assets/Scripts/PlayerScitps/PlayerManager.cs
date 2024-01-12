using UnityEngine;

public class PlayerManager : MonoBehaviour, IDataPersistance
{
    [field: SerializeField] public PlayerController[] playerArray { get; private set; }
    [field: SerializeField] public static PlayerController currentPlayer { get; private set; }

    public delegate void ActivePlayerHandler(PlayerController playerController);
    public static ActivePlayerHandler onPlayerChange;

    private void Start()
    {
        onPlayerChange.Invoke(playerArray[0]);
    }
    private void OnEnable()
    {
        onPlayerChange += SetCurrentPlayer;
    }

    private void OnDisable()
    {
        onPlayerChange -= SetCurrentPlayer;
    }

    private void SetCurrentPlayer(PlayerController playerController )
    {
        currentPlayer = playerController;
    }

    public void LoadData(GameData gameDate)
    {
        currentPlayer = playerArray[gameDate.currentPlayerIndex];
    }

    public void SaveData(ref GameData gameDate)
    {
        for (int i = 0; i < playerArray.Length; i++)
        {
            if(currentPlayer == playerArray[i])
            {
                gameDate.currentPlayerIndex = i;
                break;
            }
        }
    }
}
