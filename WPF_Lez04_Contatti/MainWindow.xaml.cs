using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Lez04_Contatti.Models;
using WPF_Lez04_Contatti.Models.DAL;

namespace WPF_Lez04_Contatti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         
            
            
        }
        private List<Contatto> GetContatti()
        {
            return ContattoDao.GetInstance().GetAll();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

            string varNome = this.txtNome.Text;
            if (varNome.Trim().Equals(""))
            {
                MessageBox.Show("Errore nome vuoto");
                return;
            }

            string varCogn = this.txtCognome.Text;
             if (varCogn.Trim().Equals(""))
            {
                MessageBox.Show("erroe cognome vuoto ");
                return;
            }
             
             string varEmail = this.txtEmail.Text;
            if (varEmail.Trim().Equals(""))
            {
                MessageBox.Show("errore email vuot");
                return;
            }
           

            string varCodFis = this.txtCodFis.Text;
            if (varCodFis.Trim().Equals(""))
            {
                MessageBox.Show("errore Codice Fiscale vuoto");
                return;
            }


            Contatto con = new Contatto()
            {
                Nome = varNome,
                Cognome = varCogn,
                Email=varEmail,
                CodFis = varCodFis,
            };

            if (ContattoDao.GetInstance().Insert(con)){

            
                this.txtNome.Text = "";
                this.txtCognome.Text = "";
                this.txtEmail.Text = "";
                this.txtCodFis.Text = "";

                
            }
            else
            {
                MessageBox.Show("errore di inserimento");
            }

            


        }
        private void btn_OpenTable_Click(object sender, RoutedEventArgs e)
        {
            TabellaContatti contattiWindow = new TabellaContatti();

  
            contattiWindow.dgContatti.ItemsSource = GetContatti();

            // Mostra la nuova finestra
            contattiWindow.Show();
        }

    }
}