using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5; //이속
    [SerializeField]
    private float JumpForce = 5; //점프 성능
    public Rigidbody2D rigid;
    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private LayerMask groundLayer; //바닥 체크를위한 레이어
    private CapsuleCollider2D collider2D; //오브젝트 충돌 범위 컴포넌트
    private bool isGround; //바닥 체크
    private Vector3 footPosition; //발의 위치

    [SerializeField]
    private int maxJumpCount = 2; //최대 점프 가능횟수
    private int JumpCount = 0; //점프 한 횟수

    [SerializeField]
    private float dashspeed = 20; // 대시 거리
    public bool _isDash; //대시중 히트 판정
    private bool _dashCool; //대시 쿨타임
    public TrailRenderer trail; //트레일 렌더러

    public Animator _anim;



    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<CapsuleCollider2D>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _isDash = false;
        _dashCool = false;
        Debug.Log("t: "+Time.timeScale);
    }
    private void FixedUpdate()
    {
        Bounds bounds = collider2D.bounds;
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        isGround = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        if (isGround == true && rigid.velocity.y <= 0)
        {
            JumpCount = maxJumpCount;
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(footPosition, 0.1f);
    }
    public void Move(float x)
    {
        if (!_isDash)
        {
            rigid.velocity = new Vector2(x * speed, rigid.velocity.y);
            _anim.SetFloat("speed", Mathf.Abs(x));
            if (x != 0) sprite.flipX = x < 0;

        }

    }

    public void Jump()
    {
        //if (isGround == true)
        if (JumpCount > 0 && !_isDash)
        {
            rigid.velocity = Vector2.up * JumpForce;
            --JumpCount;
        }

    }

    public void Dash1(float x)
    {
        StartCoroutine(Dash(x));
    }



    IEnumerator Dash(float x)
    {
        if (!_isDash && !_dashCool)
        {
            _isDash = true;
            _dashCool = true;
            trail.emitting = true;

            rigid.velocity = new Vector2(x * dashspeed, 0);
            rigid.gravityScale = 0;

            yield return new WaitForSecondsRealtime(0.2f);
            trail.emitting = false;

            rigid.gravityScale = 5;
            _isDash = false;
            yield return new WaitForSecondsRealtime(0.5f);
            _dashCool = false;
        }

    }



}
