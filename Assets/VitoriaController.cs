using UnityEngine;
using UnityEngine.SceneManagement;

public class VitoriaController : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(ReturnToInitialScreen), 3);
    }

    public void ReturnToInitialScreen()
    {
        SceneManager.LoadScene(0);
    }
}