using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorController : MonoBehaviour
{
    private float _velocity;
    private float _y;
    private StatsController _statsController;  

    private void Awake()
    {
        _statsController = FindAnyObjectByType<StatsController>();
    }
    private void Update()
    {
        transform.position += transform.right * _velocity * Time.deltaTime;
    }
    public void Move(Vector2 direction)
    {
        _y -= direction.x * _statsController.Maneuverability;
        _velocity = Mathf.MoveTowards(_velocity,direction.y * _statsController.Speed, Time.deltaTime * _statsController.Acceleration);
        transform.rotation = Quaternion.Euler(0,0,_y);
    }
}
