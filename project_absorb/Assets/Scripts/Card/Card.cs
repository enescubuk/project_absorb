using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    [Header("Card Stats")]
    public int cardID;
    public int cardType;//hepsinde var
    public int manaCost;//hepsinde var
    public int hpGain;
    public int attackPoint;
    public int manaGain;
    public bool stunCard;
    public int stunTurn;
    public bool absorbSkill;


    public int slot;
    
    public void attackPlayer()
    {
        GameManager.current.playerHp -= attackPoint;

    }

    public void CastSkill(GameObject enemy)
    {
        enemy.GetComponent<Animator>().SetTrigger("TakeHit");

        switch (cardType)
        {
            case 0:// Attack Skill

                enemy.GetComponent<EnemyScript>().hp -= attackPoint;

                break;

            case 1: // Absorb Skill

                GameObject a = Instantiate(enemy.GetComponent<EnemyScript>().card, GameObject.Find("UICanvas").transform);
                GameManager.current.DrawCard(a);
                GameManager.current.playerCards.Add(a);

                break;
            case 2: // HP Steal Skill

                enemy.GetComponent<EnemyScript>().hp -= attackPoint;
                GameManager.current.playerHp += hpGain;

                break;
        }

        GameManager.current.playerMana -= manaCost;

        GameEvents.current.DeadEnter(enemy.GetComponent<EnemyScript>().id, enemy.GetComponent<EnemyScript>().hp);
    }
}
