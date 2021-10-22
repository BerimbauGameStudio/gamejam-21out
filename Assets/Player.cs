using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;
    public Transform crosshair;
    
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MovimentaJogador();
                
    }

    private void MovimentaJogador()
    {
        var movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position = transform.position + movement * speed * Time.deltaTime;

        var mouse = Input.mousePosition;
        crosshair.position = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));
    }
}
