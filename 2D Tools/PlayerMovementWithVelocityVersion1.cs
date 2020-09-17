using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementWithVelocityVersion1 : MonoBehaviour
{
    public bool stopInputs = false;
    
    private Rigidbody2D _rb;
    private Vector2 _playerInput;
    private Vector2 _lastInput;
    
    [Header("Speed")]
    [SerializeField] private float speed = 6.5f;
    [SerializeField] private float timeToTopSpeed = .1f;

    //Acceleration
    private bool _topSpeed = false;
    private float _acceleration;
    private float _timeGone = 0;
    private float _accelerationPercentage;
    private bool _slowdownAcceleration;
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Control input
        if (!stopInputs)
        {
            _playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;    //Input
            if (_playerInput != Vector2.zero) //Save last input
            {
                _lastInput = _playerInput;
            }
        }
        else
        {
            //What happens then the player don't have control.
                //Slow down to stop
            _playerInput = Vector2.zero;
            _topSpeed = false;
            _slowdownAcceleration = true;
        }
        
        //Control how fast the player move
        if (_playerInput != Vector2.zero && !_topSpeed)     //Run-up acceleration
        {
            _timeGone += Time.deltaTime;
                
            _slowdownAcceleration = false;
                
            if (_timeGone < timeToTopSpeed)
            {
                SpeedControl();
            }
            else
            {
                _topSpeed = true;
            }
        }
        else if (_playerInput == Vector2.zero && _timeGone > 0)     //Slowdown acceleration
        {
            _timeGone -= Time.deltaTime;
                
            _topSpeed = false;
            _slowdownAcceleration = true;

            if (_timeGone > 0)
            {
                SpeedControl();
            }
            else
            {
                _timeGone = 0;
                _acceleration = 0;
            }
        }
    }

    private void SpeedControl()
    {
        _accelerationPercentage = _timeGone / timeToTopSpeed;
        _acceleration = speed * Mathf.Pow(_accelerationPercentage, 2);
    }

    private void FixedUpdate()
    {
        if (_topSpeed)
        {
            _rb.velocity = _playerInput * speed;
        }
        else
        {
            if (!_slowdownAcceleration)
            {
                _rb.velocity = _playerInput * _acceleration;
            }
            else
            {
                _rb.velocity = _lastInput * _acceleration;
            }
        }
    }
}
