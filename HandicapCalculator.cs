using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
namespace HandicapCalculator {
    
    public class HandicapCalculator {
        
        static void Main(String[] args) {
            
            Console.Write("Are you a new player? (yes/no): ");
            string s = Console.ReadLine();
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            if (s == "yes") {
                Console.WriteLine("Enter a score,date,course followed by 'ENTER' below. Enter 'q' to stop entering scores");
                List<string[]> newPlayerScores = new List<string[]>();
                while (true) {
                    Console.Write("Enter here (score,date,course): ");
                    string[] score = Console.ReadLine().Split(',');
                    if (score[0] == "q") break;
                    newPlayerScores.Add(score);
                }
                if(newPlayerScores.Count < 5) {
                    Console.WriteLine("You need at least five scores to calculate a handicap!");
                }
                StreamWriter sw = File.CreateText(name + ".txt");
                for(int i = 0; i < newPlayerScores.Count; i++) {
                    sw.WriteLine(newPlayerScores[i][0] + "," + newPlayerScores[i][1] + "," +newPlayerScores[i][2]);
                }
                sw.Close();
                Golfer newPlayer = new Golfer(name + ".txt");
            }
            else if (s == "no") {
                Golfer player = new Golfer(name + ".txt");
            }
            while(true) {
                Console.WriteLine();
                Console.Write("Would you like to add new scores or look up previous scores? (add/lookup) (q to quit): ");
                string addLookup = Console.ReadLine();
                if (addLookup == "add") {
                    List<string[]>newScores = new List<string[]>();
                    Console.WriteLine("Enter a score,date,course followed by 'ENTER' below. Enter 'q' to stop entering scores");
                    while(true){
                        Console.Write("Enter here (score,date,course): ");
                        string[] score = Console.ReadLine().Split(',');
                        if (score[0] == "q") break;
                        newScores.Add(score);
                    }
                    Golfer.updateScores(newScores, name + ".txt");

                }
                else if (addLookup == "lookup") {
                    Console.Write("Search by course name or date of round: ");
                    string input = Console.ReadLine();
                    if (input.Contains("/")) Golfer.searchDate(input, name + ".txt");
                    else Golfer.searchCourse(input, name + ".txt");
                }
                else if (addLookup == "q") break;
            }
        }
    }
}