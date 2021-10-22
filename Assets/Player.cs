using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;
    
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position = transform.position + movement * speed * Time.deltaTime;
    }
}
