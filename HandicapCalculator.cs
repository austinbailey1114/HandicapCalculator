using System;
using System.Collections;
using System.IO;
namespace HandicapCalculator {
    
    public class HandicapCalculator {
        
        static void Main(String[] args) {
            
            Console.Write("Are you a new player? (yes/no): ");
            string s = Console.ReadLine();
            if (s == "yes") {
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter a score followed by 'ENTER' below. Enter 'q' to stop entering scores");
                bool done = false;
                ArrayList newPlayerScores = new ArrayList();
                while (!done) {
                    Console.Write("Score: ");
                    string score = Console.ReadLine();
                    if (score == "q") {done = true; break;}
                    newPlayerScores.Add(score);
                }
                if(newPlayerScores.Count < 5) {
                    Console.WriteLine("You need at least five scores to calculate a handicap!");
                }
                String[] scores = new String[newPlayerScores.Count];
                for (int i = 0; i < newPlayerScores.Count; i++) {
                    scores[i] = (String)newPlayerScores[i];
                }
                StreamWriter sw = File.CreateText(name + ".txt");
                for(int i = 0; i < scores.Length; i++) {
                    sw.WriteLine(scores[i]);
                }
                sw.Close();
                Golfer newPlayer = new Golfer(name + ".txt");
            }
            else if (s == "no") {
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                Golfer player = new Golfer(name + ".txt");
            }
        }
    }
}

