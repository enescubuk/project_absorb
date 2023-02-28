using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSO : MonoBehaviour
{
    public CardValuesSO cardValuesSO;
    public Text cardname_Text => gameObject.transform.Find("Name Text").GetComponent<Text>();
    public Text carmanaCost_Text => gameObject.transform.Find("Mana Text").GetComponent<Text>();
    void Awake()
    {
        cardname_Text.text = cardValuesSO.cardName.ToString();
        carmanaCost_Text.text = cardValuesSO.cardMana.ToString();
    }

}
