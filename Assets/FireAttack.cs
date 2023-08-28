using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireAttack : StateMachineBehaviour
{
    // ���⿡ ��ƼŬ �ý��� ���� ����
    public GameObject fireEffectPrefab;
    private GameObject currentEffect;

    // �ִϸ��̼� ���¿� �� �� ȣ��Ǵ� �Լ�
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ��ƼŬ �ý��� ���� �� Ȱ��ȭ
        currentEffect = Instantiate(fireEffectPrefab, animator.transform.position, Quaternion.identity);
        currentEffect.transform.parent = animator.transform;
    }

    // �ִϸ��̼� ���¿��� ���� �� ȣ��Ǵ� �Լ�
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ��ƼŬ �ý��� ����
        if (currentEffect != null)
        {
            Destroy(currentEffect);
        }
    }
}
