using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private HashSet<Projectile> _pool; 
    private float _lastFire;
    private StatsController _statsController;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _projectileLaunch;

    private void Awake()
    {
        _statsController = FindAnyObjectByType<StatsController>();
    }

    private void Start()
    {
        SetupPool();
        _lastFire = _statsController.FireRate;
    }
    private void Update()
    {
        if(_lastFire <= _statsController.FireRate)
        {
            _lastFire += Time.deltaTime;
        }
    }
    private void SetupPool()
    {
        _pool = new HashSet<Projectile>();
        for(int index = 0;index < 10; index++)
        {
            var projectile = Instantiate(_projectilePrefab);
            projectile.gameObject.SetActive(false);
            _pool.Add(Instantiate(projectile));
        }
    }
    public void Fire()
    { 
        if(_lastFire >= _statsController.FireRate)
        { 
            var projectile = GetProjectile();
            projectile.SetupProjectile(transform.rotation, _statsController.Damage, 5, _statsController.ProjectileSpeed);
            projectile.gameObject.SetActive(true);
            _lastFire = 0;
        }
    }

    private Projectile GetProjectile()
    {
        var projectile = _pool.FirstOrDefault(x=>!x.isActiveAndEnabled);
        projectile.transform.position = _projectileLaunch.position;
        if(projectile == null)
        {
            projectile = Instantiate(_projectilePrefab);
            projectile.gameObject.SetActive(false);
            _pool.Add(Instantiate(_projectilePrefab));
            return GetProjectile();
        }
        return projectile;
    }
}
