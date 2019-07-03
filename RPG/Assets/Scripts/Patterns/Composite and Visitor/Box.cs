using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 class Box : Component
{
    private List<Component> boxes = new List<Component>();

    public string Name { get ; set; }

    public Box(string name)
    {
        Name = name;
    }

    public void Add(Component comp)
    {
        boxes.Add(comp);
    }

    public void Remove(Component comp)
    {
        boxes.Remove(comp);
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
        foreach (var component in boxes)
        {
            component.Accept(visitor);
        }
    }

    public void Print()
    {
        Debug.Log(Name);
        foreach (Component component in boxes)
        {
            component.Print();

        }
    }

    

    //public Box(string name):base (name)
    //{

    //}

    //public override void Add(Component component)
    //{
    //    boxes.Add(component);
    //}

    //public override void Remove(Component component)
    //{
    //    boxes.Remove(component);
    //}

    //public override void Print()
    //{
    //    Debug.Log(name);
    //    foreach (Component component in boxes)
    //    {
    //        component.Print();
    //    }
    //}


}
