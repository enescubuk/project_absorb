using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckSelecter : MonoBehaviour
{
    public GameObject owned,all;

    public CardDeckScript cardDeck;
    void OnEnable()
    {
        owned = GameObject.FindWithTag("OwnedCards");
        all = GameObject.FindWithTag("AllCards");
        setParent();
        
    }

    void setParent()
    {
        foreach (Transform card in all.transform)
        {
            trainerOnEnable(card.gameObject);
            if (cardDeck.checkCardDeck(card.gameObject) == false)
            {   
                Destroy(card.gameObject);
            }
        }
    }
    void trainerOnEnable(GameObject card)
    {
        Destroy(card.GetComponent<DragDrop>());
        card.AddComponent<cardAddDeck>();
    }


}
