using System;
using System.Security;

namespace MyApp
{
    public abstract class GameObject
    {
        public int X {get; set;}
        public int Y {get; set;}
        public virtual bool isWalkable => false;
        public virtual bool isInterectable => false;
        public virtual void Update(){}
    }
}