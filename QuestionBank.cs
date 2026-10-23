using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace QuizChallenge
{
    public static class QuestionBank
    {
        public static List<Question> GetQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    Text = "Which C# type stores true or false?",
                    Options = new[] { "int", "string", "bool", "double" },
                    CorrectAnswerIndex = 2
                },
                new Question
                {
                    Text = "What is the index of the first element in a C# array?",
                    Options = new[] { "0", "1", "-1", "2" },
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Text = "Which keyword creates a new object in C#?",
                    Options = new[] { "class", "return", "using", "new" },
                    CorrectAnswerIndex = 3
                },
                new Question
                {
                    Text = "Which SQL command retrieves data from a table?",
                    Options = new[] { "DELETE", "SELECT", "UPDATE", "INSERT" },
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Text = "Which language defines the user interface in WPF?",
                    Options = new[] { "SQL", "CSS", "XAML", "Python" },
                    CorrectAnswerIndex = 2
                },
                new Question
                {
                    Text = "Which data structure follows the Last In, First Out rule?",
                    Options = new[] { "Queue", "Stack", "Array", "Dictionary" },
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    Text = "Which operator checks equality in C#?",
                    Options = new[] { "=", "!=", "+=", "==" },
                    CorrectAnswerIndex = 3
                },
                new Question
                {
                    Text = "Which loop repeats while its condition is true?",
                    Options = new[] { "while", "if", "switch", "try" },
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    Text = "Which C# collection stores key-value pairs?",
                    Options = new[] { "List", "Queue", "Dictionary", "Stack" },
                    CorrectAnswerIndex = 2
                },
                new Question
                {
                    Text = "What is the result of integer division 7 / 2 in C#?",
                    Options = new[] { "3.5", "3", "4", "2" },
                    CorrectAnswerIndex = 1
                }
            };
        }
    }
}
