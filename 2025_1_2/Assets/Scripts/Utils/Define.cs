using UnityEngine;

public class Define
{
    public static class Keys
    {
        public static readonly int MouseLeftClick = 0;
        public static readonly KeyCode TurnHandLight = KeyCode.T;
    }
    
    public static class Tags
    {
        public const string ENEMY = "Enemy";
        public const string PLAYER = "Player";
    }

    public enum Scene
    {
        Main,
        Play,
        Rank,
    }
}
