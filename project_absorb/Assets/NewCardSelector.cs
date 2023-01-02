using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewCardSelector : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GameManager.current.cards.Add(gameObject.transform.GetChild(0).gameObject);
        NewCardGeneretor.current.newCardPanel.SetActive(false);
        GameManager.current.newCardRoom = false;
        
    }
}
