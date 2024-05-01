using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float distance; // 감지거리
    public LayerMask isLaye; // 레이어
    [SerializeField]
    private float speed = 5; // 적 이동속도
    public float atkDistance; // 때리는 거리
    [SerializeField]
    private GameObject bullet; // 총알
    [SerializeField]
    private GameObject fire; // 총알 나가는곳
    public float cooltime;
    private float currenttime;

    private bool hiting;

    [SerializeField]
    private AnimationClip _hitClip;

    [SerializeField]
    private AnimationClip _deathClip;

    [SerializeField]
    private float hp;

    private Animator _anima;
    private SpriteRenderer sprite;
    private Rigidbody2D rigid;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        _anima = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currenttime = 0;
        hiting = false;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        if (hp <= 0)
        {
            Death();
        }
    }
    private void FixedUpdate()
    { 
        if (!hiting)
        {
            RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLaye);
            if (raycast.collider != null)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                rigid.velocity = new Vector2(0, 0);
                if (Vector2.Distance(transform.position, raycast.collider.transform.position) < atkDistance)
                {

                    if (currenttime <= 0)
                    {
                        _anima.SetBool("move", false);

                        GameObject bulletcopy = Instantiate(bullet, fire.transform.position, transform.rotation);
                        if (bulletcopy.TryGetComponent<bullet>(out bullet _bullet))
                        {
                            _bullet.isLeft = false;
                        }

                        currenttime = cooltime;
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, raycast.collider.transform.position, Time.deltaTime * speed);
                    _anima.SetBool("move", raycast);
                }
                currenttime -= Time.deltaTime;

            }
            RaycastHit2D raycast2 = Physics2D.Raycast(transform.position, transform.right, distance, isLaye);
            if (raycast2.collider != null)
            {
                transform.localScale = new Vector3(1, 1, 1);
                rigid.velocity = new Vector2(0, 0);

                if (Vector2.Distance(transform.position, raycast2.collider.transform.position) < atkDistance)
                {


                    if (currenttime <= 0)
                    {
                        _anima.SetBool("move", false);

                        GameObject bulletcopy = Instantiate(bullet, fire.transform.position, transform.rotation);
                        if (bulletcopy.TryGetComponent<bullet>(out bullet _bullet))
                        {
                            _bullet.isLeft = true;
                        }

                        currenttime = cooltime;
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, raycast2.collider.transform.position, Time.deltaTime * speed);
                    _anima.SetBool("move", raycast2);

                }
                currenttime -= Time.deltaTime;
            }
        }
    }
    public void isHit(float x)
    {
        if (!hiting)
        {
            hp -= x;
            hiting = true;
            _anima.SetBool("Hit", true);
            StartCoroutine(AnimaHit());
        }
    }

    private void Death()
    {
        hiting = true;
        _anima.SetBool("Death", true);
        StartCoroutine(AnimaDeath());
    }

    IEnumerator AnimaDeath()
    {
        yield return new WaitForSecondsRealtime(_deathClip.length + 0.5f);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    IEnumerator AnimaHit()
    {
        yield return new WaitForSecondsRealtime(_hitClip.length);
        hiting = false;
        _anima.SetBool("Hit", false);

    }
}
