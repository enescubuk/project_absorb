using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardTarget : MonoBehaviour , IDropHandler
{
    public bool cardUsed;
    public GameObject whichCard;

    GameManager gameManager => GameObject.Find("GameManager").GetComponent<GameManager>();
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("CardUsed");
        cardUsed = true;
        whichCard = eventData.pointerDrag.gameObject;

        cardEffect();

        if (eventData.pointerDrag != null) { 
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }

        gameManager.playerCards.Remove(this.whichCard);
        Destroy(whichCard);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cardEffect()
    {
        GetComponent<EnemyScript>().valueChanges(whichCard.GetComponent<Card>().attackPoint, whichCard.GetComponent<Card>().hpGain);
        
    }
}
