using UnityEngine;
using System.Collections;

class Chocolate : Component
{
    //public Chocolate(string name):base (name)
    //{

    //}

    //public override void Print()
    //{
    //    Debug.Log(name);
    //}



    public string Name { get ; set ; }
    public int Price { get; private set; }

    public Chocolate(int price, string name)
    {
        Price = price;
        Name = name;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void Add(Component comp)
    {
        
    }

    public void Print()
    {
        Debug.Log(Name);
    }

    public void Remove(Component comp)
    {
        
    }
}
