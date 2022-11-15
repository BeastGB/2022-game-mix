using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTouch : MonoBehaviour
{
    public GameObject AHHHH;


	private void OnTriggerEnter(Collider Other)
	{
		AHHHH.SetActive(false);

	}
}
