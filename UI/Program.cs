using System;
using Models;
using Serilog;


namespace UI
{
    class Program
    {
        //Implements Start() Method in MainMenu.cs 
        static void Main(string[] args)
        {//logging when the app begins and ends
        Log. Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().WriteTo.File("../logs/logs.txt").CreateLogger();

        Log.Information("Going to get tea... ");
        
        new MainMenu().Start();

        Log.Information("Came back with a mountain of tea. ");

        Log.CloseAndFlush();
        
        }
    }
}
