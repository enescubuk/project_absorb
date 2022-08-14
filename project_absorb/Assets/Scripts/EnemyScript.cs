using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public GameObject card;

    [Header("Enemy Stats")]
    [SerializeField] int enemyType;
    [SerializeField] int mana;
    [SerializeField] int hp;
    [SerializeField] int attack;
    [SerializeField] int decreaseAttack;
    [SerializeField] int decreaseMana;
    [SerializeField] int firstHp;





    public bool turn;

    GameManager gameManager => GameObject.Find("GameManager").GetComponent<GameManager>();
    void Start()
    {
        gameManager.enemies.Add(gameObject);
        transform.GetChild(0).GetComponent<Slider>().maxValue = hp;
    }

    void Update()
    {
        
        transform.GetChild(0).GetComponent<Slider>().value = hp;
        

        if (turn == true)
        {
            useCard();
            

        }
    }

    public void useCard()
    {
        card.GetComponent<Card>().attackPlayer();
        gameManager.nextTurn = true;
        turn = false;



    }
    public void valueChanges(int attackPower, int hpGain)
    {

        hp -= attackPower;
        gameManager.playerHp += hpGain;

    }
    public void Absorbed()
    {

        attack -= card.GetComponent<Card>().attackPoint;

    }
}
