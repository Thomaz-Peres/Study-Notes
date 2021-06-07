using System; 

class URI {

    static void Main(string[] args) { 

        double x = double.Parse(Console.ReadLine());

        if(x >= 0 && x <= 25)
            Console.WriteLine("Intervalo [0,25]");
            
        else if(x > 25 && x <= 50)
            Console.WriteLine("Intervalo (25,50]");
        
        else if(x > 50 && x <= 75)
            Console.WriteLine("Intervalo (50,75]");
            
        else if(x > 75 && x <= 100)
            Console.WriteLine("Intervalo (75,100]");
        
        else
           Console.WriteLine("Fora de intervalo");

    }

}