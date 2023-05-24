using System;
using System.IO.Ports;
using System.Threading;
namespace ConsoleApp1
{
    class Program
    {
        static SerialPort _serialPort;
        public static void Main()
        {

            String[] portNames = SerialPort.GetPortNames();
            SerialPort porta;
            int frequencia = 9600;
            foreach (string portName in portNames)
            {
                porta = new SerialPort(portName, frequencia);
                using (porta)
                {
                    try
                    {
                        porta.Open();
                        string message = "Connected!\0";
                        porta.Write(message);
                        Thread.Sleep(2000);
                        String msg = porta.ReadExisting();
                        Console.WriteLine(msg);
                        if (msg.Contains("Connected!"))
                        {
                            Console.WriteLine("Arduino encontrado na porta: " + portName);
                            Thread.Sleep(10000);
                        }
                        else
                        {
                            porta.Close();
                            Console.WriteLine(portName);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine("Erro ao tentar abrir a porta " + portName + ": " + ex.Message);
                    }
                }
                if (!porta.IsOpen)
                {
                    Console.WriteLine("Arduino não encontrado!");
                }
            }
        }
    }
}
