using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Animation;

    //public AnimatorController AnimatorController;

    [SerializeField] public Animator _animator;

    private void Awake()
    {
        if (Animation == null)
        {
            Animation = this;
        }
    }
}
