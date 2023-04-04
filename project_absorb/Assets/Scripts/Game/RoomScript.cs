using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public int totalWave;
    public int cardWave;
    public int eventWave;
    public int eventPeriod;
    public static RoomScript current;
    public int cardPeriod;
    private void Awake()
    {
        //For Singelton
        if (current != null && current != this)
        {
            Destroy(this);
        }
        else
        {
            current = this;
        }

        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.current.wave == cardWave && GameManager.current.bossRoomNumber - 1 != GameManager.current.wave)
        {
            GameManager.current.newCardRoom = true;
            
        }
        else
        {
            GameManager.current.newCardRoom = false;
        }

        if (GameManager.current.wave == eventWave && GameManager.current.bossRoomNumber - 1 != GameManager.current.wave)
        {
            GameManager.current.storyEventTurn = true;
            
        }
        else
        {
            GameManager.current.storyEventTurn = false;
        }
    }


    public void NewWave(int a)
    {
        Debug.Log(99);
        if (GameManager.current.newCardRoom == true)
        {
            cardWave += cardPeriod;
        }
        if (GameManager.current.storyEventTurn == true)
        {
            eventWave+=eventPeriod;   
        }
        
        GameEvents.current.StartCoroutine("SpawnDelay");
    }
    
}
