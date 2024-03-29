using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake()
    {
        current = this;
    }
    public event Action<int> Dead;
    public void DeadEnter(int id, int hp, GameObject enemy)
    {
        if (hp <= 0)
        {
            Dead(id);
            GameManager.current.characterDataSO.Xp += 10;
            GameManager.current.characterDataSO.Money += enemy.GetComponent<EnemyScript>().maxHp;
            StartCoroutine(SpawnDelay());
        }
    }
    public event Action<int> Turn;
    public void TurnEnter(int id,int currentTurn)
    {
        if (currentTurn == id)
        {
            Turn(id);
        }
    }
    public event Action<int> EnemySpawn;
    public void ClearEnter(int enemyCount)
    {
        if (GameManager.current.newCardRoom == false && enemyCount <= 0 && GameManager.current.storyEventTurn == false && GameManager.current.isBossFight == false)
        {
                Debug.Log(77);
                GameManager.current.CardByTurn();
                EnemySpawn(enemyCount);
                GameManager.current.wave++;
                GameManager.current.NextButton.SetActive(true);
            
        }
    }
    IEnumerator SpawnDelay()
    {
       // GameManager.current.NextButton.SetActive(false);
        yield return new WaitForSeconds(GameManager.current.spawnDelay);
        ClearEnter(GameManager.current.enemies.Count);

    }
}
