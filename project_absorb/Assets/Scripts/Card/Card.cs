using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum CardType { Attack, AttackAndBleed, Bleed, Bleedx2,AllBleedx2, AttackAsCurrentBleed,Stun, FirstAttackCounter,
    Block, BlockAndCounter, AttackAsBlockValue,  AttackAsUntilPlayedCard , AttackAsMana, AttackAs , AttackAsNumberOfCards , AttackToAllEnemy};
    [Header("Card Stats")]
    
    
    public int cardID;
    public CardType cardType;
    public int manaCost;//hepsinde var
    public int hpGain;
    public int attackPoint;
    public EffectSO effect;
    public int slot;
    public int CammonCardValue;
    private GameObject target;
    EnemyScript enemyScript;
    
    public void attackPlayer(EnemyScript enemyScript)
    {
        if (enemyScript.haveCT == false)
        {
            int damage = Mathf.Max(attackPoint - GameManager.current.blockValue, 0);
            GameManager.current.blockValue -= Mathf.Min(GameManager.current.blockValue, attackPoint);
            GameManager.current.playerHp -= damage;
            GameManager.current.ShieldText.text = GameManager.current.blockValue.ToString();
        }
        else
        {
            enemyScript.hp -= attackPoint;
            enemyScript.haveCT = false;
        }
    }

    public void CastSkill(GameObject enemy)
    {
        target = enemy;
        enemyScript = enemy.GetComponent<EnemyScript>();
        switch (cardType)   
        {
            case CardType.Attack:// Slash && Piercing
                enemyTakeHit(enemy);
                enemyScript.hp -= CammonCardValue;
                    break;

            case CardType.Bleed: // Wound
                enemyTakeHit(enemy);
                effect.Effect(enemy);
                enemyScript.hp -= attackPoint;
                    break;
            
            
            case CardType.Block://Block & Shield
                GameManager.current.blockValue += CammonCardValue;
                GameManager.current.ShieldText.text = GameManager.current.blockValue.ToString();
                    break;
            
            case CardType.AttackToAllEnemy: //Swing
                for (int i = 0; i < GameManager.current.enemies.Count; i++)
                {
                    GameManager.current.enemies[i].GetComponent<EnemyScript>().hp -= 4;
                    enemyTakeHit(GameManager.current.enemies[i]);
                }
                    break;

            case CardType.FirstAttackCounter: //Counter
                enemyScript.haveCT = true;
                    break;

            case CardType.BlockAndCounter: //Prepare
                enemyScript.haveCT = true;
                goto case CardType.Block;
                    break;

            case CardType.AttackAsCurrentBleed: // Heavy Wound & Reap
                enemyScript.hp -= enemy.GetComponent<Effect>().duration * CammonCardValue;
                    break;

            case CardType.AttackAndBleed: //Stab
                enemyTakeHit(enemy);
                enemyScript.hp -= CammonCardValue;
                goto case CardType.Bleed;
                    break;

            case CardType.Bleedx2: //Impact
                effect.effectDuration *= 2;
                    break;

            //case CardType.AllBleedx2: //Heavy Impack
            //    for (int i = 0; i < GameManager.current.enemies.Count; i++)
            //    {
            //        if (GameManager.current.enemies[i].GetComponent<Effect>() != null)
            //        {
            //            effect.effectDuration *= 2;
            //        }
            //    }
            //    break;

            case CardType.Stun: //Bear
                enemyScript.haveStun = true;
                    break;

            case CardType.AttackAsBlockValue: //Charge
                enemyScript.hp -= GameManager.current.blockValue;
                    break;
            
            case CardType.AttackAsMana: //Austerity & Consume
                enemyScript.hp -= GameManager.current.playerMana * CammonCardValue;
                    break;
                

            
        }

        GameManager.current.playerMana -= GetComponent<ItemSO>().cardValuesSO.cardMana;
        
    }

    private void enemyTakeHit(GameObject enemy)
    {

                enemy.GetComponent<Animator>().SetTrigger("TakeHit");
        GameEvents.current.DeadEnter(enemy.GetComponent<EnemyScript>().id, enemy.GetComponent<EnemyScript>().hp,target);
    }
} 
