using UnityEngine;

public interface IMoveController
{
    void Move(Player playerController, CharacterController characterController, int speed);
}
