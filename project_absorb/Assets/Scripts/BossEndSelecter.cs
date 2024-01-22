using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class BossEndSelecter : MonoBehaviour
{
    [SerializeField] BossFight bF;
    [SerializeField] GameObject choosePath;
    public void BaseButton()
    {
        SceneManager.LoadScene(0);
    }
}
