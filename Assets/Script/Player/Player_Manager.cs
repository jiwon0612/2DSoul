using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    [SerializeField] private AnimationClip clip;

    public static Player_Manager instans = null;

    private PlayerMove move;
    private PlayerAttack attack;
    private Player_HP hp;
    
    [SerializeField]
    private Animator _anima;

    

    


    private void Awake()
    {
        if (instans == null)
        {
            instans = this;
        }
        move = GetComponent<PlayerMove>();
        attack = GetComponent<PlayerAttack>();
        _anima = GetComponent<Animator>();
        hp = GetComponent<Player_HP>();

    }

    private void Start()
    {
        
        _anima.SetBool("isHit", false);
        
        
    }

    private void Update()
    {
        //�÷��̾� �̵�
        float x = Input.GetAxisRaw("Horizontal");
        if (!hp.isHiting && !attack._atking)
        {
            move.Move(x);

        }

        //�÷��̾� ����
        if (Input.GetKeyDown(KeyCode.C))
        {
            move.Jump();
        }

        //�÷��̾� ���
        if (Input.GetKeyDown(KeyCode.Z) && x != 0)
        {
            move.Dash1(x);
        }

        //�÷��̾� ���
        if (hp.Hp <= 0)
        {
            hp.Death();
        }

        //�÷��̾� ����
        if (Input.GetKeyDown(KeyCode.X) && !move._isDash && !hp.isHiting && x == 0)
        {
            attack.Atk();
            
        }
    }

    

}
