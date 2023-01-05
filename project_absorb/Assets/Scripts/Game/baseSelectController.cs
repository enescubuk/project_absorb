using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class baseSelectController : MonoBehaviour
{
    public TextMeshProUGUI roomNameText;
    public TextMeshProUGUI roomDescriptionText;
    public GameObject textParents;
    public Image roomSprite;
    private GameObject targetRoom;
    public Camera camera;
    private Vector3 lastCameraPos;
    public float lastCameraSize;
    void Awake()
    {
        lastCameraPos = camera.transform.position;
        lastCameraSize = camera.orthographicSize;
    }
    
    public void enterRoomRange(GameObject room,roomSO roomSO)
    {
        setValues(room,roomSO);
    }

    public void clickRoom(GameObject room,roomSO roomSO)
    {
        targetRoom = room;
        camera.transform.DOMove(new Vector3(targetRoom.transform.position.x,targetRoom.transform.position.y,lastCameraPos.z),1);
        DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, lastCameraSize - 100, 1);
        Invoke("inMoveBoxs",0.3f);
    }

    public void exitRoomRange(GameObject room,roomSO roomSO)
    {
        
        targetRoom = null;
        camera.transform.DOMove(lastCameraPos,1);
        DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, lastCameraSize, 1);
        outMoveBoxs();
    }

    void setValues(GameObject room,roomSO roomSO)
    {
        roomNameText.text = roomSO.roomName;
        roomDescriptionText.text = roomSO.roomDescription;
        roomSprite.sprite = roomSO.roomSprite;
    }
    void inMoveBoxs()
    {
        Debug.Log("in");
        float x = 1858f;
        float y = -76.5f;
        roomSprite.gameObject.transform.DOMoveX(x,1f);
        textParents.transform.DOMoveY(y,1f);

    }
    void outMoveBoxs()
    {
        Debug.Log("out");
        float x = 1785;
        float y = -125f;
        roomSprite.gameObject.transform.DOMoveX(x,1f);
        textParents.transform.DOMoveY(y,1f);
    }
}
