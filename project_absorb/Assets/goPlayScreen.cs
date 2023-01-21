using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goPlayScreen : MonoBehaviour
{
    public void playScreenButton()
    {
        SceneManager.LoadScene("GameManager");
    }
}
