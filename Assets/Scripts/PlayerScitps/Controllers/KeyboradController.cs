using UnityEngine;

public class KeyboradController : IMoveController
{
    public void Move(Player playerController, CharacterController characterController, int speed)
    {
        var transform = playerController.GetComponent<Transform>().transform;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
