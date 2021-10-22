using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public PicadeiroController picadeiroController;
    public Player Player;
    public GameObject EspectadorPrefab;

    public float intervaloSpawnEspectador = 10;

    private float _lastEspectadorSpawned = -7;
    private int _score;
    
    private void Update()
    {
        if (Time.time - _lastEspectadorSpawned > intervaloSpawnEspectador)
        {
            var espectadorGo = Instantiate(EspectadorPrefab);
            var espectador = espectadorGo.GetComponent<Espectador>();
            espectador.picadeiroController = picadeiroController;
            espectador.player = Player.transform;
            _lastEspectadorSpawned = Time.time;
        }
    }

    public void GameOver()
    {
        Invoke(nameof(ReturnToInitialScene), 3f);
    }

    private void ReturnToInitialScene()
    {
        SceneManager.LoadScene("Initial");
    }

    public void OnEspectorHit()
    {
        _score += 100;
    }
}