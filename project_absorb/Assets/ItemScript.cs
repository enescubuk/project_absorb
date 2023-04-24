using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public enum CardType { Slash, Piercing};
    [Header("Card Stats")]
    
    
    public int cardID;
    public CardType cardType;
    public int hpGain;
    public int attackPoint;
    public EffectSO effect;
    public int slot;
    public int CammonCardValue;
    private GameObject target;
    EnemyScript enemyScript;
    
    public void attackPlayer(EnemyScript enemyScript)
    {
        if (enemyScript.haveCT == false && GameManager.current.Ct == false)
        {
            int damage = Mathf.Max(attackPoint - GameManager.current.blockValue, 0);
            GameManager.current.blockValue -= Mathf.Min(GameManager.current.blockValue, attackPoint);
            GameManager.current.playerHp -= damage;
            //GameManager.current.ShieldText.text = GameManager.current.blockValue.ToString();
            
        }
        else
        {
            enemyScript.hp -= attackPoint;
            enemyScript.haveCT = false;
            GameManager.current.Ct = false;
        }
    }

    public void CastSkill(GameObject enemy)
    {
        target = enemy;
        enemyScript = enemy.GetComponent<EnemyScript>();
        switch (cardType)   
        {
            case CardType.Slash:// Slash && Piercing
            case CardType.Piercing:
                enemyTakeHit(enemy,CammonCardValue);
                    break;
        }

        GameManager.current.playerMana -= GetComponent<ItemSO>().cardValuesSO.cardMana;
        if (GetComponent<ItemSO>().cardValuesSO.target == CardValuesSO.Target.toEnemy)
        {
            if (enemyScript.haveCutCard == true)
            {
                if (enemy.GetComponent<Effect>() != null)
                {
                    enemy.GetComponent<Effect>().duration++;
                    enemy.GetComponent<Effect>().changeDurationValue(enemy.GetComponent<Effect>().duration + 1);
                }
                else
                {
                    effect.Effect(enemy);
                }
            }
        }
    }

    private void enemyTakeHit(GameObject enemy, int damage)
    {
        enemy.GetComponent<Animator>().SetTrigger("TakeHit");
        GameEvents.current.DeadEnter(enemy.GetComponent<EnemyScript>().id, enemy.GetComponent<EnemyScript>().hp,target);
        enemy.GetComponent<EnemyScript>().hp -= damage;
    }
}
