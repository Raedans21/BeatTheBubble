using UnityEngine;
using UnityEngine.SceneManagement;


public class ReloadGame : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}