using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class seedsScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public int seeds;
    public int HowMuchADay = 100;
    public void Start()
    {
        time();
        if (PlayerPrefs.GetInt("seed") == 0)
        {
            PlayerPrefs.SetInt("seeds", 500);
            PlayerPrefs.SetInt("seed", 1);
        }
    }

    public void time()
    {
        if (PlayerPrefs.GetInt("seed") == 1)
        {
            PlayerPrefs.SetString("a", DateTime.Today.ToBinary().ToString());
            PlayerPrefs.SetInt("seed", 2);
        }
        if (PlayerPrefs.GetString("a") != DateTime.Today.ToBinary().ToString())
        {
            PlayerPrefs.SetInt("seeds", PlayerPrefs.GetInt("seeds") + HowMuchADay);
            print("Currency = " + seeds);
            PlayerPrefs.SetInt("seed", 1);
        }
        print("" + PlayerPrefs.GetString("a"));
    }

    public void Update()
    {
        seeds = PlayerPrefs.GetInt("seeds");
    }
}