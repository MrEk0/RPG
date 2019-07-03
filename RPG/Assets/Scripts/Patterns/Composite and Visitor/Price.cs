using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Price : IVisitor
{
    public int fullPrice { get; private set; }

    public void Visit(Chocolate chocolate)
    {
       fullPrice+=chocolate.Price;
    }

    public void Visit(Box box)
    {
        
    }
}

