using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{
    private bool clickedOnce = false;
    public GameObject Panel;
    public void PopUpPanel()
    {
            if (!clickedOnce ) 
            {
                Panel.SetActive(true);
                clickedOnce = true;
            }
            else
            {
                Panel.SetActive(false);
                clickedOnce = false;
            }
    }
}
