using EstoqueEntityFramework.Model;
using MessageUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstoqueEntityFramework
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            using (var db = new EstoqueContext())
            {
                AtualizarCbxCategorias(db);
            }
        }

        private void btnAdicionarCategoria_Click(object sender, EventArgs e)
        {
            using (var form = new FormCategoria())
            {
                form.Text = "Adicionando Categoria";
                form.btnSalvar.DialogResult = DialogResult.OK;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    using (var db = new EstoqueContext())
                    {
                        Categoria categoria = new Categoria();
                        categoria.Nome = form.txtNome.Text;
                        db.Categorias.Add(categoria);
                        db.SaveChanges();
                        AtualizarCbxCategorias(db);
                        SimpleMessage.Inform("Categoria adicionada com sucesso.", "Informação");
                    }
                }
            }
        }

        private void AtualizarCbxCategorias(EstoqueContext db)
        {
            cbxCategorias.DataSource = db.Categorias.ToList();
            cbxCategorias.DisplayMember = "Nome";
            cbxCategorias.ValueMember = "IdCategoria";
        }
    }
}
