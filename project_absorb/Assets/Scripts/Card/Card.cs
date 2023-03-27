using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum CardType { Attack, AttackAndBleed, Bleed, AllBleedx2, AttackAsCurrentBleed,Stun, FirstAttackCounter,
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
    
    public void attackPlayer(GameObject enemy)
    {
        if (GameManager.current.haveCT == false)
        {
            int damage = Mathf.Max(attackPoint - GameManager.current.blockValue, 0);
            GameManager.current.blockValue -= Mathf.Min(GameManager.current.blockValue, attackPoint);
            GameManager.current.playerHp -= damage;
            GameManager.current.ShieldText.text = GameManager.current.blockValue.ToString();
        }
        else
        {
            enemy.GetComponent<EnemyScript>().hp -= attackPoint;
            GameManager.current.haveCT = false;
            Debug.Log(31);
        }
    }

    public void CastSkill(GameObject enemy)
    {
        target = enemy;
        switch (cardType)   
        {
            case CardType.Attack:// Slash
                enemyTakeHit(enemy);
                enemy.GetComponent<EnemyScript>().hp -= CammonCardValue;
                    break;

            case CardType.Bleed: // Wound
                enemyTakeHit(enemy);
                effect.Effect(enemy);
                enemy.GetComponent<EnemyScript>().hp -= attackPoint;
                    break;
            
            
            case CardType.Block://Block & Shield
                GameManager.current.blockValue += CammonCardValue;
                GameManager.current.ShieldText.text = GameManager.current.blockValue.ToString();
                    break;
            
            case CardType.AttackToAllEnemy: //Swing
                for (int i = 0; i < GameManager.current.enemies.Count; i++)
                {
                    GameManager.current.enemies[i].GetComponent<EnemyScript>().hp -= 4;
                }
                    break;

            case CardType.FirstAttackCounter: //Counter
                GameManager.current.haveCT = true;
                    break;

            case CardType.BlockAndCounter: //Prepare
                GameManager.current.haveCT = true;
                goto case CardType.Block;
                    break;

            case CardType.AttackAsCurrentBleed: // Heavy Wound & Reap
                enemy.GetComponent<EnemyScript>().hp -= enemy.GetComponent<Effect>().duration * CammonCardValue;
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
