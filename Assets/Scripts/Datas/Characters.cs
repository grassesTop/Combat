using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public abstract class Characters : MonoBehaviour, ICharacter
{
    public int id;
    private Characters_OS data;
    private Resistances_OS resistances;
    private List<IEffect> effectList;
    private string elementList;
    private bool isDead;
    private int currentHealth;
    private Collider mCollider;
    private bool isOperating;
    private Rigidbody mRigidbody;
    private ICard card;
    private void Awake()
    {
        mCollider = GetComponent<Collider>();
        mRigidbody = GetComponent<Rigidbody>();
        isOperating = true;
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Thing)) {
            IThing thing = other.GetComponent<IThing>();
            var count = thing.GetEnergyCount();
            var level = thing.OriginInfo().energyLevel;
            var damage = 0;
            var recover = 0;
            switch (thing.OriginInfo().energyType)
            {
                case EnergyTypes.Heat:
                    damage = ComputeFireDamage(count, level);
                    break;
                case EnergyTypes.Cold:
                    damage = ComputeColdDamage(count, level);
                    break;
                case EnergyTypes.Spirit:
                    damage = ComputeSpiritDamage(count, level);
                    break;
                case EnergyTypes.Poison:
                    damage = ComputePoisonDamage(count, level);
                    break;
                case EnergyTypes.Slash:
                    damage = ComputeSlashDamage(count, level);
                    break;
                case EnergyTypes.Crush:
                    damage = ComputeCrushDamage(count, level);
                    break;
                case EnergyTypes.Penetrate:
                    damage = ComputePenetrateDamage(count, level);
                    break;
                case EnergyTypes.Electric:
                    damage = ComputeElectricDamage(count, level);
                    break;
                case EnergyTypes.Recover:
                    recover = ComputeRecoverHealth(count, level);
                    break;
            }
            if (damage >= 0)
            {
                TakeDamage(damage);
            }
            if (recover >= 0)
            {
                RecoverHealth(recover);
            }
        }
    }


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

    public Resistances_OS GetResistances()
    {
        return resistances;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead()) return;
        if (damage <= 0) return;
        currentHealth = Math.Max(0, currentHealth - damage);
        CheckIsDead();
    }

    public List<IEffect> GetEffects()
    {
        return effectList;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void CheckIsDead() {
        if(currentHealth <= 0)
        {
            isDead = true;
        }
    }

    private int GetValidResistance(EnergyTypes energyTypes) {
        switch (energyTypes)
        {
            case EnergyTypes.Heat:
                return GetResistances().heat;
            case EnergyTypes.Cold:
                return GetResistances().cold;
            case EnergyTypes.Electric:
                return GetResistances().electric;
            case EnergyTypes.Spirit:
                return GetResistances().spirit;
            case EnergyTypes.Poison:
                return GetResistances().poison;
            case EnergyTypes.Crush:
                return GetResistances().crush;
            case EnergyTypes.Slash:
                return GetResistances().slash;
            case EnergyTypes.Penetrate:
                return GetResistances().penetrate;
        }
        return 0;
    }

    protected virtual int ComputeFireDamage(int eneryCount, int eneryLevel)
    {
        return 0;
    }

    protected virtual int ComputeColdDamage(int eneryCount, int eneryLevel)
    {
        return 0;
    }
    protected virtual int ComputeCrushDamage(int eneryCount, int eneryLevel)
    {
        return 0;
    }
    protected virtual int ComputePenetrateDamage(int eneryCount, int eneryLevel)
    {
        return 0;
    }
    protected virtual int ComputePoisonDamage(int eneryCount, int eneryLevel)
    {
        return 0;
    }
    protected virtual int ComputeSpiritDamage(int eneryCount, int eneryLevel)
    {
        return 0;
    }
    protected virtual int ComputeElectricDamage(int eneryCount, int eneryLevel)
    {
        return 0;
    }
    protected virtual int ComputeSlashDamage(int eneryCount, int eneryLevel)
    {
        return 0;
    }
    protected virtual int ComputeRecoverHealth(int eneryCount, int eneryLevel)
    {
        return 0;
    }

    public void RecoverHealth(int point)
    {
        if (point <= 0) return;
        currentHealth = Math.Min(data.maxHealth, currentHealth + point);
    }

    public string GetElementList()
    {
        return elementList;
    }

    protected virtual void Update()
    {
        if (card != null)
        {
            SpellSkillToPoint();
        }
    }

    private void SpellSkillToPoint()
    {
        card.Invoke();
        card = null;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void SaveSpellCard(ICard card)
    {
        this.card = card;
    }
}