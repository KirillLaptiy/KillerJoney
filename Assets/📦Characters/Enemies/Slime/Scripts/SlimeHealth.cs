using __Characters.Interfaces;
using Characters.Enemies;
using Core;
using UnityEngine;

namespace __Characters.Enemies.Slime.Scripts
{
    public class SlimeHealth : MonoBehaviour, ICharacterHealth
    {
        [SerializeField] private int curHealth = 3;
        [SerializeField] private int maxHealth = 3;
    
        private Rigidbody2D _rb;
        private EnemyData _slimeData;
    
        private GameManager _gameManager;
    
        public bool IsDead => curHealth <= 0;
        public int CurHealth => curHealth;
        public int MaxHealth => maxHealth;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _slimeData = GetComponent<SlimeData>().Data;
        }

        private void Start()
        {
            _gameManager = GameManager.Instance;
        }

        public void Heal(int heal)
        {
            curHealth += heal;
        }

        public void TakeDamage(int damage)
        {
            curHealth -= damage;
            if (curHealth <= 0) Die();
        }

        public void Die()
        {
            _gameManager.SpawnExp(_rb.position, _slimeData.expForDeath);
            Destroy(gameObject);
        }
    }
}
