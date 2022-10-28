using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class MXDisplay : PlayFabManager
{
    // Start is called before the first frame update
    public TMP_Text coinsValueText;
    
    public override void PlayFabPlayerLoggedIn()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, OnError);
    }

    // Update is called once per fram
    
    void OnGetUserInventorySuccess(GetUserInventoryResult result) 
    {
        
        int coins = result.VirtualCurrency["MX"];
        coinsValueText.text = coins.ToString();
    }
    
    
    void OnError(PlayFabError error)
        {
        Debug.Log("Error: " + error.ErrorMessage);
        
    }
}
