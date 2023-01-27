using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<GameObject> shopAisle; // all item to be sold

    public List<GameObject> currentAisle;
    void Start()
    {
        randomFourItem();
    }
    void randomFourItem()
    {
        for (int i = 0; i < 4; i++)
        {
            currentAisle.Add(shopAisle[Random.Range(0,shopAisle.Count)]);
            shopAisle.Remove(currentAisle[i]);
        }
        reloadList();
    }

    void reloadList()
    {
        for (int i = 0; i < currentAisle.Count; i++)
        {
            shopAisle.Add(currentAisle[i]);
        }
    }


    public void enterRange(GameObject item)
    {

    }
    public void clickRange(GameObject item)
    {
        currentAisle.Remove(item);
    }
    public void exitRange(GameObject item)
    {
        
    }

    void increaseMoney()
    {
        
    }
}