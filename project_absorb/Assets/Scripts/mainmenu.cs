using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
