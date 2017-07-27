using System;
using System.Collections;
using System.IO;
namespace HandicapCalculator {
    
    public class HandicapCalculator {
        
        static void Main(String[] args) {
            
            Console.Write("Are you a new player? (yes/no): ");
            string s = Console.ReadLine();
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            if (s == "yes") {
                Console.WriteLine("Enter a score followed by 'ENTER' below. Enter 'q' to stop entering scores");
                ArrayList newPlayerScores = new ArrayList();
                while (true) {
                    Console.Write("Score: ");
                    string score = Console.ReadLine();
                    if (score == "q") break;
                    newPlayerScores.Add(score);
                }
                if(newPlayerScores.Count < 5) {
                    Console.WriteLine("You need at least five scores to calculate a handicap!");
                }
                String[] scores = (string[])newPlayerScores.ToArray(typeof(string));
                StreamWriter sw = File.CreateText(name + ".txt");
                for(int i = 0; i < scores.Length; i++) {
                    sw.WriteLine(scores[i]);
                }
                sw.Close();
                Golfer newPlayer = new Golfer(name + ".txt");
            }
            else if (s == "no") {
                Golfer player = new Golfer(name + ".txt");
            }
            while(true) {
                Console.WriteLine();
                Console.Write("Would you like to add new scores, or quit the program? (add/quit): ");
                string addQuit = Console.ReadLine();
                if (addQuit == "quit") break;
                if (addQuit == "add") {
                    ArrayList newScores = new ArrayList();
                    Console.WriteLine("Enter a score followed by 'ENTER' below. Enter 'q' to stop entering scores");
                    while(true){
                        Console.Write("Score: ");
                        string score = Console.ReadLine();
                        if (score == "q") break;
                        newScores.Add(score);
                    }
                    String[] scores = (string[])newScores.ToArray(typeof(string));
                    Golfer.updateScores(scores, name + ".txt");

                }
            }
        }
    }
}

