using System.Collections;
using UnityEngine;

public class Ice : Things
{
    public override bool React(IThing otherThing)
    {
        switch(otherThing.OriginInfo().energyType)
        {
            case EnergyTypes.Heat:
                if (otherThing.OriginInfo().energyLevel >= 3)
                {
                    otherThing.Consume(3);
                    Melt();
                } else
                {
                    otherThing.Consume(1);
                    Vapor();
                }
                return true;
        }
        return false;
    }

    private void Vapor() {
        Destroy(gameObject);
        var Fog = Resources.Load("Things/Fog");
        Instantiate(Fog);

    }

    private void Melt() {
        Destroy(gameObject);
        var water = Resources.Load("Things/Water");
        Instantiate(water);
    }

}