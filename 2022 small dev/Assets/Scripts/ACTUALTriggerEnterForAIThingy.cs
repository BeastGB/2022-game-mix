using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ACTUALTriggerEnterForAIThingy : MonoBehaviour
{
    
    public NavMeshAgent Enemy;
    
    public GameObject Player;
    
    private GameObject m_Player;
    
    public GameObject Capsule;
    public GameObject GorillaPlayer;
    
    
    public float timeRemaining;
    public bool timerIsRunning;
    
    private float secondtimeRemaining;
    private bool secondtimerIsRunning;
    
    public int range;
    
    public TriggerEnterVersionOfTheAIWanderAndAttack Scripthelpful;
    
    public bool TriggerYes;
    
    // Start is called before the first frame update
        void Start()
    {
        m_Player = GameObject.FindWithTag("Body");
    }

    // Update is called once per frame
    void Update()
    {
        Capsule.transform.position = GorillaPlayer.transform.position;
        
        if (Scripthelpful.EnteredTrigger)
        {
            Enemy.destination = Player.transform.position;
            Enemy.speed = 6;
        }
        else
        {
            timerIsRunning = true;
            secondtimerIsRunning = true;
        }
        
        
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                                timeRemaining -= Time.deltaTime;
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
        
        if (secondtimerIsRunning)
        {
            if (secondtimeRemaining > 0)
            {
                                secondtimeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Restarting timer");
                secondtimeRemaining = 6;
                secondtimerIsRunning = true;
                timeRemaining = 4;
                timerIsRunning = true;
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
