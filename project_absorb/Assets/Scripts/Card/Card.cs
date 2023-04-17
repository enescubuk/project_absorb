using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum CardType { Slash, Stab, Wound, Impact, HeavyImpact, HeavyWound,Reap, Bear,
    Swing, Rose, Counter,  Block , Prepare, Shield , Charge , Cut, Piercing, Consume, Austerity, Crush};
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

            case CardType.Wound: // Wound
                enemyTakeHit(enemy, attackPoint);
                effect.Effect(enemy);
                    break;
            
            
            case CardType.Block://Block & Shield
            case CardType.Shield:
                GameManager.current.blockValue += CammonCardValue;
                GameManager.current.ShieldText.text = GameManager.current.blockValue.ToString();
                    break;
            
            case CardType.Swing: //Swing
                for (int i = 0; i < GameManager.current.enemies.Count; i++)
                {
                    
                    enemyTakeHit(GameManager.current.enemies[i],CammonCardValue);
                }
                    break;

            case CardType.Counter: //Counter
                enemyScript.haveCT = true;
                    break;

            case CardType.Prepare: //Prepare
                GameManager.current.Ct = true;
                goto case CardType.Block;
                    break;

            case CardType.HeavyWound: // Heavy Wound & Reap
            case CardType.Reap:
                enemyTakeHit(enemy,enemy.GetComponent<Effect>().duration * CammonCardValue);
                    break;

            case CardType.Stab: //Stab
                enemyTakeHit(enemy,CammonCardValue);
                goto case CardType.Wound;
                    break;

            case CardType.Impact: //Impact
                enemy.GetComponent<Effect>().duration *= 2;
                    break;

            case CardType.HeavyImpact: //heavy impact
                for (int i = 0; i < GameManager.current.enemies.Count; i++)
                {
                    if (GameManager.current.enemies[i].GetComponent<Effect>() != null)
                    {
                        GameManager.current.enemies[i].GetComponent<Effect>().duration *= 2;
                    }
                }
                break;

            case CardType.Bear: //Bear
                enemyScript.haveStun = true;
                    break;

            case CardType.Rose:
                for (int i = 0; i < GameManager.current.enemies.Count; i++)
                {
                    enemyTakeHit(GameManager.current.enemies[i],CammonCardValue);
                    effect.Effect(GameManager.current.enemies[i]);
                }
                    break;

            case CardType.Charge: //Charge
                enemyTakeHit(enemy,GameManager.current.blockValue);
                    break;
            
            case CardType.Cut:
                enemyScript.haveCutCard = true;
                    break;
            
            case CardType.Consume:
                enemyTakeHit(enemy,GameManager.current.playerMana * CammonCardValue);
                    break;
            
            case CardType.Austerity:
                //elindeki kart sayısı kadar hasar ver
                    break;
                
            case CardType.Crush:
                //null
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
