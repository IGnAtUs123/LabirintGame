namespace MyApp
{
    public abstract class Creature: GameObject
    {
        public int Health {get;set;}
        public override bool isWalkable => true;
        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}