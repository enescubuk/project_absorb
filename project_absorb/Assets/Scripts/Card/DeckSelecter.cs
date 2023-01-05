using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckSelecter : MonoBehaviour,IPointerClickHandler
{
    public CardDeckScript cardDeck;

    void Awake()
    {
        cardDeck = GameObject.FindWithTag("CardDeck").GetComponent<CardDeckScript>();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (transform.parent.name == "All Card")
        {
            cardDeck.addCard(this.gameObject.GetComponent<Card>().cardID);
            transform.SetParent(GameObject.FindGameObjectWithTag("OwnedCards").transform);
        }
        else
        {
            cardDeck.removeCard(this.gameObject.GetComponent<Card>().cardID);
            transform.SetParent(GameObject.FindGameObjectWithTag("AllCards").transform);
        }
    }

    
}
