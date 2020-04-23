﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementWithVelocity : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _playerInput;

    [SerializeField] private float speed = 6.5f;
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        _rb.velocity = _playerInput * speed;
    }
}
