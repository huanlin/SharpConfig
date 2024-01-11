// Copyright (c) 2022 Michael Tsai, MIT License.
// https://github.com/huanlin/SharpConfig

using Example2.Config;

var config = AppConfig.GetInstance();
config.Load();

Console.WriteLine($"PrinterName: {config.Printing.PrinterName}");
Console.WriteLine($"AutoUpdate: {config.General.AutoUpdate}");
Console.WriteLine($"PrintTextFontSize: {config.Printing.PrintTextFontSize}");

Console.Write("Enter printer name: ");
var printerName = Console.ReadLine();
config.Printing.PrinterName = printerName;

// toggle AutoUpdate setting and save to file.
config.General.AutoUpdate = !config.General.AutoUpdate;

// Save to file
config.Save();

