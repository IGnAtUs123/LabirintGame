namespace MyApp
{
    public class Spider: Creature
    {
        public Spider()
        {
            Health = 2;
        }
        public override void Update()
        {
            
        }
        public void Attack(Player player)
        {
            player.TakeDamage(1);
        }
    }
}