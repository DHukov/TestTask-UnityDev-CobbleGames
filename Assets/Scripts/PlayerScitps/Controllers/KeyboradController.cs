using UnityEngine;

public class KeyboradController : IMoveController
{
    public void Move(PlayerController playerController, int speed)
    {
        var transform = playerController.GetComponent<Transform>().transform;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);
    }
}
