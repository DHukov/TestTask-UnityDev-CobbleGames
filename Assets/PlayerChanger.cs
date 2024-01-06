using UnityEngine;

public class PlayerChanger : MonoBehaviour
{
    public delegate void ActivePlayerHandler(PlayerController playerController);
    public event ActivePlayerHandler OnPlayerChange;


    public void PlayerSwitch(PlayerController playerController)
    {
        OnPlayerChange?.Invoke(playerController);

    }
}
