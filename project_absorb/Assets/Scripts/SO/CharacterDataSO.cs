using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Data")]
public class CharacterDataSO : ScriptableObject
{
    [SerializeField] private int level = 1;
    [SerializeField] private int money = 0;
    [SerializeField] private int health = 100;


    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int xp = 100;





    public int Level { get { return level; } set { level = value; } }
    public int Money { get { return money; }  set { money = value; } }
    public int Health { get { return health; } set { health = value; } }
    public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public int Xp { get { return xp; } set { xp = value; } }

}
