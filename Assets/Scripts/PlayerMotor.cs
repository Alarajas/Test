using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Transform targetPointSprite;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint(Vector3 point)
    {
            agent.SetDestination(point);
    }


    private void Update() 
    { 
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        animator.SetFloat("velocity", agent.velocity.magnitude);
    }


    public void HandleTargetPointSprite(Vector3 destination)
    {
        targetPointSprite.position = new Vector3(destination.x, destination.y + 0.003f, destination.z);
        
        float distanceBetweenPoints = Vector3.Distance(agent.gameObject.transform.position, destination);
        
        
        targetPointSprite.gameObject.SetActive(distanceBetweenPoints > 1);
    }
}
