using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName ="Room")]
public class roomSO : ScriptableObject
{
    public string roomName;
    public string roomDescription;
    public GameObject roomPrefab;
}
