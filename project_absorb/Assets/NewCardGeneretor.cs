using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewCardGeneretor : MonoBehaviour
{
    public GameObject newCardPanel;
    public List<GameObject> cardList;
    public Transform[] spawnPoints;
    
    public static NewCardGeneretor current;
    int a;
    private void Awake()
    {
        //For Singelton
        if (current != null && current != this)
        {
            Destroy(this);
        }
        else
        {
            current = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.current.newCardRoom && a < 2)
        {
            newCardPanel.SetActive(true);

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Instantiate(cardList[Random.Range(0,cardList.Count)],spawnPoints[i].position,Quaternion.identity,spawnPoints[i]);
                a++;
            }
            
        }
        
    }
}
