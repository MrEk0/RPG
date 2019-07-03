using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 interface IVisitor
{
    void Visit(Chocolate chocolate);
    void Visit(Box box);
}

