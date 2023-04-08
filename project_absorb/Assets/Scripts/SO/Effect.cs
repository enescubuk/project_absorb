using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Effect : MonoBehaviour
{
    
    public EffectSO effectSO;

    public int duration;
    public TMP_Text effectCounter;
    public Image effectSprite;
    void Awake()
    {
        
    }
    void changeValues(string text, bool sprite)
    {
        effectCounter.text = text;
        effectSprite.enabled = sprite;
    }

    private void Start() 
    {
        effectCounter = gameObject.transform.Find("EffectCounter").GetComponentInChildren<TMP_Text>();
        effectSprite = gameObject.transform.Find("Effect").GetComponentInChildren<Image>();
        changeValues(duration.ToString(), true);
        if (GetComponent<Effect>() == this)
        {
            effectSO.currentDamage = 1;
        }
        effectCounter.text = duration.ToString();
    }
    public void EffectEnemy()
    {
        
        if (duration < 1)
        {
            changeValues(" ",false);
            Destroy(this);
        }
        GetComponent<EnemyScript>().hp -= duration;
        duration--;
        changeValues(duration.ToString(), true);
    }

    public void EffectPlayer()
    {
        GameManager.current.playerHp -= effectSO.effectDamage;
        if (duration <= 0)
        {
            changeValues(" ",false);
            Destroy(this);
        }
        duration--;
        changeValues(duration.ToString(), true);
    }

}
