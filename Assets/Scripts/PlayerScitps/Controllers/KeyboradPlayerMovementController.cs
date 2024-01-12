using UnityEngine;

public class KeyboradPlayerMovementController : IMoveController
{
    public void Move(PlayerController playerController)
    {
        var transform = playerController.GetComponent<Transform>().transform;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(x * playerController._playerSpeed * Time.deltaTime, 0, z * playerController._playerSpeed * Time.deltaTime); //moving player by changy position
    }
}
