using System.Collections;
using UnityEngine;

public class Fog : Things
{
    public override bool React(IThing otherThing)
    {
        switch(otherThing.OriginInfo().energyType)
        {
            case EnergyTypes.Heat:
                otherThing.Consume(1);
                Consume(1);
                return true;
        }
        return false;
    }


}
