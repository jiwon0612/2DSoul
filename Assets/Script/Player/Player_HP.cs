using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public float Hp; //체력

    [SerializeField] 
    private AnimationClip clip; //죽는 모션

    [SerializeField] 
    private AnimationClip hitClip; // 맞는 모션


}
