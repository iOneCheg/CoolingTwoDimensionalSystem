using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolingTwoDimensionalSystem
{
    public class Particle
    {
        public double Xcoord, Ycoord,
                      Xvelocity, Yvelocity,
                      Fx, Fy, mass;
        public double AccX { get; set; }
        public double AccY { get; set; }
        public Particle(double x, double y, double StartVelocityX, double StartVelocityY)
        {
            Xcoord = x; Ycoord = y; Xvelocity = StartVelocityX; Yvelocity = StartVelocityY; mass = 6.7 * 1e-26;
        }

        public double CoordCalculate(double PrevCoord, double PrevVelocity, double PrevPower, double deltaT)
        {
            return PrevCoord + PrevVelocity * deltaT + (PrevPower * deltaT * deltaT) / (2 * mass);
        }
        public double VelocityCalculate(double PrevVelocity, double CurrentPower, double PrevPower, double deltaT)
        {
            return PrevVelocity + (CurrentPower + PrevPower) * deltaT / (2 * mass);
        }
        public double PowerCalculate(Particle p, double D, double a, bool XorY, List<Particle> particles)
        {
            double sum = 0;
            foreach (var particle in particles)
            {
                if (particle == p) continue;
                if (DistancePow2(p, particle) < 1.8 * a) continue;

                sum += SumForce(p, particle, a, XorY);
            }
            return 12 * D * Math.Pow(a, 6) * sum;
        }
        public static double Separation(double dx, double Lx)
        {
            if (Math.Abs(dx) > 0.5 * Lx) return dx - Math.Sign(dx) * Lx;
            return dx;
        }
        public static double Separation(Particle p1, Particle p2,out double dx,out double dy,double L)
        {
            dx = p1.Xcoord - p2.Xcoord;
            dy = p1.Ycoord - p2.Ycoord;

            // Обеспечивает, что расстояние между частицами никогда не будет больше L/2.
            if (Math.Abs(dx) > 0.5 * L)
                dx -= Math.Sign(dx) * L;
            if (Math.Abs(dy) > 0.5 * L)
                dy -= Math.Sign(dy) * L;

            return Math.Sqrt(dx * dx + dy * dy);
        }
        public static double Periodic(double x, double Lx)
        {
            if (x < 0) return x + Lx;
            if (x > Lx) return x - Lx;
            return x;
        }
        public double SumForce(Particle p1, Particle p2, double a, bool XorY)
        {
            double first = (Math.Pow(a, 6) / (DistancePow2(p1, p2) * DistancePow2(p1, p2) * DistancePow2(p1, p2))) - 1;
            double sum = 1;
            if (XorY) sum *= Separation(p1.Xcoord - p2.Xcoord, 20 * 0.382) / Math.Pow(DistancePow2(p1, p2), 4);
            else sum *= Separation(p1.Ycoord - p2.Ycoord, 20 * 0.382) / Math.Pow(DistancePow2(p1, p2), 4);
            sum *= ModifyK(Math.Sqrt(DistancePow2(p1, p2)), a);
            return sum * first;
        }
        public static double DistancePow2(Particle pI, Particle pK)
        {
            double dx = pI.Xcoord - pK.Xcoord;
            double dy = pI.Ycoord - pK.Ycoord;
            return dx * dx + dy * dy;
        }
        public static List<Particle> InitialVelocity(double V0MaxInput, List<Particle> particles)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            double r1 = rnd.NextDouble(), r2 = rnd.NextDouble();
            double sumX = 0, sumY = 0;
            double V0Max = V0MaxInput * 1e9;
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Xvelocity = (-1 + 2 * r1) * V0Max;
                sumX += particles[i].Xvelocity;
                particles[i].Yvelocity = (-1 + 2 * r2) * V0Max;
                sumY += particles[i].Yvelocity;
            }
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Xvelocity -= sumX / particles.Count;
                particles[i].Yvelocity -= sumY / particles.Count;
            }
            return particles;
        }
        public static double ModifyK(double r, double r0)
        {
            double r1 = 1.1 * r0, r2 = 1.8 * r0;

            if (r < r1) return 1.0;
            else if (r >= r1 && r <= r2)
                return (1 - ((r - r1) * (r - r1)) / ((r1 - r2) * (r1 - r2))) *
                    (1 - (r - r1) * (r - r1) / ((r1 - r2) * (r1 - r2)));
            else return 0;
        }

    }
}
