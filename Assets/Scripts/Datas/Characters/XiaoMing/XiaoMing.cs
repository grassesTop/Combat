using System.Collections;
using UnityEngine;

public class XiaoMing : Characters
{
    private void Start()
    {
        CombatManager.Instance.currentCharacter = this;
    }
}
