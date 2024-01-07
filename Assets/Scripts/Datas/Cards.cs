using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cards : ICard
{
    public int id;
    public Cards_OS originCardInfo;

    public Cards_OS OriginInfo()
    {
        return originCardInfo;
    }
}
