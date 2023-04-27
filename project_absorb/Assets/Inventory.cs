using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;

    public GameObject[] slots;

    public GameObject panel;

    void Start()
    { 
        //PickUp(GameManager.current.items[0]); 
        for (int i = 0; i < GameManager.current.currentItems.Length; i++)
        {
            PickUp(GameManager.current.currentItems[i]);  
        }
        
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            
            
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
                GameObject summonedItem = Instantiate(item,slotTransform,Quaternion.identity,panel.transform);
                summonedItem.GetComponent<ItemDragDrop>().firstPleace = slotTransform;
                //summonedItem.transform.position = slotTransform;
                break;
            }
        }
    }
}
