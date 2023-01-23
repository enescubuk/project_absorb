using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        if (GetComponent<EnemyScript>().hp < 0)
        {   
            
            GameManager.current.playerAnim.SetBool("Run",false);
            GameManager.current.endGame = true;
            GameManager.current.pathObject.SetActive(true);
            GameManager.current.gameUI.SetActive(false);
            GameManager.current.enabled = false;
            GameEvents.current.gameObject.SetActive(false);
            
            Debug.Log(22);
        }
    }
}
