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
        //플레이어 이동
        float x = Input.GetAxisRaw("Horizontal");
        if (!isHiting)
        {
            PlayerMove.Move(x);

        }

        //플레이어 점프
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerMove.Jump();
        }

        //플레이어 대시
        if (Input.GetKeyDown(KeyCode.Z) && x != 0)
        {
            PlayerMove.Dash1(x);
        }

        //플레이어 사망
        if (Hp <= 0)
        {
            Restart.gameObject.SetActive(true);
            Time.timeScale = 0;

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
