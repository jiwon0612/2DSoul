using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    [SerializeField] private AnimationClip clip;

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
        if (instans == null)
        {
            instans = this;
        }
        PlayerMove = GetComponent<PlayerMove>();
        PlayerAttac = GetComponent<PlayerAttack>();
        _anima = GetComponent<Animator>();

    }

    private void Start()
    {
        isHiting = false;
        _anima.SetBool("isHit", false);
    }
    private void Update()
    {
        //�÷��̾� �̵�
        float x = Input.GetAxisRaw("Horizontal");
        if (!isHiting && !PlayerAttac._atking)
        {
            PlayerMove.Move(x);

        }

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
            Time.timeScale = 0;

        }

        //�÷��̾� ����
        if (Input.GetKeyDown(KeyCode.X) && !PlayerMove._isDash && !isHiting && x == 0)
        {
            PlayerAttac.Atk();
            
        }
    }

    public void Hit(float x)
    {
        if (!PlayerMove._isDash && !isHiting)
        {
            Hp -= x;
            _anima.SetBool("isHit",true);
            isHiting = true;
            StartCoroutine(AnimatorHitCO());
            

        }

    }

    IEnumerator AnimatorHitCO()
    {
        yield return new WaitForSeconds(clip.length);
        _anima.SetBool("isHit",false);
        isHiting = false;
    }

}
