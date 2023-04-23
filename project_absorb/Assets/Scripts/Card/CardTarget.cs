using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class CardTarget : MonoBehaviour , IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    public bool cardUsed;

    GameManager gameManager => GameManager.current;
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.gameObject.transform.DOScale(new Vector2(0.7f, 0.7f), 0.2f).SetEase(Ease.OutExpo);
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(eventData.pointerDrag.gameObject.transform.DOMoveY(gameObject.transform.position.y+50,0.2f)).Append(eventData.pointerDrag.gameObject.transform.DOMoveY(gameObject.transform.position.y,0.2f).SetEase(Ease.OutExpo));
        //eventData.pointerDrag.gameObject.transform.DOMoveY(gameObject.transform.position.y,0.2f).SetEase(Ease.OutExpo);
        eventData.pointerDrag.gameObject.transform.DOMoveX(gameObject.transform.position.x,0.2f).SetEase(Ease.OutExpo);
        //eventData.pointerDrag.gameObject.transform.DOScale(new Vector2(0.5f, 0.5f), 0.2f).SetEase(Ease.OutExpo);
        
        cardUsed = true;

        GameObject whichCard = eventData.pointerDrag.gameObject;

        cardEffect(whichCard);

        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }

        if (cardUsed == true)
        {
            eventData.pointerDrag.gameObject.GetComponent<DragDrop>().isEnd = true;

            gameManager.playerCards.Remove(eventData.pointerDrag.gameObject);

            Destroy(eventData.pointerDrag.gameObject,0.4f);
        }
        

    }


    public void cardEffect(GameObject which)
    {

        if (gameManager.playerMana - which.GetComponent<ItemSO>().cardValuesSO.cardMana >= 0)
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            
        }
        /* else
        {
            eventData.pointerDrag.gameObject.GetComponent<DragDrop>().onTarget = true;
            eventData.pointerDrag.gameObject.transform.DOMoveY(gameObject.transform.position.y+50,0.2f);
            eventData.pointerDrag.gameObject.transform.DOMoveX(gameObject.transform.position.x,0.2f);
            eventData.pointerDrag.gameObject.transform.DOScale(new Vector2(1f, 1f), 0.2f).SetEase(Ease.InCubic);
        }*/
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            
        }
        /* else
        {
            eventData.pointerDrag.gameObject.transform.DOScale(new Vector2(1.3f, 1.3f), 0.2f).SetEase(Ease.InCubic);
            eventData.pointerDrag.gameObject.GetComponent<DragDrop>().onTarget = false;
        }*/
    }
}
