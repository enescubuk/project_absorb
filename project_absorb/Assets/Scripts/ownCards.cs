using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ownCards : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;
    GameManager gameManager => GameManager.current;
    public void openPanel()
    {
        panel.SetActive(true);
        for (int i = panel2.transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(panel2.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < gameManager.cards.Count; i++)
        {
            GameObject instantiated = Instantiate(gameManager.cards[i].gameObject,panel2.transform);
            Destroy(instantiated.GetComponent<DragDrop>());
        }
    }
    public void closePanel()
    {
        panel.SetActive(false);
    }
}
