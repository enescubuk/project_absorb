using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewCardGeneretor : MonoBehaviour
{
    public GameObject newCardPanel;
    public List<GameObject> cardList;
    public Transform[] spawnPoints;
    
    public GameObject parent;
    public static NewCardGeneretor current;
    public int a;
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
    void FixedUpdate()
    {
        if (GameManager.current.newCardRoom && a < 2 && GameManager.current.enemies.Count == 0 && GameManager.current.isBossFight == false)
        {
            
            newCardPanel.SetActive(true);

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                GameObject b;
                b = Instantiate(cardList[Random.Range(0,cardList.Count)],spawnPoints[i].position,Quaternion.identity,spawnPoints[i]);
                Destroy(b.GetComponent<DragDrop>());
                a++;
            }
            
        }


        
    }
}
