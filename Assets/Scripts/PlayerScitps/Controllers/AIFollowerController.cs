using UnityEngine;
using UnityEngine.AI;

public class AIFollowerController : IMoveController
{
    public void Move(PlayerController playerController)
    {
        if (playerController != null)
        {
            playerController.GetComponent<NavMeshAgent>().isStopped = false;
            playerController.GetComponent<NavMeshAgent>().SetDestination(PlayerManager.currentPlayer.GetComponent<Transform>().position);
        }
    }
}
