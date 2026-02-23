using UnityEngine;

namespace Core.Arena
{
    public class TeleportZone : MonoBehaviour
    {
        [SerializeField] private GameObject teleportZonePrefab;
        
        [Header("Distance between arena edge and teleport zone")]
        [SerializeField] private float tileDistanceX;
        [SerializeField] private float tileDistanceY;
        
        private GridManager _gridManager;
        
        private GameObject _teleportZone;

        private void Start()
        {
            _gridManager = GridManager.Instance;
            CreateTeleportZone();
        }
        
        private void OnDrawGizmos()
        {
            if (_gridManager == null) return;
            if (_teleportZone == null) return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_teleportZone.GetComponent<BoxCollider2D>().offset, _teleportZone.GetComponent<BoxCollider2D>().size);
        }
        
        private void CreateTeleportZone()
        {
            var worldDistanceX = TileUnit.ToWorld(tileDistanceX);
            var worldDistanceY = TileUnit.ToWorld(tileDistanceY);
            
            _teleportZone = Instantiate(teleportZonePrefab);
            _teleportZone.transform.position = _gridManager.Center;
            _teleportZone.GetComponent<BoxCollider2D>().size = new Vector2(_gridManager.Size.x - worldDistanceX, _gridManager.Size.y - worldDistanceY);
        }
    }
}
