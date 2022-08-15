using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System;

public class GameManager : MonoBehaviour
{
    public int killCount;
    [SerializeField] Text killText;
    public List<int> combs;

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

    public Text hpText;
    public Image mana => GameObject.Find("Mana").GetComponent<Image>();
    public Sprite[] manaPots;


    [Header("Enemies")]
    public List<GameObject> enemies;
    public List<GameObject> enemiesType;



    public List<GameObject> playerCards;

    public Animator playerAnim;
    
    void Start()
    {
        
       

        GameObject a = Instantiate(cards[Random.Range(0, cards.Count)], GameObject.Find("UICanvas").transform);
        a.transform.localPosition = new Vector3(-850 , -600, 0);
        playerCards.Add(a);
        GameObject b = Instantiate(cards[Random.Range(0, cards.Count)],  GameObject.Find("UICanvas").transform);
        b.transform.localPosition = new Vector3(-400 , -600, 0);
        playerCards.Add(b);
        GameObject c = Instantiate(cards[Random.Range(0, cards.Count)], GameObject.Find("UICanvas").transform);
        c.transform.localPosition = new Vector3(50 , -600, 0);
        playerCards.Add(c);
        
    }

    void Update()
    {
        PlayerPrefs.SetInt("KillCount", killCount);
        killText.text = "Kill Count: " + killCount;
        if (playerHp<=0)
        {
            SceneManager.LoadScene("finish");
        }
        if (enemies.Count<= 0)
        {
            GameObject a = Instantiate(enemiesType[Random.Range(0, enemiesType.Count)], GameObject.Find("UICanvas").transform);
            a.transform.localPosition = new Vector3(1150, 50, 0);
            GameObject b = Instantiate(enemiesType[Random.Range(0, enemiesType.Count)], GameObject.Find("UICanvas").transform);
            b.transform.localPosition = new Vector3(450, 50, 0);
        }
        
        memberNumber = enemies.Count;
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
        GameObject.Find("ManaText").GetComponent<Text>().text = "" + playerMana;

        healthBar.value = playerHp;
        hpText.text = "" + playerHp;
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
