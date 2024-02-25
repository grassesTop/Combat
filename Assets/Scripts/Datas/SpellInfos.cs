using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellInfos {
    public SpellTypes SpellType;
    public Vector3 startPosition;
    public Vector3 endPosition;

    public static SpellInfos CreatesDirectionSpellInfo(Vector3 startPosition, Vector3 endPosition)
    {
        var info = new SpellInfos();
        info.SpellType = SpellTypes.Directional;
        info.startPosition = startPosition;
        info.endPosition = endPosition;
        return info;
    }
}
