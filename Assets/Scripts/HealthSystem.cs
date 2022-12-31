using System;
using UnityEngine;

namespace ST.Systems
{
    public class HealthSystem
    {
        private int _health;
        private readonly int _maxHealth;

        public HealthSystem(int maxHealth = 100)
        {
            _health = maxHealth;
            _maxHealth = maxHealth;
        }

        public int Health { get => _health; private set => _health = Mathf.Clamp(value, 0, _maxHealth); }
        public float HealthPercentage => (float)_health / _maxHealth * 100;
        public EventHandler OnHealthChanged { get; set; }

        public void Damage(int amount)
        {
            if (Health != 0)
            {
                Health -= amount;
                OnHealthChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Heal(int amount)
        {
            if (Health != _maxHealth)
            {
                Health += amount;
                OnHealthChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}