using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    //public static TapController Instance;
    public event Action OnPressed;


    public float Taps;
    /*private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }*/

    public void GenerateTaps()
    {
        Taps++;
    }

    public void DecreaseTaps()
    {
        Debug.Log(OnPressed);
        Taps--;
        OnPressed?.Invoke();
    }


}
