using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardTarget : MonoBehaviour , IDropHandler
{
    public bool cardUsed;
     

    GameManager gameManager => GameObject.Find("GameManager").GetComponent<GameManager>();
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("CardUsed");
        gameManager.nextTurn = true;
        
        cardUsed = true;
        GameObject whichCard = eventData.pointerDrag.gameObject;
        

        cardEffect(whichCard);
        if (whichCard.GetComponent<Card>().absorbSkill == true)
        {
            AbsorbCard(whichCard);
        }
        

        if (eventData.pointerDrag != null) { 
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }

        gameManager.playerCards.Remove(eventData.pointerDrag.gameObject);
        Destroy(eventData.pointerDrag.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cardEffect(GameObject which)
    {
        GetComponent<EnemyScript>().valueChanges(which.GetComponent<Card>().attackPoint, which.GetComponent<Card>().hpGain);

    }

    public void AbsorbCard(GameObject which)
    {
        GameObject a = Instantiate(GetComponent<EnemyScript>().card , GameObject.Find("UICanvas").transform);
        gameManager.playerCards.Add(a);

        GetComponent<EnemyScript>().Absorbed();


    }
}
