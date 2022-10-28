using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using System;

public class PlayfabBuyTopHatTest : MonoBehaviour
{
    public GameObject EnableButton;
    public GameObject DisableButton;
    public GameObject PurchaseButton;
    
    // Start is called before the first frame update
    private void OnTriggerEnter (Collider Other)
    {
      base.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

    // Update is called once per fram
    }
    
    private void OnTriggerExit (Collider Other)
    {
      PurchaseItemRequest request = new PurchaseItemRequest();
      request.CatalogVersion = "rare";
      request.ItemId = "TopHat";
      request.VirtualCurrency = "MX";
      request.Price = 500;
        
        
       PlayFabClientAPI.PurchaseItem(request, result => {
           
           
        
        
    }, error => {
           Debug.Log(error.ErrorMessage);
       });
        base.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);  
        EnableButton.SetActive(true);
        DisableButton.SetActive(true);
        PurchaseButton.SetActive(false);
        
    }
}