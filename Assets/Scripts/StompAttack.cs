using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompAttack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
