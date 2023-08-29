using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public ParticleSystem ps;

    private void Start()
    {
        monsterspawn.instance.onEnemySpawn.AddListener((obj) => { ps.trigger.AddCollider(obj.GetComponent<SphereCollider>());});
    }

    private void OnParticleTrigger()
    {
        Debug.Log("Ãæµ¹ÇÔ");
    }
}
