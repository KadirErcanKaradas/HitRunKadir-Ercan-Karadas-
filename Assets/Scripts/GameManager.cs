using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private int rowCount;
	[SerializeField] private int columnCount;
	[SerializeField] private float spaceBetweenCubes;
	[SerializeField] private GameObject coloredCube;
	[SerializeField] private UIController ui;

	private List<GameObject> cubes = new List<GameObject>();

	private void Start() {
		StartCoroutine(CreateCubes());
		
	}

	private IEnumerator CreateCubes() {
		float totalWidth = columnCount + ((columnCount - 1) * spaceBetweenCubes);
		
		Debug.Log((totalWidth / 2f));
		
		for (int z = 0; z < rowCount; z++) {
			for (int x = 0; x < columnCount; x++) {
				
				Vector3 position = new Vector3(
					x + (spaceBetweenCubes * x) - (totalWidth / 2f) + .5f, 
					.5f, 
					z + (spaceBetweenCubes * z)
					);
				if(x == 0 && z == 0) Debug.Log(position);
				var instantiatedCube = Instantiate(coloredCube, position, Quaternion.identity);
				instantiatedCube.GetComponent<ShootableObject>().Destroyed += CubeCheckCallback;
				cubes.Add(instantiatedCube);
				yield return new WaitForSeconds(1f/(rowCount * columnCount));
			}
		}
	}

	private void CubeCheckCallback(GameObject cubeGO) {
		cubeGO.GetComponent<ShootableObject>().Destroyed -= CubeCheckCallback;
		if (cubes.Contains(cubeGO)) {
			cubes.Remove(cubeGO);
		}

		if (cubes.Count == 0) {
			ui.restart.gameObject.SetActive(true);
		}
	}
}
