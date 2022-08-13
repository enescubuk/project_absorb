using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spaceCounter : MonoBehaviour
{
    public Text text;
    public Text text2;
    int counter = 0;
    int highScore;
    public PlayFabManager playFabManager_script;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "" + counter;
        text2.text = "" + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            counter++;
            text.text = "" + counter;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (counter > highScore)
            {
                highScore = counter;
                text2.text = "" + highScore;
                playFabManager_script.SendLeaderboard(highScore);
            }
            counter = 0;
        }
    }
}
