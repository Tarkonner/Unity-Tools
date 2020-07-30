public class HealthFunction 
{
    private int _max;
    public int current;
    public bool living;
    
    //Constructor
    public HealthFunction(int maxHealth)
    {
        _max = maxHealth;
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
