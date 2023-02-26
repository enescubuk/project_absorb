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

    public int currentDamage;

    public void Reset() {
        currentDamage = 0;
    }
    public void Effect(GameObject target)
    {
        Effect a = target.AddComponent<Effect>();
        a.effectSO = this;
        currentDamage += effectDamage;
    }
    

}
