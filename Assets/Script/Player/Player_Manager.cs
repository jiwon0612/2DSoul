using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{

    public static Player_Manager instans = null;

    private PlayerMove move;
    private PlayerAttack attack;
    private Player_HP hp;
    
    [SerializeField]
    private Animator _anima;

    private bool isDeath;

    private float x;
    

    


    private void Awake()
    {
        if (instans == null)
        {
            instans = this;
        }
        move = GetComponent<PlayerMove>();
        attack = GetComponent<PlayerAttack>();
        hp = GetComponent<Player_HP>();

    }

    private void Start()
    {
        isDeath = false;
        
        
        
    }

    private void Update()
    {
        //플레이어 이동
        if (hp.Hp > 0)
        {
            x = Input.GetAxisRaw("Horizontal");

        }
        if (!hp.isHiting && !attack._atking&& !isDeath)
        {
            move.Move(x);

        }

        //플레이어 점프
        if (Input.GetKeyDown(KeyCode.C) && !isDeath)
        {
            
            move.Jump();
        }

        //플레이어 대시
        if (Input.GetKeyDown(KeyCode.Z) && x != 0 && !isDeath)
        {
            move.Dash1(x);
        }

        //플레이어 사망
        if (hp.Hp <= 0)
        {
            isDeath = true;
            hp.Death();
        }

        //플레이어 공격
        if (Input.GetKeyDown(KeyCode.X) && !move._isDash && !hp.isHiting && x == 0 && !isDeath && !attack._atking)
        {
            attack.Atk();
            
        }
    }

    

}
