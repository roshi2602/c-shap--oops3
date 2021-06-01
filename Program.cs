using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_basics2
{

    //NOTE - public - can be accessed publically
    //static - objects are not created
    //void - dont return value
    //main - executed first



    //abstract class -
    //1)concrete class as abstract

    //NOTE-  //static - we cannot create object of static class and cannot access it
    //static class cannot be instantiated
    //static class contain static methods, variables, static operators
    //accessed by - ClassName.MemberName


    public abstract class Conc
    {
        //creating static method
        public static void meth1()
        {
            Console.WriteLine("method 1 works as it is static");
        }

        public void meth2()
        {
            Console.WriteLine("method2 dosent work ");
        }
    }


    //-------------------------------------------------------

    //2)abstract class and abstract method
    //abstract class is used when --
    //--method is without body
    //--class has abstract method then it must have abstract keyword
    //subclass of abstract class should ovveride abstract method 


    public abstract class Abst                                  //abstract class
    {
        public abstract void Methods1(double x);            //abstract method having 1 parameter
    }

    //subclasses
    class subclass1 : Abst                           //subclass of abstract class will overide abstract methods
    {
        public override void Methods1(double x)
        {
            Console.WriteLine(Math.Sqrt(x));             // to find square root
        }

    }


    class subclass2 : Abst                           //subclass of abstract class will overide abstract methods
    {
        public override void Methods1(double x)
        {
            Console.WriteLine(x * x);
        }

    }

    //------------------------------------------------------------------


    //polymorphism
    //types-function  and operator overloading (dynamic), method overloading(static)
    //in this in a class, multiple methods have same name but different arguments

    //1)method overloading
    class Poly
    {
        public void mul(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public void mul(string x, string y)
        {
            Console.WriteLine(x + y);
        }

        public void mul(float c, float d)
        {
            Console.WriteLine(c * d);
        }
    }

    //------------------------------------------------------------------
    //2)inheritance overloading
    //--class can be overloaded within child class

    class Poly2
    {
        public void add(int j, int k)
        {
            Console.WriteLine(j + k);
        }


        public void add(float c, float d)
        {
            Console.WriteLine(c + d);
        }
    }


    class Poly3 : Poly2
    {
        public void add(string f, string g)
        {
            Console.WriteLine(f + g);
        }
    }

    //------------------------------------------------------------

    //3)method overriding
    //process of reimplementing base class non static method in sub class with same paramters

    //virtual method- method which can be redefined in child/derived class
    //it is created in base class and can be overridden in child class

    class Over
    {
        public virtual void show()                  //virtual method
        {
            Console.WriteLine("show method ");
        }

    }
    class Subover : Over
    {
        public override void show()                    //overriding parent class virtual method
        {
            Console.WriteLine("overriding");

        }
    }
    //------------------------------------------------------------

    //method hiding
    //we use new keyword to hide base class member
    //used for reimplementing parent class under child class

    class Hiding
    {
        public void dis()
        {
            Console.WriteLine("main method");
        }
    }

    class Hiding2 : Hiding
    {
        public new void dis()                       //using new keyword
        {
            Console.WriteLine("subclass method");
        }
    }

    //------------------------------------------------------------

    //partial classes and methods
    //a class in which code is written into 2 or more files
    //use keyword - partial
    //in this, 2 classes are combined as 1 single class
    //is used to split UI design and business logic of code
    //press ctrl+R in this after selecting
    public partial class Partial
    {
        //it will have 2 private property
        private string first_name;
        private string last_name;

        //to access them we will use public property
        public string First
        {
            get
            {
                return first_name;
            }
            set
            {
                first_name = value;
            }
        }

        //now click on search ->select private last_name -> select encapsulate field(ctrl+R)

        public string Last_name
        {
            get => last_name;
            set => last_name = value;
        }



        //now create a method to concatenate first_name and last_name

        public string Fullname()
        {
            return first_name + last_name;
        }

        //now right click on project -> click add ->click class ->name the class ,add 2 classes

    }





    //------------------------------------------------------------
    //sealed class 
    //a class from which it is not possible to create  an new class
    //it can never be used as base class
    //it can not use abstract class
    //keyword sealed is used

   public class Demo1
    {
        protected int did, dage;
        protected string dname, daddress;

        public virtual void demodata()
        {
            Console.WriteLine("did");
            did = int.Parse(Console.ReadLine());
            Console.WriteLine("dage");
            dage = int.Parse(Console.ReadLine());
            Console.WriteLine("dname");
            dname = Console.ReadLine();
            Console.WriteLine("daddress");
            daddress = Console.ReadLine();

        }
        public virtual void readdata()
        {
            Console.WriteLine("did" + did);
            Console.WriteLine("dage" + dage);
            Console.WriteLine("dname" + dname);
            Console.WriteLine("daddress" + daddress);
        }


        //creating sealed class

        public sealed class Demo2 : Demo1
        {
            double amount, rate;
            public override void demodata()
            {
                Console.WriteLine("dname");
                dname = Console.ReadLine();
                Console.WriteLine("amount");
                amount = double.Parse(Console.ReadLine());
                Console.WriteLine("rate");
                rate = double.Parse(Console.ReadLine());

            }

            public override void readdata()
            {
                Console.WriteLine("dname"+dname);
                Console.WriteLine("amount" + amount);
                Console.WriteLine("rate" + rate);
            }
        }


    }

    //------------------------------------------------------------
    //extension method
    //to extend functionality of class by defining methods
    //add class in new class and bind them togther
    //extension must de defined under static class
    //The first parameter of an extension method is known as the binding parameter
    //which should be the name of the class to which the method has to be bound
    //and the binding parameter should be prefixed with this keyword.

    public class Oldclass
    {
        public int x = 100;
        public void test1()
        {
            Console.WriteLine(this.x);
        }
    }


    //now we want to add 2 new methods to oldclass but dont want to change the source code of oldclass

    //create new class(static)
    public static class Newclass
    {
        public static void test2(this Oldclass o)    //binding paramter with this keyword
        {
            Console.WriteLine(o.x);
        }
    }








    //------------------------------------------------------------

    //multiple inheritance 
    //interface is used for multiple inheritance

    public interface Interface1                    //interface class
    {
        //abstract methods(partially implemented now)
        void method1();
        void method2();
    }

    public interface Interface2                        //interface class
    {
        //abstract methods(partially implemented now)
        void method1();
        void method2();

    }


    //now showing multiple inheritance
    class Employees : Interface1, Interface2
    {
        public void method1()
        {
            Console.WriteLine("method 1 implemented");
        }
        public void method2()
        {
            Console.WriteLine("method 2 implemented");
        }
    }

    //output =  method 1 implemented
    //                 method 2 implemented
    //                 method 1 implemented
    //                 method 2 implemented
    //                   method 1 implemented
    //                  method 2 implemented






    //---------------------------------------------------------------------


    //interface -method without body(unimplemented class i.e. method without body)
    //contains abstract methods

    public interface Area                    //interface
    {
        //abstract methods(partially implemented)
        void method1(double a, double b);  //taking 2 parameters
    }

    class rectangle : Area
    {
        public void method1(double a, double b)
        {
            double z;          //variable and its data type
            z = a * b;
            Console.WriteLine(z);
        }

    }

    class circle : Area
    {

        public void method1(double a, double b)
        {
            double y = a * a;
            Console.WriteLine(y);
        }
    }




    //------------------------------------------------------------------


    //inheritance- parent and child class

    //creating parent class
    class Branch                                 //base class
    {
        int code;
        string name, address;

        public void getbranch()
        {
            Console.WriteLine("enter code");
            Console.WriteLine("enter name");
            Console.WriteLine("enter address");
            code = int.Parse(Console.ReadLine());       //int.parse-to convert string into integer
            name = Console.ReadLine();
            address = Console.ReadLine();
        }
        public void display()
        {
            Console.WriteLine("branchcode" + code);
            Console.WriteLine("branchname" + name);
            Console.WriteLine("branchaddress" + address);

        }
    }

    //creating child class

    class Employee : Branch                        //derived class
    {
        int eid;
        string ename, eaddress;

        public void getemployee()
        {
            Console.WriteLine("enter eid");
            Console.WriteLine("enter ename");
            Console.WriteLine("enter eaddress");
            eid = int.Parse(Console.ReadLine());       //int.parse-to convert string into integer
            ename = Console.ReadLine();
            eaddress = Console.ReadLine();
        }
        public void display2()
        {
            Console.WriteLine("id" + eid);
            Console.WriteLine("ename" + ename);
            Console.WriteLine("eaddress" + eaddress);

        }
    }
    //--------------------------------------------------------------------------


    //--------------------------------------------------------------------------------
    class Program
    {

        static void Main(string[] args)
        {
            //calling oldclass(extension method)
            Oldclass oo = new Oldclass();
            oo.test1();
            oo.test2();
            Console.ReadLine();



            //calling Demo1(sealed method)
            Demo1 d = new Demo1();
            d.demodata();
            d.readdata();
            




            //calling Hiding(method hiding)
            Hiding2 hh = new Hiding2();
            hh.dis();
            Console.ReadLine();





            //calling Over(method overriding)
            Subover ss = new Subover();
            ss.show();
            Console.ReadLine();



            //calling of Poly(polymorphism)
            Poly pp = new Poly();
            pp.mul(10, 20);
            pp.mul("roshi", "dubey");
            pp.mul(10.4f, 20.4f);
            Console.ReadLine();

            //calling of Poly2(inheritance overloading-polymorphism)
            Poly3 p = new Poly3();
            p.add(10, 20);
            p.add(5.0f, 6.0f);
            p.add("sakshi", "sharma");
            Console.ReadLine();



            //calling of Abst(abstract class and methods)

            subclass1 s1 = new subclass1();
            subclass2 s2 = new subclass2();
            s1.Methods1(36);              //      object of method for square root
            s2.Methods1(5);                  // object of method for x*x






            //calling class Conc(concrete as abstract class)
            Conc.meth1();




            //creating an object for Employees(multiple inheritance)
            Employees es = new Employees();
            es.method1();
            es.method2();
            //creating objects of interface class using child class(Employees)
            Interface1 obb1 = new Employees();
            Interface2 obb2 = new Employees();
            obb1.method1();
            obb1.method2();
            obb2.method1();
            obb2.method2();
            Console.ReadLine();




            //creating of object for Area(interference)
            Area aa = new rectangle();
            aa.method1(10, 20);
            //using same instance for other class
            aa = new circle();
            aa.method1(4, 5);

            Console.ReadLine();




            //creting object of both class(inheriatnce)
            Employee ee = new Employee();
            //we can access parent class objects using child class
            ee.getbranch();
            ee.getemployee();
            ee.display2();
            ee.display();
            Console.ReadLine();





        }
    }
}