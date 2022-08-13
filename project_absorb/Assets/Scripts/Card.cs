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
    public bool stunCard;
    public int stunTurn;
    public bool absorbSkill;




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
        /*if (stunCard == true)
        {
            gameManager.stuned = true;
            stunTurn++;
            stunCard = false;
            if (stunTurn == 2)
            {
                stunCard = true;
                stunTurn = 0;
            }
            
        }*/
        
        
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

    public void attackPlayer(int attackPoint,int manaPoint)
    {
        gameManager.playerHp -= attackPoint;

        gameManager.playerMana -= manaPoint;
        if (gameManager.playerMana - manaPoint < 0)
        {
            gameManager.playerMana = 0;
        }
    }
}
