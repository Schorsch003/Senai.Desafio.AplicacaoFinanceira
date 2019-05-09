using System;

namespace Senai.Desafio.AplicacaoFinanceira.Utils {
    public class MenuUtils {

        public static int MenuDeslogado () {
            Console.WriteLine("-----------------------------------------");
            Console.Write("|      Bem vindo ao ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("BANCO THESCHOR    ");
            Console.ResetColor();
            Console.WriteLine("  |");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("|    1 - Cadastrar novo usuário         |");
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine("|    2 - Login                          |");
            Console.WriteLine("-----------------------------------------");
            Console.Write("código: ");
            return int.Parse(Console.ReadLine());

        }
    }
}