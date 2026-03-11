using UnityEngine;

namespace Core.Arena
{
    public class TeleportZone : MonoBehaviour
    {
        [SerializeField] private GameObject teleportZone;
        
        [Header("Distance between arena edge and teleport zone")]
        [SerializeField] private float tileDistanceX;
        [SerializeField] private float tileDistanceY;
        
        private GridManager _gridManager;

        private void Start()
        {
            _gridManager = GridManager.Instance;
            CreateTeleportZoneBounds();
        }
        
        private void OnDrawGizmos()
        {
            if (_gridManager == null) return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_gridManager.Center, teleportZone.GetComponent<BoxCollider2D>().size);
        }
        
        private void CreateTeleportZoneBounds()
        {
            var worldDistanceX = TileUnit.ToWorld(tileDistanceX);
            var worldDistanceY = TileUnit.ToWorld(tileDistanceY);
            
            teleportZone.transform.position = _gridManager.Center;
            teleportZone.GetComponent<BoxCollider2D>().size = new Vector2(_gridManager.Size.x - worldDistanceX, _gridManager.Size.y - worldDistanceY);
        }
    }
}
