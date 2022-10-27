using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject rPlatform;
    public GameObject rHand;
    public GameObject lPlatform;
    public GameObject lHand;
    public Vector3 Offset;
    //public MeshRenderer rplatformmeshrenderer;
    //public BoxCollider rplatformcollider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("TriggerR")) {
            rPlatform.SetActive(true);
            rPlatform.transform.position = rHand.transform.position - Offset;
            //rPlatform.transform.rotation = rHand.transform.rotation;

        }

        if (Input.GetButtonUp("TriggerR"))
        {
            rPlatform.transform.position = rHand.transform.position - Offset;
            //rPlatform.transform.rotation = rHand.transform.rotation;
            rPlatform.SetActive(false);
         }

            if (Input.GetButtonDown("TriggerL"))
            {
                lPlatform.SetActive(true);
                lPlatform.transform.position = lHand.transform.position - Offset;
                //rPlatform.transform.rotation = rHand.transform.rotation;

            }

            if (Input.GetButtonUp("TriggerL"))
            {
                lPlatform.transform.position = lHand.transform.position - Offset;
                //rPlatform.transform.rotation = rHand.transform.rotation;
                lPlatform.SetActive(false);
            }
        }
}   