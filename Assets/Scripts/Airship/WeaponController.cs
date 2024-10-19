using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private HashSet<Projectile> _pool;
    private float _fireRate = 1;
    private float _lastFire;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _projectileLaunch;

    private void Start()
    {
        SetupPool();
        _lastFire = _fireRate;
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
        _lastFire += Time.deltaTime; 
        if(_lastFire >= _fireRate)
        {
            Debug.Log("Fire");
            var projectile = GetProjectile();
            projectile.SetupProjectile(transform.rotation, 1, 1, 6);
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
