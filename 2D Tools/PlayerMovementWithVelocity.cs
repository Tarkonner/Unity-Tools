using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementWithVelocity : MonoBehaviour
{
    public bool stopInputs = false;
    
    private Rigidbody2D _rb;
    private Vector2 _playerInput;

    [SerializeField] private float speed = 6.5f;
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (!stopInputs)
        {
            _playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
        else
        {
            _playerInput = Vector2.zero;;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = _playerInput * speed;
    }
}
