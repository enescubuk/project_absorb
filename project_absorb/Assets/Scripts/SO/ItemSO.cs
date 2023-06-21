using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSO : MonoBehaviour
{
    public CardValuesSO cardValuesSO;
    public Text cardname_Text => gameObject.transform.Find("Name Text").GetComponent<Text>();
    public Text cardmanaCost_Text => gameObject.transform.Find("Mana Text").GetComponent<Text>();
    public TMP_Text cardDescription => gameObject.transform.Find("Card Description").GetComponent<TMP_Text>();
    void Awake()
    {
        cardname_Text.text = cardValuesSO.cardName.ToString();
        cardmanaCost_Text.text = cardValuesSO.cardMana.ToString();
        cardDescription.text = cardValuesSO.cardDiscription;
        
    }

}
