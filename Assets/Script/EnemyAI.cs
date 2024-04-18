using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float distance; // �����Ÿ�
    public LayerMask isLaye; // ���̾�
    [SerializeField]
    private float speed = 5; // �� �̵��ӵ�
    public float atkDistance; // ������ �Ÿ�
    [SerializeField]
    private GameObject bullet; // �Ѿ�
    [SerializeField]
    private GameObject fire; // �Ѿ� �����°�
    public float cooltime;
    private float currenttime;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        currenttime = 0;
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

}