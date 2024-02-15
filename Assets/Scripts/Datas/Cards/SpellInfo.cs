using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellInfo
{
    SpellTypes spellTypes;

    public Vector3 startPosition;
    public Vector3 endPosition;

    public void CreateDirectionSpellType(Vector3 startPosition, Vector3 endPosition) { 
        this.startPosition = startPosition;
        this.endPosition = endPosition;
    }
}
