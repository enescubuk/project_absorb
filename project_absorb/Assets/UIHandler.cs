using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIHandler : MonoBehaviour
{
    [SerializeField] CharacterDataSO characterData;

    [SerializeField] TextMeshProUGUI goldText;

    [SerializeField] TextMeshProUGUI hpText;
    
    void FixedUpdate()
    {
        goldText.text = "" + characterData.Money;
        hpText.text = "HP:" + characterData.Health + "/" + characterData.MaxHealth;
    }
}
