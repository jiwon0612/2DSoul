using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerASkill : MonoBehaviour
{
    private TrailRenderer Trail;
    private Rigidbody2D rigid;
    [SerializeField]
    private float _skillSpeed;
    [SerializeField]
    private float skillCoolTime;

    public bool isSkillCoolTime;

    private void Awake()
    {
        Trail = GetComponentInChildren<TrailRenderer>();
        rigid = GetComponentInParent<Rigidbody2D>();
        
    }
    private void Start()
    {
        isSkillCoolTime = false;
    }

    public void Askill(float x)
    {
        if (!isSkillCoolTime)
        {
            Trail.emitting = true;
            isSkillCoolTime = true;

            rigid.AddForce(Vector2.right * x * _skillSpeed, ForceMode2D.Impulse);

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
