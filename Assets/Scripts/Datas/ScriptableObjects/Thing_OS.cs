using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Thing", menuName = "ScriptableObejcts/Things")]
public class Thing_OS : ScriptableObject
{
    public string thingName;
    public string description;

    //硬度,物体碰撞时,可能发生破坏
    public int hardness;
    //形态, 模拟物体的体积占用情况
    public ThingStates states;
    public int energyLevel;
    public EnergyTypes energyType;
    //能量, 全部反应完成才会消失
    public int energyCount;
}

public enum EnergyTypes
{
    Heat, Cold, Impact, Penetrate, ForceField, Damp, None
}

public enum ThingStates
{
    Solid, Liquid, Gas, Plasma
}