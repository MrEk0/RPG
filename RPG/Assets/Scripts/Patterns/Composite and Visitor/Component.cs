using UnityEngine;
using System.Collections;

 interface Component 
{
    string Name { get; set; }
    void Add(Component comp);
    void Remove(Component comp);
    void Print();

    void Accept(IVisitor visitor);

    //protected string name;

    //public Component(string name)
    //{
    //    this.name = name;
    //}

    //public abstract void Print();
    //public virtual void Add(Component comp)
    //{

    //}
    //public virtual void Remove(Component comp)
    //{

    //}
}
