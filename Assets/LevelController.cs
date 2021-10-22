using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public PicadeiroController picadeiroController;
    public Player player;
    public GameObject espectadorPrefab;
    public TMP_Text tempoUi;
    public TMP_Text scoreUi;
    public int tempoParaVitoria = 60;

    public float intervaloSpawnEspectador = 10;

    private float _lastEspectadorSpawned = -7;
    private int _score;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
        
        if (Time.time >= tempoParaVitoria)
        {
            SceneManager.LoadScene("Vitoria");
        }

        tempoUi.text = ((int)(tempoParaVitoria - Time.time)).ToString();
        scoreUi.text = _score.ToString();

        if (Time.time - _lastEspectadorSpawned > intervaloSpawnEspectador)
        {
            var espectadorGo = Instantiate(espectadorPrefab);
            var espectador = espectadorGo.GetComponent<Espectador>();
            espectador.picadeiroController = picadeiroController;
            espectador.player = player.transform;
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