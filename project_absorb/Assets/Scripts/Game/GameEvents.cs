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
    public void DeadEnter(int id, int hp)
    {
        if (hp <= 0)
        {
            
            Dead(id);
            //Spawn Enemy
            
            StartCoroutine(SpawnDelay());
            

        }

    }

    public event Action<int> Turn;

    public void TurnEnter(int id,int currentTurn)
    {
        //Debug.Log(currentTurn);

        if (currentTurn == id)
        {
            Turn(id);
        }
    }

    public event Action<int> EnemySpawn;
    public void ClearEnter(int enemyCount)
    {
        if (GameManager.current.newCardRoom == false && enemyCount <= 0 && GameManager.current.isBossFight == false)
        {
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
