using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using System;



public class PlayFabCosmeticsOpposite : PlayFabManager

{

    public List<GameObject> Cosmetics;



    public override void PlayFabPlayerLoggedIn()

    {

        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), delegate (GetUserInventoryResult result)

        {

            foreach (ItemInstance item in result.Inventory)

            {

                Debug.Log(item.CatalogVersion);

                if (item.CatalogVersion == "rare")

                {

                    for (int i = 0; i < Cosmetics.Count; i++)

                    {

                        if (Cosmetics[i].name == item.ItemId)

                        {

                            Cosmetics[i].SetActive(false);
                            Debug.Log("Succesfully disabled Purchase states");

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

} 