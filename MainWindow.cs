using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolingTwoDimensionalSystem
{
    public partial class MainWindow : Form
    {
        public System.Timers.Timer timerAnim;
        public List<Particle> particles;
        public Potential _potential;
        public int StepCount, counter;
        public double _ke, _pe;
        public static double tau = 2 * 1e-12;
        public readonly double dT = 0.01 * tau;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StepCount = 10000;
            counter = 0;
            timerAnim = new System.Timers.Timer(dT);
            timerAnim.Start();
            timerAnim.Elapsed += OnTimedEvent;
            if (counter == StepCount) timerAnim.Stop();
            textBoxCounter.Text = "";
            //InitialDraw();
        }
        private void InitData()
        {
            particles = new List<Particle>(256);

            double a = 0.382;
            double b = 1.25 * a;

            for (double i = b / 2; i < 20 * a; i += b)
            {
                for (double j = b / 2; j < 20 * a; j += b)
                {
                    particles.Add(new Particle(i, j, 0, 0));
                }
            }

        }
        private void InitialDraw()
        {

            Bitmap bmp = new Bitmap(pictureBox_SettlementCell.Width, pictureBox_SettlementCell.Height);
            Graphics graph = Graphics.FromImage(bmp);

            int a = 20;
            double b = 1.25 * a, radius = a / 2;

            graph.SmoothingMode = SmoothingMode.HighQuality;
            for (double i = 0; i < pictureBox_SettlementCell.Width; i += b)
            {
                for (double j = 0; j < pictureBox_SettlementCell.Height; j += b)
                {
                    graph.FillEllipse(Brushes.Red, (float)(i + b / 2 - radius), (float)(j + b / 2 - radius), (float)(2 * radius), (float)(2 * radius));
                }
            }
            pictureBox_SettlementCell.Image = bmp;
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox_SettlementCell.Width, pictureBox_SettlementCell.Height);
            Graphics graph = Graphics.FromImage(bmp);
            graph.SmoothingMode = SmoothingMode.HighQuality;
            int a = 20;
            double b = 1.25 * a, radius = a / 2;
            for (int i = 0; i < particles.Count; i++)
            {
                double scale = 400 / 7.64;
                graph.FillEllipse(Brushes.Red, (float)(particles[i].Xcoord * scale - radius), (float)(particles[i].Ycoord * scale - radius), (float)(2 * radius), (float)(2 * radius));
            }
            pictureBox_SettlementCell.Image = bmp;
        }
        private void SimpleDraw()
        {
            Bitmap bmp = new Bitmap(pictureBox_SettlementCell.Width, pictureBox_SettlementCell.Height);
            Graphics graph = Graphics.FromImage(bmp);
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.FillEllipse(Brushes.Red, (float)(particles[0].Xcoord), (float)(particles[0].Ycoord), (float)(20), (float)(20));
            pictureBox_SettlementCell.Image = bmp;

        }

        private void button_InitialPlacement_Click(object sender, EventArgs e)
        {
            InitData();
            InitialDraw();
            particles = Particle.InitialVelocity(1000.0, particles);  //скорость в м/с
            InitCalculation();
            //Verlet();
            textBoxCounter.Text = "xxx";
        }

        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Verlet();
            counter++;
            double EnergyPotential = SumPotentialEnergy();
            double EnergyKinetic = SumKineticEnergy();
            //SimpleDraw();
            Draw();
            textBoxCounter.Text = counter.ToString();
            chart1.Series[0].Points.AddXY(counter, EnergyPotential);
            chart2.Series[0].Points.AddXY(counter, EnergyKinetic);
            // int a = 20;
            //double b = 1.25 * a, radius = a / 2;
            //graph.FillEllipse(Brushes.Red, (float)(i + b / 2 - radius), (float)(j + b / 2 - radius), (float)(2 * radius), (float)(2 * radius));
        }
        public double SumPotentialEnergy()
        {
            double sum = 0;
            for (int i = 0; i < particles.Count; i++)
            {
                sum += PotentialEnergyParticle(particles[i], 0.382, 0.0103);
            }
            return sum / 2;
        }
        public double SumKineticEnergy()
        {
            double sum = 0;
            for(int i=0;i<particles.Count;i++)
            {
                sum += KineticEnergyParticle(particles[i]);
            }
            return sum;
        }
        public double KineticEnergyParticle(Particle pI)
        {
            return pI.mass * ((pI.Xvelocity * pI.Xvelocity) + (pI.Yvelocity * pI.Yvelocity)) / 2;
        }
        public double PotentialEnergyParticle(Particle pI, double r0, double D)
        {
            double sigma = r0 * Math.Pow(2, -1 / 6);
            double Sum = 0;
            for (int i = 0; i < particles.Count; i++)
            {
                if (particles[i] == pI) continue;
                Sum += (Math.Pow(sigma, 12) / Math.Pow(Particle.DistancePow2(particles[i], pI), 6) -
                    Math.Pow(sigma, 6) / Math.Pow(Particle.DistancePow2(particles[i], pI), 3)) *
                    Particle.ModifyK(Math.Sqrt(Particle.DistancePow2(particles[i], pI)), r0);
            }
            return 4 * D * Sum;
        }
        public void InitCalculation()
        {
            _ke = 0;
            _pe = 0;
            _potential = new Potential(0.0103,0.3408);
            Accel();

            // Вычисление кинетической энергии.
            particles.ForEach(particle => _ke += KineticEnergyParticle(particle));
        }
        private double Periodic(double pos,double L)
        {
            var newPos = 0.0;
            if (pos > L) newPos = pos - L;
            else if (pos < 0) newPos = L + pos;
            else newPos = pos;
            return newPos;
        }
        public void Verlet()
        {
            _ke = 0;
            _pe = 0;
            //_virial = 0;

            // Вычисление новых координат.
            particles.ForEach(particle =>
            {
                var newPosX = particle.Xvelocity * dT + 0.5 * particle.AccX * dT * dT;
                var newPosY = particle.Yvelocity * dT + 0.5 * particle.AccY * dT * dT;
                // Изменение координат с учётом периодических граничных условий.
                particle.Xcoord = Periodic(particle.Xcoord + newPosX, 20 * 0.382);
                particle.Ycoord = Periodic(particle.Ycoord + newPosY, 20 * 0.382);
            });

            // Частичное изменение скорости, используя старое ускорение.
            particles.ForEach(particle=> particle.Xvelocity += 0.5 * particle.AccX * dT);
            particles.ForEach(particle => particle.Yvelocity += 0.5 * particle.AccY * dT);

            // Вычисление нового ускорения.
            Accel();

            particles.ForEach(particle =>
            {
                // Частичное изменение скорости, используя новое ускорение.
                particle.Xvelocity += 0.5 * particle.AccX * dT;
                particle.Yvelocity += 0.5 * particle.AccY * dT;
                // Вычисление кинетической энергии.
                _ke += KineticEnergyParticle(particle);
            });
        }
        private void Accel()
        {
            //particles.ForEach(atom => atom.Acceleration = Vector2D.Zero);

            for (var i = 0; i < particles.Count-1; i++)
            {
                var pI = particles[i];
                double sumForceX = 0;
                double sumForceY = 0;
                for (var j = i + 1; j < particles.Count; j++)
                {
                    var pJ = particles[j];

                    // Вычисление расстояния между частицами.
                    var rij = Particle.Separation(pI, pJ,out var dx,out var dy, 20 * 0.382);

                    var forceX = _potential.Force(rij, dx);
                    var forceY = _potential.Force(rij, dy);
                    sumForceX += forceX;
                    sumForceY += forceY;
                    pI.AccX += forceX / pI.mass;
                    pI.AccY += forceY / pI.mass;
                    pJ.AccX -= forceX / pJ.mass;
                    pJ.AccY -= forceY / pJ.mass;
                    _pe += _potential.PotentialEnergy(rij);
                }
            }
        }
        //public void Verlet()
        //{
        //    for (int i = 0; i < particles.Count; i++)
        //    {

        //        double Fx = particles[i].PowerCalculate(particles[i], 0.0103, 0.382, true, particles);
        //        double Fy = particles[i].PowerCalculate(particles[i], 0.0103, 0.382, false, particles);

        //        particles[i].Xcoord = particles[i].CoordCalculate(particles[i].Xcoord, particles[i].Xvelocity, Fx, dT);
        //        particles[i].Ycoord = particles[i].CoordCalculate(particles[i].Ycoord, particles[i].Yvelocity, Fy, dT);

        //        particles[i].Fx = particles[i].PowerCalculate(particles[i], 0.0103, 0.382, true, particles);
        //        particles[i].Fy = particles[i].PowerCalculate(particles[i], 0.0103, 0.382, false, particles);

        //        particles[i].Xvelocity = particles[i].VelocityCalculate(particles[i].Xvelocity, particles[i].Fx, Fx, dT);
        //        particles[i].Yvelocity = particles[i].VelocityCalculate(particles[i].Yvelocity, particles[i].Fy, Fy, dT);

        //        particles[i].Xcoord = Particle.Periodic(particles[i].Xcoord, 20 * 0.382);
        //        particles[i].Ycoord = Particle.Periodic(particles[i].Ycoord, 20 * 0.382);
        //    }
        //}
    }
}
