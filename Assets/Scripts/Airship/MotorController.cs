using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorController : MonoBehaviour
{
    private float _velocity;
    private float _y;
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _maneuverability;


    private void Update()
    {
        transform.position += transform.right * _velocity * Time.deltaTime;
    }
    public void Move(Vector2 direction)
    {
        _y -= direction.x * _maneuverability;
        _velocity = Mathf.MoveTowards(_velocity,direction.y * _speed, Time.deltaTime * _acceleration);
        transform.rotation = Quaternion.Euler(0,0,_y);
    }
}
