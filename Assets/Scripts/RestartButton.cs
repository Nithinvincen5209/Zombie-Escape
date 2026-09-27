using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public AK.Wwise.Event MouseClick;
    public AK.Wwise.Event Stop_Akm_Shot;
    public void Restart()
    {
        Stop_Akm_Shot.Post(gameObject);
        MouseClick.Post(gameObject);

        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        MouseClick.Post(gameObject);
        Application.Quit();
    }
}
