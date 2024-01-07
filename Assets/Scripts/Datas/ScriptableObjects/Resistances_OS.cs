using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Resistance", menuName = "ScriptableObejcts/Resistances")]
public class Resistances_OS : ScriptableObject
{
    //热
    public int heat;
    //冷
    public int cold;
    //电
    public int electric;
    //精神
    public int spirit;
    //毒
    public int poison;
    //钝击
    public int crush;
    //斩击
    public int slash;
    //穿透
    public int penetrate;
}
