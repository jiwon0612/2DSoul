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
    
    public int Hp = 6;
    

    private void Awake()
    {
        if(instans == null)
        {
            instans = this;
        }
        PlayerMove = GetComponent<PlayerMove>();
        PlayerAttac = GetComponent<PlayerAttack>();
        
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
        if (Hp == 0)
        {
            Time.timeScale = 0;
            Restart.gameObject.SetActive(true);
        }
    }

    public void Hit(int x)
    {
        if (!PlayerMove._isDash) Hp -= x;
    }
}
