using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeckSelector : MonoBehaviour
{
    public List<GameObject> selectedCards;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
