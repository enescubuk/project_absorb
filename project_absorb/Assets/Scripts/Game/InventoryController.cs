using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<GameObject> ownedItems;
    void buyingItem(GameObject item)
    {
        ownedItems.Add(item);
    }
}
