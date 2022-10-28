using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

[AddComponentMenu("Cloud Script Demo/Cloud Script Demo")]
[DisallowMultipleComponent]
public class CloudScript : MonoBehaviour
{
    public string PlayfabID;
    public string Reason;
    public int BanTime;
    public string OutputBan;
    public int amountToGive;
    public string outputGive;

    public void GiveCurrency()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "GivePlayerCurrency",
            FunctionParameter = new { PlayerToGiveID = PlayfabID, AmountToGive = amountToGive}
        }, OnGoodGive, OnError);
    }

    public void RemoveCurrency()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "RemovePlayerCurrency",
            FunctionParameter = new { PlayerToRemoveID = PlayfabID, AmountToRemove = amountToGive }
        }, OnGoodGive, OnError);
    }

    public void BanPlayer()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest() 
        {
            FunctionName = "BanPlayer",
            FunctionParameter = new { PlayerID = PlayfabID, BanHours = BanTime, BanReason = Reason }
        }, OnGoodBan, OnError);
    }

    void OnGoodBan(ExecuteCloudScriptResult result)
    {
        OutputBan = result.FunctionResult.ToString();
        Debug.Log(result.FunctionResult);
    }

    void OnError(PlayFabError error)
    { 
        Debug.Log("Failed To Ban Player/Give Currency");
    }

    void OnGoodGive(ExecuteCloudScriptResult result)
    {
        Debug.Log(result.FunctionResult);
    }
}
