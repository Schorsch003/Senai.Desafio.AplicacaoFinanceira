using System;
using System.Collections.Generic;
using System.IO;
using Senai.Desafio.AplicacaoFinanceira.Model;

namespace Senai.Desafio.AplicacaoFinanceira.Repositorio {
    public class UsuarioRepositorio {
        public void Inserir (UsuarioModel us) {
            List<UsuarioModel> lista = Listar ();
            int contador = 0;
            if (lista != null) {
                contador = lista.Count;
            }
            us.Id = contador + 1;

            StreamWriter sw = new StreamWriter ("usuarios.csv", true);
            sw.WriteLine ($"{us.Id};{us.Nome};{us.Email};{us.Senha};{us.DataNascimento};");
            sw.Close ();
        }

        public List<UsuarioModel> Listar () {
            var listaUsuarios = new List<UsuarioModel> ();
            UsuarioModel usuarioListado;

            if (!File.Exists ("usuarios.csv")) {
                return null;
            }

            string[] linhasUsuarios = File.ReadAllLines ("usuarios.csv");
            foreach (var item in linhasUsuarios) {
                if (item == null) {
                    return null;
                }
                usuarioListado = new UsuarioModel ();
                string[] dadosUsuarios = item.Split (";");
                for (int i = 0; i < dadosUsuarios.Length; i++) {
                    usuarioListado.Id = int.Parse (dadosUsuarios[0]);
                    usuarioListado.Nome = dadosUsuarios[1];
                    usuarioListado.Email = dadosUsuarios[2];
                    usuarioListado.Senha = dadosUsuarios[3];
                    usuarioListado.DataNascimento = DateTime.Parse (dadosUsuarios[4]);
                    listaUsuarios.Add (usuarioListado);
                }
            }
            return listaUsuarios;
        }

        public UsuarioModel BuscarUsuario (string email, string senha) {
            List<UsuarioModel> listaUsuarios = Listar ();

            foreach (var item in listaUsuarios) {

                if (item != null && item.Email == email && item.Senha == senha) {
                    return item;
                }
            }

            return null;
        }

    }
}