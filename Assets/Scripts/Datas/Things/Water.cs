using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Things
{
    public override bool React(IThing otherThing)
    {
        switch (otherThing.OriginInfo().energyType) {
            case EnergyTypes.Heat:
                otherThing.Consume(1);
                Vapor();
                return true;
            case EnergyTypes.Cold:
                otherThing.Consume(1);
                Freeze();
                return true;
        }
        return false;
    }

    //’Ù∑¢,±‰≥…ŒÌ
    private void Vapor() {
        Consume(1);
        var fog = Resources.Load("Things/Fog");
        Instantiate(fog);
    }
    private void Freeze()
    {
        Consume(1);
        var ice = Resources.Load("Things/Ice");
        Instantiate(ice);
    }
}
