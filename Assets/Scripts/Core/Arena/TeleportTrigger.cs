using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core.Arena
{
    public class TeleportTrigger : MonoBehaviour
    {
        private GridManager _gridManager;
        private Tilemap _groundTilemap;
        private BoxCollider2D _boxCollider2D;

        private void Start()
        {
            _gridManager = GridManager.Instance;
            _groundTilemap = _gridManager.GroundTilemap;
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag(Tags.Player)) return;
            if (!_groundTilemap) return;
            
            var bounds = _boxCollider2D.bounds;

            var playerPos = collision.transform.position;
            var arenaPos = _groundTilemap.transform.position;

            var arenaSize = new Vector2(bounds.size.x, bounds.size.y);
            
            // Bottom exit
            if (playerPos.y < bounds.min.y) arenaPos.y -= arenaSize.y;
            // Top exit
            if (playerPos.y > bounds.max.y) arenaPos.y += arenaSize.y;
            // Left exit
            if (playerPos.x < bounds.min.x) arenaPos.x -= arenaSize.x;
            // Right exit
            if (playerPos.x > bounds.max.x) arenaPos.x += arenaSize.x;

            // Move ground tilemap
            _groundTilemap.transform.position = arenaPos;
            
            // Move teleport zone
            GetComponent<Transform>().position = _gridManager.Center;
        }
    }
}
