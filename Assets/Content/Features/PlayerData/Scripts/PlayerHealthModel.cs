using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerHealthModel), menuName = "RSG/Player/"+nameof(PlayerHealthModel))]
public class PlayerHealthModel : ScriptableObject
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;
    
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    
    public event Action<int,int> OnHealthChanged;

    public void Reset(int maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(maxHealth, maxHealth);
    }
    public void SetHealth(int health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth,maxHealth);
    }
    
    public void TakeDamage(int damage) => SetHealth(currentHealth - damage);
    public void Heal(int heal) => SetHealth(currentHealth + heal);
    
}
