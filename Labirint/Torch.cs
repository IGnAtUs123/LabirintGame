namespace MyApp
{
    public class Torch: Item
    {
        public override void Use(Player player)
        {
            player.HasTorch = true;
        }
    }
}