namespace Enemy
{
    public static class EnemyScore
    {
        public static int _zombieKilled;
        public static void Clean() => _zombieKilled = 0;
        public static void ZombieKilled() => _zombieKilled++;
    }
}