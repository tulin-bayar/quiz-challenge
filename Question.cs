using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizChallenge
{
    public class Question
    {
        public string Text { get; set; } = string.Empty;

        public string[] Options { get; set; } = new string[4];

        public int CorrectAnswerIndex { get; set; }
    }
}