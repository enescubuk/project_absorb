using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="CardDeck",menuName ="Card Deck")]
public class CardDeckSO : ScriptableObject
{
    public List<GameObject> ownCards;
    [SerializeField] private GameObject card;
    public int itemCount = 0;

    public void Set(GameObject card)
    {
        //Debug.Log(card.GetType());
        this.card = card;
        //ownCards.Add(card);
        foreach (GameObject item in ownCards)
        {
            if (item == null)
            {
                ownCards[itemCount] = card;
                itemCount++;
                break;
            }
        }
        
    }
    public void removeCard(GameObject card)
    {
        this.card = card;
        ownCards.Remove(card);
    }
}
