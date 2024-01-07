using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class NavMeshController : IMoveController
{
    public void Move(PlayerController playerController, int speed)
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerController.GetComponent<NavMeshAgent>().isStopped = false;
            Ray endPosition = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(endPosition, out var hitInfo))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log(hitInfo.collider.gameObject.layer);
                    playerController.GetComponent<NavMeshAgent>().SetDestination(hitInfo.point);
                }
            }
        }
    }
}
