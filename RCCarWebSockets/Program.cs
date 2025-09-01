using System.Device.Gpio;
using System.Threading.Tasks;

const int Pin = 17;


using var controller = new GpioController();
controller.OpenPin(Pin, PinMode.Output);
controller.OpenPin(27, PinMode.Output);

controller.OpenPin(22, PinMode.Output);
controller.OpenPin(23, PinMode.Output);

Console.WriteLine("lenkung Zustand 1");
controller.Write(17, PinValue.High);
controller.Write(27, PinValue.Low);

await Task.Delay(500); // 0,5 Sekunden warten

Console.WriteLine("lenkung Zustand 2");
controller.Write(17, PinValue.Low);
controller.Write(27, PinValue.High);

await Task.Delay(500);

controller.Write(17, PinValue.Low);
controller.Write(27, PinValue.Low);

Console.WriteLine("Antrieb Zustand 1");
controller.Write(22, PinValue.High);
controller.Write(23, PinValue.Low);

await Task.Delay(500);

Console.WriteLine("Antrieb Zustand 2");
controller.Write(22, PinValue.Low);
controller.Write(23, PinValue.High);

await Task.Delay(500);

controller.Write(22, PinValue.Low);
controller.Write(23, PinValue.Low);