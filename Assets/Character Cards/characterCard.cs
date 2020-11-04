using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "cards/Character")]
public class characterCard : ScriptableObject {
    public new string name;
    public string description;

    public Sprite artwork;

    public int range;
    public int health;
    public int damage;
    public int miss;
    public int attack;


}
