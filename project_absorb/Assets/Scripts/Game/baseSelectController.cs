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
    public GameObject roomDescriptionText;
    public GameObject textParents;
    public GameObject roomSprite;
    private GameObject targetRoom;
    public new Camera camera;
    private Vector3 lastCameraPos;
    private float lastCameraSize;
    Vector3 firstPosSprite,firstPosTexts;
    public Transform close_button;
    private bool isRoomOpen = false;
    [SerializeField] TrainerDialog td;
    [Header("Rooms")]
    public GameObject CardTrainerRoom;
    public GameObject RecruiterRoom;
    public GameObject GeneralRoom;
    public GameObject Hospital;
    void Awake()
    {
        lastCameraPos = camera.transform.position;
        lastCameraSize = camera.orthographicSize;
        firstPosTexts = textParents.transform.position;
    }
    public void enterRoomRange(GameObject room,roomSO roomSO)
    {
        setValues(room,roomSO);
    }

    public void newClickRoom(roomSO roomSO)
    {
        if (isRoomOpen == false)
        {
            camera.transform.DOMove(new Vector3(targetRoom.transform.position.x,targetRoom.transform.position.y-65,lastCameraPos.z),1);
            DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, lastCameraSize - 300, 1);
            td.FirstTrainerDialog();
            Invoke("inMoveBoxs",0.3f);
        }
        else
        {
            goOut();
            openRoom().SetActive(true);
        }
    }
    public void clickRoom(GameObject room,roomSO roomSO)
    {
        if (isRoomOpen == false)
        {
            targetRoom = room;
            Debug.Log(targetRoom.name);
            camera.transform.DOMove(new Vector3(targetRoom.transform.position.x,targetRoom.transform.position.y-65,lastCameraPos.z),1);
            DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, lastCameraSize - 300, 1);
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
                clickingRoom = GeneralRoom;
                    break;
            case "Recruiter":
                clickingRoom = RecruiterRoom;
                    break;
            case "Hospital":
                clickingRoom = Hospital;
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
        roomSprite = roomSO.roomSprite;
    }
    void inMoveBoxs()
    {
        isRoomOpen = true;
        
        goIn();
    }
    void goIn()
    {
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
        td.Close();
    }

    private void resetCamera()
    {
        targetRoom = null;
        camera.transform.DOMove(lastCameraPos,1);
        DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, lastCameraSize, 1);
    }
}
