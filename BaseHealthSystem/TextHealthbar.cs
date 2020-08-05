using UnityEngine;
using TMPro;

public class TextHealthbar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textForMaxHealth;
    [SerializeField] private TextMeshProUGUI textForMinHealth;
    
    private GameObject _player;
    private BaseForHealthSystem _playerHealthSystem;
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
            _playerHealthSystem = _player.GetComponent<BaseForHealthSystem>();
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
        _savedHealth = _playerHealthSystem.HealthFunction.current;
        textForMinHealth.text = _savedHealth.ToString();
    }
    
    void ShowMaxHealth()
    {
        string showText = _playerHealthSystem.HealthFunction._max + " /";
        textForMaxHealth.text = showText;
    }
}
