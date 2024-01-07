using System.Collections;
using UnityEngine;

public class Fire : Things
{
    public override bool React(IThing otherThing)
    {
        return false;
    }
}
