using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public int totalWave;
    public int waveCount;
    
    public static RoomScript current;
    public int wavePeriod;
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
        if (GameManager.current.wave == waveCount && GameManager.current.bossRoomNumber - 1 != GameManager.current.wave)
        {
            GameManager.current.newCardRoom = true;
            
        }
        else
        {
            GameManager.current.newCardRoom = false;
        }
    }


    public void NewWave(int a)
    {
        Debug.Log(99);
        waveCount += wavePeriod;
        GameEvents.current.StartCoroutine("SpawnDelay");

    }
    
}
