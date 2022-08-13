using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    [Header("Card Stats")]
    public int cardType;
    public int manaCost;
    public int hpGain;
    public int attackPoint;
    public int manaGain;



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

    public void cardUsed()
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
