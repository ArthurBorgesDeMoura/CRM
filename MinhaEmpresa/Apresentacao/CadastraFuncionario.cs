using MinhaEmpresa.Apresentacao;
using MinhaEmpresa.Dados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinhaEmpresa
{
    public partial class CadastraFuncionario : Form
    {
        public CadastraFuncionario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.numericUpDown1.Controls[1].Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (ValidaFormulario())
            {
                var dao = new FuncionarioDao();
                dao.AdicionarFuncionario(new Negocio.Funcionario
                {
                    Nome = textBox1.Text,
                    Cargo = comboBox1.SelectedItem.ToString(),
                    Departamento = comboBox2.SelectedItem.ToString(),
                    DataContratacao = dateTimePicker1.Value,
                    Salario = numericUpDown1.Value
                });
                this.Close();
            }
        }

        private bool ValidaFormulario()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("O campo Nome é obrigatório.");
                textBox1.Focus();
                return false;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("O campo Cargo é obrigatório.");
                comboBox1.Focus();
                return false;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("O campo Departamento é obrigatório.");
                comboBox1.Focus();
                return false;
            }

            if (dateTimePicker1.Value > DateTime.Now)
            {
                MessageBox.Show("A data de admissão não pode ser maior que a data atual.");
                dateTimePicker1.Focus();
                return false;
            }

            if (!dateTimePicker1.Checked)
            {
                MessageBox.Show("O campo Data de Contratação é obrigatório.");
                dateTimePicker1.Focus();
                return false;
            }

            if (numericUpDown1.Value.Equals(0))
            {
                MessageBox.Show("O campo Salário deve ser maior que zero.");
                numericUpDown1.Focus();
                return false;
            }

            return true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
