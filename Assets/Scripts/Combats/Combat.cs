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

    //����ս��״̬
    public void Update() {
        if (currentTurn.lastTime <= 0)
        {
            //��ǰ�غϽ���
            OnTurnEnd?.Invoke(currentTurn);
            isCombatCompleted = CheckIsComplete();
            if (!isCombatCompleted)
            {
                //��ʼ�µĻغ�
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

    //�����ŵĽ�ɫ��û���û������Ľ�ɫʱ,��û�е���ʱ,����ս��
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
