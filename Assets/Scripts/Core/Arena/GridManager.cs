using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core.Arena
{
    public class GridManager : MonoBehaviour
    {
        public static GridManager Instance { get; private set; }
        
        [SerializeField] private Tilemap groundTilemap;

        public Vector3 Center { get; private set; }
        public Vector3 Size { get; private set; }
        public Tilemap GroundTilemap => groundTilemap;

        private void Awake()
        {
            Instance = this;
            CalcArenaValues();
        }
        
        private void CalcArenaValues()
        {
            groundTilemap.CompressBounds();
            
            Center = groundTilemap.localBounds.center;
            Size = groundTilemap.localBounds.size;
        }
    }
}
