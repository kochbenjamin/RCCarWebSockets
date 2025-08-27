using System.Device.Gpio;
using System.Threading.Tasks;

const int Pin = 17;


using var controller = new GpioController();
controller.OpenPin(Pin, PinMode.Output);
controller.OpenPin(27, PinMode.Output);

DateTime starttime = DateTime.Now;

while (DateTime.Now - starttime < TimeSpan.FromSeconds(1))
{
    Console.WriteLine("Writing High Value");
    controller.Write(17, PinValue.High); // IN1
    controller.Write(27, PinValue.Low);  // IN2

    await Task.Delay(50);
}


Console.WriteLine("Motor gestoppt.");

controller.Write(17, PinValue.Low);
controller.Write(27, PinValue.Low);