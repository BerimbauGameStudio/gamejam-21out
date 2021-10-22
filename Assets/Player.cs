using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;
    public Transform crosshair;
    public GameObject tortaPrefab;
    public float reloadTime = 1;

    private LineRenderer _lineRenderer;
    private float _ultimaTorta;

    private Vector3 movementPlayerVector;
    public Animator an;
    private bool _dead;

    private void Start()
    {
        Cursor.visible = false;

        _lineRenderer = GetComponent<LineRenderer>();
        _ultimaTorta = -reloadTime;
    }

    void Update()
    {
        if (_dead) return;
        
        MovimentaMira();
        MovimentaJogador();
        DesenhaLinhaParaMira();
        AtiraTorta();
        WalkAnimation();
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

            ThrowAnimation();
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
        movementPlayerVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position = transform.position + movementPlayerVector * speed * Time.deltaTime;
        transform.right = (crosshair.position - transform.position).normalized;
    }

    private void WalkAnimation()
    {
        an.SetFloat("Vel", Mathf.Abs(movementPlayerVector.magnitude));
    }

    private void ThrowAnimation()
    {
        an.SetTrigger("Throw");
    }

    public void Hit()
    {
        FindObjectOfType<LevelController>().GameOver();
        _dead = true;
    }
}