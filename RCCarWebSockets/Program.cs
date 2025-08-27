using System.Device.Gpio;
using System.Threading.Tasks;

const int Pin = 17;


using var controller = new GpioController();
controller.OpenPin(Pin, PinMode.Output);
controller.OpenPin(27, PinMode.Output);

controller.Write(17, PinValue.High);
controller.Write(27, PinValue.Low);

await Task.Delay(1000); // 1 Sekunde warten

controller.Write(17, PinValue.Low);
controller.Write(27, PinValue.Low);


Console.WriteLine("Motor gestoppt.");

controller.Write(17, PinValue.Low);
controller.Write(27, PinValue.Low);