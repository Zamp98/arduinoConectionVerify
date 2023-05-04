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

            //_serialPort = new SerialPort();
            //_serialPort.PortName = "COM3";//Set your board COM
            //_serialPort.BaudRate = 9600;
            //_serialPort.Open();
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
                        // Talvez algum código para esperar para que o Arduino envie os dados

                        /*
                            Código do Arduino para enviar a mensagem:
                            void setup() { 
                                Serial.begin(9600);
                                Serial.println("Conexão estabelecida!");
                            }
                        */
                        
                        string message = "Connected!\0";
                        porta.Write(message);
                        Thread.Sleep(2000);
                        String msg = porta.ReadExisting();
                        Console.WriteLine(msg);
                        if (msg.Contains("Connected!"))
                        {
                            Console.WriteLine("Arduino encontrado na porta: " + portName);
                            Thread.Sleep(10000);
                            //break;
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

            /*while (true)
            {
                string a = _serialPort.ReadExisting();
                //tem que mandar a string com \0 pro arduino n ficar doido
                string message = "O GUTO\0";
                _serialPort.Write(message);
                Console.WriteLine(a);
                Thread.Sleep(2000);
                int s = portNames.Length;
                
            }*/
        }
    }
}