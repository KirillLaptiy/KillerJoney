namespace __Characters.Interfaces
{
    public interface ICharacterHealth
    {
        void Heal(int heal);
        void TakeDamage(int damage);
        void Die();
    }
}
