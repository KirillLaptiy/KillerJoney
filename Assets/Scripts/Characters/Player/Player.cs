using Core.Arena;
using UnityEngine;

namespace Characters.Player
{
    public class Player : MonoBehaviour
    {
        private PlayerMovement _movement;
        
        private GridManager _gridManager;
        
        private Vector3 _spawnPosition;

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            _gridManager = GridManager.Instance;
            
            // Teleports player to an arena center
            _movement.TeleportTo(_gridManager.Center);
        }
    }
}
