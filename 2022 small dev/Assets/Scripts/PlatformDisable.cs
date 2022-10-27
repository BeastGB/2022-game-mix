using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDisable : MonoBehaviour
{
    
    public PlatformsRight platformScriptRight;
    public PlatformsLeft platformScriptLeft;
    
    // Start is called before the first frame update
    private void OnTriggerEnter (Collider Other)
    {
        platformScriptRight.enabled = false;  
        platformScriptLeft.enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerExit (Collider Other)
    {
        platformScriptRight.enabled = false;
        platformScriptLeft.enabled = false;
    }
}