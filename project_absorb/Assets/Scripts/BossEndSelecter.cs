using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class BossEndSelecter : MonoBehaviour
{
    [SerializeField] BossFight bF;

    [SerializeField] GameObject choosePath;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void BaseButton()
    {

        SceneManager.LoadScene("Base");

    }
}
