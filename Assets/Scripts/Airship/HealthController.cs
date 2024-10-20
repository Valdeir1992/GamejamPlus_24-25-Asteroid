using System;
using System.Collections; 
using UnityEngine;
using Zenject;

public class HealthController : MonoBehaviour, IDamageable
{
    private int _currentLife;
    private bool _isInvulnerable;
    private bool _isDead;
    private GameplayController _gameplayController;
    [SerializeField] private int _lifeMax;
    [SerializeField] private float _timeInvulnerable;
    public bool IsInvulnerable { get => _isInvulnerable; }

    private void Awake()
    {
        _currentLife = _lifeMax;
        _gameplayController = FindAnyObjectByType<GameplayController>();
    }

    public void Die()
    {
        if (_isDead)
            return;
        _isDead = true;
        _gameplayController.GameOver();
        Destroy(gameObject);
    }
    public void Recovery(int recovery)
    {
        _currentLife += recovery;
    }
    public void TakeDamage(Damage damage)
    {
        _currentLife -= damage.Amount;
        if(_currentLife <= 0)
        {
            Die();
        }
        StartInvulnerability();
    }
    private IEnumerator Coroutine_Invulberability()
    {
        _isInvulnerable = true;
        yield return new WaitForSeconds(_timeInvulnerable);
        _isInvulnerable = false;
    }
    private void StartInvulnerability()
    {
        StartCoroutine(Coroutine_Invulberability());
    }
}
public interface IDamageable
{
    public void TakeDamage(Damage damage);
}
