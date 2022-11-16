using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager instance;
        public List<GameObject> Cosmetics;
    
    public List<GameObject> CosmeticsPurchaseState;
    
        public TMP_Text coinsValueText;
//private string LocalPlayFabID;

    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
    

    public void getVirtualCurrencies()
        {
            PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, jOnError);
        }
    
    void OnGetUserInventorySuccess(GetUserInventoryResult result) 
    {
        
        int coins = result.VirtualCurrency["MX"];
        coinsValueText.text = coins.ToString();
    }
    
    void jOnError(PlayFabError jerror)
        {
        Debug.Log("Error: " + jerror.ErrorMessage);
        
    }
    
    public void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");

        PlayFabPlayerLoggedIn();

        string pUsername = PlayerPrefs.GetString("username");
        
        
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, jOnError);
        
        
        
        void OnGetUserInventorySuccess(GetUserInventoryResult result) 
    {
        
        int coins = result.VirtualCurrency["MX"];
        coinsValueText.text = coins.ToString();
    }

        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = pUsername
        }, delegate (UpdateUserTitleDisplayNameResult result)
        {
            Debug.Log("Display Name Changed!");
        }, delegate (PlayFabError error)
        {
            Debug.Log("Error");
            Debug.Log(error.ErrorDetails);
        });

        //LocalPlayFabID = result.PlayFabId;
        
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), delegate (GetUserInventoryResult result)

        {

            foreach (ItemInstance item in result.Inventory)

            {

                Debug.Log("Catalog is " + item.CatalogVersion);

                if (item.CatalogVersion == "rare")

                {

                    for (int i = 0; i < Cosmetics.Count; i++)

                    {

                        if (Cosmetics[i].name == item.ItemId)

                        {

                            Cosmetics[i].SetActive(true);
                            Debug.Log("Yessir");

                        }

                    }

                }
                {

                    for (int i = 0; i < CosmeticsPurchaseState.Count; i++)

                    {

                        if (CosmeticsPurchaseState[i].name == item.ItemId)

                        {

                            CosmeticsPurchaseState[i].SetActive(false);
                            Debug.Log("Shit disabled");

                        }

                    }

                }

            }

        }, delegate (PlayFabError error)

        {

            if (error.Error == PlayFabErrorCode.AccountBanned)

            {

                Application.Quit();

            }

        });

    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account!");
        if (error.Error == PlayFabErrorCode.AccountBanned)
        {
            Debug.Log("PLAYER IS BANNED");
            
            {
                
            }
            SceneManager.LoadScene("Bans");
        }
        Debug.Log(error.GenerateErrorReport());
    }

    public virtual void PlayFabPlayerLoggedIn()
    {

    }

    //public override void OnConnectedToMaster()
    //{
    //var Hash = PhotonNetwork.LocalPlayer.CustomProperties;
    //Hash.Add("PlayFabPlayerID", LocalPlayFabID);
    //Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["PlayFabPlayerID"]);
    //}

}