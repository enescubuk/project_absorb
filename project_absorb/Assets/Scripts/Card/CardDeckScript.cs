using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardDeckScript : MonoBehaviour
{
    public static CardDeckScript current;

    public static List<GameObject> CardDeck = new List<GameObject>();
    public static List<GameObject> ownedCardDeck = new List<GameObject>();
    public List<GameObject> cardsPrefabs;

    private void Awake()
    {
        //For Singelton
        if (current != null && current != this)
        {
            Destroy(this);
        }
        else
        {
            current = this;
        }
    }
    void Start()
    {
        
    }
    public void addCard(GameObject card)
    {
        CardDeck.Add(card);
    }
    public void removeCard(GameObject card)
    {
        CardDeck.Remove(card);
    }

    public bool checkCardDeck(GameObject card)
    {
        bool boolValue = false;
        foreach (GameObject _card in CardDeck)
        {
            if (card.name == _card.name)
            {
                boolValue = true;
                break;
            }
            else
            {
                boolValue = false;
            }

        }
        return boolValue;
    }
    public void asd()
    {
        Debug.Log(CardDeck.Count);
    }
    public void restartList()
    {
        CardDeck.Clear();
    }
    
}
