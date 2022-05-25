using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] protected float speed;
	[SerializeField] protected float collisionForce;
	[SerializeField] protected LayerMask shootableLayerMask;
	protected Vector3 _direction;
	protected Rigidbody _rigidbody;
	
	protected virtual void Awake() {
		_rigidbody = GetComponent<Rigidbody>();
		
		Destroy(gameObject, 5);
	}

	public virtual void Fire(Vector3 direction) {
		direction.y = 0;
		_direction = direction;
		_rigidbody.velocity = direction * speed;
	}

	protected virtual void Effect(Collision collision) {
		Destroy(collision.collider.gameObject, 2);
	}
	
	protected void OnCollisionEnter(Collision collision) {
		if (collision.collider.CompareTag("Shootable")) {
			Effect(collision);
		}
	}
}
