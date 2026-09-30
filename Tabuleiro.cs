using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_do_Velho
{
    public partial class Tabuleiro : Form
    {
        Player p1, p2, patual;
        internal void TrocarPlayer()
        {
            if (patual.Num == 1)
            {
                lbl_Turno2.Text = "O";
                lbl_Turno2.ForeColor = Color.Red;
                patual = p2;
            }
            else
            {
                lbl_Turno2.Text = "X";
                lbl_Turno2.ForeColor = Color.Blue;
                patual = p1;
            }
            if (p2.Ult)
            {
                lbl_RouboO2.Text = "1";
            }
            else
            {
                lbl_RouboO2.Text = "0";
            }
            if (p1.Ult)
            {
                lbl_RouboX2.Text = "1";
            }
            else
            {
                lbl_RouboX2.Text = "0";
            }

        }
        //adicionar que a casa não pode ser roubada duas vezes
         
        private void ApertarBotao( Button btn, Casa c)
        {
            if ((!c.preenchido || (patual.Ult && !c.roubada)) && c.caracter != patual.Marca)
            {
                if (c.preenchido)
                {
                    patual.Ult = false;
                    c.roubada = true;
                }
                if (patual.Num == 1)
                {
                    btn.ForeColor = Color.Blue;
                }
                else
                {
                    btn.ForeColor = Color.Red;
                }
                btn.Text = patual.Marca;
                c.caracter = patual.Marca;
                c.preenchido = true;
                this.VerificarTodas();
                this.TrocarPlayer();
            }
            
        }

        private void Resetar()
        {
            patual = p2;
            p1.Ult = true;
            p2.Ult = true;

            btn_A1.Text = "";
            btn_A1.Tag = new Casa();
            btn_A2.Text = ""; 
            btn_A2.Tag = new Casa();
            btn_A3.Text = ""; 
            btn_A3.Tag = new Casa();
            btn_A4.Text = ""; 
            btn_A4.Tag = new Casa();
            btn_B1.Text = ""; 
            btn_B1.Tag = new Casa();
            btn_B2.Text = ""; 
            btn_B2.Tag = new Casa();
            btn_B3.Text = ""; 
            btn_B3.Tag = new Casa();
            btn_B4.Text = ""; 
            btn_B4.Tag = new Casa();
            btn_C1.Text = ""; 
            btn_C1.Tag = new Casa();
            btn_C2.Text = ""; 
            btn_C2.Tag = new Casa();
            btn_C3.Text = ""; 
            btn_C3.Tag = new Casa();
            btn_C4.Text = ""; 
            btn_C4.Tag = new Casa();
            btn_D1.Text = ""; 
            btn_D1.Tag = new Casa();
            btn_D2.Text = ""; 
            btn_D2.Tag = new Casa();
            btn_D3.Text = ""; 
            btn_D3.Tag = new Casa();
            btn_D4.Text = ""; 
            btn_D4.Tag = new Casa();
        }

        private void Verificar(Casa c1, Casa c2, Casa c3, Casa c4)
        {
            if (c1.preenchido && c1.caracter == c2.caracter && c1.caracter == c3.caracter && c4.caracter == c1.caracter)
            {
                MessageBox.Show("Player " + patual.Num + " venceu!");
                this.Resetar();
            }
        }

        private void VerificarVelho()
        {
            if (((Casa)btn_A1.Tag).preenchido && ((Casa)btn_A2.Tag).preenchido && ((Casa)btn_A3.Tag).preenchido && ((Casa)btn_A4.Tag).preenchido && ((Casa)btn_B1.Tag).preenchido && ((Casa)btn_B2.Tag).preenchido && ((Casa)btn_B3.Tag).preenchido && ((Casa)btn_B4.Tag).preenchido && ((Casa)btn_C1.Tag).preenchido && ((Casa)btn_C2.Tag).preenchido && ((Casa)btn_C3.Tag).preenchido && ((Casa)btn_C4.Tag).preenchido && ((Casa)btn_D1.Tag).preenchido && ((Casa)btn_D2.Tag).preenchido && ((Casa)btn_D3.Tag).preenchido && ((Casa)btn_D4.Tag).preenchido)
            {
                MessageBox.Show("Deu velho! O jogo empatou.");
                this.Resetar();
            }
        }

        private void VerificarTodas()
        {
            Verificar((Casa)btn_A1.Tag, (Casa)btn_A2.Tag, (Casa)btn_A3.Tag, (Casa)btn_A4.Tag); // linha 1
            Verificar((Casa)btn_B1.Tag, (Casa)btn_B2.Tag, (Casa)btn_B3.Tag, (Casa)btn_B4.Tag); // linha 2
            Verificar((Casa)btn_C1.Tag, (Casa)btn_C2.Tag, (Casa)btn_C3.Tag, (Casa)btn_C4.Tag); // linha 3
            Verificar((Casa)btn_D1.Tag, (Casa)btn_D2.Tag, (Casa)btn_D3.Tag, (Casa)btn_D4.Tag); // linha 4
            Verificar(((Casa)btn_B1.Tag), ((Casa)btn_A1.Tag), ((Casa)btn_C1.Tag), ((Casa)btn_D1.Tag));// coluna 1
            Verificar(((Casa)btn_B2.Tag), ((Casa)btn_A2.Tag), ((Casa)btn_C2.Tag), ((Casa)btn_D2.Tag));// coluna 2
            Verificar(((Casa)btn_B3.Tag), ((Casa)btn_A3.Tag), ((Casa)btn_C3.Tag), ((Casa)btn_D3.Tag));// coluna 3
            Verificar(((Casa)btn_B4.Tag), ((Casa)btn_A4.Tag), ((Casa)btn_C4.Tag), ((Casa)btn_D4.Tag));// coluna 4
            Verificar(((Casa)btn_A1.Tag), ((Casa)btn_B2.Tag), ((Casa)btn_C3.Tag), ((Casa)btn_D4.Tag));// Diagonal principal
            Verificar(((Casa)btn_A4.Tag), ((Casa)btn_B3.Tag), ((Casa)btn_C2.Tag), ((Casa)btn_D1.Tag));// Diagonal secundária
            VerificarVelho();// Empate
        }

        private void btn_A2_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_A2, (Casa)btn_A2.Tag);
        }

        private void btn_A3_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_A3, (Casa)btn_A3.Tag);
        }

        private void btn_A4_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_A4, (Casa)btn_A4.Tag);
        }

        private void btn_B1_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_B1, (Casa)btn_B1.Tag);
        }

        private void btn_B2_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_B2, (Casa)btn_B2.Tag);
        }

        private void btn_B3_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_B3, (Casa)btn_B3.Tag);
        }

        private void btn_B4_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_B4, (Casa)btn_B4.Tag);
        }

        private void btn_C4_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_C4, (Casa)btn_C4.Tag);
        }

        private void btn_C3_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_C3, (Casa)btn_C3.Tag);
        }

        private void btn_C2_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_C2, (Casa)btn_C2.Tag);
        }

        private void btn_C1_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_C1, (Casa)btn_C1.Tag);
        }

        private void btn_D1_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_D1, (Casa)btn_D1.Tag);
        }

        private void btn_D2_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_D2, (Casa)btn_D2.Tag);
        }

        private void btn_D3_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_D3, (Casa)btn_D3.Tag);
        }

        private void btn_D4_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_D4, (Casa)btn_D4.Tag);
        }

        private void btn_A1_Click(object sender, EventArgs e)
        {
            this.ApertarBotao(btn_A1, (Casa)btn_A1.Tag);
        }

        public Tabuleiro()
        {
            InitializeComponent();
            p1 = new Player(1, "X");
            p2 = new Player(2, "O");
            patual = p1;
            btn_A1.Tag = new Casa();
            btn_A2.Tag = new Casa();
            btn_A3.Tag = new Casa();
            btn_A4.Tag = new Casa();
            btn_B1.Tag = new Casa();
            btn_B2.Tag = new Casa();
            btn_B3.Tag = new Casa();
            btn_B4.Tag = new Casa();
            btn_C1.Tag = new Casa();
            btn_C2.Tag = new Casa();
            btn_C3.Tag = new Casa();
            btn_C4.Tag = new Casa();
            btn_D1.Tag = new Casa();
            btn_D2.Tag = new Casa();
            btn_D3.Tag = new Casa();
            btn_D4.Tag = new Casa();
            
        }
    }
}
