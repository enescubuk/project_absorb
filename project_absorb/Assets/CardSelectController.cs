using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelectController : MonoBehaviour,IPointerClickHandler
{
    public CardDeckSO cardDeckSO;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        
        if (transform.parent.name == "All Card")
        {
            cardDeckSO.Set(this.gameObject);
            transform.SetParent(GameObject.FindGameObjectWithTag("OwnedCards").transform);
        }
        else
        {
            cardDeckSO.removeCard(this.gameObject);
            transform.SetParent(GameObject.FindGameObjectWithTag("AllCards").transform);
        }
    }

    
}
