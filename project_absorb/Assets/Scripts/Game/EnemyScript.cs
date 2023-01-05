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

    GameManager gameManager => GameManager.current;
    void Start()
    {
        gameManager.enemies.Add(gameObject);

        turnNumber = gameManager.enemies.IndexOf(gameObject);

        transform.GetChild(0).GetComponent<Slider>().maxValue = hp;


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
            Destroy(this.gameObject);
            
        }
        else
        {
            turnNumber = GameManager.current.enemies.IndexOf(gameObject);
        }

    }

    private void FixedUpdate()
    {
        transform.GetChild(0).GetComponent<Slider>().value = hp;
        transform.GetChild(1).GetComponent<Text>().text = "" + hp;
    }

    IEnumerator UseCard()
    {

        GetComponent<Animator>().SetTrigger("Attack");
        gameManager.playerAnim.SetTrigger("Hit");
        card.GetComponent<Card>().attackPlayer();
        yield return new WaitForSeconds(1);
        gameManager.nextTurn = true;
        gameManager.turnNumber++;

    }
}
