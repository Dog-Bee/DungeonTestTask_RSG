using System;
using Content.Features.AIModule.Scripts;
using Content.Features.InteractionModule;
using UnityEngine;

namespace Content.Features.DamageablesModule.Scripts
{
    public class MonoDamageable : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private DamageableType _damageableType;
        [SerializeField] private AttackInteractable _attackInteractable;
        [SerializeField] private EnemyHealthBarView _enemyHealthBar;


        private PlayerHealthModel _playerHealthModel;
        private float _currentHealth = 1;

        public Vector3 Position => transform.position;
        public DamageableType DamageableType => _damageableType;
        public bool IsActive => _currentHealth > 0;
        public AttackInteractable Interactable => _attackInteractable;


        public event Action OnDamaged;
        public event Action OnKilled;


        private void InitAsEnemy()
        {
            _enemyHealthBar.SetHealth(_currentHealth, _maxHealth);
        }

        public void InitAsPlayer(PlayerHealthModel model)
        {
            _playerHealthModel = model;
        }

        public void Damage(float damage)
        {
            if (_damageableType == DamageableType.Player)
            {
                _playerHealthModel.TakeDamage((int)damage);
                return;
            }

            _currentHealth -= damage;
            if(_damageableType == DamageableType.Enemy)
            UpdateUI();
            OnDamaged?.Invoke();

            if (_currentHealth <= 0)
            {
                OnKilled?.Invoke();
                Destroy(gameObject);
            }
        }

        private void UpdateUI()
        {
            _enemyHealthBar.SetHealth(_currentHealth, _maxHealth);
        }

        public void SetHealth(float health, PlayerHealthModel model = null)
        {
            _maxHealth = health;
            _currentHealth = _maxHealth;
            if (model == null)
            {
                InitAsEnemy();
                return;
            }

            InitAsPlayer(model);
        }
    }
}