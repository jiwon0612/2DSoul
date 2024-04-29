using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public float Hp; //체력

    public bool isHiting;

    private bool isDeath;

    [SerializeField] 
    private AnimationClip deathClip; //죽는 모션

    [SerializeField] 
    private AnimationClip hitClip; // 맞는 모션

    [SerializeField]
    public GameObject reStart;

    public Animator _anima;
    private PlayerMove move;
    private PlayerASkill aSkill;

    private Rigidbody2D rigid;
    

    private void Awake()
    {
        move = GetComponent<PlayerMove>();
        rigid = GetComponent<Rigidbody2D>();
        aSkill = GetComponentInChildren<PlayerASkill>();
        
    }

    private void Start()
    {
        isHiting = false;
        isDeath = false;
    }

    public void Death()
    {
        rigid.velocity = new Vector3(0, 0, 0);
        //Time.timeScale = 0;
        isDeath = true;
        _anima.SetBool("isDeath", true);
        StartCoroutine(AnimaDeath());
    }

    public void Hit(float x)
    {
        if (!move._isDash && !isHiting && !isDeath &&!aSkill.isOnSkill)
        {
            rigid.velocity = new Vector3(0, 0, 0);
            Hp -= x;
            _anima.SetBool("isHit", true);
            isHiting = true;
            StartCoroutine(AnimatorHitCO());
            

        }

    }

    IEnumerator AnimaDeath()
    {
        yield return new WaitForSecondsRealtime(deathClip.length);
        _anima.SetBool("isDeath", false);
        reStart.SetActive(true);
    }
    IEnumerator AnimatorHitCO()
    {
        yield return new WaitForSecondsRealtime(hitClip.length);
        _anima.SetBool("isHit", false);
        isHiting = false;
    }
    
}
