using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace WPF_Lez04_Contatti.Models.DAL
{
    internal class ContattoDao : IDao<Contatto>
    {
        private static ContattoDao? instance;
        public static ContattoDao GetInstance() 
        { 

        if  (instance == null)
            instance =new ContattoDao();

        return instance; 
            }
         private ContattoDao() { }
        public List<Contatto> GetAll()
        {
            List<Contatto> elenco = new List<Contatto>();
            using (var ctx = new Lez03RubricaContext())
            {
                elenco = ctx.Contattos.ToList();
            }
            return  elenco;

        }

        public Contatto? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Contatto t)
        {
           bool risultato = false;
            using (var ctx = new Lez03RubricaContext())
            {
                try
                {
                    ctx.Contattos.Add(t);
                    ctx.SaveChanges();
                    risultato = true;
                    MessageBox.Show("Dati inseriti con successo");            
                 }

                catch (Exception ex) {

                    MessageBox.Show(ex.Message);
                }
            }

            return risultato;
        }



    }
}
