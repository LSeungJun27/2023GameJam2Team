using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeaponCollider : MonoBehaviour
{


    void OnCollisionenter(GameObject other)

    {

        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
        }

    }

}