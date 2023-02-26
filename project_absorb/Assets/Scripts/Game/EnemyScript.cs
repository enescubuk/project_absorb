using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy Cards")]
    public GameObject card;

    [Header("Enemy Stats")]
    public int hp;

    public int cardType;

    public int id;

    public int turnNumber;

    public int currentEffectDamage;

    GameManager gameManager => GameManager.current;
    void Start()
    {
        gameManager.enemies.Add(gameObject);

        turnNumber = gameManager.enemies.IndexOf(gameObject);

        GameEvents.current.Dead += HpController;

        GameEvents.current.Turn += ThisEnemyTurn;

        
    }

    public void ThisEnemyTurn(int id)
    {
        if (id == this.turnNumber)
        {
            StartCoroutine(UseCard());
        }
    }
    public void HpController(int id)
    {
        if (id == this.id)
        {
            GameEvents.current.Dead -= HpController;

            GameEvents.current.Turn -= ThisEnemyTurn;

            gameManager.killCount++;
            gameManager.enemies.Remove(this.gameObject);
            Destroy(this.gameObject,0.4f);
            
        }
        else
        {
            turnNumber = GameManager.current.enemies.IndexOf(gameObject);
        }

    }

    private void FixedUpdate()
    {
        if (GetComponent<Effect>() == true)
        {
            currentEffectDamage = GetComponent<Effect>().effectSO.currentDamage;
        }
        else
        {
            currentEffectDamage = 0;
        }
    }


    IEnumerator UseCard()
    {
        if (GetComponent<Effect>() == true)
        {
            hp-= GetComponent<Effect>().effectSO.currentDamage;
            GetComponent<Effect>().effectSO.currentDamage--;
            GameEvents.current.DeadEnter(id, hp);
            for (int i = 0; i < GetComponents<Effect>().Length; i++)
            {

                GetComponents<Effect>()[i].EffectEnemy();
            }
            

            Debug.Log(55);
        }
        GetComponent<Animator>().SetTrigger("Attack");
        gameManager.playerAnim.SetTrigger("Hit");
        card.GetComponent<Card>().attackPlayer();
        yield return new WaitForSeconds(1);
        gameManager.nextTurn = true;
        gameManager.turnNumber++;

    }
}
