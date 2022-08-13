using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Card Stats")]
    [SerializeField] int enemyType;
    [SerializeField] int mana;
    [SerializeField] int hp;
    [SerializeField] int attack;

    GameManager gameManager => GameObject.Find("GameManager").GetComponent<GameManager>();
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void valueChanges(int attackPower, int hpGain)
    {

        hp -= attackPower;
        hp += hpGain;
    }
}
