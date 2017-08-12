# HandicapCalculator
### Features ###
HandicapCalculator is an application to be run in console of your IDE. It tracks and calculates a user's GHIN handicap in golf.
It tracks multiple users' data by storing their previous scores in a .txt file. The user inputs score, date, and golf course.
The user is also prompted to either add new scores, look up previous scores based on date or course played at, or quit the application.
### How to use it ###
`git clone` the repository, run `HandicapCalculator.cs`, and follow the command line prompts.  
### Example Output ###
Are you a new player? (yes/no): yes

Enter your name: Test0

Enter a score,date,course followed by 'ENTER' below. Enter 'q' to stop entering scores

Enter here (score,date,course): 79,6/12/2017,TPC Boston

Enter here (score,date,course): q

You need at least five scores to calculate a handicap!

Your Handicap: 6.328

Would you like to add new scores or look up previous scores? (add/lookup) (q to quit): add

Enter a score,date,course followed by 'ENTER' below. Enter 'q' to stop entering scores

Enter here (score,date,course): 81,7/12/2017,St. Andrews

Enter here (score,date,course): 83,7/14/2017,Pebble Beach

Enter here (score,date,course): 78,7/18/2017,Bald Peak

Enter here (score,date,course): 77,7/21/2017,Augusta

Enter here (score,date,course): q

Your updated handicap is: 4.52

Would you like to add new scores or look up previous scores? (add/lookup) (q to quit): lookup

Search by course name or date of round: Bald Peak

Score(s) shot at Bald Peak: 

78 on 7/18/2017

Would you like to add new scores or look up previous scores? (add/lookup) (q to quit): 7/12/2017

Would you like to add new scores or look up previous scores? (add/lookup) (q to quit): q

