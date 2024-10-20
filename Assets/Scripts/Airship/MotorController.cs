using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorController : MonoBehaviour
{
    private float _velocity;
    private float _y;
    private StatsController _statsController;
    private Rigidbody2D _rb;
    private CharacterMediator _mediator;

    private void Awake()
    {
        _statsController = FindAnyObjectByType<StatsController>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    { 
        _rb.AddForce(transform.right * _velocity);
    }
    public void Move(Vector2 direction)
    {
        _y -= direction.x * (_statsController.Maneuverability + _mediator.Data.StartManeuverability);
        _velocity = Mathf.MoveTowards(_velocity,direction.y * (_statsController.Speed + _mediator.Data.StartSpeed), Time.deltaTime * (_statsController.Acceleration + _mediator.Data.StartAcceleration));
        transform.rotation = Quaternion.Euler(0,0,_y);
    }

    internal void SetupMediator(CharacterMediator characterMediator)
    {
        _mediator = characterMediator;
    }
}
