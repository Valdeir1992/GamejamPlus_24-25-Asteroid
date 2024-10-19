using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterMediator : MonoBehaviour
{
    private MotorController _motorController;
    private WeaponController _weaponController;
    private HealthController _healthController;
    private bool _fire;
    [Inject] private InputController _inputController;
    private void Awake()
    {
        _motorController = GetComponent<MotorController>();
        _weaponController = GetComponent<WeaponController>();
        _healthController = GetComponent<HealthController>();
    }
    private void OnEnable()
    {
        _inputController.OnMove += Move; 
        _inputController.OnFirePress += Fire;
        _inputController.OnFireRelease += FireRelease;
    }
    private void Update()
    {
        if (_fire)
        {
            _weaponController.Fire();
        }
    }
    private void OnDisable()
    {
        _inputController.OnMove -= Move;   
        _inputController.OnFirePress -= Fire;
        _inputController.OnFireRelease -= FireRelease;
    }
    private void Move(Vector2 direction)
    {
        _motorController.Move(direction);
    }
    private void Fire()
    {
        _fire = true;
    }
    public void TakeDamage(Damage damage)
    {
        if (!_healthController.IsInvulnerable)
        {
            _healthController.TakeDamage(damage);
        }
    }
    private void FireRelease()
    {
        _fire = false;
    }
}
public struct Damage
{
    public int Amount;
    public string Source;
}
