using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hospital : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healText;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI restoreText;

    [SerializeField] TextMeshProUGUI currentHPText;

    [SerializeField] int healPrice;
    [SerializeField] int restorePrice;

    [SerializeField] CharacterDataSO characterData;

    public void HealButton()
    {
        if (characterData.Money-healPrice>0 && characterData.Health != characterData.MaxHealth)
        {
        characterData.Health = characterData.MaxHealth;
        characterData.Money -= healPrice;
        }
        

    }

    public void RestoreButton()
    {
        if (characterData.Money-restorePrice > 0)
        {
            characterData.MaxHealth = 100;
            characterData.Money -= restorePrice;
        }
        
    }

    void Start()
    {
        healText.text = "" + healPrice;
        restoreText.text = "" + restorePrice;
    }

    void FixedUpdate()
    {
        goldText.text= ""+ characterData.Money;
        currentHPText.text = "HP:" + characterData.Health + "/" + characterData.MaxHealth;

    }
}
