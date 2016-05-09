﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APS_5.Code;
using APS_5.Forms;

namespace APS_5.Forms
{
    public partial class TelaInicial : FormBridge
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var NomeUsuario = textBox1.Text;
            var IPServidor = textBox2.Text;
            string AntiBug = @"(\s+|^$)";
            if (System.Text.RegularExpressions.Regex.IsMatch(NomeUsuario, AntiBug))
            {
                MessageBox.Show("Nome Inválido, não é permitido o uso de espaço.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (ComunicacaoServidor.Conectar(NomeUsuario, IPServidor))
            {
                Telas.telaChat = new TelaChat();
                Telas.telaChat.Show();
                Telas.telaInicial.Close(true);
            }
            else {
                MessageBox.Show("Nome ou IP inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
        }
         
    }
}
