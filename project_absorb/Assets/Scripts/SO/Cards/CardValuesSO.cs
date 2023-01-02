using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName ="Card/Default Card Values")]
public class CardValuesSO : ScriptableObject
{
    public string cardName;
    public int cardMana;
    public Sprite cardSprite;
    public GameObject cardPrefab;
}
