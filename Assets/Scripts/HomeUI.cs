using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUI : MonoBehaviour
{
    public GameObject loadingUI;
    public GameObject optionUI;
    public AK.Wwise.Event Play_Intro;
    public AK.Wwise.Event Stop_Intro;
    public AK.Wwise.Event MouseClick;
   

    private void Start()
    {
      loadingUI.SetActive(false);
      optionUI.SetActive(false);
       
        Play_Intro.Post(gameObject);
        Play_Intro.Post(gameObject);



    }
    public void LoadGame()
    {
        MouseClick.Post(gameObject);
        loadingUI.SetActive(true);
        StartCoroutine(Loading());
    }
    public void Options()
    {
        MouseClick.Post(gameObject);
        optionUI.SetActive(true);

    }
    public void CloseOptions()
    {
        MouseClick.Post(gameObject);
        optionUI.SetActive(false);
    }
    public void QuitGame()
    {
        MouseClick.Post(gameObject);
        Application.Quit();
    }
    IEnumerator Loading()
    {
       Stop_Intro.Post(gameObject);
        
        Time.timeScale = 1f; // Resume the game
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
