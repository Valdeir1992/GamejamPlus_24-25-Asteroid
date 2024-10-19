using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    private int _currentLife;
    public Action<DamageInfo> OnTakeDamage;
    public Action OnDie;
    [SerializeField] private int _lifeMax;

    private void Awake()
    {
        _currentLife = _lifeMax;
    }
    public void TakeDamage(Damage damage)
    {
        var damageInfo = new DamageInfo() { Amount = damage.Amount, Source = damage.Source };
        _currentLife -= damage.Amount;
        OnTakeDamage?.Invoke(damageInfo);
        if(_currentLife <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
public struct DamageInfo
{
    public int Amount;
    public string Source;
}
