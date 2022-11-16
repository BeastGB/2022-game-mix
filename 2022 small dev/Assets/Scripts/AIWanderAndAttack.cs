using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class AIWanderAndAttack : MonoBehaviour
{
    public GameObject Player;
 
    public NavMeshAgent Enemy;
 
    public int range;
    
    public float timeRemaining = 4;
    public bool timerIsRunning = false;

 
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, Player.transform.position);
 
        if(dist < range)
        {
            Enemy.destination = Player.transform.position;
            timerIsRunning = false;
        }
        else
        {
            timerIsRunning = true;
        }
        
        
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {

            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                Vector3 newPos = RandomNavSphere(transform.position, range, -1);
                Enemy.SetDestination(newPos);
            }
        }
    }
    
    
    



public static Vector3 RandomNavSphere (Vector3 origin, float distance, int layermask) {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
           
            randomDirection += origin;
           
            NavMeshHit navHit;
           
            NavMesh.SamplePosition (randomDirection, out navHit, distance, layermask);
           
            return navHit.position;
        }
}