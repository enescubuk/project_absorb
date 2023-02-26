using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarScript : MonoBehaviour
{
    [SerializeField] TMP_Text waveText;
    [SerializeField] TMP_Text xpText;
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text goldText;




    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waveText.text = ""+ GameManager.current.wave;
    }
}
