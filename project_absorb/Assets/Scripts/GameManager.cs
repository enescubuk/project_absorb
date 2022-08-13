using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Turn Things")]
    public int turnNumber;
    public int memberNumber;

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
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (turnNumber == memberNumber)
            {
                turnNumber = 0;
                CardByTurn();
                Debug.Log("MainChar Turn");
            }
            else
            {
                enemies[turnNumber].GetComponent<EnemyScript>().turn = false;
                turnNumber++;
                enemies[turnNumber].GetComponent<EnemyScript>().turn = true;
            }
            
        }
    }
}
