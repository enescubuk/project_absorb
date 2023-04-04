using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEventSpawner : MonoBehaviour
{
    [SerializeField] GameObject eventPanel;

    void FixedUpdate()
    {
        if (GameManager.current.storyEventTurn && GameManager.current.enemies.Count == 0 && GameManager.current.isBossFight == false)
        {
            eventPanel.GetComponent<StoryEvents>().GetEvent();
            eventPanel.SetActive(true);
            
            
        }
    }
}
