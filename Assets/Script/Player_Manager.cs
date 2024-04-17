using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public static Player_Manager instans = null;

    private PlayerMove PlayerMove;
    private PlayerAttack PlayerAttac;
    [SerializeField]
    private RestartUI Restart;
    [SerializeField]
    private Animator _anima;

    private bool isHiting;

    public float Hp = 100;
    

    private void Awake()
    {
        if(instans == null)
        {
            instans = this;
        }
        PlayerMove = GetComponent<PlayerMove>();
        PlayerAttac = GetComponent<PlayerAttack>();
        _anima = GetComponent<Animator>();
        
    }

    private void Start()
    {
        isHiting = true;
    }
    private void Update()
    {
        //�÷��̾� �̵�
        float x = Input.GetAxisRaw("Horizontal");
        PlayerMove.Move(x);
        
        //�÷��̾� ����
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerMove.Jump();
        }

        //�÷��̾� ���
        if (Input.GetKeyDown(KeyCode.Z) && x != 0)
        {
            PlayerMove.Dash1(x);
        }
        
        //�÷��̾� ���
        if (Hp <= 0)
        {
            Restart.gameObject.SetActive(true);
        }
    }

    public void Hit(float x)
    {
        if (!PlayerMove._isDash && !isHiting) Hp -= x;
        _anima.SetTrigger("isHit");
        if (_anima.GetCurrentAnimatorStateInfo(1).IsName("Player_Hit")) ;
        
    }
    
}
