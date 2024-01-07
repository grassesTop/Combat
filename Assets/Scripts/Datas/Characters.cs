using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characters : MonoBehaviour, ICharacter
{
    public int id;
    public Characters_OS data;
    public bool isDead;

    public Characters_OS OriginInfo()
    {
        return data;
    }
    public bool IsDead()
    {
        return isDead;
    }

    public string GetCharacterName()
    {
        return data.characterName;
    }

    public string GetDescription()
    {
        return data.description;

    }

    public int GeLevel()
    {
        return data.level;
    }

    public RaceEnum GetRace()
    {
        return data.race;
    }

    public int GetMaxHealth()
    {
        return data.maxHealth;
    }

    public CampEnum GetCamp()
    {
        return data.camp;
    }
}
