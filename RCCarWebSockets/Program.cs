using System.Device.Gpio;
using System.Threading.Tasks;

const int Pin = 17;
const string Alert = "ALERT 🚨";
const string Ready = "READY ✅";

using var controller = new GpioController();
controller.OpenPin(Pin, PinMode.InputPullUp);

Console.WriteLine(
    $"Initial status ({DateTime.Now}): {(controller.Read(Pin) == PinValue.High ? Alert : Ready)}");


DateTime starttime = DateTime.Now;

while (DateTime.Now - starttime < TimeSpan.FromSeconds(1))
{
    Console.WriteLine( "Writing High Value");
    controller.Write(Pin, PinValue.High);
}

/*controller.RegisterCallbackForPinValueChangedEvent(
    Pin,
    PinEventTypes.Falling | PinEventTypes.Rising,
    OnPinEvent);

await Task.Delay(Timeout.Infinite);

static void OnPinEvent(object sender, PinValueChangedEventArgs args)
{
    Console.WriteLine(
        $"({DateTime.Now}) {(args.ChangeType is PinEventTypes.Rising ? Alert : Ready)}");
}*/