using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Combat 
{
    public int id;
    public bool isCombatCompleted;
    public List<Turn> turns;
    public Turn currentTurn;

    public List<ICharacter> characters;
    public Action<Turn> OnTurnStart;
    public Action<Turn> OnTurnEnd;

    public Action<Combat> OnCombatStart;
    public Action<Combat> OnCombatEnd;

    public void Start() {
        OnCombatStart?.Invoke(this);
        currentTurn = new Turn();
        OnTurnStart?.Invoke(currentTurn);
    }

    //更新战斗状态
    public void Update() {
        if (currentTurn.lastTime <= 0)
        {
            //当前回合结束
            OnTurnEnd?.Invoke(currentTurn);
            isCombatCompleted = CheckIsComplete();
            if (!isCombatCompleted)
            {
                //开始新的回合
                var nextTurn = new Turn();
                currentTurn.nextTurn = nextTurn;
                nextTurn.preTurn = currentTurn;
                turns.Add(nextTurn);
                OnTurnStart?.Invoke(nextTurn);
            } else
            {
                OnCombatEnd?.Invoke(this);
            }
        } else
        {
            currentTurn.lastTime -= Time.deltaTime;
        }
    }

    //当活着的角色里没有用户操作的角色时,或没有敌人时,结束战斗
    public virtual bool CheckIsComplete() {
        var PlayerCount = 0;
        var EnemyCount = 0;
        foreach (var character in characters)
        {
            if (character.IsDead()) continue;
            if (character.GetCamp() == CampEnum.Player) {
                PlayerCount++;
            }
            if (character.GetCamp() == CampEnum.Enemy)
            {
                EnemyCount++;
            }
        }
        return PlayerCount == 0 || EnemyCount == 0;
    }
}
