using UnityEngine;

public partial class BaseForHealthSystem : MonoBehaviour, IWeaponInteractive
{
    public HealthFunction HealthFunction { get; private set; }
    [SerializeField] private int setMaxHealth = 3;
    
    private void Awake() => HealthFunction = new HealthFunction(setMaxHealth);
    private void OnEnable() => HealthFunction.FullHeal();

    
    protected virtual void Dead()
    {
        Debug.Log($"{gameObject.name} is dead." );
        gameObject.SetActive(false);
    }

    public virtual void Interaction(int damage) //Damage
    {
        HealthFunction.TakingDamage(damage);
        
        if(!HealthFunction.living)
            Dead();
    }
}
