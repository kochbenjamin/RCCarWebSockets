using RCCarWebSockets;
using System.Device.Gpio;
using System.Threading.Tasks;

var controller = new MotorController();



controller.TurnLeft();

await Task.Delay(500); // 0,5 Sekunden warten

controller.TurnRight();

await Task.Delay(500);

//controller.TurnStop();

controller.DriveForward();

await Task.Delay(500);

controller.DriveBackWard();

await Task.Delay(500);

controller.DriveStop();