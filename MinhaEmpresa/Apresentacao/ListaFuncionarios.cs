using MinhaEmpresa.Dados;
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
    public partial class ListaFuncionarios : Form
    {
        public ListaFuncionarios()
        {
            InitializeComponent();
        }

        private void ListaFuncionarios_Load(object sender, EventArgs e)
        {
            var dao = new FuncionarioDao();
            var lista = dao.ListarFuncionarios();

            dataGridView1.DataSource = lista;

            if (!dataGridView1.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn
                {
                    HeaderText = "Editar",
                    Name = "Editar",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(btnCol);
            }

            if (!dataGridView1.Columns.Contains("Remover"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn
                {
                    HeaderText = "Remover",
                    Name = "Remover",
                    Text = "Remover",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(btnCol);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Editar" && e.RowIndex >= 0)
            {
                var editarFuncionarioForm = new EditaFuncionario();
                var funcionario = new Funcionario
                {
                    ID = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value,
                    Nome = dataGridView1.Rows[e.RowIndex].Cells["Nome"].Value.ToString(),
                    Cargo = dataGridView1.Rows[e.RowIndex].Cells["Cargo"].Value.ToString(),
                    Departamento = dataGridView1.Rows[e.RowIndex].Cells["Departamento"].Value.ToString(),
                    DataContratacao = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["DataContratacao"].Value,
                    Salario = (decimal)dataGridView1.Rows[e.RowIndex].Cells["Salario"].Value
                };
                editarFuncionarioForm.AbrirEdicao(funcionario, this);
                AtualizarGrid();
            }

            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Remover" && e.RowIndex >= 0)
            {
                try
                {
                    var dao = new FuncionarioDao();
                    int id = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                    dao.RemoverFuncionario(id);
                    AtualizarGrid();
                }
                catch (Exception)
                {

                    MessageBox.Show("não foi possível excluir usuário");
                }

            }

        }


        public void AtualizarGrid()
        {
            var dao = new FuncionarioDao();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dao.ListarFuncionarios();
            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["Nome"].DisplayIndex = 1;
            dataGridView1.Columns["Cargo"].DisplayIndex = 2;
            dataGridView1.Columns["Departamento"].DisplayIndex = 3;
            dataGridView1.Columns["DataContratacao"].DisplayIndex = 4;
            dataGridView1.Columns["Salario"].DisplayIndex = 5;
            dataGridView1.Columns["Editar"].DisplayIndex = 6;
            dataGridView1.Columns["Remover"].DisplayIndex = 6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
