using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;
    public Transform crosshair;

    private LineRenderer _lineRenderer;
    
    private void Start()
    {
        Cursor.visible = false;

        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimentaJogador();
        MovimentaMira();
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, crosshair.transform.position);
    }

    private void MovimentaMira()
    {
        var mouse = Input.mousePosition;
        crosshair.position = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));
    }

    private void MovimentaJogador()
    {
        var movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position = transform.position + movement * speed * Time.deltaTime;
    }
}
