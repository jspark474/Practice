using System.Numerics;
using System.Threading;

namespace CSharp;

class Program
{ 
  static void OnInputTest()
    {
        Console.WriteLine("Input Recieved");
    }

   
    static void Main(string[] args)
    {
        InputManager inputManager = new InputManager();

        inputManager.InputKey += OnInputTest;

        while (true)
        {
            inputManager.Update();
        }

    }
}

