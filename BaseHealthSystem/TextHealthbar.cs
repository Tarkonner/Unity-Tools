using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHealthbar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textForMaxHealth, textForMinHealth;

    private GameObject _player;
    private BaseHealthSystem _playerHealthSystem;
    private bool _playerIsActive = false;

    private int _savedHealth;

    private void OnEnable()
    {
        PlayerHealth.OnDamage += ShowCurrentHealth;
    }

    private void OnDisable()
    {
        PlayerHealth.OnDamage -= ShowCurrentHealth;
    }

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        if (_player != null)
        {
            _playerIsActive = true;
            _playerHealthSystem = _player.GetComponent<BaseHealthSystem>();
        }
        else
        {
            Debug.LogError("Here is no player, or it has no tag");
        }
        
        if (_playerIsActive)
        {
            ShowMaxHealth();
            ShowCurrentHealth();
        }
    }
    
    void ShowCurrentHealth()
    {
        _savedHealth = _playerHealthSystem.currentHealth;
        textForMinHealth.text = _savedHealth.ToString();
    }
    
    void ShowMaxHealth()
    {
        string showText = _playerHealthSystem.maxHealth.ToString() + " /";
        textForMaxHealth.text = showText;
    }
}
