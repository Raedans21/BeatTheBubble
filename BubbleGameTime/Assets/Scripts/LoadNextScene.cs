using UnityEngine;
using UnityEngine.SceneManagement;

public class LadNextScene : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
