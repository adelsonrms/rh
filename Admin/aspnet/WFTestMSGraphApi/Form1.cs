using MSGraph.Services;
using MSGraphService.Models;
using MSGraphService.RestServices.Auth;
using System;
using System.Windows.Forms;

namespace WFTestMSGraphApi
{

    public partial class Form1 : Form
    {
        MSGraphApiService MSGraph = null;
        public Form1()
        {
            InitializeComponent();
            MSGraph = new MSGraphApiService(new AppClient());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtSobreNome.Text = "";
            txtEmail.Text = "";
            txtTelCel.Text = "";

            //Recupera informações sobre o perfil do usuario atraves do email
            var user = await MSGraph.GetUser<User>(txtEmailConsulta.Text);

            if (user.IsValid())
            {
                txtNome.Text = user.DisplayName;
                txtSobreNome.Text = user.Surname;
                txtEmail.Text = user.Mail;
                txtTelCel.Text = user.MobilePhone;
                MessageBox.Show("Consulta Finalizada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não foi possivel obter informações sobre o usuário", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
