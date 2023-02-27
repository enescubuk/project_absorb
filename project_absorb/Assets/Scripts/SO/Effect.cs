using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    
    public EffectSO effectSO;

    public int duration;
    void Awake()
    {
        
    }

    private void Start() {
        
        
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
        GetComponent<EnemyScript>().hp -= duration;
        duration--;
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
