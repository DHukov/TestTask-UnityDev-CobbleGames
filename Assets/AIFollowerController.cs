using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class AIFollowerController : IMoveController
{
    public void Move(PlayerController playerController, int speed)
    {
        if (playerController != null)
        {
            playerController.GetComponent<NavMeshAgent>().isStopped = false;
            playerController.GetComponent<NavMeshAgent>().SetDestination(PlayerManager.currentPlayer.GetComponent<Transform>().position);

        }

    }
}
