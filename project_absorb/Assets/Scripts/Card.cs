using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    [Header("Card Stats")]
    [SerializeField] int cardType;
    [SerializeField] int manaCost;
    [SerializeField] int hpGain;
    [SerializeField] int attackPoint;


    GameManager gameManager => GameObject.Find("GameManager").GetComponent<GameManager>();

    void Start()
    {
        

    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            cardUsed();
        }
        
    }

    void cardUsed()
    {
        

        if (gameManager.turnNumber == 0)
        {
            gameManager.playerMana -= manaCost;



        }
        else
        {

        }

        gameManager.playerCards.Remove(this.gameObject);
        Destroy(gameObject);


    }
}
