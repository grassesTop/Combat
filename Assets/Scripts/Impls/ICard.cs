using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard 
{
    Cards_OS OriginInfo();
    void Invoke(ICharacter character);

    public void SetSpellInfo(SpellInfo info);


}
