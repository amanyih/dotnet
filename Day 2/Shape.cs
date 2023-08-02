using System;

namespace Day2{
    class Shape{
    public string Name {get; set;}

    public Shape(string name){
        Name = name;
    }

    public virtual double CalculateArea(){
        return 0;
    }
}

//class for circle
class Circle : Shape{
    public double Radius {get; set;}

    public Circle(string name, double r) : base(name){
        Radius = r;
    }

    public override double CalculateArea(){
        return Math.PI * Radius * Radius;
    }
}

//class for rectangle
class Rectangle : Shape{
    public double Base {get; set;}
    public double Height {get; set;}

    public Rectangle(string name, double b, double h) : base(name){
        Base = b;
        Height = h;
    }

    public override double CalculateArea(){
        return Base * Height;
    }
}

//class for Triangle
class Triangle : Shape {
    public double Base {get; set;}
    public double Height {get; set;}

    public Triangle(string name, double b, double h) : base(name){
        Base = b;
        Height = h;
    }
    public override double CalculateArea(){
        return 0.5 * Base * Height;
    }
}
}