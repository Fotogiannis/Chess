using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        private Point point;//Αρχικοποίηση της μεταβλητής point
        bool move;//Αρχικοποίηση της μεταβλητής move
        int countDown;//Αρχικοποίηση της μεταβλητής countDown
        int countDown2;//Αρχικοποίηση της μεταβλητής countDown2
        String connectionString = "Data Source=ChessDB.db;Version=3;";//Το String της σύνδεσης με την βάση
        SQLiteConnection conn;//Αρχικοποίηση σύνδεσης με την βάση
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            point = e.Location;//Εκχώρηση της θέσης του κέρσορα στην μεταβλητή point
            move = true;//Aρχικοποίηση της μεταβλητής move σε true
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (move)
            {
                PictureBox pictureBox = (PictureBox)sender;//Δημιουργία sender έτσι ώστε να μπορούν να περαστούν οι ιδιότητες του συγκεκριμένου picturebox και σε άλλα
                pictureBox.Location = new Point(pictureBox.Left + e.X - point.X, pictureBox.Top + e.Y - point.Y);//Αλλαγή της θέσεις του picturebox κάνοντας dragging
            }
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            move = false;//Aρχικοποίηση της μεταβλητής move σε true
            timer2.Enabled = false;//Mόλις ο παίκτης μετακινήσει και αφήσει ένα από τα λευκά κομμάτια σταμάτησε τον timer του λευκού και ενεργοποίησε τον timer του μαύρου
            if (timer1.Enabled)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox) sender;//Δημιουργία sender έτσι ώστε να μπορούν να περαστούν οι ιδιότητες του συγκεκριμένου picturebox και σε άλλα
            panel1.Controls.Remove(pictureBox);//Κάνοντας doubleclick πάνω σε κάποιο κομμάτι το "τρώς"
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countDown--;//Σε κάθε χτύπο του timer1 μείωσε τον countDown κατα 1
            label1.Text = countDown.ToString();//εκχώρηση της μεταβλητής countDown στην label1
            if (countDown == 0)//Αν ο countDown είναι 0 απενεργοποίησε timer1 και pictureBox1
            {
                timer1.Enabled = false;
                pictureBox1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            countDown2--;//Σε κάθε χτύπο του timer2 μείωσε τον countDown2 κατα 1
            label2.Text = countDown2.ToString();//εκχώρηση της μεταβλητής countDown2 στην label2
            if (countDown2 == 0)//Αν ο countDown2 είναι 0 απενεργοποίησε timer2 και pictureBox20
            {
                timer2.Enabled = false;
                pictureBox20.Enabled = false;
            }
        }

        private void pictureBox20_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;//Aρχικοποίηση της μεταβλητής move σε true
            timer1.Enabled = false;//Mόλις ο παίκτης μετακινήσει και αφήσει ένα από τα μαύρα κομμάτια σταμάτησε τον timer του μαύρου και ενεργοποίησε τον timer του λευκού
            if (timer2.Enabled)
                timer2.Enabled = false;
            else
                timer2.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(//Μετακίνηση της σκακιέρας στο κέντρο της οθόνης
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            DateTime dateTime = DateTime.Now;//Ημερομηνία
            label7.Text = dateTime.ToString();//Εκχώρηση ημερομηνίας στην label7
            label8.Text = Form2.returnText1();//Μέσω της συνάρτησης returnText1 εκχώρησε την μεταβλητή text1 στην label8
            label9.Text = Form2.returnText2();//Μέσω της συνάρτησης returnText2 εκχώρησε την μεταβλητή text2 στην label9
            countDown = Form2.returnCount();//Μέσω της συνάρτησης returnCount εκχώρησε την μεταβλητή count στον countDown
            countDown2 = Form2.returnCount();//Μέσω της συνάρτησης returnCount εκχώρησε την μεταβλητή count στον countDown2
            label1.Text = countDown.ToString();//Εκχώρησε την τιμή του countDown στην label1
            label2.Text = countDown2.ToString();//Εκχώρησε την τιμή του countDown2 στην label2
            conn = new SQLiteConnection(connectionString);//Σύνδεση με την βάση
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//Κλείσε την φόρμα                      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;//Ενεργοποίησε το χρονομετρο του λευκού
            if (timer2.Enabled)
                timer2.Enabled = false;
            else
                timer2.Enabled = true;

            Player1 player1 = new Player1(label9.Text);//Εκχώρησε το περιεχόμενο της label9 ως όνομα του player1
            Player2 player2 = new Player2(label8.Text);//Εκχώρησε το περιεχόμενο της label8 ως όνομα του player2

            conn.Open();//Άνοιγμα σύνδεσης 
            String insertQuery = "Insert into Chess(Player1, Player2, Date) values('" + player2.Name + "','" + player1.Name + "', '" + label7.Text + "')";//Γράψε την βάση τα ονόματα των παικτών και την τρέχουσα ημερομηνία
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();//Κλείσιμο σύνδεσης
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            String query1 = "Select * from Chess";//Εμφάνισε όλα τα δεδομένα του πίνακα Chess
            SQLiteCommand cmd = new SQLiteCommand(query1, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            StringBuilder builder = new StringBuilder();
            while (reader.Read())
            {
                builder.Append(reader.GetString(0))
                    .Append(",")
                    .Append(reader.GetString(1))
                    .Append(",")
                    .Append(reader.GetString(2))
                    .Append(Environment.NewLine);
            }
            MessageBox.Show(builder.ToString());
            conn.Close();
        }
    }
}
