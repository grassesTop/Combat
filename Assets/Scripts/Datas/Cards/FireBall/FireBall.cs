using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class FireBall : Cards
{
    public GameObject fireBall;
    public Vector3 startPosition;
    public Vector3 endPosition;
    private Vector3 force;

    public FireBall() {
        originCardInfo = Resources.Load<Cards_OS>("OS/Cards/FireBall");
    }

    public override void Invoke(ICharacter character)
    {
        var lookAt = endPosition;
        lookAt.y = character.GetTransform().position.y;
        character.GetTransform().LookAt(lookAt);
        var obj = GameObject.Instantiate(Resources.Load("Cards/FireBall"), startPosition, Quaternion.identity);
        var rigidbody = obj.GetComponent<Rigidbody>();
        force = endPosition - startPosition;
        force = force.normalized;
        force *= 100f;
        rigidbody.useGravity = true;
        rigidbody.AddForce(force);
    }

    public override void SetSpellInfo(SpellInfo info)
    {
        startPosition = info.startPosition;
        endPosition = info.endPosition;
    }
}
