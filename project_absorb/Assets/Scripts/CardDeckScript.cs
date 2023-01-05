using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardDeckScript : MonoBehaviour
{
    public static CardDeckScript current;

    public static List<int> CardDeck = new List<int>();
    public List<GameObject> cardsPrefabs;

    private void Awake()
    {
        //For Singelton
        if (current != null && current != this)
        {
            Destroy(this);
        }
        else
        {
            current = this;
        }
    }

    public void addCard(int cardID)
    {
        CardDeck.Add(cardID);
    }
    public void removeCard(int cardID)
    {
        CardDeck.Remove(cardID);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("asd");
            foreach (int card in CardDeck)
            {
                Debug.Log("dsa");
                Debug.Log(card);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("GameManager");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            CardDeck.Clear();
        }
    }
}
