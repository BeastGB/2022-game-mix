using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter (Collider Other)
    {
        Application.Quit();
    }

    // Update is called once per frame
    private void OnTriggerExit (Collider Other)
    {
        Application.Quit();
    }
}
