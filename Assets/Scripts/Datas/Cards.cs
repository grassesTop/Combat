using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cards : ICard
{
    public int id;
    public Cards_OS originCardInfo;
    public SpellInfos spellInfos;

    public abstract void Invoke();

    public Cards_OS OriginInfo()
    {
        return originCardInfo;
    }

    public void SetSpellInfo(SpellInfos info)
    {
        spellInfos = info;
    }
}
