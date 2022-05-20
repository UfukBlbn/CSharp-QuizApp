using System;

namespace QuizApp_1
{
    class Questions
    {
        public Questions(string text, string[] choices, string answers)
        {
            this.Text=text;
            this.Answers=answers;
            this.Choices=choices;
        }
        public string Text { get; set; }
        public string[] Choices { get; set; }
        public string Answers { get; set; }
        public bool checkAnswer(string answers)
        {
            //Nesne olarak oluşturduğumuz Answer ile parametre olarak getirilen answers eşitlenir bu küçük bir if kontrolüdür.
            return this.Answers.ToLower() == answers.ToLower();
        }
    }
     class Quiz
        {
            public Quiz(Questions[] questions)
            {
                this.Questions = questions;
                this.QuestionIndex=0;
                this.Score=0;
            }
            public int QuestionIndex { get; set; }
            private Questions[] Questions { get; set; }

            private int Score { get; set; }

            public Questions GetQuestion()

            { 
                return this.Questions[this.QuestionIndex];
            }

            public void DisplayQuestion()
            {
                var questions = this.GetQuestion();
                Console.WriteLine($" Question {this.QuestionIndex+1} : {questions.Text}");
                
                   foreach (var a in questions.Choices)
                 {
                     Console.WriteLine($"-{a}");
                 }

                 Console.Write("Answer : ");
                 string qanswer = Console.ReadLine();
                 this.GuessQuestion(qanswer);
             }

             public void GuessQuestion(string manswer)
                 {
                     var questions = this.GetQuestion();  
                     this.DisplayProgress();             
                     if(questions.checkAnswer(manswer))
                        this.Score++;

                     this.QuestionIndex++;

                    if(this.Questions.Length == this.QuestionIndex )
                    {
                        this.DisplayScore();
                    }
                    else
                    {
                         
                         this.DisplayQuestion();
                    }
                 }

             private void DisplayScore()
             {
                 Console.WriteLine($"Score : {this.Score}");
             }

             private void DisplayProgress()
            {
                int totalQuestion = this.Questions.Length;
                int numberOfQuestion =this.QuestionIndex+1;

                if(totalQuestion>=numberOfQuestion)
                {
                    Console.WriteLine($"Question {numberOfQuestion} of {totalQuestion}");
                } 
            }
             
        }
    class Program
    {
        static void Main(string[] args)
        {

            var q1 = new Questions("Which one is the best programming language ?", new string[]{"C#","Java","Pyhton"},"C#");
            var q2 = new Questions("Which one is the most popular programming language ?", new string[]{"Java","C#","Pyhton"},"Java");                     
            var q3 = new Questions("Which one has the highest salary programming language ?", new string[]{"C#","Pyhton","Java"},"Python");
            var q4 = new Questions("Which one is the best programming language ?", new string[]{"C#","Java","Pyhton"},"C#");
            var q5 = new Questions("Which one is the most popular programming language ?", new string[]{"Java","C#","Pyhton"},"Java");                     
            var q6 = new Questions("Which one has the highest salary programming language ?", new string[]{"C#","Pyhton","Java"},"Python");
            var q7 = new Questions("Which one is the best programming language ?", new string[]{"C#","Java","Pyhton"},"C#");
            var q8 = new Questions("Which one is the most popular programming language ?", new string[]{"Java","C#","Pyhton"},"Java");                     
            var q9 = new Questions("Which one has the highest salary programming language ?", new string[]{"C#","Pyhton","Java"},"Python");

            var questions = new Questions[]{q1,q2,q3,q4,q5,q6,q7,q8,q9};

            var quiz = new Quiz(questions);
            quiz.DisplayQuestion();
           
        }
    }
}
