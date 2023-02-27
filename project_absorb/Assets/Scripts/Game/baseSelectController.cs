using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class baseSelectController : MonoBehaviour
{
    public TextMeshProUGUI roomNameText;
    public TextMeshProUGUI roomDescriptionText;
    public GameObject textParents;
    public Image roomSprite;
    private GameObject targetRoom;
    public new Camera camera;
    private Vector3 lastCameraPos;
    private float lastCameraSize;
    Vector3 firstPosSprite,firstPosTexts;
    public Transform close_button;
    private bool isRoomOpen = false;


    [Header("Rooms")]
    public GameObject CardTrainerRoom;
    public GameObject RecruiterRoom;
    public GameObject GeneralRoom;


    void Awake()
    {
        lastCameraPos = camera.transform.position;
        lastCameraSize = camera.orthographicSize;
        firstPosSprite = roomSprite.gameObject.transform.position;
        firstPosTexts = textParents.transform.position;
    }
    
    public void enterRoomRange(GameObject room,roomSO roomSO)
    {
        setValues(room,roomSO);
        
    }

    public void clickRoom(GameObject room,roomSO roomSO)
    {
        if (isRoomOpen == false)
        {
            targetRoom = room;
            camera.transform.DOMove(new Vector3(targetRoom.transform.position.x,targetRoom.transform.position.y,lastCameraPos.z),1);
            DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, lastCameraSize - 100, 1);
            Invoke("inMoveBoxs",0.3f);
        }
        else
        {
            goOut();
            room.GetComponent<SpriteRenderer>().enabled = false;
            openRoom().SetActive(true);
        }
    }

    GameObject openRoom()
    {
        GameObject clickingRoom = targetRoom;
        switch (targetRoom.name)
        {
            case "CardTrainer":
                clickingRoom = CardTrainerRoom;
                    break;
            case "General":
                //clickingRoom = CardTrainerRoom;
                    break;
            case "Recruiter":
                clickingRoom = RecruiterRoom;
                    break;
        }
        return clickingRoom;
    }

    public void exitRoomRange(GameObject room,roomSO roomSO)
    {

    }

    void setValues(GameObject room,roomSO roomSO)
    {
        roomNameText.text = roomSO.roomName;
        roomDescriptionText.text = roomSO.roomDescription;
        roomSprite.sprite = roomSO.roomSprite;
    }
    void inMoveBoxs()
    {
        isRoomOpen = true;
        goIn();
    }
    void goIn()
    {
        roomSprite.transform.DOMoveX(firstPosSprite.x + 19.5f ,1f);
        textParents.transform.DOMoveY(firstPosTexts.y + 8.05f ,1f);
        close_button.DOMoveY(close_button.position.y + 32.5f,1);
    }
    public void outMoveBoxs()
    {
        if (isRoomOpen == true)
        {
            targetRoom.GetComponent<SpriteRenderer>().enabled = true;
            openRoom().SetActive(false);
            isRoomOpen = false;
        }
        goOut();
        close_button.DOMoveY(close_button.position.y - 32.5f,1);
        resetCamera();
    }

    void goOut()
    {
        roomSprite.transform.DOMoveX(firstPosSprite.x,1f);
        textParents.transform.DOMoveY(firstPosTexts.y,1f);
        
        
    }

    private void resetCamera()
    {
        targetRoom = null;
        camera.transform.DOMove(lastCameraPos,1);
        DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, lastCameraSize, 1);
    }
}
