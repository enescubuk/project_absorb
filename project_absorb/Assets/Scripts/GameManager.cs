using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Turn Things")]
    public int turnNumber;
    public int memberNumber;
    public bool nextTurn;

    [Header("Cards")]
    public GameObject[] cards;
    //public GameObject[] playerCards;

    [Header("Player Stats")]
    public int playerMana;
    public int playerHp;
    public int playerAttack;

    [Header("Enemies")]
    public List<GameObject> enemies;



    public List<GameObject> playerCards;


    void Start()
    {
        GameObject a = Instantiate(cards[Random.Range(0, cards.Length)], GameObject.Find("UICanvas").transform);
        playerCards.Add(a);
        GameObject b = Instantiate(cards[Random.Range(0, cards.Length)], GameObject.Find("UICanvas").transform);
        playerCards.Add(b);
        GameObject c = Instantiate(cards[Random.Range(0, cards.Length)], GameObject.Find("UICanvas").transform);
        playerCards.Add(c);

        turnNumber = enemies.Count;
    }

    
    void Update()
    {
        TurnSystem();
        //Debug.Log(turnNumber);

        /*if (playerTarget.cardUsed == true)
        {
            playerTarget.whichCard.GetComponent<Card>().cardUsed();
        }*/
    }

    void CardByTurn()
    {
        GameObject a = Instantiate(cards[Random.Range(0, cards.Length)] , GameObject.Find("UICanvas").transform);
        playerCards.Add(a);

    }
    void TurnSystem()
    {
        if (nextTurn == true)
        {
            if (turnNumber == memberNumber)
            {
                nextTurn = false;
                turnNumber = 0;
                CardByTurn();
                Debug.Log("MainChar Turn");
            }
            else
            {
                enemies[turnNumber-1].GetComponent<EnemyScript>().turn = true;

            }
            turnNumber++;

        }
    }
}
