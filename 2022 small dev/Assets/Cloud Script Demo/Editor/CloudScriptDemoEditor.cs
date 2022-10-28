using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CloudScript))]
public class CloudScriptDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CloudScript cloudScript = (CloudScript)target;

        cloudScript.PlayfabID = EditorGUILayout.TextField("PlayFab ID", cloudScript.PlayfabID);
        EditorGUILayout.Space(20);
        if (GUILayout.Button("Click To Ban Player"))
        {
            if (cloudScript.PlayfabID == "")
            {

            }
            else
            {
                cloudScript.BanPlayer();
            }
        }
        cloudScript.Reason = EditorGUILayout.TextField("Reason For Ban", cloudScript.Reason);
        EditorGUILayout.Space(5);

        EditorGUILayout.LabelField("Ban Time In Hours");
        cloudScript.BanTime = EditorGUILayout.IntSlider(cloudScript.BanTime, 1, 999);
        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("Output: " ,cloudScript.OutputBan);


        EditorGUILayout.Space(50);

        if (GUILayout.Button("Click To Give Player Currency"))
        {
            if (cloudScript.PlayfabID == "")
            {

            }
            else
            {
                cloudScript.GiveCurrency();
            }
        }
        if (GUILayout.Button("Click To Remove Player Currency"))
        {
            if (cloudScript.PlayfabID == "")
            {

            }
            else
            {
                cloudScript.RemoveCurrency();
            }
        }
        EditorGUILayout.Space(5);
        EditorGUILayout.LabelField("Amount To Give/Remove To Player");
        cloudScript.amountToGive = EditorGUILayout.IntSlider(cloudScript.amountToGive, 1, 999);
        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("Output: ", cloudScript.outputGive);


        EditorGUILayout.Space(20);
        EditorGUILayout.LabelField("Must Watch!");
        if (GUILayout.Button("Tutorial", GUILayout.Width(65)))
        {
            Application.OpenURL("https://youtu.be/3zvgsk0Uy6M");
        }
        EditorGUILayout.LabelField("Must Watch!");
        EditorGUILayout.Space(20);

        if (GUILayout.Button("Help", GUILayout.Width(45)))
        {
            Application.OpenURL("https://discord.gg/GhctvzuzJ8");
        }

        if (Debug = EditorGUILayout.Toggle("Debug?", Debug))
        {
            if (Debug)
            {
                EditorGUILayout.LabelField("Playfab ID: ", cloudScript.PlayfabID);
                EditorGUILayout.Separator();
                EditorGUILayout.LabelField("Bans");
                EditorGUILayout.LabelField("Ban Reason: ", cloudScript.Reason);
                EditorGUILayout.LabelField("Ban Time: ", cloudScript.BanTime.ToString());
                EditorGUILayout.Separator();
                EditorGUILayout.LabelField("Give Currency");
                EditorGUILayout.LabelField("Amount To Give/Remove: ", cloudScript.amountToGive.ToString());
            }
            else
            {

            }
        }
    }

    public bool Debug;
}
