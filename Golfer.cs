using System;
using System.IO;
using System.Collections;

namespace HandicapCalculator {
	public class Golfer {
		public Golfer(string name) {
            //StreamReader sr = new StreamReader(name);
            //ArrayList scores = new ArrayList();
            String[] scores = File.ReadAllLines(name);
            double handicap = calculateHandicap(scores);
            Console.WriteLine();
            Console.WriteLine("Your Handicap: "+ handicap);
		}

        public static double calculateHandicap(string[] stringScores) {
            /* Calculates handicap assuming a slope of 120 and rating of 72 */
            double slope = 120;
            double rating = 72;
            double[] differentials = new double[20];
            for(int i = 0; i < 20; i++) {
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

        public static void updateScores(string[] newScores, string name) {
            string[] scores = File.ReadAllLines(name);
            ArrayList concatenate = new ArrayList();
            concatenate.AddRange(newScores);
            concatenate.AddRange(scores);
            String[] newNewScores = (string[])concatenate.ToArray(typeof(string));
            double newHandicap = calculateHandicap(newNewScores);
            Console.WriteLine("Your updated handicap is: " + newHandicap);
            StreamWriter sw = new StreamWriter(name);
            for(int i = 0; i < newNewScores.Length; i++) {
                sw.WriteLine(newNewScores[i]);
            }
            sw.Close();
        }



	}
}
