using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Room")]
public class roomSO : ScriptableObject
{
    public string roomName;
    public string roomDescription;
    public Sprite roomSprite;
    public GameObject roomPrefab;
}
