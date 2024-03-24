using System;
using System.ComponentModel.DataAnnotations;


/*
I exceeded requirements on this assignment through the following:
1. createing a static utility class (learned about these as i was looking for solutions to a problem)
    to contain a useful function
2. Learned and implemented the first level of interfaces to use the run method in a seperate class containing a list of 
    all different subclasses
3. Modified the breathing exersize to better fulfill its purpose
4. Made printing messages prettier
5. Started documenting more of my code to make it easier to understand later

*/
class Program
{
    static void Main(string[] args)
    {
        Menu home = new Menu();
        while (true)
        {
            home.DisplayMenu();
        }
    }
}


