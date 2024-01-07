using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObejcts/Characters")]
public class Characters_OS : ScriptableObject
{
    public string characterName;
    public string description;
    public int level;
    public RaceEnum race;
    public int maxHealth;
    public CampEnum camp;
}

public enum CampEnum
{
    Player, Enemy, Neutral
}

public enum RaceEnum
{
    Human, Spirit, Demon, Devil, Elf
}
