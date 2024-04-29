using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerASkill : MonoBehaviour
{
    private TrailRenderer Trail;
    private Rigidbody2D rigid;
    private ParticleSystem particle;
    private CapsuleCollider2D collider;
    [SerializeField]
    private float _skillSpeed;
    [SerializeField]
    private float skillCoolTime;

    public bool isSkillCoolTime;
    public bool isOnSkill;

    private void Awake()
    {
        Trail = GetComponentInChildren<TrailRenderer>();
        rigid = GetComponentInParent<Rigidbody2D>();
        particle = GetComponentInChildren<ParticleSystem>();
        collider = GetComponentInParent<CapsuleCollider2D>();
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
            particle.Play();
            rigid.gravityScale = 0;
            
            rigid.AddForce(new Vector2(x * _skillSpeed, 0), ForceMode2D.Impulse);
            StartCoroutine(SkillCoolTime());
        }
    }

    IEnumerator SkillCoolTime()
    {

        yield return new WaitForSecondsRealtime(0.2f);
        Trail.emitting = false;
        rigid.gravityScale = 5;
        isOnSkill = false;



        yield return new WaitForSecondsRealtime(skillCoolTime);
        isSkillCoolTime = false;
    }
}
