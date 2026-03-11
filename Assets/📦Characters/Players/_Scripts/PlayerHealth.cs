using __Characters.Interfaces;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ICharacterHealth
{
    [SerializeField] private int curHealth = 3;
    [SerializeField] private int maxHealth = 3;
    
    public bool IsDead => curHealth <= 0;
    public int CurHealth => curHealth;
    public int MaxHealth => maxHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Destroy(gameObject);
    }
}
