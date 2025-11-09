using MinhaEmpresa.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinhaEmpresa.Apresentacao
{
    public partial class EditaFuncionario : Form
    {

        private int idFuncionario;

        private ListaFuncionarios instaciaFormLista;
        public EditaFuncionario()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void AbrirEdicao(Funcionario funcionario, ListaFuncionarios formLista)
        {
            this.textBox1.Text = funcionario.Nome;
            this.comboBox1.SelectedItem = funcionario.Cargo;
            this.dateTimePicker1.Value = funcionario.DataContratacao;
            this.comboBox2.SelectedItem = funcionario.Departamento;
            this.numericUpDown1.Value = funcionario.Salario;
            this.idFuncionario = funcionario.ID;
            instaciaFormLista = formLista;
            this.ShowDialog();
        }
        

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (ValidaFormulario())
            {
                var dao = new Dados.FuncionarioDao();
                dao.EditaFuncionario(new Funcionario
                {
                    Nome = textBox1.Text,
                    Cargo = comboBox1.SelectedItem.ToString(),
                    Departamento = comboBox2.SelectedItem.ToString(),
                    DataContratacao = dateTimePicker1.Value,
                    Salario = numericUpDown1.Value,
                    ID = this.idFuncionario
                });
                //instaciaFormLista.AtualizarGrid();
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

            if(numericUpDown1.Value.Equals(0))
            {
                MessageBox.Show("O campo Salário deve ser maior que zero.");
                numericUpDown1.Focus();
                return false;
            }

            return true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
