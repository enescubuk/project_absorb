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
        foreach (int card_ID in CardDeckScript.CardDeck)
        {
            if (GetComponent<Card>().cardID == card_ID)
            {
                Debug.Log(transform.gameObject.name);
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
