using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyalgorithm : MonoBehaviour
{
    
    public  List<int> attackValues = new List<int>();
    public int maxValue,randomNumber,enemyMembers,total;
    
    void Start()
    {

    }

    void asd()
    {
        RandomNumber();
        if (total == maxValue)
        {
            Debug.Log("bitti");
            for (int i = 0; i < attackValues.Count ; i++)
            {
                Debug.Log(attackValues[i]);
            }
            
        }
        else
        {
            if (total > maxValue)
            {
                total -= randomNumber;
                enemyMembers--;
            }
        }
    }


    void RandomNumber()
    {
        randomNumber = Random.Range(1,maxValue);
        enemyMembers++;
        attackValues.Add(randomNumber);
        total += randomNumber;
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    asd();
        //}

        if (total != maxValue)
        {
            asd();
        }
    }
}
