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
    }

    public override void Invoke()
    {
        var obj = GameObject.Instantiate(Resources.Load("Cards/FireBall"), startPosition, Quaternion.identity);
        var rigidbody = obj.GetComponent<Rigidbody>();
        force = endPosition - startPosition;
        force = force.normalized;
        force *= 100;
        rigidbody.AddForce(force);
    }
}
