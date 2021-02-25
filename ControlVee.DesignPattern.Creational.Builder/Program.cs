namespace ControlVee.DesignPattern.Creational.Builder
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /*  
         Participants:
        
            The classes and objects participating in this pattern are:
                Builder  (VehicleBuilder)
                    - specifies an abstract interface for creating parts of a Product object
                    - (optional) implements the successor link

                ConcreteBuilder  (MotorCycleBuilder, CarBuilder, ScooterBuilder)
                    - constructs and assembles parts of the product by implementing the Builder interface
                    - defines and keeps track of the representation it creates
                    - provides an interface for retrieving the product

                Director  (Shop)
                    - constructs an object using the Builder interface

                Product  (Vehicle)
                    - represents the complex object under construction. 
                    ConcreteBuilder builds the product's internal representation 
                    and defines the process by which it's assembled
                    - includes classes that define the constituent parts, including 
                    interfaces for assembling the parts into the final result
    */
    /// </summary>
    class Program
    {
        public static void Main()
        {
            Director director = new Director();

            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();
            Builder b3 = new ConcreteBuilder1();
            Builder b4 = new ConcreteBuilder2();

            // Construct two products here:

            // This...
            director.Construct(b1);
            Product product1 = b1.GetResult();
            product1.Show();

            director.Construct(b2);
            Product product2 = b2.GetResult();
            product2.Show();

            // OR // 

            // This...
            director.Construct(b3);
            director.Construct(b4);
            Product product3 = b3.GetResult();
            Product product4 = b4.GetResult();
            product3.Show();
            product4.Show();
        }
    }

    class Director
    {
        // Builder uses a series of steps.
        public void Construct(Builder abstractBuilder)
        {
            abstractBuilder.BuildPartA();
            abstractBuilder.BuildPartB();
        }
    }

    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }

    class ConcreteBuilder1 : Builder
    {
        private Product _product = new Product();

        // Override an abstract the same way as virtual? Why?
        public override void BuildPartA()
        {
            _product.Add("part_a");
        }

        public override void BuildPartB()
        {
            _product.Add("part_b");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    class ConcreteBuilder2 : Builder
    {
        private Product _product = new Product();

        // Override an abstract the same way as virtual? Why?
        // Is this a good example if method names are part A and B
        // when it is creating x and y parts?
        public override void BuildPartA()
        {
            _product.Add("part_x");
        }

        public override void BuildPartB()
        {
            _product.Add("part_y");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    class Product
    {
        private List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nProduct Parts -------");
            foreach (string part in _parts)
                Console.WriteLine(part);
        }
    }
}
