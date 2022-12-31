using System;
using ST.Systems;
using UnityEngine;

namespace ST.Games.TypingGame
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private int _defaultHealth = 100;
        private HealthSystem _health;

        private void Awake()
        {
            _health = new(_defaultHealth);
        }

        private void OnEnable()
        {
            _health.OnHealthChanged += HealthSystem_OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.OnHealthChanged -= HealthSystem_OnHealthChanged;
        }

        private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
        {
            Debug.LogFormat("Name: {0} | Health: {1} | Percentage: {2}%", gameObject.name.ToLower(), _health.Health, _health.HealthPercentage);

            if (_health.Health <= 0)
                Kill();
        }

        private void Kill()
        {
            Debug.LogFormat("{0} was killed.", gameObject.name.ToLower());
            Destroy(gameObject);
        }
    }
}