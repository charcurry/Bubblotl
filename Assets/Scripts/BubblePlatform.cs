using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubblePlatform : MonoBehaviour
{
    public float uptime;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has collided with the bubble platform");
            StartCoroutine(JumpOnBubble());
        }
    }

    IEnumerator JumpOnBubble()
    {
        yield return new WaitForSeconds(uptime);
        Destroy(gameObject);
    }
}
