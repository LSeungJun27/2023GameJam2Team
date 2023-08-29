using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public GameObject effectPrefab; 
    public float effectDuration = 0.5f; 

    private bool isClicking = false; 
    private float clickStartTime = 0f; 
    private GameObject currentEffect; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                Vector3 playerPosition = player.transform.position;

                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 direction = (mousePosition - playerPosition).normalized;
                Vector3 effectPos = playerPosition + direction;

                if (currentEffect != null)
                {
                    Destroy(currentEffect);
                }

                currentEffect = Instantiate(effectPrefab, effectPos, Quaternion.identity);

                isClicking = true;
                clickStartTime = Time.time;
            }
        }

        if (isClicking && Time.time - clickStartTime >= effectDuration)
        {
            Destroy(currentEffect);
            isClicking = false;
            currentEffect = null;
        }
    }
}
