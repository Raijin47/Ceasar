namespace Enemy
{
    public static class EnemyScore
    {
        public static int _zombieKilled;
        public static int _bossKilled;

        public static void Clean()
        {
            _zombieKilled = 0;
            _bossKilled = 0;
        }
        public static void ZombieKilled() => _zombieKilled++;
        public static void BossKilled() => _bossKilled++;
    }
}