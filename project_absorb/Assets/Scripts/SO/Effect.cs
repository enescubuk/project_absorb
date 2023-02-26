using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    
    public EffectSO effectSO;

    int duration;
    void Awake()
    {
        
    }

    private void Start() {
        
        duration = effectSO.effectDuration;
        if (GetComponent<Effect>() == this)
        {
            effectSO.currentDamage = 1;
        }
    }
    public void EffectEnemy()
    {

        if (effectSO.currentDamage < 1)
        {
            Destroy(this);
        }
        //GetComponent<EnemyScript>().hp -= effectSO.effectDamage;
    }

    public void EffectPlayer()
    {
        GameManager.current.playerHp -= effectSO.effectDamage;
        if (duration <= 0)
        {
            Destroy(this);
        }
        duration--;
    }

}
