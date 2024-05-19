﻿using System;
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
            List<Festival> list = new List<Festival>();
        public Form1()
        {
            InitializeComponent();
            string[] lines = File.ReadAllLines("fesztival.txt");

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                Festival obj = new Festival(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                list.Add(obj);
            }

            Dictionary<string, double> dict = new Dictionary<string, double>();

            foreach (var item in list)
            {
                double osszeg = item.ar * item.nap * item.fo;
                if (item.kedvezmeny == "igen")
                {
                    osszeg *= 0.75;
                }

                if (dict.ContainsKey(item.nev))
                {

                    dict[item.nev] += osszeg;
                }
                else
                {
                    dict[item.nev] = osszeg;
                }
            }

            var novDict = dict.OrderByDescending(x => x.Value);

            foreach (var item in novDict)
            {
                dataGridView1.Rows.Add(item.Key, item.Value);
            }

            var maxKolto = dict.OrderBy(x => x.Value).First();
            label1.Text = $" A legkevesebbet költő személy: {maxKolto.Key}, összeg: {maxKolto.Value} Ft";

            Dictionary<string, int> fogalalasDict = new Dictionary<string, int>();

            foreach (var item in list)
            {
                if (fogalalasDict.ContainsKey(item.nev))
                {
                    fogalalasDict[item.nev]++;
                }
                else
                {
                    fogalalasDict[item.nev] = 1;
                }
            }

            var tobbFoglalas = fogalalasDict.Where(x => x.Value >= 3);

            foreach (var person in tobbFoglalas)
            {
                listBox1.Items.Add($"A neve legalább háromszor szerepel a listában: {person.Key}");
            }
        }


    }
}
