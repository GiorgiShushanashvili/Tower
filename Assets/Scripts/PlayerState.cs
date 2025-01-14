using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateScriptableObject", menuName = "ScriptableObjects/PlayerStateScriptableObject", order = 3)]
public class PlayerState : ScriptableObject
{
    [SerializeField] public RuntimeAnimatorController animatorController;
}
