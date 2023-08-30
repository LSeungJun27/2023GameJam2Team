using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TestFireEffect : MonoBehaviour
{
    private CinemachineDollyCart cart;
    private FireEffectController fireEffectController;
    void Start()
    {
        cart = GetComponent<CinemachineDollyCart>();
        fireEffectController = GetComponentInChildren<FireEffectController>();
    }

    // Update is called once per frame
    void Update()
    {
        fireEffectController.growth = Mathf.Clamp01(cart.m_Position*2.5f / cart.m_Path.PathLength);
    }
}
