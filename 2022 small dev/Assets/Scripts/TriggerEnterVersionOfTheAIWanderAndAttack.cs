using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerEnterVersionOfTheAIWanderAndAttack : MonoBehaviour
{
    
    public bool EnteredTrigger;
    
    public Material Jumpscare1;
        
    public GameObject Bean;
    
    
    private void OnTriggerEnter(Collider other)
    {
           if (other.gameObject.CompareTag("AIAttacker"))
           {
               EnteredTrigger = true;
           }
        if (other.gameObject.CompareTag("JumpscareGuy"))
           {
               Bean.GetComponent<MeshRenderer>().material = Jumpscare1;
           }
             
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AIAttacker"))
           {
               EnteredTrigger = false;
           }   
    }
    

}
