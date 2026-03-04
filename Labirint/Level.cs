namespace MyApp
{
    public abstract class Level: GameObject
    {
        public GameObject[,] Grid {get; set;}
        public Player player {get; set;}
        public List<Spider> spiders {get;set;}
        public List<Item> items {get;set;}
        public Level(int width, int height)
        {
            Grid = new GameObject[width, height];
        }
        public void SetCell(int x, int y, GameObject obj)
        {
            Grid[x,y] = obj;
            obj.X = x;
            obj.Y = y;
        }
        public GameObject GetCell(int x, int y)
        {
            if (x < 0 || x > Grid.GetLength(0) || y < 0 || y > Grid.GetLength(0)) {
                return null;
            }
            return Grid[x, y];
        }
        public bool isWalkable(int x, int y)
        {
            var cell = GetCell(x, y);
            return cell != null && cell.isWalkable;
        }
    }
}