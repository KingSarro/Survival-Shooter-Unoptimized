using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour{

    //S.S
    private PlayerHealth playerHealth;
    private Transform playerTransform;
    public EnemyHealth health;
    private NavMeshAgent agent;

    private void Start(){
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        playerHealth = playerTransform.GetComponent<PlayerHealth>();
        health = GetComponent<EnemyHealth>();
        agent = GetComponent<NavMeshAgent>();
    }





    
    void Update ()
    {

        if (health.currentHealth > 0 && playerHealth.playerStats.GetCurrentHealth() > 0)
        {
            agent.SetDestination (playerTransform.position);
        }
        else
        {
            agent.enabled = false;
        }
    }

    
}
