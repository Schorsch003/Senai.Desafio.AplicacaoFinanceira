using System;

namespace Senai.Desafio.AplicacaoFinanceira.Utils {
    public class MenuUtils {

        public static int MenuDeslogado () {
            Console.WriteLine ("-----------------------------------------");
            Console.Write ("|      Bem vindo ao ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write ("BANCO THESCHOR    ");
            Console.ResetColor ();
            Console.WriteLine ("  |");
            Console.WriteLine ("-----------------------------------------");
            Console.WriteLine ("|    1 - Cadastrar novo usuário         |");
            Console.WriteLine ("|---------------------------------------|");
            Console.WriteLine ("|    2 - Login                          |");
            Console.WriteLine ("|---------------------------------------|");
            Console.WriteLine ("|    0 - Sair                           |");
            Console.WriteLine ("-----------------------------------------");
            Console.Write ("código: ");
            return int.Parse (Console.ReadLine ());

        }

        public static int MenuLogado () {
            Console.WriteLine ("-----------------------------------------");
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write ("            BANCO THESCHOR           ");
            Console.ResetColor ();
            Console.WriteLine ("  |");
            Console.WriteLine ("-----------------------------------------");
            Console.WriteLine ("|   1 - Inserir crédito                 |");
            Console.WriteLine ("|---------------------------------------|");
            Console.WriteLine ("|   2 - Realizar Transição              |");
            Console.WriteLine ("|---------------------------------------|");
            Console.WriteLine ("|   3 - Visualizar Transações           |");
            Console.WriteLine ("|---------------------------------------|");
            Console.WriteLine ("|   4 - Visualizar Situação da conta    |");
            Console.WriteLine ("|---------------------------------------|");
            Console.WriteLine ("|   0 - Encerar transação               |");
            Console.WriteLine ("-----------------------------------------");
            Console.WriteLine("Selecione uma opção acima:");
            return int.Parse (Console.ReadLine());

         }
    }
}