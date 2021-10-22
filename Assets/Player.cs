using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;
    public Transform crosshair;
    public GameObject tortaPrefab;
    public float reloadTime = 1;

    private LineRenderer _lineRenderer;
    private float _ultimaTorta;

    private void Start()
    {
        Cursor.visible = false;

        _lineRenderer = GetComponent<LineRenderer>();
        _ultimaTorta = -reloadTime;
    }

    void Update()
    {
        MovimentaJogador();
        MovimentaMira();
        DesenhaLinhaParaMira();
        AtiraTorta();
    }

    private void AtiraTorta()
    {
        if (Time.time - _ultimaTorta < reloadTime) return;

        if (Input.GetMouseButtonDown(0))
        {
            var torta = Instantiate(tortaPrefab);
            torta.transform.position = transform.position;
            torta.transform.forward = (crosshair.position - transform.position).normalized;
            _ultimaTorta = Time.time;
        }
    }

    private void DesenhaLinhaParaMira()
    {
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