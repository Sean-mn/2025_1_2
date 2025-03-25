using UnityEngine;

public class Define
{
    public static class Keys
    {
        public static readonly int MouseLeftClick = 0;
        public static readonly KeyCode TurnHandLight = KeyCode.R;
        public static readonly KeyCode OpenInventory = KeyCode.Tab;
        public static readonly KeyCode GetItem = KeyCode.F;
    }
    
    public static class Tags
    {
        public const string ENEMY = "Enemy";
        public const string PLAYER = "Player";
    }

    public static class Layers
    {
        public static readonly LayerMask ITEM = 1 << 6;
        public static readonly LayerMask OUT = 1 << 7;
    }

    public enum Scene
    {
        Main,
        Play,
        Rank,
    }
}
