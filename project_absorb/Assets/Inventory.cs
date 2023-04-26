using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;

    public GameObject[] slots;

    public GameObject test;

    void Start()
    { 
        
        PickUp(test);    
        
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PickUp(test);
            
        }
    }
    public void PickUp(GameObject item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (isFull[i] == false)
            { // ITEM CAN BE ADDED TO INVENTORY
                isFull[i] = true;
                Vector3 slotTransform = new Vector3(slots[i].transform.position.x,slots[i].transform.position.y,slots[i].transform.position.z);
                item.GetComponent<ItemDragDrop>().firstPleace = slotTransform;
                item.transform.position = slotTransform;
                break;
            }
        }
    }
}
