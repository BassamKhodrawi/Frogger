﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Frogger
{
    public partial class FrmFrogger : Form
    {
        static int anzahlBereiche = 6;
        int breite = -1;
        int hoehe = -1;
        int hoeheJeBereich = -1;
        Rectangle[] alleBahnen = new Rectangle[anzahlBereiche];
        List<Hindernis> alleHindernisse = new List<Hindernis>();
        Rectangle spieler;
        int spawnRate = 14;
        int spawnZaehler = 0;
        Random rndBahn = new Random();
        bool spielerUeberfahren = false;

        public FrmFrogger()
        {
            InitializeComponent();
        }

        private void FrmFrogger_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void FrmFrogger_Paint(object sender, PaintEventArgs e)
        {
            if (tmrGameTick.Enabled == false)
            {
                breite = this.ClientSize.Width;
                hoehe = this.ClientSize.Height;
                hoeheJeBereich = hoehe / anzahlBereiche + 2;
                spieler = new Rectangle((breite / 2) - 15, hoehe - 35, 30, 30);

                for (int i = 0; i < alleBahnen.Length; i++)
                {
                    alleBahnen[i] = new Rectangle(0, i * hoeheJeBereich, breite, hoeheJeBereich);
                }
                tmrGameTick.Start();
            }

            SolidBrush brStart = new SolidBrush(Color.LightBlue);
            SolidBrush brZiel = new SolidBrush(Color.LightYellow);
            SolidBrush brBahnHell = new SolidBrush(Color.LightGray);
            SolidBrush brBahnDunkel = new SolidBrush(Color.Gray);
            SolidBrush brSpieler = new SolidBrush(Color.Green);
            Pen pnRand = new Pen(Color.Black, 1);

            for (int i = 0; i < alleBahnen.Length; i++)
            {
                e.Graphics.FillRectangle(i % 2 == 0 ? brBahnHell : brBahnDunkel, alleBahnen[i]);
            }

            e.Graphics.FillRectangle(brZiel, alleBahnen[0]);
            e.Graphics.FillRectangle(brStart, alleBahnen[alleBahnen.Length - 1]);
            e.Graphics.DrawRectangles(pnRand, alleBahnen);

            foreach (Hindernis aktuellesHindernis in alleHindernisse)
            {
                e.Graphics.FillRectangle(
                    aktuellesHindernis.Brush,
                    aktuellesHindernis.X,
                    aktuellesHindernis.Y,
                    aktuellesHindernis.Width,
                    aktuellesHindernis.Height);
            }

            e.Graphics.FillEllipse(brSpieler, spieler);
        }

        private void tmrGameTick_Tick(object sender, EventArgs e)
        {
            spawnZaehler++;
            if (spawnZaehler == spawnRate)
            {
                spawnZaehler = 0;
                int zufall = rndBahn.Next(1, anzahlBereiche - 1);
                int yWertDerBahn = alleBahnen[zufall].Top;
                alleHindernisse.Add(new Hindernis(breite, yWertDerBahn, 60, hoeheJeBereich, 10, Color.Red));
            }

            foreach (Hindernis aktuellesHindernis in alleHindernisse)
            {
                aktuellesHindernis.Move();
            }

            for (int i = alleHindernisse.Count - 1; i >= 0; i--)
            {
                if ((alleHindernisse[i].X + alleHindernisse[i].Width) < 0)
                {
                    alleHindernisse.RemoveAt(i);
                }
            }

            if (!spielerUeberfahren)
            {
                foreach (Hindernis aktuellesHindernis in alleHindernisse)
                {
                    if (spieler.IntersectsWith(new Rectangle(aktuellesHindernis.X, aktuellesHindernis.Y, aktuellesHindernis.Width, aktuellesHindernis.Height)))
                    {
                        spielerUeberfahren = true;
                        tmrGameTick.Stop();
                        MessageBox.Show("Spieler wurde überfahren! Spiel startet neu.");
                        ResetSpiel();
                        return;
                    }
                }
            }

            this.Refresh();
        }

        private void FrmFrogger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                spieler.Y -= hoeheJeBereich;
            }
            else if (e.KeyCode == Keys.Down && spieler.Y + hoeheJeBereich < hoehe)
            {
                spieler.Y += hoeheJeBereich;
            }
            else if (e.KeyCode == Keys.Left && spieler.X > 0)
            {
                spieler.X -= 30;
            }
            else if (e.KeyCode == Keys.Right && spieler.X + 30 < breite)
            {
                spieler.X += 30;
            }

            if (spieler.Y < alleBahnen[0].Bottom)
            {
                MessageBox.Show("Geschafft! Spiel wird schwerer.");
                ResetSpiel();
                spawnRate = Math.Max(5, spawnRate - 2);
            }

            this.Refresh();
        }

        private void ResetSpiel()
        {
            spieler = new Rectangle((breite / 2) - 15, hoehe - 35, 30, 30);
            alleHindernisse.Clear();
            spawnZaehler = 0;
            spielerUeberfahren = false;
            tmrGameTick.Start();
        }
    }
}
