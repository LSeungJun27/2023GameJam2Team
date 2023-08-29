using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountBar : MonoBehaviour
{
    private Camera _camera;
    public Slider slider;
    public GameObject entity;
    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        entity = entity ? entity : transform.parent.gameObject;
        transform.parent = GameManager.instance.transform;
        
        slider.gameObject.SetActive(false);
        GameManager.instance.onStart.AddListener(() => { slider.gameObject.SetActive(true); });
    }
    
    private void LateUpdate()
    {
        slider.transform.position = _camera.WorldToScreenPoint(entity.transform.position+Vector3.up*0.7f)+Vector3.down*10f;
        slider.value = ItemManager.instance.amount;
    }
}
