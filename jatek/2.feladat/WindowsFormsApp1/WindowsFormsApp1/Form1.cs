using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Game> list = new List<Game>();
        public Form1()
        {
            InitializeComponent();

            string[] lines = File.ReadAllLines("jatekok.txt");

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                Game obj = new Game(values[0], values[1], values[2], values[3], values[4]);
                list.Add(obj);
            }

            int db = 0;
            foreach (var item in list)
            {
                db += item.db;
            }

            label1.Text = $"Az össz darabszám: {db}";

            List<Game> games = new List<Game>();
            Game legdragabb = list[0];
            games.Add(legdragabb);

            foreach (var item in list)
            {
                if (item.ar > legdragabb.ar)
                {
                    legdragabb = item;
                    games.Clear();
                    games.Add(legdragabb);
                }
                else if (item.ar == legdragabb.ar)
                {
                    games.Add(item);
                }
            }

            foreach (var item in games)
            {
                dataGridView1.Rows.Add(item.kateg, item.nev, item.ar);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selected))
            {
                var selectedProd = list.Where(t => t.kateg == selected).ToList();

                listBox1.Items.Clear();

                foreach (var item in selectedProd)
                {
                    listBox1.Items.Add($"Cím: {item.nev}, Ár: {item.ar}, Darabszám: {item.db}");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
