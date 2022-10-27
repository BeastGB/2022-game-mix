using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnable : MonoBehaviour
{
    
    public Platform platformScript;
    
    // Start is called before the first frame update
    private void OnTriggerEnter (Collider Other)
    {
        platformScript.enabled = true;   
    }

    // Update is called once per frame
    private void OnTriggerExit (Collider Other)
    {
        platformScript.enabled = true; 
    }
}