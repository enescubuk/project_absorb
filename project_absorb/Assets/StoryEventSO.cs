using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Story/StoryEvent")]
public class StoryEventSO : ScriptableObject
{
    private List<StoryEventListener> listeners = new List<StoryEventListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
            Debug.Log(55);
        }
    }

    public void RegisterListener(StoryEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(StoryEventListener listener)
    {
        listeners.Remove(listener);
    }
}
