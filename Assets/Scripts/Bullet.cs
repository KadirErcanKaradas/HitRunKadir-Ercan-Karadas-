using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    protected override void Effect(Collision collision) {
        base.Effect(collision);
        var cubeRB = collision.collider.transform.GetComponent<Rigidbody>();
        cubeRB.AddForce(_direction * collisionForce);
        Destroy(gameObject);
    }
}
