using RCCarWebSockets;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var controller = new MotorController();

app.UseWebSockets();

app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        Console.WriteLine("WebSocket connected");

        var buffer = new byte[1024 * 4];

        while (true)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            if (result.MessageType == WebSocketMessageType.Close)
            {
                Console.WriteLine("WebSocket closed");
                break;
            }

            var jsonString = Encoding.UTF8.GetString(buffer, 0, result.Count);
            Console.WriteLine("Received JSON: " + jsonString);

            try
            {
                var command = JsonDocument.Parse(jsonString);
                var type = command.RootElement.GetProperty("type").GetString();
                if (command != null)
                {

                    switch (type)
                    {
                        case "drive":
                            var direction = command.RootElement.GetProperty("value").GetString();
                            HandleDrive(direction);
                            break;

                        case "turn":
                            var steerDir = command.RootElement.GetProperty("value").GetString();
                            HandleTurn(steerDir);
                            break;
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid JSON: " + ex.Message);
            }
        }
    }
    else
    {
        context.Response.StatusCode = 400;
    }
});

void HandleDrive(string direction)
{
    switch (direction)
    {
        case "forward":
            controller.DriveForward();
            break;
        case "backward":
            controller.DriveBackWard();
            break;
        case "stop":
            controller.DriveStop();
            break;
    }
}

void HandleTurn(string direction)
{
    switch (direction)
    {
        case "left":
            controller.TurnLeft();
            break;
        case "right":
            controller.TurnRight();
            break;
        case "stop":
            controller.TurnStop();
            break;
    }
}

app.Run("http://0.0.0.0:5000");


/*public class ControlCommand
{
    public string Direction { get; set; } = "";
    public int Drive { get; set; }
}

/*
var controller = new MotorController();



controller.TurnLeft();

await Task.Delay(500); // 0,5 Sekunden warten

controller.TurnRight();

await Task.Delay(500);

controller.TurnStop();

controller.DriveForward();

await Task.Delay(500);

controller.DriveBackWard();

await Task.Delay(500);

controller.DriveStop();*/