namespace MyApp
{
    public class Axe: Item
    {
        public override void Use(Player player)
        {
            player.HasAxe = true;
        }
    }
}