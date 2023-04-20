using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Effect : MonoBehaviour
{
    
    public EffectSO effectSO;

    public int duration;

    private enemyEffectIndicator indicatorScript;
    
    void Awake()
    {
        
    }
    void changeValues(string text, bool sprite)
    {
        indicatorScript.bleedEffectCounter.text = text;
        indicatorScript.bleedEffectSprite.enabled = sprite;
    }

    private void Start() 
    {
        indicatorScript = GetComponent<enemyEffectIndicator>();
        changeValues(duration.ToString(), true);
        if (GetComponent<Effect>() == this)
        {
            effectSO.currentDamage = 1;
        }
        indicatorScript.bleedEffectCounter.text = duration.ToString();
    }
    public void EffectEnemy()
    {
        
        if (duration < 1)
        {
            Destroy(this);
        }
        Debug.Log("duration: " + duration);
        GetComponent<EnemyScript>().hp -= duration;
        duration--;
        if (duration == 0)
        {
            changeValues(" ",false);
        }
        else
        {
            changeValues(duration.ToString(), true);
        }
        
    }
    public void changeDurationValue(int value)
    {
        duration = value;
        changeValues(duration.ToString(),true);
    }

    public void EffectPlayer()
    {
        GameManager.current.playerHp -= effectSO.effectDamage;
        if (duration <= 0)
        {
            Destroy(this);
        }
        duration--;
        changeValues(duration.ToString(), true);
    }
    

    void OnDestroy()
    {
        changeValues(" ",false);
    }
}
