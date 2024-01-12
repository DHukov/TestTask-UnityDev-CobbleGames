using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class NavMeshPlayerMovementController : IMoveController
{
    public void Move(PlayerController playerController)
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerController.GetComponent<NavMeshAgent>().isStopped = false;
            Ray endPosition = Camera.main.ScreenPointToRay(Input.mousePosition); // get position for move direction froum mouse click position

            if (!EventSystem.current.IsPointerOverGameObject()) // avoid UI detection 
            {
                if (Physics.Raycast(endPosition, out var hitInfo))
                    playerController.GetComponent<NavMeshAgent>().SetDestination(hitInfo.point); // set end position for player move 
            }
        }
    }
}
