using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMARTHOME
{

    namespace SmartHome
    {
        public class Device
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsOn { get; set; }
            public virtual void TurnOn() => IsOn = true;
            public virtual void TurnOff() => IsOn = false;
            public virtual void Configure() { }
            public virtual void Update() { }
            public override string ToString() => $"{Name} - {(IsOn ? "On" : "Off")}";
        }

        public class Lightbulb : Device
        {
            public Lightbulb(string name, string description, bool isOn, int brightness)
            {
                this.Name = name;
                this.Description = description;
                this.IsOn = isOn;
                this.Brightness = brightness;
            }

            public int Brightness { get; set; }
            public string Color { get; set; }
            public override void Configure()
            {
                Console.Write("Enter brightness level (0-100): ");
                if (int.TryParse(Console.ReadLine(), out int level))
                {
                    Brightness = level;
                    Console.WriteLine($"Brightness set to {Brightness}");
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            public override string ToString() => $"{base.ToString()} (Brightness: {Brightness}, Color: {Color})";
        }

        public class Light : Device
        {
            public int Brightness { get; set; }
        }

        public class TV : Device
        {
            public string Channel { get; set; }
            public int Volume { get; set; }
        }

        public class AirConditioner : Device
        {
            public int Temperature { get; set; }
            public string FanSpeed { get; set; }
        }

        public class StoveOven : Device
        {
            public int Temperature { get; set; }
            public string Mode { get; set; }
        }

        public class ExhaustFan : Device
        {
            public int Speed { get; set; }
        }

        public class Humidifier : Device
        {
            public int Humidity { get; set; }
        }

        public class Blinds : Device
        {
            public string Position { get; set; }
        }


        public class Thermostat : Device
        {
            public int Temperature { get; set; }
            public string Mode { get; set; }


            public class SecurityCamera : Device
            {
                public string Resolution { get; set; }
                public bool IsRecording { get; set; }


                public class DeviceManager
                {
                    private List<Device> devices = new List<Device>();

                    public void AddDevice(Device device)
                    {
                        devices.Add(device);
                        Console.WriteLine($"Device {device.Name} added.");
                    }

                    public void RemoveDevice(string name)
                    {
                        var device = devices.Find(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (device != null)
                        {
                            devices.Remove(device);
                            Console.WriteLine($"Device {name} removed.");
                        }
                        else
                        {
                            Console.WriteLine("Device not found.");
                        }
                    }

                    public void TurnOnAllDevices()
                    {
                        foreach (var device in devices)
                        {
                            device.TurnOn();
                        }
                        Console.WriteLine("All devices turned on.");
                    }

                    public void TurnOffAllDevices()
                    {
                        foreach (var device in devices)
                        {
                            device.TurnOff();
                        }
                        Console.WriteLine("All devices turned off.");
                    }

                    public void TurnOnDevice(string name)
                    {
                        var device = devices.Find(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (device != null)
                        {
                            device.TurnOn();
                            Console.WriteLine($"{name} turned on.");
                        }
                        else
                        {
                            Console.WriteLine("Device not found.");
                        }
                    }

                    public void TurnOffDevice(string name)
                    {
                        var device = devices.Find(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (device != null)
                        {
                            device.TurnOff();
                            Console.WriteLine($"{name} turned off.");
                        }
                        else
                        {
                            Console.WriteLine("Device not found.");
                        }
                    }

                    public void ConfigureDevice(string name)
                    {
                        name = name.Trim(); // Trim any leading or trailing spaces
                        var device = devices.Find(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (device != null)
                        {
                            Console.WriteLine($"\nConfiguring {device.Name} ({device.GetType().Name})");

                            switch (device)
                            {
                                case Lightbulb lightbulb:
                                    Console.Write("Enter brightness (1-100): ");
                                    lightbulb.Brightness = GetValidInput(1, 100);
                                    Console.Write("Enter color: ");
                                    lightbulb.Color = Console.ReadLine();
                                    break;

                                case Light light:
                                    Console.Write("Turn on? (yes/no): ");
                                    light.IsOn = Console.ReadLine().ToLower() == "yes";
                                    Console.Write("Enter brightness (1-100): ");
                                    light.Brightness = GetValidInput(1, 100);
                                    break;

                                case TV tv:
                                    Console.Write("Enter channel: ");
                                    tv.Channel = Console.ReadLine();
                                    Console.Write("Enter volume (1-100): ");
                                    tv.Volume = GetValidInput(1, 100);
                                    break;

                                case AirConditioner ac:
                                    Console.Write("Set temperature (16-30): ");
                                    ac.Temperature = GetValidInput(16, 30);
                                    Console.Write("Enter fan speed (Low/Medium/High): ");
                                    ac.FanSpeed = Console.ReadLine();
                                    break;

                                case StoveOven stove:
                                    Console.Write("Set temperature (100-500): ");
                                    stove.Temperature = GetValidInput(100, 500);
                                    Console.Write("Enter mode (Bake/Broil): ");
                                    stove.Mode = Console.ReadLine();
                                    break;

                                case ExhaustFan fan:
                                    Console.Write("Enter speed level (1-5): ");
                                    fan.Speed = GetValidInput(1, 5);
                                    break;

                                case Humidifier humidifier:
                                    Console.Write("Set humidity level (30-70): ");
                                    humidifier.Humidity = GetValidInput(30, 70);
                                    break;

                                case Blinds blinds:
                                    Console.Write("Enter position (Open/Close/Half): ");
                                    blinds.Position = Console.ReadLine();
                                    break;

                                case Thermostat thermostat:
                                    Console.Write("Set temperature (16-30): ");
                                    thermostat.Temperature = GetValidInput(16, 30);
                                    Console.Write("Enter mode (Heating/Cooling): ");
                                    thermostat.Mode = Console.ReadLine();
                                    break;

                                case SecurityCamera camera:
                                    Console.Write("Enter resolution (e.g., 1080p, 4K): ");
                                    camera.Resolution = Console.ReadLine();
                                    Console.Write("Start recording? (yes/no): ");
                                    camera.IsRecording = Console.ReadLine().ToLower() == "yes";
                                    break;

                                default:
                                    Console.WriteLine("No configurable settings for this device.");
                                    break;
                            }

                            Console.WriteLine("Device configured.");
                            // Display the current state of the configured device
                            DisplayDeviceState(device);
                        }
                        else
                        {
                            Console.WriteLine("Device not found.");
                            // Debugging output to see the current devices
                            Console.WriteLine("Current devices:");
                            foreach (var d in devices)
                            {
                                Console.WriteLine(d.Name);
                            }
                        }
                    }

                    private void DisplayDeviceState(Device device)
                    {
                        switch (device)
                        {
                            case Lightbulb lightbulb:
                                Console.WriteLine($"Lightbulb - Brightness: {lightbulb.Brightness}, Color: {lightbulb.Color}");
                                break;

                            case Light light:
                                Console.WriteLine($"Light - Is On: {light.IsOn}, Brightness: {light.Brightness}");
                                break;

                            case TV tv:
                                Console.WriteLine($"TV - Channel: {tv.Channel}, Volume: {tv.Volume}");
                                break;

                            case AirConditioner ac:
                                Console.WriteLine($"Air Conditioner - Temperature: {ac.Temperature}, Fan Speed: {ac.FanSpeed}");
                                break;

                            case StoveOven stove:
                                Console.WriteLine($"Stove Oven - Temperature: {stove.Temperature}, Mode: {stove.Mode}");
                                break;

                            case ExhaustFan fan:
                                Console.WriteLine($"Exhaust Fan - Speed Level: {fan.Speed}");
                                break;

                            case Humidifier humidifier:
                                Console.WriteLine($"Humidifier - Humidity Level: {humidifier.Humidity}");
                                break;

                            case Blinds blinds:
                                Console.WriteLine($"Blinds - Position: {blinds.Position}");
                                break;

                            case Thermostat thermostat:
                                Console.WriteLine($"Thermostat - Temperature: {thermostat.Temperature}, Mode: {thermostat.Mode}");
                                break;

                            case SecurityCamera camera:
                                Console.WriteLine($"Security Camera - Resolution: {camera.Resolution}, Recording: {camera.IsRecording}");
                                break;

                            default:
                                Console.WriteLine("Unknown device type.");
                                break;
                        }
                    }

                    public void UpdateDevice(string name)
                    {
                        var device = devices.Find(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (device != null)
                        {
                            device.Update();
                        }
                        else
                        {
                            Console.WriteLine("Device not found.");
                        }
                    }

                    public void ListDevices()
                    {
                        Console.WriteLine("\nDevices:");
                        foreach (var device in devices)
                        {
                            Console.WriteLine(device);
                        }
                        Console.WriteLine();
                    }


                    // Helper method to ensure valid input within a specified range
                    private int GetValidInput(int minValue, int maxValue)
                    {
                        int input;
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out input) && input >= minValue && input <= maxValue)
                            {
                                return input;
                            }
                            else
                            {
                                Console.WriteLine($"Please enter a valid number between {minValue} and {maxValue}: ");
                            }
                        }
                    }
                }

                class Program
                {
                    static void Main(string[] args)
                    {
                        DeviceManager manager = new DeviceManager();
                        bool running = true;

                        while (running)
                        {
                            Console.WriteLine("Smart Home Control Panel");
                            Console.WriteLine("1. List Devices");
                            Console.WriteLine("2. Add Device");
                            Console.WriteLine("3. Remove Device");
                            Console.WriteLine("4. Turn On Device");
                            Console.WriteLine("5. Turn Off Device");
                            Console.WriteLine("6. Configure Device");
                            Console.WriteLine("7. Update Device");
                            Console.WriteLine("8. Turn On All Devices");
                            Console.WriteLine("9. Turn Off All Devices");
                            Console.WriteLine("0. Exit");
                            Console.Write("Select an option: ");

                            string input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    manager.ListDevices();
                                    break;
                                case "2":
                                    Console.WriteLine("Select device type to add:");
                                    Console.WriteLine("1. Lightbulb");
                                    Console.WriteLine("2. TV");
                                    Console.WriteLine("3. Light");
                                    Console.WriteLine("4. Air Conditioner");
                                    Console.WriteLine("5. Stove/Oven");
                                    Console.WriteLine("6. Exhaust Fan");
                                    Console.WriteLine("7. Humidifier");
                                    Console.WriteLine("8. Blinds");
                                    Console.WriteLine("9. Thermostat");
                                    Console.WriteLine("10. Security Camera");

                                    string type = Console.ReadLine();
                                    Console.Write("Enter device name: ");
                                    string name = Console.ReadLine();
                                    Console.Write("Enter device description: ");
                                    string desc = Console.ReadLine();

                                    switch (type)
                                    {
                                        case "1":
                                            Console.Write("Enter brightness (0-100): ");
                                            int brightness = int.Parse(Console.ReadLine());
                                            manager.AddDevice(new Lightbulb(name, desc, false, brightness));
                                            break;
                                        case "2":
                                            manager.AddDevice(new TV { Name = name, Description = desc, IsOn = false });
                                            break;
                                        case "3":
                                            manager.AddDevice(new Light { Name = name, Description = desc, IsOn = false });
                                            break;
                                        case "4":
                                            manager.AddDevice(new AirConditioner { Name = name, Description = desc, IsOn = false });
                                            break;
                                        case "5":
                                            manager.AddDevice(new StoveOven { Name = name, Description = desc, IsOn = false });
                                            break;
                                        case "6":
                                            manager.AddDevice((new ExhaustFan { Name = name, Description = desc, IsOn = false }));
                                            break;
                                        case "7":
                                            manager.AddDevice(new Humidifier { Name = name, Description = desc, IsOn = false });
                                            break;
                                        case "8":
                                            manager.AddDevice(new Blinds { Name = name, Description = desc, IsOn = false });
                                            break;
                                        case "9":
                                            manager.AddDevice(new Thermostat { Name = name, Description = desc, IsOn = false });
                                            break;
                                        case "10":
                                            manager.AddDevice(new SecurityCamera { Name = name, Description = desc, IsOn = false });
                                            break;
                                        default:
                                            Console.WriteLine("Invalid type.");
                                            break;
                                    }
                                    break;

                                case "3":
                                    Console.Write("Enter device name to remove: ");
                                    manager.RemoveDevice(Console.ReadLine().Trim());
                                    break;
                                case "4":
                                    Console.Write("Enter device name to turn on: ");
                                    manager.TurnOnDevice(Console.ReadLine().Trim());
                                    break;
                                case "5":
                                    Console.Write("Enter device name to turn off: ");
                                    manager.TurnOffDevice(Console.ReadLine().Trim());
                                    break;
                                case "6":
                                    Console.Write("Enter device name to configure: ");
                                    manager.ConfigureDevice(Console.ReadLine().Trim());
                                    break;
                                case "7":
                                    Console.Write("Enter device name to update: ");
                                    manager.UpdateDevice(Console.ReadLine().Trim());
                                    break;
                                case "8":
                                    manager.TurnOnAllDevices();
                                    break;
                                case "9":
                                    manager.TurnOffAllDevices();
                                    break;

                                case "0":
                                    running = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid option.");
                                    break;
                            }

                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}