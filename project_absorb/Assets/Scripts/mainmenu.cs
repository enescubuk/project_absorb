using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    public Text kill;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        kill.text = "Score: " + PlayerPrefs.GetInt("KillCount");
    }
    public void startButton()
    {
        SceneManager.LoadScene("gamescene");
    }

    public void leaderboardsButton()
    {
        SceneManager.LoadScene("leaderboards");
    }

    public void quitButton()
    {
        Application.Quit();
    }
    public void retryButton()
    {
        SceneManager.LoadScene("gamescene");
    }
    public void mainmenuButton()
    {
        SceneManager.LoadScene("mainmenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
