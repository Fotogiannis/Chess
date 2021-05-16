using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form2 : Form
    {
        public static String text1;//Αρχικοποίηση της μεταβλητής text1
        public static String text2;//Αρχικοποίηση της μεταβλητής text2
        public static int count;//Αρχικοποίηση της μεταβλητής count
        public Form2()
        {
            InitializeComponent();
        }

        public static String returnText1()//Επιστρέφει το text1
        {
            return text1;
        }

        public static String returnText2()//Επιστρέφει το text2
        {
            return text2;
        }

        public static int returnCount()//Επιστρέφει το count
        {
            return count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = 180;//Αρχικοποίηση του count σε 3 λεπτά
            text1 = textBox1.Text;//Εισαγωγή του εσωτερικού του textΒox1 στην μεταβλητή text1
            text2 = textBox2.Text;//Εισαγωγή του εσωτερικού του textΒox2 στην μεταβλητή text2
            Form1 form1 = new Form1();//Αρχικοποίηση της φόρμας 1
            this.Hide();//Κλείσε αυτήν την φόρμα
            form1.ShowDialog();//Εμφάνιση της φόρμας 1
            this.Close();//Κλείσε αυτήν την φόρμα
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count = 300;//Αρχικοποίηση του count σε 5 λεπτά
            text1 = textBox1.Text;//Εισαγωγή του εσωτερικού του textΒox1 στην μεταβλητή text1
            text2 = textBox2.Text;//Εισαγωγή του εσωτερικού του textΒox2 στην μεταβλητή text2
            Form1 form1 = new Form1();//Αρχικοποίηση της φόρμας 1
            this.Hide();//Κλείσε αυτήν την φόρμα
            form1.ShowDialog();//Εμφάνιση της φόρμας 1
            this.Close();//Κλείσε αυτήν την φόρμα
        }

        private void button3_Click(object sender, EventArgs e)
        {
            count = 600;//Αρχικοποίηση του count σε 10 λεπτά
            text1 = textBox1.Text;//Εισαγωγή του εσωτερικού του textΒox1 στην μεταβλητή text1
            text2 = textBox2.Text;//Εισαγωγή του εσωτερικού του textΒox2 στην μεταβλητή text2
            Form1 form1 = new Form1();//Αρχικοποίηση της φόρμας 1
            this.Hide();//Κλείσε αυτήν την φόρμα
            form1.ShowDialog();//Εμφάνιση της φόρμας 1
            this.Close();//Κλείσε αυτήν την φόρμα
        }
    }
}
