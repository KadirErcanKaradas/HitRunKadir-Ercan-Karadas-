using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootableObject : MonoBehaviour
{
	public Action<GameObject> Destroyed;
	private Renderer _renderer;

	private void Awake() {
		_renderer = GetComponent<Renderer>();
	}

	private void Start() {
		ChangeColor();
		Weapon.shotAction += ChangeColor;
	}

	private void ChangeColor() {
		float r = Random.value;
		float g = Random.value;
		float b = Random.value;

		Color randomColor = new Color(r, g, b);
		
		_renderer.material.color = randomColor;
	}

	private void OnDestroy() {
		Weapon.shotAction -= ChangeColor;
		Destroyed?.Invoke(gameObject);
	}
}
