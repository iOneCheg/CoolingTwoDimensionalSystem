using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolingTwoDimensionalSystem
{
    public class Potential
    {
        private const double eV = 0.1602176634;
        private double R1, R2, Sigma, D;
        public Potential(double sigma, double d)
        {
            Sigma = sigma;
            D = d;
            double R0 = sigma * Math.Pow(2, 1.0 / 6.0);
            R1 = 1.2 * R0;
            R2 = 1.8 * R0;
        }
        public double PotentialEnergy(double r)
        {
            //return PLD(r);
            return (r < R1) ? PLD(r) : ((r > R2) ? 0 : PLD(r) * K(r));
        }
        public double Force(double r, double dr)
        {
            //return FLD(r) * dxdy;
            return (r < R1) ? FLD(r) * dr : (r > R2) ? 0 : FLD(r) * dr * K(r);
        }
        private double PLD(double r)
        {
            var ri = Sigma / r;
            var ri3 = ri * ri * ri;
            var ri6 = ri3 * ri3;
            return 4 * D * ri6 * (ri6 - 1);
        }
        private double FLD(double r)
        {
            var ri = Sigma / r;
            var ri3 = ri * ri * ri;
            var ri6 = ri3 * ri3;
            return 24 * D *eV* ri6 * (2 * ri6 - 1) / (r * r);
        }
        private double K(double r)
        {
            return Math.Pow(1 - (r - R1) * (r -R1) / (R1 - R2) / (R1 - R2), 2);
        }
    }
}
