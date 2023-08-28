using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Camera _camera;
    public Slider slider;
    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        
    }
    
    private void LateUpdate()
    {
        slider.transform.position = _camera.WorldToScreenPoint(gameObject.transform.position+Vector3.up);
        if(slider.transform.position.z<0) slider.gameObject.SetActive(false);
        else slider.gameObject.SetActive(true);
    }
}
