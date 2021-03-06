﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace APS_5.Code
{
    static class ComunicacaoServidor
    {
        private static Connection conexao;
        private static string servidor;
        private static string usuario;

        public static IList<string> ListarUsuariosOnline()
        {
            conexao = new Connection(servidor);
            dynamic resposta = conexao.SendData(new { tipo = "obter-usuarios-online"});
            if (resposta.status != "ok") return null;

            return resposta.data.ToObject<List<string>>();
        }

        public static IList<Mensagem> ListarMensagens()
        {
            conexao = new Connection(servidor);
            dynamic resposta = conexao.SendData(new { tipo = "obter-mensagens" });
            return resposta.ToObject<List<Mensagem>>();
        }

        public static bool EnviarMensagem(string mensagem)
        {
            conexao = new Connection(servidor);
            dynamic resposta = conexao.SendData(new { tipo = "enviar-mensagem", usuario = usuario, mensagem = mensagem });
            if (resposta.status != "ok") return false;
            return true;
        }

        public static bool Conectar(string nome, string servidorTemp)
        {



            try
            {
                servidor = servidorTemp;
                usuario = nome;
                conexao = new Connection(servidor);
                dynamic resposta = conexao.SendData(new { tipo = "definir-nome", nome = nome});
                if (resposta.status == "ok")
                    return true;
                else
                    return false;
            }

            catch(Exception e) {


                return false;
            
            }
         }
         
        public static bool Desconectar ()
        {
            try
            {
                conexao = new Connection(servidor);
                dynamic resposta = conexao.SendData (new { tipo = "desconectar", usuario = usuario});
                //conexao.Disconnect();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

       // public static bool VerificarNovasMensagens(string)
        public static Mensagem ReceberMensagem()
        {
            return new Mensagem
            {
                usuario = "Victor",
                mensagem = "Blablabla"
            };
        }
    }
}