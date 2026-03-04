using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;

namespace MyApp
{
    public class Level: GameObject
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
        public static Level LoadFromFile(StringBuilder filename)
        {
            string[] lines = File.ReadAllLines("Level.txt");
            int height = lines.Length;
            int width = lines[0].Length;

            Level level = new Level(width, height);
            for (int y = 0; y < height; y++)
            {
                string line = lines[y];
                for (int x = 0; x < width; x ++)
                {
                    string c = lines[x];
                    switch (c)
                    {
                        case ("#"): level.SetCell(x, y, new Wall()); break;
                        case ("."): level.SetCell(x, y, new Wall()); break;
                        case ("E"): level.SetCell(x, y, new Wall()); break;
                        case ("P"):
                            level.player = new Player();
                            level.SetCell(x,y,level.player);
                            break;
                        case ("S"):
                            var spider = new Spider();
                            level.spiders.Add(spider);
                            level.SetCell(x,y,spider);
                            break;
                        case ("T"):
                            var torch = new Torch();
                            level.items.Add(torch);
                            level.SetCell(x,y,torch);
                            break;
                        case ("A"):
                            var axe = new Axe();
                            level.items.Add(axe);
                            level.SetCell(x,y,axe);
                            break;
                    }
                }
            }
            return level;
        }
    }
}