using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum CardType { Attack, AttackAndBleed, Bleed, Bleedx2, AllBleedx2, AttackAsCurrentBleed, AttackAsCurrentBleedx2,Stun, FirstAttackCounter,
    Block, BlockAndCounter, AttackAsBlockValue,  AttackAsUntilPlayedCard , AttackAsMana, AttackAs , AttackAsNumberOfCards};
    [Header("Card Stats")]
    
    
    public int cardID;
    public CardType cardType;//hepsinde var
    public int manaCost;//hepsinde var
    public int hpGain;
    public int attackPoint;
    public EffectSO effect;
    public int slot;
    public int CammonCardValue;
    private GameObject target;
    
    public void attackPlayer()
    {
        if (GameManager.current.blockValue <= attackPoint)
        {
            GameManager.current.playerHp -= (attackPoint - GameManager.current.blockValue);
        }
        else
        {
            GameManager.current.blockValue = (GameManager.current.blockValue - attackPoint);
        }
        
        //if (Mathf.Min(attackPoint,GameManager.current.blockValue) == GameManager.current.blockValue)
        //{
        //    GameManager.current.playerHp -= attackPoint + GameManager.current.blockValue;
        //    Debug.Log("Attack Value : " + (attackPoint + GameManager.current.blockValue));
        //}
    }

    public void CastSkill(GameObject enemy)
    {
        target = enemy;
        enemy.GetComponent<Animator>().SetTrigger("TakeHit");

        switch (cardType)   
        {
            case CardType.Attack:// Attack Skill
                enemy.GetComponent<EnemyScript>().hp -= attackPoint;
                break;

            case CardType.Bleed: // Bleed Card
                effect.Effect(enemy);
                enemy.GetComponent<EnemyScript>().hp -= attackPoint;
                break;

            case CardType.Block:
                GameManager.current.blockValue += CammonCardValue;
                break;
        }

        GameManager.current.playerMana -= manaCost;

        GameEvents.current.DeadEnter(enemy.GetComponent<EnemyScript>().id, enemy.GetComponent<EnemyScript>().hp,target);
    }
}
