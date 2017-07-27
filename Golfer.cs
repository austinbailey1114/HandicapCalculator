using System;
using System.IO;
using System.Collections;

namespace HandicapCalculator {
	public class Golfer {
		public Golfer(string name) {
            //StreamReader sr = new StreamReader(name);
            //ArrayList scores = new ArrayList();
            string[] scores = File.ReadAllLines(name);
            double handicap = calculateHandicap(scores);
            Console.WriteLine(handicap);
		}

        public double calculateHandicap(string[] stringScores) {
            /* Calculates handicap assuming a slope of 120 and rating of 72 */
            double slope = 120;
            double rating = 72;
            double[] differentials = new double[stringScores.Length];
            for(int i = 0; i < stringScores.Length; i++) {
                differentials[i] = Convert.ToDouble(stringScores[i]);
                differentials[i] = ((differentials[i] - rating) * 113) / slope;
            }
            Array.Sort(differentials);
            if (differentials.Length < 10) return differentials[0] * .96;
            else if (differentials.Length < 20) {
                double diff = (differentials[0] + differentials[1] + differentials[2] + differentials[4] + differentials[3]) / 5;
                    return diff * .96;
            }
            else {
                double sum = 0;
                for(int i = 0; i < 10; i++) {
                    sum += differentials[i];
                }
                return (sum/10) * .96;

            }




        }


	}
}
