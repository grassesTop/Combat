using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : Singleton<CombatManager>
{
    public Combat currentCombat;
    public Combat StartNewCombat()
    {
        currentCombat = new Combat();
        currentCombat.OnCombatEnd += OnCombatEnd;
        currentCombat.Start();
        return currentCombat;
    }

    private void Update()
    {
        if (currentCombat != null)
        {
            currentCombat.Update();
        }
    }

    public void OnCombatEnd(Combat combat) {
        if (currentCombat == combat)
        {
            currentCombat.OnCombatEnd -= OnCombatEnd;
            currentCombat = null;
        }
    }
}
