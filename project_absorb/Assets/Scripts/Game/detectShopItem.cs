using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class detectShopItem : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ShopManager ShopManager;
    public InventoryController inventoryController;
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        ShopManager.enterRange(gameObject);
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        ShopManager.clickRange(gameObject);
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        ShopManager.exitRange(gameObject);
    }
}
