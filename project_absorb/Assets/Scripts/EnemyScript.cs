using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject card;

    [Header("Enemy Stats")]
    [SerializeField] int enemyType;
    [SerializeField] int mana;
    [SerializeField] int hp;
    [SerializeField] int attack;
    [SerializeField] int decreaseAttack;
    [SerializeField] int decreaseMana;



    

    public bool turn;

    GameManager gameManager => GameObject.Find("GameManager").GetComponent<GameManager>();
    void Start()
    {
        gameManager.enemies.Add(gameObject);
    }

    void Update()
    {
        if (turn == true)
        {
            useCard();
            
        }
    }

    public void useCard()
    {
        card.GetComponent<Card>().attackPlayer(attack,decreaseMana,decreaseAttack);
        turn = false;

    }
    public void valueChanges(int attackPower, int hpGain)
    {

        hp -= attackPower;
        hp += hpGain;

    }
}
