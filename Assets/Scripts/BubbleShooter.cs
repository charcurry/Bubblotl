using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleShooter : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private Transform bubbleSpawnPoint;
    [SerializeField] private float bubbleSpeed = 10f;

    public float defaultBubbleLifeTime = 5f;
    [SerializeField] private float bubbleLifeTime;

    public float defaultBubbleSpawnRate = 2f;
    [SerializeField] private float bubbleSpawnRate;
    [SerializeField] public Vector3 targetPosition;

    [SerializeField] private GameObject bubbleObject;
    // Start is called before the first frame update
    void Start()
    {
        bubbleSpawnRate = defaultBubbleSpawnRate;
        bubbleLifeTime = defaultBubbleLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (bubbleSpawnRate <= 0)
        {
            bubbleSpawnRate = defaultBubbleSpawnRate;
            bubbleObject = ShootBubble();
        }
        else
        {
            bubbleSpawnRate -= Time.deltaTime;
        }

        if (bubbleObject != null)
        {
            bubbleLifeTime -= Time.deltaTime;
            LerpToTarget(bubbleObject);

            if (bubbleLifeTime <= 0)
            {
                Destroy(bubbleObject);
                bubbleLifeTime = defaultBubbleLifeTime;
            }
        }
    }

    private GameObject ShootBubble()
    {
        return Instantiate(bubblePrefab, bubbleSpawnPoint.position, bubbleSpawnPoint.rotation);
    }

    private void LerpToTarget(GameObject bubble)
    {
        bubble.transform.position = Vector3.Lerp(bubble.transform.position, targetPosition, bubbleSpeed * Time.deltaTime);
    }
}
