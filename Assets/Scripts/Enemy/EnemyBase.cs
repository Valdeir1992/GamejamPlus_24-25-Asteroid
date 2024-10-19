using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    private int _currentLife;
    public Action OnTakeDamage;
    public Action OnDie;
    [SerializeField] private int _lifeMax;

    private void Awake()
    {
        _currentLife = _lifeMax;
    }
    public void TakeDamage(Damage damage)
    {
        _currentLife -= damage.Amount;
        OnTakeDamage?.Invoke();
        if(_currentLife <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        throw new NotImplementedException();
    }
}
public struct DamageInfo
{
    public int Amount;
    public string Source;
}
