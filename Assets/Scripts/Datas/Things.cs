using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Things : MonoBehaviour, IThing
{
    public Things_OS data;
    public Resistances_OS resistance;
    public int elementCount;
    private Collider mCollider;

    private void Awake()
    {
        mCollider = GetComponent<Collider>();
        gameObject.tag = Tags.Thing;
    }

    public int GetEnergyCount()
    {
        return elementCount;
    }

    public Things_OS OriginInfo()
    {
        return data;
    }

    public abstract bool React(IThing otherThing);

    public bool Consume(int num)
    {
        elementCount = Math.Max(0, elementCount - num);
        if (elementCount == 0) {
            Destroy(gameObject);
        }
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Thing)) {
            React(other.GetComponent<IThing>());
        }
    }

    public Resistances_OS GetResistances()
    {
        return resistance;
    }
}
