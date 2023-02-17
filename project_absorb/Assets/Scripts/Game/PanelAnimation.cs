using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelAnimation : MonoBehaviour
{

    public float fadeTime;

    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;

    public CanvasGroup canvasGroupGame;
    public RectTransform rectTransformGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanelFadeIn()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3 (0,-1000f,0);
        rectTransform.DOAnchorPos(new Vector2(0f,0f),fadeTime,false).SetEase(Ease.OutCirc);
        canvasGroup.DOFade(1,fadeTime);
    }

    public void PanelFadeOut()
    {
        canvasGroupGame.alpha = 1f;
        //rectTransformGame.transform.localPosition = new Vector3 (0,0,0);
        //rectTransformGame.DOAnchorPos(new Vector2(0f, -1000f),fadeTime,false).SetEase(Ease.InOutCirc);
        canvasGroupGame.DOFade(0,fadeTime);

    }
}
