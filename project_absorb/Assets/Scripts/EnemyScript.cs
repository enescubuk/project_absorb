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
        transform.GetChild(1).GetComponent<Text>().text = "" + hp;


        if (turn == true)
        {
            useCard();
            

        }


        if (hp <= 0)
        {
            gameManager.killCount++;
            gameManager.enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void useCard()
    {
        GetComponent<Animator>().SetTrigger("Attack");
        gameManager.playerAnim.SetTrigger("Hit");
        card.GetComponent<Card>().attackPlayer(attack);
        gameManager.nextTurn = true;
        turn = false;



    }
    public void valueChanges(int attackPower, int hpGain)
    {

        hp -= attackPower;
        gameManager.playerHp += hpGain;
        GetComponent<Animator>().SetTrigger("TakeHit");

    }
    public void Absorbed()
    {


    }
}
