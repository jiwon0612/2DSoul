using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerASkill : MonoBehaviour
{
    private TrailRenderer Trail;
    private Rigidbody2D rigid;
    private ParticleSystem particle;
    private EnemyAI enemyHit;
    private Collider2D item;
    [SerializeField]
    private float _skillSpeed;
    [SerializeField]
    private float _skillDamage;
   
    public float skillCoolTime;
    [SerializeField]
    private LayerMask enemy;
    [SerializeField]
    private LayerMask not;
    [SerializeField]
    private Transform pos;
    [SerializeField]
    private Vector2 size;
   

    public bool isSkillCoolTime;
    public bool isOnSkill;

    

    private void Awake()
    {
        Trail = GetComponentInChildren<TrailRenderer>();
        rigid = GetComponentInParent<Rigidbody2D>();
        particle = GetComponentInChildren<ParticleSystem>();
    }
    private void Start()
    {
        isSkillCoolTime = false;

    }



    public void Askill(float x)
    {
        if (!isSkillCoolTime && x != 0)
        {
            Trail.emitting = true;
            isSkillCoolTime = true;
            isOnSkill = true;
            rigid.excludeLayers = enemy;
            particle.Play();
            rigid.gravityScale = 0;
            
            rigid.AddForce(new Vector2(x * _skillSpeed, 0), ForceMode2D.Impulse);


            InvokeRepeating("OverLap", 0, 0.01f);
            StartCoroutine(SkillCoolTime());
        }
    }

    private void OverLap()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(pos.position, size, 0,enemy);
        foreach (Collider2D item in hit)
        {
            enemyHit = item.GetComponent<EnemyAI>();
            StartCoroutine(skilldamage());

            //StartCoroutine(skilldamage());
        }
    }

    //private void OnParticleCollision(GameObject other)
    //{
    //    Debug.Log("¾È³ç");
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        enemyHit = other.GetComponent<EnemyAI>();
    //        enemyHit.isHit(_skillDamage);
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, size);
    }

    IEnumerator skilldamage()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        enemyHit.isHit(_skillDamage);
    }

    IEnumerator SkillCoolTime()
    {

        yield return new WaitForSecondsRealtime(0.2f);
        Trail.emitting = false;
        rigid.gravityScale = 5;
        isOnSkill = false;
        rigid.excludeLayers = not;



        yield return new WaitForSecondsRealtime(skillCoolTime);
        isSkillCoolTime = false;
    }
}
