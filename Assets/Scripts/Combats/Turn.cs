using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn
{
    public int id;
    public Turn preTurn;
    public Turn nextTurn;
    //默认一个回合三秒
    public float lastTime = 3 * 1000;
    public Combat combat;

    public void GetData() { }

    public void SaveData() { }
}
