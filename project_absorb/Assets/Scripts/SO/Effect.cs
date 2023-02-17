using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    
    public EffectSO effectSO;

    int firstTurn, lastTurn, duration;

    
    
    void Awake()
    {
        firstTurn = GameManager.current.turnNumber;
        lastTurn = GameManager.current.turnNumber + duration; 
        
    }
    
    public void EffectEnemy()
    {
        
        GetComponent<EnemyScript>().hp -= effectSO.effectDamage;
        
    }

    public void EffectPlayer()
    {

        GameManager.current.playerHp -= effectSO.effectDamage;
    }

}
