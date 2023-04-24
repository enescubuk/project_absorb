using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cardAddDeck : MonoBehaviour, IPointerClickHandler
{
    private DeckSelecter deckSelecter;
    void OnEnable()
    {
        deckSelecter = GameObject.FindWithTag("DeckSelecter").GetComponent<DeckSelecter>();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("asdasdasdasda");
        gameObject.transform.SetParent(deckSelecter.owned.transform);
    }
}
