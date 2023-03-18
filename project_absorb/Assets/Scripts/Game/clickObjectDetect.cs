using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickObjectDetect : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public roomSO roomSO;
    public baseSelectController baseSelectController;
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
       // baseSelectController.enterRoomRange(gameObject,roomSO);
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        baseSelectController.clickRoom(gameObject,roomSO);
        baseSelectController.newClickRoom(roomSO);
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
       // baseSelectController.exitRoomRange(gameObject,roomSO);
    }
}
