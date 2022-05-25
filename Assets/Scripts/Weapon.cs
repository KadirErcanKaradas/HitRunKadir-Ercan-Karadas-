using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject grenadePrefab;
    
    private GameObject _activePrefab;
    private Camera _camera;

    public static Action shotAction;

    private void Awake() {
        _camera = Camera.main;
    }

    private void Start() {
        _activePrefab = bulletPrefab;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            ProcessInput();
        }
    }

    private void ProcessInput() {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = _camera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out var hit, 50)) {
            
            
            var mouseWorldPosition = _camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, _camera.transform.position.y));
            mouseWorldPosition.y = .5f;
            
            var direction = mouseWorldPosition - spawnPoint.position;
            direction.Normalize();
            
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Shootable")) {
                Fire(direction);
                shotAction?.Invoke();
            }
        }
    }

    private void Fire(Vector3 direction) {
        var bulletGo = Instantiate(_activePrefab, spawnPoint.position, Quaternion.identity);

        bulletGo.GetComponent<Projectile>()?.Fire(direction);
        
    }

    public void SwitchToGrenade() {
        _activePrefab = grenadePrefab;
    }

    public void SwitchToBullet() {
        _activePrefab = bulletPrefab;
    }
}
