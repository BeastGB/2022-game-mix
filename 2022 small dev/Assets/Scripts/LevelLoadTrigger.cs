using GorillaLocomotion;
using UnityEngine;

public class LevelLoadTrigger : MonoBehaviour
{
    public GameObject MapToEnable;
    public GameObject MapToDisable;

    private void OnTriggerEnter(Collider other)
    {
        MapToEnable.SetActive(true);
        MapToDisable.SetActive(false);
    }
}