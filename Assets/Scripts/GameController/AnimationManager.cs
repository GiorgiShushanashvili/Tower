using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Animation;

    [SerializeField] public Animator _animator;

    private void Awake()
    {
        if (Animation == null)
        {
            Animation = this;
        }
    }
}
