using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private HashSet<Projectile> _pool; 
    private float _lastFire;
    private StatsController _statsController;
    private CharacterMediator _mediator;
    [SerializeField] private Transform[] _projectilePosition;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _projectileLaunch;

    private void Awake()
    {
        _statsController = FindAnyObjectByType<StatsController>();
    }

    private void Start()
    {
        SetupPool();
        _lastFire = _statsController.FireRate + _mediator.Data.StartFireRate;
    }
    private void Update()
    {
        if(_lastFire <= _statsController.FireRate + _mediator.Data.StartFireRate)
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

    internal void SetupMediator(CharacterMediator characterMediator)
    {
        _mediator = characterMediator;
    }

    public void Fire()
    { 
        if(_lastFire >= _statsController.FireRate + _mediator.Data.StartFireRate)
        { 
            Projectile projectile = null; 
            _lastFire = 0;
            for (int index = 0; index < Mathf.Clamp(_statsController.NumberProjects + _mediator.Data.StartNumberProjectiles, 1, _projectilePosition.Length); index++)
            {
                projectile = GetProjectile();
                projectile.transform.position = _projectilePosition[index].position;
                projectile.gameObject.SetActive(true);
                projectile.SetupProjectile(_projectilePosition[index].rotation, _statsController.Damage +_mediator.Data.StartDamage, 5, _statsController.ProjectileSpeed + _mediator.Data.StartProjectileSpeed);
            }
        }
    }

    private Projectile GetProjectile()
    {
        var projectile = _pool.FirstOrDefault(x=>!x.isActiveAndEnabled); 
        if(projectile == null)
        {
            projectile = Instantiate(_projectilePrefab);
            projectile.gameObject.SetActive(false);
            _pool.Add(projectile);
            return GetProjectile();
        } 
        return projectile;
    }
}
