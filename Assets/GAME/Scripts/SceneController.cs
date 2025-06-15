using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void LoadLevel(int id)
    {
        ScreenFader.Instance.FadeIn(() => { SceneManager.LoadScene(id); });
    }

    public void LoadLevel(string name)
    {
        ScreenFader.Instance.FadeIn(() => { SceneManager.LoadScene(name); });
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
