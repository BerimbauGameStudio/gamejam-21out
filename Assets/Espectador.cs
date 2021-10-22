using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espectador : MonoBehaviour
{
    public PicadeiroController picadeiroController;
    public Transform espectadorVisual;
    public float maxSpeed = 10;
    public float shootInterval = 3;
    public Transform player;
    public GameObject tomatePrefab;

    private float rotationSpeed;
    private float _lastShootTime;
    
    // Start is called before the first frame update
    void Start()
    {
        espectadorVisual.position = picadeiroController.radius * Vector3.right;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        rotationSpeed = Random.Range(-maxSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        if (Time.time - _lastShootTime > shootInterval)
        {
            var tomate = Instantiate(tomatePrefab);
            tomate.transform.position = espectadorVisual.position;
            tomate.transform.forward = (player.position - espectadorVisual.position).normalized;
            _lastShootTime = Time.time;
        }
    }
}
