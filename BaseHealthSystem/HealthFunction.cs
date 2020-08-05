public class HealthFunction 
{
        private int _max;
    public int current { get; private set; }
    public bool living { get; private set; }
    
    //Constructor
    public HealthFunction(int maxHealth)
    {
        _max = maxHealth;
    }
    
    
    //Set Health
    public void SetHealth(int healthAmount)
    {
        current = healthAmount;
    }
    
    //Healing
    public bool Healing(int heal)
    {
        if (current == _max || heal < 1)
            return false;

        if (heal + current >= _max)
        {
            current = _max;
        }
        else
        {
            current += heal;
        }
        
        return true;
    }

    public void FullHeal()
    {
        current = _max;
        living = true;
    }

    public void AddToMaxHealth(int increase)
    {
        _max += increase;
        Healing(increase);
    }
    
    //Damage
    public void TakingDamage(int damage)
    {
        if(damage < 1) //Gate for negativ numbers 
            return;
        
        current -= damage;

        if (current <= 0)
            living = false;
    }
}
