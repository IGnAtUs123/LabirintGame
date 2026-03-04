namespace MyApp
{
    public abstract class Item: GameObject
    {
        public override bool isWalkable => true;
        public abstract void Use(Player player);
    }
}