using GorillaLocomotion;
using UnityEngine;

public class GorillaGravityZone : MonoBehaviour
{
    public Rigidbody rigidbody;
    
    private void Awake() => gameObject.layer = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other == Player.Instance.bodyCollider)
        {
            Debug.Log("Entered gravity zone");
            rigidbody.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == Player.Instance.bodyCollider)
        {
            Debug.Log("Exited gravity zone");
            rigidbody.useGravity = true;
        }
    }
}

// made by BeastyTheSpoopyFish