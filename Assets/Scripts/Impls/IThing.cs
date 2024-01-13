using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IThing
{
    Things_OS OriginInfo();

    int GetEnergyCount();

    bool React(IThing otherThing);

    bool Consume(int num);

    Resistances_OS GetResistances();

    int GetCurrentHardness();

}