using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public Transform spawnPoint;
    public List<GameObject> bossList;
    public List<GameObject> currentBoss;
    GameObject currentBosss;
    public bool isBossSpawned;
    GameObject theBoss;
    void Start()
    {
        if (GameManager.current.wave == GameManager.current.bossRoomNumber)
        {
            GameManager.current.isBossFight = true;
        }
    }

    void FixedUpdate()
    {
        if (GameManager.current.wave == GameManager.current.bossRoomNumber - 1 && GameManager.current.isBossFight == false && GameManager.current.enemies.Count == 0)
        {
            BossFightCondition();
        }
        if (GameManager.current.isBossFight == true && currentBosss == null)
        {
            GameManager.current.enemies.Clear();
        }
        if (isBossSpawned == true)
        {
            Invoke("delay",3);
        }

        
    }
    void BossFightCondition()
    {
        GameManager.current.CardByTurn();
        GameObject a = Instantiate(bossList[0], GameObject.Find("Enemy").transform);
        a.transform.localScale = new Vector3(0,0,0);
        a.transform.localPosition = new Vector3(spawnPoint.localPosition.x, spawnPoint.localPosition.y, 10);
        a.AddComponent<Boss>();
        GameManager.current.enemies.Add(a);
        GameManager.current.isBossFight = true;
        GameManager.current.NextButton.SetActive(true);
        isBossSpawned = true;
        theBoss = a;
    }
    void delay()
    {
        
        theBoss.transform.localScale = new Vector3(-2,2,-2);
        isBossSpawned = false;
        Destroy(this.gameObject);
    }
}
