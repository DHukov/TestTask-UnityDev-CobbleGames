using UnityEngine;

public class KeyboardInputPlayerChanger : MonoBehaviour, IPlayerChanger
{
    [SerializeField] private PlayerController playerOne;
    [SerializeField] private PlayerController playerTwo;
    [SerializeField] private PlayerController playerThree;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            PlayerSwitch(playerOne);

        else if (Input.GetKeyDown(KeyCode.Alpha2))
            PlayerSwitch(playerTwo);

        else if (Input.GetKeyDown(KeyCode.Alpha3))
            PlayerSwitch(playerThree);
    }
    public void PlayerSwitch(PlayerController playerController)
    {
        PlayerManager.onPlayerChange.Invoke(playerController);
    }
}


