using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public ParticleSystem attackParticle;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            PlayAttackParticle();
        }
    }

    void PlayAttackParticle()
    {
        attackParticle.Play(); // ��ƼŬ �ý��� Ȱ��ȭ
    }
}
