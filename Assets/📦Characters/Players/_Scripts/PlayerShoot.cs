using System;
using __Characters.Players._Scripts;
using Core;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float spawnOffset = 10f;
    [SerializeField] private float recoilStrength = 10f;
    
    private float recoilTime;
    private Vector2 recoilDirection;
    [SerializeField]private float recoilPower;
    
    private Rigidbody2D _rb;
    private float _nextFireTime;
    
    [SerializeField] AnimationCurve recoilCurve;
    [SerializeField] private float recoilDuration = 1f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        recoilTime += Time.fixedDeltaTime;

        float t = recoilTime / recoilDuration;
        float strength = recoilCurve.Evaluate(t);

        _rb.linearVelocity += recoilDirection * recoilPower * strength;

        if (t >= 1f)
        {
            recoilPower = 0;
        }
        
        var shootInput = PlayerInput.ShootInput;
        
        if (shootInput == Vector2.zero) return;
        if (Time.time < _nextFireTime) return;
        
        _nextFireTime = Time.time + fireRate;
        
        var dir = shootInput.normalized;
        
        Vector2 spawnPos = _rb.transform.position + (Vector3)(dir * spawnOffset);
        
        recoilTime = 0;
        recoilDirection = -shootInput.normalized;
        recoilPower = recoilStrength;
        
        var bul = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        bul.GetComponent<Rigidbody2D>().linearVelocity = dir * 6;
    }
}