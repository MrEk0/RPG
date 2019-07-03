using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //Component sweetBox = new Box("Box for sweets");
        //Component cookBox = new Box("Box for cookies");
        //Component snickers = new Chocolate("Snickers");
        //Component bounty = new Chocolate("bounty");

        //sweetBox.Add(snickers);
        //sweetBox.Add(bounty);
        //cookBox.Add(sweetBox);
        //cookBox.Print();

        //sweetBox.Remove(bounty);
        //cookBox.Print();


        //Composite
        Component sweetBox = new Box("Box for sweets");
        Component largeSweetBox = new Box("Large Box for sweets");
        Component snickers = new Chocolate(20, "snickers");
        Component bounty = new Chocolate(15, "bounty");
                
        sweetBox.Add(snickers);
        sweetBox.Add(bounty);

        largeSweetBox.Add(sweetBox);
        //before deleting;
        largeSweetBox.Print();
        sweetBox.Print();

        //sweetBox.Remove(snickers);
        ////after deleting snickers
        //largeSweetBox.Print();
        //sweetBox.Print();


        //Visitor
        Price price = new Price();
        sweetBox.Accept(price);
        print(price.fullPrice);
    }


}
