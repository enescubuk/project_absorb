using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Effect/EffectSO")]
public class EffectSO : ScriptableObject
{
    // Start is called before the first frame update
    public string effectType;
    public int effectNumber;
    public int effectDuration;
    public int effectDamage;

    public void Effect(GameObject target)
    {
        target.AddComponent<Effect>();
        target.GetComponent<Effect>().effectSO = this;
    }
}
