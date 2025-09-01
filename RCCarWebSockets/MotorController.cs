using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Gpio;

namespace RCCarWebSockets
{
    internal class MotorController
    {
        private GpioController controller = new GpioController();

        public MotorController() 
        {
            controller.OpenPin(17, PinMode.Output);
            controller.OpenPin(27, PinMode.Output);

            controller.OpenPin(22, PinMode.Output);
            controller.OpenPin(23, PinMode.Output);
        }

        public void DriveForward()
        {
            Console.WriteLine("Antrieb vorwärts");
            controller.Write(22, PinValue.High);
            controller.Write(23, PinValue.Low);
        }

        public void DriveBackWard()
        {
            Console.WriteLine("Antrieb rückwärts");
            controller.Write(22, PinValue.Low);
            controller.Write(23, PinValue.High);
        }

        public void DriveStop()
        {
            Console.WriteLine("Antrieb stop");
            controller.Write(22, PinValue.Low);
            controller.Write(23, PinValue.Low);
        }

        public void TurnLeft()
        {
            Console.WriteLine("Lenkung links");
            controller.Write(17, PinValue.High);
            controller.Write(27, PinValue.Low);
        }

        public void TurnRight()
        {
            Console.WriteLine("Lenkung rechts");
            controller.Write(17, PinValue.Low);
            controller.Write(27, PinValue.High);
        }

        public void TurnStop()
        {
            Console.WriteLine("Lenkung stop");
            controller.Write(17, PinValue.Low);
            controller.Write(27, PinValue.Low);
        }

        ~MotorController()
        {
            controller.ClosePin(17);
            controller.ClosePin(27);
            controller.ClosePin(22);
            controller.ClosePin(23);
        }
    }
}
