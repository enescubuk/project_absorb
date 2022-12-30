using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardTarget : MonoBehaviour , IDropHandler
{
    public bool cardUsed;

    GameManager gameManager => GameManager.current;
    public void OnDrop(PointerEventData eventData)
    {
        
        cardUsed = true;
        GameObject whichCard = eventData.pointerDrag.gameObject;

        cardEffect(whichCard);

        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }

        if (cardUsed == true)
        {
            gameManager.playerCards.Remove(eventData.pointerDrag.gameObject);

            Destroy(eventData.pointerDrag.gameObject);
        }
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(31);
    }

    public void cardEffect(GameObject which)
    {

        if (gameManager.playerMana - which.GetComponent<Card>().manaCost >= 0)
        {
            gameManager.playerAnim.SetTrigger("Attack");

            gameManager.EmptySlot(which);

            which.GetComponent<Card>().CastSkill(gameObject);

            
        }
        else
        {
            cardUsed = false;
        }
    }
}
