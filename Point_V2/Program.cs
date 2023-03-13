using System.Numerics;
using System.Text.RegularExpressions;


class Point:IComparable
{
    //Поля
    protected double x, y;
    
    public double X { get { return x; } set { x = value; } }
    public double Y { get { return y; } set { y = value; } }
    //Конструкторы
    public Point()
    {
        X = 0;
        Y = 0;
    }

    public Point(double x)
    {
        X = x;
        Y = 0;
    }

    public Point (double x, double y)
    {
        X = x;
        Y = y;
    }

    //Методы
    public override string ToString()
    {
        return $"({X};{Y})";
    }

    public override bool Equals(object p)
    {
        Point _point_ = (Point)p;
        if (this.X == _point_.X && this.Y == _point_.Y) return true;
        else return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public static bool operator == (Point a, Point b)
    {
        return a.Equals(b);
    }

    public static bool operator != (Point a, Point b)
    {
        return !(a.Equals(b));
    }

    public static Point operator + (Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }
}

class ColorPoint:Point
{
    //Поля
    string color;
    //Конструкторы
    public ColorPoint():base()
    {
        color = "White";
    }

    public ColorPoint(double x, string color):base(x)
    {
        this.color = color;
    }

    public ColorPoint (double x, double y, string color):base(x,y)
    {
        this.color = color;
    }
    //Методы
    public override string ToString()
    {
        string Pattern = $"Координаты и цвет точки: (" + Convert.ToString(x) + ";" + Convert.ToString(y) + ";" + Convert.ToString(color);
        Pattern += ")";
        return Pattern;
    }

    public override bool Equals(object cp)
    {
        ColorPoint _colorpoint_ = (ColorPoint)cp;
        if (this.X == _colorpoint_.X && this.Y == _colorpoint_.Y && this.color == _colorpoint_.color) return true;
        else return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator == (ColorPoint a, ColorPoint b)
    {
        return a.Equals(b);
    }

    public static bool operator != (ColorPoint a, ColorPoint b)
    {
        return !(a.Equals(b));
    }
}

class Line:Point
{
    //Поля
    protected Point point1 = new Point();
    protected Point point2 = new Point();
    public Point Point1
    {
        get { return point1; }
        set { point1 = value; }
    }

    public Point Point2
    {
        get { return point2; }
        set { point2 = value; }
    }
    //Конструкторы
    public Line()
    {
        int x = 0;
        int y = 0;
        Point1 = new Point(x , y);
        Point2 = new Point(x , y);
    }

    public Line(Point t1, Point t2)
    {
        this.point1 = t1;
        this.point2 = t2;
    }
    //Методы
    public override string ToString()
    {
        string Pattern = $"(" + point1.ToString() + ";" + point2.ToString();
        Pattern += ")";
        return Pattern;
    }

    public override bool Equals(object ln)
    {
        if (ln == null) return false;
        Line _line_ = (Line) ln;
        if (_line_.point1 == point1 && _line_.point2 == point2) return true;
        else return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator == (Line p1, Line p2)
    {
        return p1.Equals(p2);
    }
    public static bool operator != (Line p1, Line p2)
    {
        return !(p1.Equals(p2));
    }

    public static Line operator + (Line l1, Line l2)
    {
        return new Line (l1.point1 + l2.point1, l1.point2 = l2.point2);
    }
}

class ColorLine:Line
{
    //Поля
    protected string color;

    public string Color
    {
        get { return color; }
        set { color = value; }
    }
    //Конструкторы
    public ColorLine():base() 
    {
        color = "White";
    }

    public ColorLine(Point point1, Point point2, string color):base(point1,point2)
    {
        this.color = color;
    }
    //Методы
    public override string ToString()
    {
        string Pattern = $"Линия и её цвет: (" + point1.ToString() + ";" + point2.ToString() + ";" + color;
        Pattern += ")";
        return Pattern;
    }

    public override bool Equals(object cl)
    {
        if (cl == null) return false;
        ColorLine _line_ = (ColorLine)cl;
        if (_line_.point1 == point1 && _line_.point2 == point2 && _line_.color == color) return true;
        else return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator == (ColorLine cl1, ColorLine cl2)
    {
        return cl1.Equals(cl2);
    }

    public static bool operator != (ColorLine cl1, ColorLine cl2)
    {
        return !(cl1.Equals(cl2));
    }

    public static ColorLine operator + (ColorLine cl1, ColorLine cl2)
    {
        return new ColorLine (cl1.point1 + cl2.point1, cl1.point2 + cl2.point2, cl1.color = cl2.color);
    }
}

class Polygon:Point
{
    //Поля
    protected Line[] Lines = new Line[50];
    protected int Angles = 0;
    //Конструкторы
    public Polygon()
    {
        Lines[0] = new Line();
        Angles = 1;
    }

    public Polygon(params Line[] a)
    {
        Array.Copy(a, Lines, a.Length);
        Angles = a.Length;
    }
    //Методы
    public override string ToString()
    {
        string Pattern = $"{Angles}-угольник\n";
        for (int i = 0; i < Angles; i++)
        {
            Pattern += Lines[i].ToString();
        }
        return Pattern;
    }

    public override bool Equals(object pl)
    {
        bool check = true;
        if (pl == null) return false;
        Polygon _polygon_ = (Polygon)pl;
        if (Angles == _polygon_.Angles)
        {
            for (int i = 0; i < Angles; i++)
            {
                if (!this.Lines[i].Equals(_polygon_.Lines[i]))
                    check = false;
            }
        }
        return check;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator == (Polygon a, Polygon b) 
    {
        return a.Equals(b);
    }

    public static bool operator != (Polygon a, Polygon b)
    {
        return !(a.Equals(b));
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Точки");
        Console.WriteLine("Сложение точки:\n");
        Point p1 = new Point(9, 2);
        Point p2 = new Point(4, 6);
        Console.WriteLine(p1.ToString() + " + " + p2.ToString());
        Point p3 = p1 + p2;
        Console.WriteLine(p3.ToString());

        Console.WriteLine("\n\nЦветная точка");
        ColorPoint cp = new ColorPoint(9,2,"Black");
        Console.WriteLine(cp.ToString());

        Console.WriteLine("Линии");
        Console.WriteLine("\n\nСравнение линий");
        Line l1 = new Line(p1,p2);
        Line l2 = new Line(p1,p2);
        Console.WriteLine(l1.ToString());
        Console.WriteLine(l2.ToString());
        Console.WriteLine(l1 == l2);

        Console.WriteLine("\n\nЦветная линия");
        ColorLine cl = new ColorLine(p1,p2,"White");
        Console.WriteLine(cl.ToString());

        Console.WriteLine("\n\nМногоугольник");
        Polygon pl = new Polygon(l1,l2, new Line (p2,p1));
        Console.WriteLine(pl.ToString());
    }
}