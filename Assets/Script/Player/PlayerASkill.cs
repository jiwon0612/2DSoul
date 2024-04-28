using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerASkill : MonoBehaviour
{
    private TrailRenderer Trail;
    private Rigidbody2D rigid;
    private ParticleSystem particle;
    [SerializeField]
    private float _skillSpeed;
    [SerializeField]
    private float skillCoolTime;

    public bool isSkillCoolTime;

    private void Awake()
    {
        Trail = GetComponentInChildren<TrailRenderer>();
        rigid = GetComponentInParent<Rigidbody2D>();
        particle = GetComponentInChildren<ParticleSystem>();
    }
    private void Start()
    {
        isSkillCoolTime = false;
        particle.Play(false);

    }

    public void Askill(float x)
    {
        if (!isSkillCoolTime)
        {
            Trail.emitting = true;
            isSkillCoolTime = true;
            particle.Play(true);
            Debug.Log("¿€µø" + x);
            rigid.AddForce(new Vector2(x * _skillSpeed, 1), ForceMode2D.Force);
            //rigid.velocity = new Vector2(x * _skillSpeed, 0);

            StartCoroutine(SkillCoolTime());
        }
    }

    IEnumerator SkillCoolTime()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        Trail.emitting = false;

        yield return new WaitForSecondsRealtime(skillCoolTime);
        isSkillCoolTime = false;
    }
}
