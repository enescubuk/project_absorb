using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn current;
    public List<int> powers;
    public List<GameObject> enemyType;
    public List<GameObject> currentEnemies;
    public List<Transform> spawnPoints;
    public int roomPower = 5;
    int currentPower = 0;
    public int roomNumber;
    private void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(this);
        }
        else
        {
            current = this;
        }
    }
    void Start()
    {
        GameEvents.current.EnemySpawn += EnemySpawner;
        for (int i = 0; i < enemyType.Capacity; i++)
        {
            powers.Add(enemyType[i].GetComponent<EnemyScript>().cardType);
        }
        StartCoroutine(SpawnDelay());
    }

    public IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(GameManager.current.spawnDelay);
        GameEvents.current.ClearEnter(GameManager.current.enemies.Count);
    }

    public void EnemySpawner(int currentEnemy)
    {
        currentPower = 0;
        currentEnemies.Clear();
        while (roomPower > currentPower)
        {
            int randomNum = UnityEngine.Random.Range(0, powers.Count);
            int selected = powers[randomNum];
            GameObject selectedEnemy = enemyType[randomNum];
            currentPower += selected;
            if (currentPower > roomPower)
            {
                currentPower -= selected;
            }
            else
            {
                if (currentEnemies.Count < roomNumber)
                {
                    GameObject a = Instantiate(selectedEnemy, GameObject.Find("Enemy").transform);
                    a.transform.localPosition = new Vector3(spawnPoints[currentEnemies.Count].localPosition.x, spawnPoints[currentEnemies.Count].localPosition.y, 10);
                    a.GetComponent<EnemyScript>().id = currentEnemies.Count;
                    currentEnemies.Add(a);
                }
            }
        }
    }
}
