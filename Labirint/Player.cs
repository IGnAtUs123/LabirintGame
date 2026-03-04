namespace MyApp
{
    public class Player: Creature
    {
        public bool HasTorch {get; set;}
        public bool HasAxe {get; set;}
        public List<Item> Inventory {get; set;}
        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }
        public void PickUp(Item item)
        {
            Inventory.Add(item);
        }
        public void Attack(Spider spider)
        {
            if (HasAxe)
            {
                spider.TakeDamage(1);
            }
        }
    }
}