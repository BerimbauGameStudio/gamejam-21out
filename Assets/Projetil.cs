using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float speed;
    public float timeToLive;

    private float spawnTime;
    
    private void Start()
    {
        spawnTime = Time.time;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        if (Time.time - spawnTime > timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
