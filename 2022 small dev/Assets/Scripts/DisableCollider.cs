using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DisableCollider : MonoBehaviour
{
    public PhotonView pv;
    public List<MeshCollider> MeshColliders; //list of meshcolliders set this in the editor

    void Start()
    {
        pv = GetComponent<PhotonView>(); // finds your players photonview

        if (pv.IsMine) // checks if u own the photonview
        {
            foreach (MeshCollider col in MeshColliders)
            {
                col.enabled = false; // disables colliders
            }
        }
    }
}