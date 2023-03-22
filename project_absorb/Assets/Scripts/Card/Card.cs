using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum CardType { Attack, AttackAndBleed, Bleed, Bleedx2, AllBleedx2, AttackAsCurrentBleed, AttackAsCurrentBleedx2,Stun, FirstAttackCounter,
    Block, BlockAndCounter, AttackAsBlockValue,  AttackAsUntilPlayedCard , AttackAsMana, AttackAs , AttackAsNumberOfCards};
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
    
    public void attackPlayer()
    {
        int damage = Mathf.Max(attackPoint - GameManager.current.blockValue, 0);
        GameManager.current.blockValue -= Mathf.Min(GameManager.current.blockValue, attackPoint);
        GameManager.current.playerHp -= damage;
    }

    public void CastSkill(GameObject enemy)
    {
        target = enemy;
        switch (cardType)   
        {
            case CardType.Attack:// Attack Skill
                enemyTakeHit(enemy);
                enemy.GetComponent<EnemyScript>().hp -= attackPoint;
                break;

            case CardType.Bleed: // Bleed Card
                enemyTakeHit(enemy);
                effect.Effect(enemy);
                enemy.GetComponent<EnemyScript>().hp -= attackPoint;
                break;

            case CardType.Block:
                GameManager.current.blockValue += CammonCardValue;
                break;
        }

        GameManager.current.playerMana -= manaCost;
        
    }

    private void enemyTakeHit(GameObject enemy)
    {

        enemy.GetComponent<Animator>().SetTrigger("TakeHit");
        GameEvents.current.DeadEnter(enemy.GetComponent<EnemyScript>().id, enemy.GetComponent<EnemyScript>().hp,target);
    }
}
