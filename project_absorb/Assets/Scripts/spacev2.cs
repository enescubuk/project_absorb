using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacev2 : MonoBehaviour
{
    public int counter;
    public int highScore;
    public PlayfabMan playFabManager_script;
    public GameObject gameoverScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            counter++;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameoverScene.SetActive(true);
            if (counter > highScore)
            {
                highScore = counter;
                playFabManager_script.SendLeaderboard(highScore);
            }
            counter = 0;
        }
    }
}
