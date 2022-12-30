using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DragDrop : MonoBehaviour, IPointerDownHandler , IBeginDragHandler , IEndDragHandler , IDragHandler , IDropHandler , IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rectTransform;

    [SerializeField] private Canvas canvas;
    CanvasGroup canvasGroup;

    public Vector3 firstPleace;

    bool isDrag;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Start()
    {

    
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        DOTween.KillAll();
        isDrag = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        isDrag = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.DOScale(new Vector2(1.3f, 1.3f), 0.2f).SetEase(Ease.InCubic);
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            
            transform.DOMove(firstPleace, 0.2f);
            transform.DOScale(new Vector2(1f, 1f), 0.2f).SetEase(Ease.InCubic);
        }
        canvasGroup.alpha = 1f;
        
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        

    }

    private void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

        
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector2(1.3f, 1.3f), 0.2f).SetEase(Ease.InCubic);
        transform.DOMoveY(firstPleace.y+10, 0.2f);
        //transform.localScale = new Vector2(1.2f, 1.2f);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (isDrag == false)
        {
            transform.DOScale(new Vector2(1f, 1f), 0.2f).SetEase(Ease.InCubic);
            transform.DOMoveY(firstPleace.y, 0.2f);
        }
        
        //transform.localScale = new Vector2(1f, 1f);
    }
}
