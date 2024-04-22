using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5; //�̼�
    [SerializeField]
    private float JumpForce = 5; //���� ����
    public Rigidbody2D rigid;
    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private LayerMask groundLayer; //�ٴ� üũ������ ���̾�
    private CapsuleCollider2D collider2D; //������Ʈ �浹 ���� ������Ʈ
    private bool isGround; //�ٴ� üũ
    private Vector3 footPosition; //���� ��ġ

    [SerializeField]
    private int maxJumpCount = 2; //�ִ� ���� ����Ƚ��
    private int JumpCount = 0; //���� �� Ƚ��

    [SerializeField]
    private float dashspeed = 20; // ��� �Ÿ�
    public bool _isDash; //����� ��Ʈ ����
    private bool _dashCool; //��� ��Ÿ��
    public TrailRenderer trail; //Ʈ���� ������

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
