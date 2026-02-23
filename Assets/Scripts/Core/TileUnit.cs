using System.Numerics;

namespace Core
{
    public static class TileUnit
    {
        private static float TileSize => 0.5f;

        public static float ToWorld(float tiles)
        {
            return tiles * TileSize;
        }

        public static Vector2 ToWorld(Vector2 tiles)
        {
            return tiles * TileSize;
        }
    }
}