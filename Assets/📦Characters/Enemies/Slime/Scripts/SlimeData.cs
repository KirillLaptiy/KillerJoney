using Characters.Enemies;
using UnityEngine;

namespace __Characters.Enemies.Slime.Scripts
{
    public class SlimeData : MonoBehaviour
    {
        [SerializeField] private EnemyData data;
        public EnemyData Data => data;
    }
}
