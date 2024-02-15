using System.Collections;
using UnityEngine;

public class XiaoMing : Characters
{

    /*    protected override void Update()
        {
            base.Update();
        }*/


    private void Start()
    {
        Debug.Log("set playing characeter");
        CombatManager.Instance.playingCharacter = this;
    }

}
