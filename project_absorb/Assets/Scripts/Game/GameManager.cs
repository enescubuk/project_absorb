using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
//using System;

public class GameManager : MonoBehaviour
{
    public CharacterDataSO characterDataSO;
    public static GameManager current;
    public PanelAnimation UIAnim;
    public bool endGame;
    public bool canWalk;
    public int bossRoomNumber;
    public bool isBossFight;
    public bool newCardRoom;
    public int wave;
    public bool isWalk;
    bool isEmptySlot;
    public int killCount;
    [SerializeField] Text killText;
    public List<int> combs;

    [Header("Turn Things")]
    public int turnNumber;
    public bool nextTurn;
    public bool stuned;

    [Header("Cards")]
    public List<GameObject> cards ;
    public Transform[] cardSlots;
    public bool[] availableCardSlots;
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
    public TMP_Text ShieldText;
    public Image mana => GameObject.Find("Mana").GetComponent<Image>();
    public Sprite[] manaPots;
    public int blockValue;
    


    [Header("Enemies")]
    public List<GameObject> enemies;
    public List<GameObject> enemiesType;
    public int spawnDelay;



    public List<GameObject> playerCards;

    public Animator playerAnim;

    public GameObject NextButton;
    
    public void EmptySlot(GameObject card)
    {
        availableCardSlots[card.GetComponent<Card>().slot] = true;
    }


    private void Awake()
    {

        playerHp = characterDataSO.Health;

        List<int> selectedCards = CardDeckScript.CardDeck;
        //For Singelton
        if (current != null && current != this)
        {
            Destroy(this);
        }
        else
        {
            current = this;
        }
        for (int i = 0; i < CardDeckScript.current.cardsPrefabs.Count; i++)
        {
            for (int j = 0; j < selectedCards.Count; j++)
            {
                if (selectedCards[j] == CardDeckScript.current.cardsPrefabs[i].GetComponent<Card>().cardID)
                {
                    this.cards.Add(CardDeckScript.current.cardsPrefabs[i]);
                    break;
                }
            } 
        }
    }
    void Start()
    {
        //Get 3 Card From Start
    GameObject a = Instantiate(cards[Random.Range(0, cards.Count)], GameObject.Find("Card").transform);
    DrawCard(a);
    
    playerCards.Add(a);
    
    GameObject b = Instantiate(cards[Random.Range(0, cards.Count)],  GameObject.Find("Card").transform);
    DrawCard(b);
    
    playerCards.Add(b);
    }

    private void FixedUpdate()
    {
    
        

        if (canWalk == true)
        {
            playerAnim.SetBool("Run",true);
        }
        else
        {
            playerAnim.SetBool("Run",false);
        }

        HealthAndManaSystem();

        if (availableCardSlots[0] == false && availableCardSlots[1] == false && availableCardSlots[2] == false && availableCardSlots[3] == false && availableCardSlots[4] == false)
        {
            isEmptySlot = true;
        }
        else
        {
            isEmptySlot = false;
        }

        if (enemies.Count != 0)
        {
            TurnSystem();
        }
        else
        {
            NextButton.SetActive(false);
        }

    }

    void HealthAndManaSystem()
    {

        characterDataSO.Health = playerHp;
        //Max Hp
        if (playerHp > playerMaxHp)
        {
            playerHp = playerMaxHp;
        }

        //Hp Text Wrtier
        healthBar.value = playerHp;
        hpText.text = "" + playerHp;

        //Mana Bar
        GameObject.Find("ManaText").GetComponent<Text>().text = "" + playerMana;
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

        

        //Die
        if (playerHp <= 0)
        {
            if (characterDataSO.MaxHealth - 10 >= 40)
            {
                characterDataSO.MaxHealth -= 10;
            }
     //   SceneManager.LoadScene("finish");
        }


        //End Room
        

    }
    public void CardByTurn()
    {
        for (int i = 0; i < 2; i++)
        {
        GameObject a = Instantiate(cards[Random.Range(0, cards.Count)] , GameObject.Find("Card").transform);
        a.transform.localScale = new Vector3(1,1,1);
        DrawCard(a);
        playerCards.Add(a);
        }
        
    }

    public void DrawCard(GameObject card)
    {
        for (int i = 0; i < availableCardSlots.Length; i++)
        {
            if (availableCardSlots[i] == true)
            {
                card.GetComponent<Card>().slot = i;
                card.transform.DOMove(cardSlots[i].position, 0.5f).From(new Vector3(cardSlots[2].position.x, cardSlots[2].position.y - 50, cardSlots[2].position.z)).SetEase(Ease.OutQuart);
                //card.transform.position = cardSlots[i].position;
                card.transform.rotation = cardSlots[i].rotation;
                card.GetComponent<DragDrop>().firstPleace = cardSlots[i].position;

                availableCardSlots[i] = false;

                return;
            }
        }
    }
    void TurnSystem()
    {

        if (enemies.Count >= 0 && turnNumber == enemies.Count)
        {
            NextButton.SetActive(true);
            playerMana = 4;
            nextTurn = false;
            turnNumber = 0;
            if (isEmptySlot == false)
            {
                CardByTurn();
            }
            Debug.Log("Main Char Turn");

        }
        if (nextTurn == true)
        {
            NextButton.SetActive(false);

            GameEvents.current.TurnEnter(enemies[turnNumber].GetComponent<EnemyScript>().turnNumber, turnNumber);
            
            nextTurn = false;
        }
    }

    public void NextTurn()
    {

        nextTurn = true;
    }
    
}
