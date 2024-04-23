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

    [SerializeField]
    private float hp;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        currenttime = 0;
    }
    private void Update()
    {
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position,transform.right * -1,distance,isLaye);
        if (raycast.collider != null)
        {
            sprite.flipX = true;
            if (Vector2.Distance(transform.position, raycast.collider.transform.position) < atkDistance)
            {
                if (currenttime <= 0)
                {
                     GameObject bulletcopy = Instantiate(bullet, fire.transform.position,transform.rotation);
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
            }
            currenttime -= Time.deltaTime;

        }
        RaycastHit2D raycast2 = Physics2D.Raycast(transform.position,transform.right,distance,isLaye);
        if (raycast2.collider != null)
        {
            sprite.flipX = false;
            if (Vector2.Distance(transform.position, raycast2.collider.transform.position) < atkDistance)
            {
                if (currenttime <= 0)
                {
                     GameObject bulletcopy = Instantiate(bullet, fire.transform.position,transform.rotation);
                    if(bulletcopy.TryGetComponent<bullet>(out bullet _bullet))
                    {
                        _bullet.isLeft = true;
                    }

                    currenttime = cooltime;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, raycast2.collider.transform.position, Time.deltaTime * speed);
            }
            currenttime -= Time.deltaTime;
        }
    }
    public void isHit(float x)
    {
        hp -= x;
    }
}
