using Newtonsoft.Json;
using static TaskWinformApp.Form1;


namespace TaskWinformApp
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Human
        {
            public string ? Name { get; set; }
            public string ? surname { get; set; }
            public string ? Ataadi { get; set; }
            public string ?  olke { get; set; }
            public string ?  seher { get; set; }
            public string ?  telefon  { get; set; }
            public string ? Birtday { get; set; }  
            
            public string ? Cinsi { get; set; } 


            public Human(string? name, string? surname, string? ataadi, string? olke, string? seher, string? telefon , string? birtday, string? Cinsi)
            {
                Name = name;
                this.surname = surname;
                Ataadi = ataadi;
                this.olke = olke;
                this.seher = seher;
                this.telefon = telefon;
                Birtday = birtday;
                this.Cinsi = Cinsi;
                
            }


            public Human()
            {

            }



        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Radio Button yoxlanisi 

        string cinsiyet = radioButton1.Checked ? "Kisi" : "Qadin";

            Human human = new Human
            {
                Name = textboxad.Text,
                surname = textBoxsoyad.Text,
                Ataadi = textboxataadi.Text,
                olke = textboxolke.Text,
                seher = textboxseher.Text,
                telefon = textboxtelefon.Text,
                Birtday = dateTimePicker1.Text,
                Cinsi = cinsiyet




            };





            string Jsondata = JsonConvert.SerializeObject(human);


            File.WriteAllText("HumanAbout.json",Jsondata );
        }


        private void DeserializeJson(string jsonData)
        {



            Human human = JsonConvert.DeserializeObject<Human>(jsonData);
            string cins = "Kisi";
            if (human.Cinsi == cins)
            {
                radioButton1.Checked= true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked= true;
            }
            if (human.Name == textBoXaxtaris.Text)
            {

                textboxad.Text = human.Name;
                textBoxsoyad.Text = human.surname;
                textboxataadi.Text = human.Ataadi;
                textboxolke.Text = human.olke;
                textboxseher.Text = human.seher;
                textboxtelefon.Text = human.telefon;
                dateTimePicker1.Text = human.Birtday;
                cins = human.Cinsi;
                
            }
            else
            {
                textboxad.Text = "";
                textBoxsoyad.Text = "";
                textboxataadi.Text = "";
                textboxolke.Text = "";
                textboxseher.Text = "";
                textboxtelefon.Text = "";
                dateTimePicker1.Text = "";
                MessageBox.Show("Qeydiyyatdan kecirilmiyib!!");

            }



        }

        private void buttonaxtar_Click(object sender, EventArgs e)
        {
            string fileYeri = "HumanAbout.json";

            try
            {
                if (File.Exists(fileYeri))
                {
                    string jsonData = File.ReadAllText(fileYeri);
                    DeserializeJson(jsonData);
                }
                else
                {
                    MessageBox.Show("Qeyydiyyat edilmir..!.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror " + ex.Message);
            }

        }

    }
}