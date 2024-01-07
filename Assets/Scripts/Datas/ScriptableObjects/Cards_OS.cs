using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObejcts/Cards")]
public class Cards_OS : ScriptableObject
{
    public string cardName;
    public string description;
    public Texture2D texture;
    public ElementEnum elementEnum;
    //施法时间
    public float spellTime;
    //技能类型,
    public SpellTypes spellType;
    public int Level;
    public string cost;
    public CardTags tags;
}

public enum SpellTypes
{
    Directional, Range, RollCall, Ballistic
}

public enum CardTags
{
    
}
