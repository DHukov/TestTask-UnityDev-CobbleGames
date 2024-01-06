using UnityEngine;

public class PlayerChanger : MonoBehaviour
{
    public delegate void ActivePlayerHandler(Player playerController);
    public event ActivePlayerHandler OnPlayerChange;

    public void PlayerSwitch(Player playerController)
    {
        OnPlayerChange?.Invoke(playerController);
    }
}
