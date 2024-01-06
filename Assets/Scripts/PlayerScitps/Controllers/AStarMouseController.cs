using UnityEngine;

public class AStarMouseController : IMoveController
{
    public void Move(Player playerController, CharacterController characterController, int speed)
    {
        Debug.Log("AStarMouseController");
    }
}
