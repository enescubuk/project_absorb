using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckSelecter : MonoBehaviour,IPointerClickHandler
{
    public CardDeckScript cardDeck;

    void setParent()
    {
        Debug.Log(31);
        cardDeck = GameObject.FindWithTag("CardDeck").GetComponent<CardDeckScript>();
        foreach (GameObject card in CardDeckScript.CardDeck)
        {
            if (this.gameObject == card)
            {
                transform.SetParent(GameObject.FindGameObjectWithTag("OwnedCards").transform);
                break;
            }
        }
    }
    void OnEnable()
    {
        setParent();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (transform.parent.name == "All Cards")
        {
            cardDeck.addCard(this.gameObject);
            transform.SetParent(GameObject.FindGameObjectWithTag("OwnedCards").transform);
        }
        else
        {
            cardDeck.removeCard(this.gameObject);
            transform.SetParent(GameObject.FindGameObjectWithTag("AllCards").transform);
        }
    }
}
