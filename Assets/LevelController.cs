using UnityEngine;

public class LevelController : MonoBehaviour
{
    public PicadeiroController picadeiroController;
    public Player Player;
    public GameObject EspectadorPrefab;

    public float intervaloSpawnEspectador = 10;

    private float _lastEspectadorSpawned;

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
}