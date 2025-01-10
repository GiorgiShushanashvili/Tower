using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    public event Action OnPressed;
    

    public void DecreaseTaps()
    {
        OnPressed?.Invoke();
    }
}
