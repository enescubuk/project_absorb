using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Turn Things")]
    public int turnNumber;
    public int memberNumber;
    public bool nextTurn;
    public bool stuned;

    [Header("Cards")]
    public List<GameObject> cards;
    //public GameObject[] playerCards;

    [Header("Player Stats")]
    public int playerMana;
    public int playerHp;
    public int playerMaxMana;
    public int playerMaxHp;
    public int playerAttack;
    public Slider manaBar;
    public Slider healthBar;
    public Image mana => GameObject.Find("Mana").GetComponent<Image>();
    public Sprite[] manaPots;


    [Header("Enemies")]
    public List<GameObject> enemies;



    public List<GameObject> playerCards;


    void Start()
    {
        GameObject a = Instantiate(cards[Random.Range(0, cards.Count)], GameObject.Find("UICanvas").transform);
        playerCards.Add(a);
        GameObject b = Instantiate(cards[Random.Range(0, cards.Count)], GameObject.Find("UICanvas").transform);
        playerCards.Add(b);
        GameObject c = Instantiate(cards[Random.Range(0, cards.Count)], GameObject.Find("UICanvas").transform);
        playerCards.Add(c);

        memberNumber = enemies.Count;
    }

    
    void Update()
    {
        TurnSystem();
        if (playerHp>20)
        {
            playerHp = 20;
        }

        switch (playerMana)
        {
            case 0:
                mana.sprite = manaPots[0];
                break;
            case 1:
                mana.sprite = manaPots[1];
                break;
            case 2:
                mana.sprite = manaPots[1];
                break;
            case 3:
                mana.sprite = manaPots[1];
                break;
            case 4:
                mana.sprite = manaPots[2];
                break;
        }

        healthBar.value = playerHp;
        //manaBar.value = playerMana;

        //Debug.Log(turnNumber);

        /*if (playerTarget.cardUsed == true)
        {
            playerTarget.whichCard.GetComponent<Card>().cardUsed();
        }*/
    }

    void CardByTurn()
    {
        GameObject a = Instantiate(cards[Random.Range(0, cards.Count)] , GameObject.Find("UICanvas").transform);
        playerCards.Add(a);

    }
    void TurnSystem()
    {
        if (turnNumber == memberNumber)
        {
            playerMana = 4;
            nextTurn = false;
            if (stuned)
            {
                nextTurn = true;
                stuned = false;
            }
            turnNumber = 0;
            CardByTurn();
            Debug.Log("MainChar Turn");

        }
        if (nextTurn == true)
        {
            enemies[turnNumber].GetComponent<EnemyScript>().turn = true;
            nextTurn = false;
            Debug.Log(turnNumber);
            turnNumber++;

        }
    }

    public void NextTurn()
    {

        nextTurn = true;
    }
}
