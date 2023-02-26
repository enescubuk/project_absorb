using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Text text;
    public Slider effectBar;
    public Slider healthBar;
    public float maxValue;
    public EnemyScript parent;
    
    void Awake()
    {
        parent = gameObject.transform.parent.GetComponent<EnemyScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        maxValue = parent.hp;
        effectBar.maxValue = maxValue;
        healthBar.maxValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        healthBar.value = parent.hp - parent.currentEffectDamage;
        effectBar.value = parent.hp;
        text.text = "" + parent.hp;
    }
}
