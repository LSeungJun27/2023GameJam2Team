using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ collider ��ũ��Ʈdlqslek.

public class boombaya : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Weapon"))
        {
            Destroy(this.gameObject);
        }

    }
        void OnParticleCollision(GameObject other)

        {
            if (other.gameObject.CompareTag("Weapon"))
            {
                Destroy(this.gameObject);
            }
        


    }
}
