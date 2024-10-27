using System;
using UnityEngine;

public abstract class Creature
{
    public Sprite Icon { get; private set; }
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public int Damage { get; private set; }
    public int HealthRecoverNextDay { get; private set; } = 0;

    public Action Died;

    protected Creature(Sprite icon, string name, int maxHealth, int damage)
    {
        Icon = icon;
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Damage = damage;
    }

    public void ApplyDamage(int value)
    {
        Health = Mathf.Clamp(Health + Mathf.Abs(value), 0, MaxHealth);

        if (Health == 0)
            Died?.Invoke();
    }

    public void Feed(int value)
    {
        HealthRecoverNextDay += Mathf.Abs(value);
    }

    public void Sleep()
    {
        Health = Mathf.Clamp(Health + HealthRecoverNextDay, 0, MaxHealth);
        HealthRecoverNextDay = 0;
    }
}
