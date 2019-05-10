using System;
using System.Collections.Generic;
using Senai.Desafio.AplicacaoFinanceira.Model;
using Senai.Desafio.AplicacaoFinanceira.Repositorio;

namespace Senai.Desafio.AplicacaoFinanceira.Controller {
    public class UsuarioController {
        
        static UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio ();

        public static void CadastrarUsuario () {
            string nome, email, senha;
            DateTime dataNascimento;

            Console.WriteLine ("Insira o nome do usuário");
            nome = Console.ReadLine ();
            Console.WriteLine ("Insira o email");
            email = Console.ReadLine ();
            Console.WriteLine ("Insira a senha");
            senha = Console.ReadLine ();
            Console.WriteLine ("Insira a data de nascimento");
            dataNascimento = DateTime.Parse (Console.ReadLine ());

            var usuario = new UsuarioModel ();
            usuario.Nome = nome;
            usuario.Senha = senha;
            usuario.Email = email;
            usuario.DataNascimento = dataNascimento;

            usuarioRepositorio.Inserir(usuario);

        }

        public static UsuarioModel FazerLogin(){
            string email, senha;
            Console.WriteLine("Insira o email");
            email = Console.ReadLine();
            Console.WriteLine("Insira a senha");
            senha = Console.ReadLine();
            var usuarioRetornado = usuarioRepositorio.BuscarUsuario(email, senha);
            if(usuarioRetornado != null){
                return usuarioRetornado;
            }
            return null;
        } 
    }
}