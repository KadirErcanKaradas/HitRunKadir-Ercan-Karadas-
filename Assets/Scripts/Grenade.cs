using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Projectile
{
	[SerializeField] private float explosionRadius;

	protected override void Effect(Collision collision) {
		var cubesInRange = Physics.OverlapSphere(transform.position, explosionRadius, shootableLayerMask);

		foreach (var col in cubesInRange) {
			Rigidbody cubeRb = col.GetComponent<Rigidbody>();
			cubeRb.AddExplosionForce(collisionForce, transform.position, explosionRadius, collisionForce/2);
			Destroy(col.gameObject, 2);
		}
		
		Destroy(gameObject);
	}
}
