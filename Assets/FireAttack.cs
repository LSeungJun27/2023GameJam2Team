using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireAttack : StateMachineBehaviour
{
    // 여기에 파티클 시스템 변수 선언
    public GameObject fireEffectPrefab;
    private GameObject currentEffect;

    // 애니메이션 상태에 들어갈 때 호출되는 함수
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 파티클 시스템 생성 및 활성화
        currentEffect = Instantiate(fireEffectPrefab, animator.transform.position, Quaternion.identity);
        currentEffect.transform.parent = animator.transform;
    }

    // 애니메이션 상태에서 나올 때 호출되는 함수
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 파티클 시스템 제거
        if (currentEffect != null)
        {
            Destroy(currentEffect);
        }
    }
}
