using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSO : MonoBehaviour
{
    public CardValuesSO cardValuesSO;
    private Text cardname_Text => GetComponentInChildren<Text>();
    public Text carmanaCost_Text;
    void Awake()
    {
        cardname_Text.text = cardValuesSO.cardName;
        //carmanaCost_Text.text = cardValuesSO.cardMana.ToString();
    }

}
