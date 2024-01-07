using Unity.VisualScripting;
using UnityEngine;

public class UIPlayerChanger : MonoBehaviour, IPlayerChanger
{
    public delegate void ActivePlayerHandler(PlayerController playerController);
    public event ActivePlayerHandler OnPlayerChange;

    public void PlayerSwitch(PlayerController playerController)
    {
        OnPlayerChange?.Invoke(playerController);
    }
}
