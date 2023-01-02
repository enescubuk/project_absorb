using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public int totalWave;
    public int waveCount;
    
    public int wavePeriod;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.current.wave == waveCount)
        {
            GameManager.current.newCardRoom = true;
            
        }
        else
        {
            GameManager.current.newCardRoom = false;
        }
        //Başka bir event yoluyla çağıralacak
        if (Input.GetButtonDown("Jump"))
        {
            waveCount += wavePeriod;
            GameEvents.current.ClearEnter(0);
        }
    }
    
}
