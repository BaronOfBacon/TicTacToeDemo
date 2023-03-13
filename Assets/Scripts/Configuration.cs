using UnityEngine;

namespace Root
{
    [CreateAssetMenu]
    public class Configuration: ScriptableObject
    {
        public int LevelWidth = 3;
        public int LevelHeight = 3;
        public int WinChainLength = 3;
        public CellView CellView;
        public Vector2 Offset;
        public SignView CrossView;
        public SignView CircleView;
    }
}