using Aclerbois.GameOfLife.Business.Models;
using System.Text;

namespace Aclerbois.GameOfLife.Console
{
    public class Drawer
    {
        private const char leftTopCornerSymbol = '╔';
        private const char leftBottomCornerSymbol = '╚';
        private const char rightTopCornerSymbol = '╗';
        private const char rightBottomCornerSymbol = '╝';
        private const char horizontalSymbol = '═';
        private const char verticalSymbol = '║';
        private const string lifeCellularSymbol = "██";
        private const string deadCellularSymbol = "  ";

        public void DrawLogo()
        {
            System.Console.WriteLine(
@"  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████    █████▒    ██▓     ██▓  █████▒▓█████ 
 ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██   ▒    ▓██▒    ▓██▒▓██   ▒ ▓█   ▀ 
▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒▒████ ░    ▒██░    ▒██▒▒████ ░ ▒███   
░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░░▓█▒  ░    ▒██░    ░██░░▓█▒  ░ ▒▓█  ▄ 
░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░░▒█░       ░██████▒░██░░▒█░    ░▒████▒
 ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░  ▒ ░       ░ ▒░▓  ░░▓   ▒ ░    ░░ ▒░ ░
  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░  ░         ░ ░ ▒  ░ ▒ ░ ░       ░ ░  ░
░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒   ░ ░         ░ ░    ▒ ░ ░ ░       ░   
      ░       ░  ░       ░      ░  ░       ░ ░                 ░  ░ ░             ░  ░
                                                              powered by AClerbois");
        }

        public void DrawGeneration(Generation generation)
        {
            ClearConsole();
            DrawLogo();
            DrawSeparator();
            DrawGenerationArray(generation);
            DrawMetaDataGeneration(generation);
            DrawCloseExplaination();
        }

        private void DrawCloseExplaination()
        {
            WriteLine($"To close the application. [Ctrl]+[c]");
        }

        private void DrawMetaDataGeneration(Generation generation)
        {
            WriteLine($"Generation information");
            WriteLine($"----------------------");
            WriteLine($"Count : {generation.GenerationNumber}");
            WriteLine($"Size : {generation.GenerationSize.Width}x{generation.GenerationSize.Height}");
            WriteLine($"----------------------");
        }

        private void DrawGenerationArray(Generation generation)
        {
            var horizontalLine = new string(horizontalSymbol, generation.GenerationSize.Width * 2);
            WriteLine($"{leftTopCornerSymbol}{horizontalLine}{rightTopCornerSymbol}");

            for (int row = 0; row < generation.GenerationSize.Height; row++)
            {
                var line = new StringBuilder();
                line.Append(verticalSymbol);
                for (int column = 0; column < generation.GenerationSize.Width; line.Append(generation.CurrentGeneration[row, column++] ? lifeCellularSymbol : deadCellularSymbol)) ;
                line.Append(verticalSymbol);
                WriteLine(line.ToString());
            }
            WriteLine($"{leftBottomCornerSymbol}{horizontalLine}{rightBottomCornerSymbol}");
        }

        private void ClearConsole()
        {
            System.Console.SetCursorPosition(0, 0);
        }

        private void DrawSeparator()
        {
            System.Console.WriteLine("======================================================================================");
        }

        private void WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }

        private void Write(string text)
        {
            System.Console.Write(text);
        }
    }
}
