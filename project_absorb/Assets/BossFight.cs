using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    

    public Transform spawnPoint;

    public List<GameObject> bossList;

    public List<GameObject> currentBoss;

    GameObject currentBosss;
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
            
            StartCoroutine(BossFightDelay());
            

        }

        if (GameManager.current.isBossFight == true && currentBosss == null)
        {
            Debug.Log(32);
            //GameManager.current.wave++;
            GameManager.current.isBossFight = false;
            GameManager.current.enemies.Clear();
            Destroy(this.gameObject);
        }
        
    }
    // Update is called once per frame
    void BossFightCondition()
    {
        GameManager.current.CardByTurn();
        GameObject a = Instantiate(bossList[0], GameObject.Find("Enemy").transform);
        a.transform.localPosition = new Vector3(spawnPoint.localPosition.x, spawnPoint.localPosition.y, 10);
        GameManager.current.enemies.Add(a);
        GameManager.current.isBossFight = true;
        GameManager.current.NextButton.SetActive(true);
    }

    IEnumerator BossFightDelay()
    {

        yield return new WaitForSeconds(GameManager.current.spawnDelay);
        BossFightCondition();
    }
}
