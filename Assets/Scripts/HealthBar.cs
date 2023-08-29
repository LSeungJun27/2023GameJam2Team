using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Camera _camera;
    public Slider slider;

    public GameObject entity;

    private hpcount _hpcount;
    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;

        entity = entity ? entity : transform.parent.gameObject;

        entity.TryGetComponent(out _hpcount);

        transform.parent = GameManager.instance.transform;
        
        slider.gameObject.SetActive(false);
    }
    
    private void LateUpdate()
    {
        if (!GameManager.instance.gameStart) return;
        slider.transform.position = _camera.WorldToScreenPoint(entity.transform.position+Vector3.up*0.7f);
        if(slider.transform.position.z<0) slider.gameObject.SetActive(false);
        else slider.gameObject.SetActive(true);
        if (_hpcount)
        {
            slider.value = _hpcount.currentHP;
            slider.maxValue = _hpcount.maxHP;
        }
        
    }
}
