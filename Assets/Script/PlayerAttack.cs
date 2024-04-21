using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _anim;

    public bool _atking;

    public Transform pos;
    public Vector2 size;

    [SerializeField]
    private AnimationClip _clip;

    private void Awake()
    {
        _anim = GetComponent<Animator>();

    }
    private void Start()
    {
        _anim.SetBool("Atk", false);
        _atking = false;
    }

    

    public void Atk()
    {
        _anim.SetBool("Atk",true);
        _atking = true;
        StartCoroutine(Atking());

        Collider2D[] hit = Physics2D.OverlapBoxAll(pos.position, size, 0);

        foreach (Collider2D collider in hit)
        {
            Debug.Log(collider.tag);
        }

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
}
