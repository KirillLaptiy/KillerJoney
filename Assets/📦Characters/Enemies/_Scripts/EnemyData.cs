using UnityEngine;

namespace Characters.Enemies
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Enemies/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public int health;
        public float speed;
        public int expForDeath;
    }
}
