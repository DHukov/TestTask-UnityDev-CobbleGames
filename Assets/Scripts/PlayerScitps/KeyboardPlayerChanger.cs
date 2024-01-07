using System.Collections.Generic;
using UnityEngine;

public class KeyboardPlayerChanger : MonoBehaviour, IPlayerChanger
{
    [SerializeField] private PlayerController[] playerControllers = new PlayerController[3];

    public void PlayerSwitch(PlayerController playerController)
    {
        //var keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), Input.inputString.ToUpper());
        //switch (keyCode)
        //{
        //    case KeyCode.Keypad1:
        //        Debug.Log("Face left");
        //        break;
        //    case KeyCode.Keypad2:
        //        Debug.Log("Face Right");
        //        break;
        //    case KeyCode.Keypad3:
        //        Debug.Log("Face Right");
        //        break;
        //    default:
        //        Debug.Log("No action");
        //        break;
        //}
    }

}
