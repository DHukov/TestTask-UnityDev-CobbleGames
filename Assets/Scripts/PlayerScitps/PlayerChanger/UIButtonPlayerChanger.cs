using UnityEngine;

public class UIButtonPlayerChanger : MonoBehaviour, IPlayerChanger
{
    public void PlayerSwitch(PlayerController playerController)
    {
        PlayerManager.onPlayerChange?.Invoke(playerController);
    }
}


