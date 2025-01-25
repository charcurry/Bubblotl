using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BubblePlatform : MonoBehaviour
{
    [SerializeField] private bool wasJumpedOn = false;

    private Vector3 scaleChange = new Vector3(0.05f, 0.05f, 0.05f);

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has collided with the bubble platform");
            wasJumpedOn = true;
        }
    }

    void FixedUpdate()
    {
        if (wasJumpedOn)
        {
            gameObject.transform.localScale -= scaleChange;
        }

        if (gameObject.transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }
}
