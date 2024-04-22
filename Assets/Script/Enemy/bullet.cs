using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public bool isLeft = false;
    public float distance;
    public LayerMask isLaye;
    public float speed;
    [SerializeField]
    private float Damge = 20;

    //private Player_Manager target;

   
    private void Update()
    {
        if (isLeft)
        {
            transform.Translate(transform.right  * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("dkvk");
            Player_Manager.instans.Hit(Damge);
            DestroyBullet();
        }
        else if (!collision.gameObject.CompareTag("Enemy"))
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
