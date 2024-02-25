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
    Resistances_OS GetResistances();

    void TakeDamage(int damage);

    void RecoverHealth(int point);

    List<IEffect> GetEffects();

    int GetCurrentHealth();

    string GetElementList();

    Transform GetTransform();

    void SaveSpellCard(ICard card);

}
