using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Things : MonoBehaviour, IThing
{
    public Thing_OS data;
    public int elementCount;
    private Collider mCollider;

    private void Awake()
    {
        mCollider = GetComponent<Collider>();
        gameObject.tag = "Thing";
    }

    public int GetEnergyCount()
    {
        return elementCount;
    }

    public Thing_OS OriginInfo()
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
        if (other.CompareTag("Thing")) {
            React(other.GetComponent<IThing>());
        }
    }
}
