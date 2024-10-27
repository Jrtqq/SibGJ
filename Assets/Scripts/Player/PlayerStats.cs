using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    private List<Food> _food = new();
    private List<Creature> _pets = new();

    public int Health { get; private set; } = 100;
    public int Money { get; private set; } = 0;
    public int GoalMoney { get; private set; } = 10000;

    public IReadOnlyList<Food> Food => _food;
    public IReadOnlyList<Creature> Pets => _pets;

    public Action Died;
    public Action BecameRich;

    public PlayerStats() //конструктор только для дебага
    {
        Food temp = Resources.Load<Food>("ScriptableObjects/Food/Raw Meat");
        _food = new() { temp, temp, temp };
    }

    public void AddFood(Food food)
    {
        _food.Add(food);
    }

    public void RemoveFood(Food food)
    {
        _food.Remove(food);
    }

    public void AddPet(Creature pet)
    {
        _pets.Add(pet);
    }

    public void RemovePet(Creature pet)
    {
        _pets.Remove(pet);
    }

    public void ApplyDamage(int value)
    {
        Health = Mathf.Clamp(Health - Mathf.Abs(value), 0, int.MaxValue);

        if (Health == 0)
            Died?.Invoke();
    }

    public void ChangeMoney(int value)
    {
        Money = Mathf.Clamp(Money + value, 0, GoalMoney);

        if (Money == 0)
            BecameRich?.Invoke();
    }
}