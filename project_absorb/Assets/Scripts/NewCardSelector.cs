using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewCardSelector : MonoBehaviour, IPointerClickHandler
{
    
    public void OnPointerClick(PointerEventData pointerEventData)
    {   

        gameObject.transform.GetChild(0).gameObject.AddComponent<DragDrop>();
        GameManager.current.cards.Add(gameObject.transform.GetChild(0).gameObject);
        //Draw Selected Card
        GameObject b = Instantiate(gameObject.transform.GetChild(0).gameObject , GameObject.Find("Card").transform);
        b.transform.localScale = new Vector3(1,1,1);
        GameManager.current.DrawCard(b);
        GameManager.current.playerCards.Add(b);

        RoomScript.current.NewWave();
        NewCardGeneretor.current.newCardPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.parent = NewCardGeneretor.current.parent.transform;
        NewCardGeneretor.current.newCardPanel.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.parent = NewCardGeneretor.current.parent.transform;
        NewCardGeneretor.current.newCardPanel.SetActive(false);
        NewCardGeneretor.current.a = 0;
        GameManager.current.newCardRoom = false;
        
    }
}
