using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator _anim;

    public bool _atking;

    

    public Transform pos;
    public Vector3 size;

    private EnemyAI enemyHit;

    [SerializeField]
    private AnimationClip _clip;
    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private float damage;

    private void Awake()
    {
       // _anim.GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        _anim.SetBool("Atk", false);
        _atking = false;
        
    }

    private void Update()
    {
        
    }


    public void Atk()
    {
        
        _anim.SetBool("Atk",true);
        _atking = true;
        StartCoroutine(Atking());

        StartCoroutine(cooltime());

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, size);
    }

    IEnumerator Atking()
    {
        yield return new WaitForSecondsRealtime(_clip.length);
        _anim.SetBool("Atk", false);
        _atking = false;
    }

    IEnumerator cooltime()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        Collider2D[] hit = Physics2D.OverlapBoxAll(pos.position, size, 0);

        foreach (Collider2D collider in hit)
        {
            
            if (collider.gameObject.CompareTag("Bullet"))
            {
                Destroy(collider.gameObject);
            }
            if (collider.gameObject.CompareTag("Enemy"))
            {
                enemyHit = collider.GetComponent<EnemyAI>();
                enemyHit.isHit(damage);
            }
        }
    }
}
