using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

/*
 * Math Quiz Game
 * Author/Creator: Daniel Wei
 * 
 * This is a quiz game that tests the user's math skills.
 * When the program starts, it begins to generate random math questions, either addition or subtraction, with numbers
 * in a certain range depending on difficulty selected. The range is always from 0 (inclusive) to 10 ^ difficulty (exclusive).
 * So if difficulty = 3, then range is 0 - 1000.
 * 
 * For each question, a correct answer is computed and randomly assigned a button (A, B, C, or D). Then, three random wrong answers
 * are generated and manipulated based on the following criteria: while any of the three wrong answers are equal to each other or the correct answer,
 * add a random value in range -1 * (3 ^ difficulty) (inclusive) to 3 ^ difficulty (inclusive). So if difficulty = 2, then the range is -9 to 9.
 * 
 * The user is to then select from the answers for each question, being unable to move on until they either concede defeat, or get the answer correct. 
 * Harder questions grant more point upon AC (Answer Correct), easier questions grant less. Harder questions result in small point deductions per WA (wrong answer),
 * easier questions result in more. Conceding defeat results in an automatic score deduction of 10.  
 * 
 * Special Features:
 * - The method I created for generating wrong answers that I described above
 * - There is a reaction image that shows up on the right side; the more answers you get wrong during a question, the reaction changes
 * - If the answer was correct, there is also a reaction image
 *   (the program starts with an empty space on the right side, it is not actually empty! This is where the image shows up!)
 * - The program will mock you if you concede defeat
 * - To prevent users from cheating the system (recognizing what number the sums of the units digits of the numbers make, such as xyz5 + abc3 = hjk8), at higher difficulties, all the units digits
 *   of all the answers are the same
 * 
 * What I found interesting:
 * - Having programmed in both C++ and Java, I was surprised to see that C# was more similar to Java than C++, despite C++ and C# having similar names
 * - Learning how to program event-driven software was interesting
 * - I found some parallels between Visual Studio and Android Studio, which helped me learn how to use it better
 * 
 * Challenges I ran into:
 * - Ensuring that in the checklist, only one element is checked at a time. I ended up using a foreach loop to deselect any old selected objects when a new one was selected.
 * - Ensuring that at any given moment, one element was selected in the checklist, otherwise the program would crash. I just set the default to be 1 to fix this.
 * - Importing images: it was hard for me to find the file location to import from
 */

 
namespace DanielWeiQuizGame
{
    public partial class Form1 : Form
    {
        // Random object that is used to generate numbers for questions and answers
        Random ran = new Random();

        // Question difficulty variable
        int difficulty = 1;

        // Values for the question, as well as the answer to the question
        int val1 = 0;
        int val2 = 0;
        int ans = 0;

        // Tracks the location of the correct answer
        int correctAnsLocation = 0;

        // A set of wrong answers for each question that are randomly generated
        int wrongAns1 = 0;
        int wrongAns2 = 0;
        int wrongAns3 = 0;

        // User's score
        int score = 0;

        // Number of wrong answers in a question
        int numWA = 0;

        // A variable to track if there is currently a question on the display (and being solved)
        bool hasQuestion = true;

        // Variables to check which answers have been tried so far
        bool triedA = false;
        bool triedB = false;
        bool triedC = false;
        bool triedD = false;

        // Image files. These reaction images are Twitch emotes.
        Image pogChamp = DanielWeiQuizGame.Properties.Resources.PogChamp;
        Image NotLikeThis = DanielWeiQuizGame.Properties.Resources.NotLikeThis;
        Image Wutface = DanielWeiQuizGame.Properties.Resources.Wutface;
        Image BibleThump = DanielWeiQuizGame.Properties.Resources.BibleThump;

        public Form1()
        {
            InitializeComponent();
            difficulties.SetItemChecked(0, true);
            reactionBox.SizeMode = PictureBoxSizeMode.StretchImage;
            generateQuestion();
            generateAnswers();
            displayAnswers();

            // backgroundUpdate is the idle update method
            Application.Idle += backgroundUpdate;
        }

        // Idle update method; it updates the score
        private void backgroundUpdate(object sender, EventArgs e)
        {
            scoreDisplay.Text = "" + score;
        }

        // Initialize the button states (at the beginning of a question no answer has been tried yet)
        private void init()
        {
            triedA = false;
            triedB = false;
            triedC = false;
            triedD = false;
        }

        // Get the checked difficulty from the checkbox
        private int getDifficulty()
        {
            return difficulties.CheckedIndices[0];
        }

        // Return true if there is an item checked in the check list. If there is no checked item, return false.
        private bool hasCheckedItem()
        {
            foreach (int index in difficulties.CheckedIndices) { return true; }
            return false;
        }

        /*
         * Generate a random question based on the selected difficulty. The constraints on each number in the question scales with
         * the difficulty. The maximum bound for each term will be 10 raised to the power of the difficulty. So at difficulty = 3, the maximum
         * is 10 raised to the power of 3, or 1000.
         */
        private void generateQuestion()
        {
            difficulty = getDifficulty() + 1; // Because the choices are indexed from 0, it is necessary to add 1 to correspond to the numbers in the checklist
            int chosenOperation = ran.Next(0, 2); // 0 will represent a subtraction question, 1 will represent an addition question
            if (difficulty == 1) // Random numbers from 0 to 10
            {
                val1 = ran.Next(0, 11);
                val2 = ran.Next(0, 11);
            } 
            else if (difficulty == 2) // Random numbers from 0 to 100
            {
                val1 = ran.Next(0, 101);
                val2 = ran.Next(0, 101);
            }
            else if (difficulty == 3) // Random numbers from 0 to 1000
            {
                val1 = ran.Next(0, 1001);
                val2 = ran.Next(0, 1001);
            }
            else if (difficulty == 4) // Random numbers from 0 to 10000
            {
                val1 = ran.Next(0, 10001);
                val2 = ran.Next(0, 10001);
            }
            else if (difficulty == 5) // Random numbers from 0 to 100000
            {
                val1 = ran.Next(0, 100001);
                val2 = ran.Next(0, 100001);
            }

            // Display the question in the main long textbox based on the operation selected
            if (chosenOperation == 0)
            {
                ans = val1 - val2;
                questionDisplay.Text = "What is the value of " + val1 + " - " + val2 + "?";
            }
            else
            {
                ans = val1 + val2;
                questionDisplay.Text = "What is the value of " + val1 + " + " + val2 + "?";
            }
        }

        /* 
         * A method that generates a set of answers, as well as selects the location
         * to place the correct answer
         */
        private void generateAnswers()
        {
            /*
             * Generate a number from 1 - 4 to choose which letter will contain the correct answer. 
             * 1 = A, 2 = B, 3 = C, 4 = D
             */
            correctAnsLocation = ran.Next(1, 5); 

            /*
             * Generate a set of incorrect answers. Incorrect answers depend on the difficlty. 
             * This is done to prevent absurd answers from showing up as options (for example, an answer of 3829 to a question of 4 + 27).
             * If two or more answers end up being generated
             * the same, they are altered such that they will not be. 
             */
            if (difficulty == 1)
            {
                wrongAns1 = ans + ran.Next(-5, 6);
                wrongAns2 = ans + ran.Next(-5, 6);
                wrongAns3 = ans + ran.Next(-5, 6);

                // Ensure no two answers get repeated!
                while (wrongAns1 == wrongAns2 || wrongAns2 == wrongAns3 || wrongAns3 == wrongAns1 || wrongAns1 == ans || wrongAns2 == ans || wrongAns3 == ans)
                {
                    if (wrongAns1 == ans) { wrongAns1 += ran.Next(-3, 4); }
                    if (wrongAns2 == ans) { wrongAns2 += ran.Next(-3, 4); }
                    if (wrongAns3 == ans) { wrongAns3 += ran.Next(-3, 4); }
                    if (wrongAns1 == wrongAns2) { wrongAns2 += ran.Next(-3, 4); }
                    if (wrongAns2 == wrongAns3) { wrongAns3 += ran.Next(-3, 4); }
                    if (wrongAns1 == wrongAns3) { wrongAns3 += ran.Next(-3, 4); }
                }
                
            }
            else if (difficulty == 2)
            {
                wrongAns1 = ans + ran.Next(-25, 26);
                wrongAns2 = ans + ran.Next(-25, 26);
                wrongAns3 = ans + ran.Next(-26, 26);

                // Ensure no two answers get repeated!
                while (wrongAns1 == wrongAns2 || wrongAns2 == wrongAns3 || wrongAns3 == wrongAns1 || wrongAns1 == ans || wrongAns2 == ans || wrongAns3 == ans)
                {
                    if (wrongAns1 == ans) { wrongAns1 += ran.Next(-9, 10); }
                    if (wrongAns2 == ans) { wrongAns2 += ran.Next(-9, 10); }
                    if (wrongAns3 == ans) { wrongAns3 += ran.Next(-9, 10); }
                    if (wrongAns1 == wrongAns2) { wrongAns2 += ran.Next(-9, 10); }
                    if (wrongAns2 == wrongAns3) { wrongAns3 += ran.Next(-9, 10); }
                    if (wrongAns1 == wrongAns3) { wrongAns3 += ran.Next(-9, 10); }
                }
            }
            else if (difficulty == 3)
            {
                int answerUnitsDigit = ans % 10;
                wrongAns1 = ans + ran.Next(-125, 126);
                wrongAns2 = ans + ran.Next(-125, 126);
                wrongAns3 = ans + ran.Next(-126, 126);

                // Make all the units digits the same
                wrongAns1 += (answerUnitsDigit - wrongAns1 % 10);
                wrongAns2 += (answerUnitsDigit - wrongAns2 % 10);
                wrongAns3 += (answerUnitsDigit - wrongAns3 % 10);

                // Ensure no two answers get repeated!
                while (wrongAns1 == wrongAns2 || wrongAns2 == wrongAns3 || wrongAns3 == wrongAns1 || wrongAns1 == ans || wrongAns2 == ans || wrongAns3 == ans)
                {
                    if(wrongAns1 == ans) { wrongAns1 += ran.Next(-27, 28); }
                    if (wrongAns2 == ans) { wrongAns2 += ran.Next(-27, 28); }
                    if (wrongAns3 == ans) { wrongAns3 += ran.Next(-27, 28); }
                    if (wrongAns1 == wrongAns2) { wrongAns2 += ran.Next(-27, 28); }
                    if (wrongAns2 == wrongAns3) { wrongAns3 += ran.Next(-27, 28); }
                    if (wrongAns1 == wrongAns3) { wrongAns3 += ran.Next(-27, 28); }
                }
            }
            else if (difficulty == 4)
            {
                int answerUnitsDigit = ans % 10;
                wrongAns1 = ans + ran.Next(-625, 626);
                wrongAns2 = ans + ran.Next(-625, 626);
                wrongAns3 = ans + ran.Next(-625, 626);

                // Make all the units digits the same
                wrongAns1 += (answerUnitsDigit - wrongAns1 % 10);
                wrongAns2 += (answerUnitsDigit - wrongAns2 % 10);
                wrongAns3 += (answerUnitsDigit - wrongAns3 % 10);

                // Ensure no two answers get repeated!
                while (wrongAns1 == wrongAns2 || wrongAns2 == wrongAns3 || wrongAns3 == wrongAns1 || wrongAns1 == ans || wrongAns2 == ans || wrongAns3 == ans)
                {
                    if (wrongAns1 == ans) { wrongAns1 += ran.Next(-81, 82); }
                    if (wrongAns2 == ans) { wrongAns2 += ran.Next(-81, 82); }
                    if (wrongAns3 == ans) { wrongAns3 += ran.Next(-81, 82); }
                    if (wrongAns1 == wrongAns2) { wrongAns2 += ran.Next(-81, 82); }
                    if (wrongAns2 == wrongAns3) { wrongAns3 += ran.Next(-81, 82); }
                    if (wrongAns1 == wrongAns3) { wrongAns3 += ran.Next(-81, 82); }
                }
            }
            else if (difficulty == 5)
            {
                int answerUnitsDigit = ans % 10;
                wrongAns1 = ans + ran.Next(-3125, 3126);
                wrongAns2 = ans + ran.Next(-3125, 3126);
                wrongAns3 = ans + ran.Next(-3125, 3126);

                // Make all the units digits the same
                wrongAns1 += (answerUnitsDigit - wrongAns1 % 10);
                wrongAns2 += (answerUnitsDigit - wrongAns2 % 10);
                wrongAns3 += (answerUnitsDigit - wrongAns3 % 10);

                // Ensure no two answers get repeated!
                while (wrongAns1 == wrongAns2 || wrongAns2 == wrongAns3 || wrongAns3 == wrongAns1 || wrongAns1 == ans || wrongAns2 == ans || wrongAns3 == ans)
                {
                    if (wrongAns1 == ans) { wrongAns1 += ran.Next(-243, 244); }
                    if (wrongAns2 == ans) { wrongAns2 += ran.Next(-243, 244); }
                    if (wrongAns3 == ans) { wrongAns3 += ran.Next(-243, 244); }
                    if (wrongAns1 == wrongAns2) { wrongAns2 += ran.Next(-243, 244); }
                    if (wrongAns2 == wrongAns3) { wrongAns3 += ran.Next(-243, 244); }
                    if (wrongAns1 == wrongAns3) { wrongAns3 += ran.Next(-243, 244); }
                }
            }
        }

        /*
         * A method called to display the answers into their appropriate boxes. 
         */
        private void displayAnswers()
        {
            if (correctAnsLocation == 1) // If A is the correct answer
            {
                ansA.Text = "" + ans;
                ansB.Text = "" + wrongAns1;
                ansC.Text = "" + wrongAns2;
                ansD.Text = "" + wrongAns3;
            }
            else if (correctAnsLocation == 2) // If B is the correct answer
            {
                ansB.Text = "" + ans;
                ansA.Text = "" + wrongAns1;
                ansC.Text = "" + wrongAns2;
                ansD.Text = "" + wrongAns3;
            }
            else if (correctAnsLocation == 3) // If C is the correct answer
            {
                ansC.Text = "" + ans;
                ansB.Text = "" + wrongAns1;
                ansA.Text = "" + wrongAns2;
                ansD.Text = "" + wrongAns3;
            }
            else if (correctAnsLocation == 4) // If D is the correct answer
            {
                ansD.Text = "" + ans;
                ansB.Text = "" + wrongAns1;
                ansC.Text = "" + wrongAns2;
                ansA.Text = "" + wrongAns3;
            }
        }

        /*
         * A method called to update the reaction image based on the numbers of wrong answers
         * from the user. 
         * 
         * 1 Wrong Answer = Wutface
         * 2 Wrong Answers = NotLikeThis
         * 3 Wrong Answers = BibleThump
         */
        private void updateImage()
        {
            if (numWA == 1)
            {
                reactionBox.Image = Wutface;
            } 
            else if (numWA == 2)
            {
                reactionBox.Image = NotLikeThis;
            }
            else if (numWA == 3)
            {
                reactionBox.Image = BibleThump;
            }
        }


        /*
         * Next button moves on to the next question, only if the previous question has been solved
         * or the user has conceded defeat. 
         */
        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (!hasQuestion)
            {
                if (!hasCheckedItem()) { difficulties.SetItemChecked(0, true); }
                init();
                generateQuestion();
                generateAnswers();
                displayAnswers();
                numWA = 0;
                hasQuestion = true;
                reactionBox.Image = null;
            }
        }

        /*
         * The following four methods handle the four buttons used to answer the questions, A, B, C, and D.
         * Each method has the same logic behind it. 
         * 
         * If the button has not yet been clicked (to prevent
         * spamming the button to get excessive points), then check if the answer is assigned to that particular
         * button's above textbox. If it is, add some number of points to the score depending on the difficulty, and 
         * tell the user that they have gotten the correct answer, and terminate the current question.
         * 
         * Otherwise, display WA (Wrong Answer) in the button's associated textbox to tell the user that they answered wrong, and
         * subtract some number of points depending on difficulty. 
         */
        private void buttonA_Click(object sender, EventArgs e)
        {
            if (correctAnsLocation == 1 && !triedA)
            {
                questionDisplay.Text = "Correct!";
                score += 10 * difficulty;
                hasQuestion = false;
                reactionBox.Image = pogChamp;
            }
            else
            {
                if (hasQuestion && !triedA)
                {
                    ansA.Text = "WA";
                    numWA++;
                    score -= 10 * (6 - difficulty);
                    reactionBox.Image = NotLikeThis;
                    updateImage();
                }
            }
            triedA = true;
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            if (correctAnsLocation == 2 && !triedB)
            {
                questionDisplay.Text = "Correct!";
                score += 10 * difficulty;
                hasQuestion = false;
                reactionBox.Image = pogChamp;
            }
            else
            {
                if (hasQuestion && !triedB)
                {
                    ansB.Text = "WA";
                    numWA++;
                    score -= 10 * (6 - difficulty);
                    reactionBox.Image = NotLikeThis;
                    updateImage();
                }
            }
            triedB = true;
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            if (correctAnsLocation == 3 && !triedC)
            {
                questionDisplay.Text = "Correct!";
                score += 10 * difficulty;
                hasQuestion = false;
                reactionBox.Image = pogChamp;
            }
            else
            {
                if (hasQuestion && !triedC)
                {
                    ansC.Text = "WA";
                    numWA++;
                    score -= 10 * (6 - difficulty);
                    reactionBox.Image = NotLikeThis;
                    updateImage();
                }
            }
            triedC = true;
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            if (correctAnsLocation == 4 && !triedD) 
            {
                questionDisplay.Text = "Correct!";
                score += 10 * difficulty;
                hasQuestion = false;
                reactionBox.Image = pogChamp;
            }
            else
            {
                if (hasQuestion && !triedD)
                {
                    ansD.Text = "WA";
                    numWA++;
                    score -= 10 * (6 - difficulty);
                    reactionBox.Image = NotLikeThis;
                    updateImage();
                }
            }
            triedD = true;
        }

        /*
         * The concede button is for those who give up too soon on math.
         * It allows you to skip the problem for 500 point fee
         */
        private void ConcedeBtn_Click(object sender, EventArgs e)
        {
            if (hasQuestion)
            {
                questionDisplay.Text = "Smh my head";
                reactionBox.Image = NotLikeThis;
                ansA.Text = "F";
                ansB.Text = "A";
                ansC.Text = "I";
                ansD.Text = "L";
                score -= 10;
                hasQuestion = false;
            }
            else
            {
                questionDisplay.Text = "There isn't even a question to give up on!";
            }
        }
        
        /*
         * This method handles the difficulty checklist in the top right corner.
         * It ensures that only one option can be selected at once.
         * Each time a new difficulty is selected, the method loops through the list,
         * uncheecking any difficulties that were previously checked off
         */
        private void Difficulties_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = difficulties.SelectedIndex;
            foreach (int index in difficulties.CheckedIndices)
            {
                if (index != selectedIndex)
                {
                    difficulties.SetItemChecked(index, false);
                }
            }
            
        }
    }
}
