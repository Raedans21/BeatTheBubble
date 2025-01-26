using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    public CountdownTimer time;

    [SerializeField] GameObject endScreen;

    private void Awake()
    {
        endScreen.SetActive(false);
    }

    private void Update()
    {
        if (time.timeRemaining <= 0)
        {
            endScreen.SetActive(true);
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene("PlayScreen");
    }
}
