using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public List<GameObject> shopAisle; 

    public List<GameObject> currentAisle;
    GameObject instantiated;
    public GameObject[] texts;
    public CharacterDataSO characterData;
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
        createCard();
    }


    void checkAisleForSale()
    {
        //ürünlere paramız yetiyor mu diye checkleyip non-interactive yapıyor
        for (int i = 0; i < texts.Length; i++)
        {
            if (characterData.Money < int.Parse(texts[i].GetComponent<TMP_Text>().text))
            {
                texts[i].gameObject.GetComponentInParent<Button>().interactable = false;
            }
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

    public void saleCard()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        int buttonTextArrayNumber = 0;
        switch (buttonName)
        {
            case "Button":
                buttonTextArrayNumber = 0;
                    break ;
            case "Button (1)":
                buttonTextArrayNumber = 1;
                    break ;
            case "Button (2)":
                buttonTextArrayNumber = 2;
                    break ;
            case "Button (3)":
                buttonTextArrayNumber = 3;
                    break ;
        }
        characterData.Money -= currentAisle[buttonTextArrayNumber].GetComponent<ItemSO>().cardValuesSO.cardCostOfSale;
    }

    void createCard()
    {
        for (int i = 0; i < currentAisle.Count; i++)
        {
            instantiated = Instantiate(currentAisle[i].gameObject,transform.position,Quaternion.identity,transform.GetChild(0).GetChild(0));
            Destroy(instantiated.GetComponent<DragDrop>());
            if (instantiated.GetComponent<ItemSO>() != null)
            {
                texts[i].GetComponent<TMP_Text>().text = instantiated.GetComponent<ItemSO>().cardValuesSO.cardCostOfSale.ToString();
            }
            else
            {
                texts[i].GetComponent<TMP_Text>().text = instantiated.GetComponent<Card>().cardID.ToString();
            }
        }
        checkAisleForSale();
    }
}