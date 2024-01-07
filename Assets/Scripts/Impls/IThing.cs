using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IThing
{
    Thing_OS OriginInfo();

    int GetEnergyCount();

    bool React(IThing otherThing);

    bool Consume(int num);

}