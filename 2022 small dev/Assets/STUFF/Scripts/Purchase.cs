using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.XR;
using PlayFab;
using PlayFab.ClientModels;
using Photon.Pun;

public class Purchase : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enable;
    public GameObject disable;
    public string CosmeticName;
    public int price;

    private void OnTriggerEnter(Collider other)
    {
        base.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        
    }
    
    private void OnTriggerExit(Collider other)
    {
       base.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);   
        if (PlayerPrefs.GetInt("seeds") >= price)
        {
            if (PlayerPrefs.GetInt(CosmeticName) != 1)
            {
                int s = PlayerPrefs.GetInt("seeds");
                PlayerPrefs.SetInt(CosmeticName, 1);
                s -= price;
                PlayerPrefs.SetInt("seeds", s);
            }
            if (PlayerPrefs.GetInt(CosmeticName) == 1)
            {
                enable.SetActive(true);
                disable.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(CosmeticName) == 1)
        {
            enable.SetActive(true);
            disable.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}