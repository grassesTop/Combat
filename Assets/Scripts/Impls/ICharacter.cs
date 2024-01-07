using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    Characters_OS OriginInfo();
    bool IsDead();
    string GetCharacterName();
    string GetDescription();
    int GeLevel();
    RaceEnum GetRace();
    int GetMaxHealth();
    CampEnum GetCamp();
}
