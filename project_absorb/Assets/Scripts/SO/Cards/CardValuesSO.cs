using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName ="Card/Default Card Values")]
public class CardValuesSO : ScriptableObject
{
    public enum Target { toEnemy, toMe};
    public Target target;
    public string cardName;
    [TextArea]public string cardDiscription;
    public int cardMana;
    public int cardID;
    public int cardType;
    public Sprite cardSprite;
    public GameObject cardPrefab;
    public int cardCostOfSale;
    public Sprite cardEffectIcon;
}
