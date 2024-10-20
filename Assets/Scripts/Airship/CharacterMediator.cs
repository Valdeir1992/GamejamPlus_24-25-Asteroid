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
    [SerializeField] private string _name;
    [SerializeField] private SpaceShipData _data;
    [SerializeField] private Animator _turbineAnimator;
    [SerializeField] private Animator _spaceShipAnimator;
    private InputController _inputController;
    private SpaceShipAudioController AudioController;

    public string Name { get => _name; set => _name = value; }
    public SpaceShipData Data { get => _data; set => _data = value; }

    private void Awake()
    {
        AudioController = GetComponent<SpaceShipAudioController>();
        _motorController = GetComponent<MotorController>();
        _motorController.SetupMediator(this);
        _weaponController = GetComponent<WeaponController>();
        _weaponController.SetupMediator(this);
        _healthController = GetComponent<HealthController>();
        _inputController = FindAnyObjectByType<InputController>();

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
        if (!Mathf.Approximately(direction.y, 0))
        {
            _turbineAnimator.SetBool("Fire",true);
            AudioController.AudioPropulsionShipOn();

        }
        else
        {
            AudioController.AudioPropulsionShipOff();
            _turbineAnimator.SetBool("Fire", false);
        }
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
