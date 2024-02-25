using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class FireBall : Cards
{
    public GameObject fireBall;
    private Vector3 force;

    public FireBall() {
        originCardInfo = Resources.Load<Cards_OS>("Cards/OS/FireBall");
    }

    public override void Invoke()
    {
        var obj = GameObject.Instantiate(Resources.Load("Cards/FireBall"), spellInfos.startPosition, Quaternion.identity);
        var rigidbody = obj.GetComponent<Rigidbody>();
        force = spellInfos.endPosition - spellInfos.startPosition;
        force = force.normalized;
        force *= 100;
        rigidbody.AddForce(force);
    }
}
