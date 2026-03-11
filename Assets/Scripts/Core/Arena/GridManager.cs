using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core.Arena
{
    public class GridManager : MonoBehaviour
    {
        public static GridManager Instance { get; private set; }
        
        [SerializeField] private Tilemap groundTilemap;
        
        public Vector3 Center => groundTilemap.transform.position + groundTilemap.localBounds.center;
        public Vector3 Size => groundTilemap.localBounds.size;
        public Tilemap GroundTilemap => groundTilemap;

        private void Awake()
        {
            Instance = this;
            groundTilemap.CompressBounds();
        }
    }
}
