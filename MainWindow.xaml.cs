using System.Collections.Generic;
using System.Windows;

namespace QuizChallenge
{
    public partial class MainWindow : Window
    {
        private readonly List<Question> questions = QuestionBank.GetQuestions();
        private int currentIndex = 0;
        private int score = 0;
        private bool isFinished = false;

        public MainWindow()
        {
            InitializeComponent();

            NextButton.Click += NextButton_Click;
            RestartButton.Click += RestartButton_Click;

            ResetQuiz();
        }

        private void ShowQuestion()
        {
            Question currentQuestion = questions[currentIndex];

            ProgressText.Text =
                $"Question {currentIndex + 1}/{questions.Count}";

            QuestionText.Text = currentQuestion.Text;

            Option0.Content = currentQuestion.Options[0];
            Option1.Content = currentQuestion.Options[1];
            Option2.Content = currentQuestion.Options[2];
            Option3.Content = currentQuestion.Options[3];

            Option0.IsChecked = false;
            Option1.IsChecked = false;
            Option2.IsChecked = false;
            Option3.IsChecked = false;

            FeedbackText.Text = string.Empty;

            NextButton.Content =
                currentIndex == questions.Count - 1 ? "Finish" : "Next";
        }

        private int GetSelectedAnswerIndex()
        {
            if (Option0.IsChecked == true) return 0;
            if (Option1.IsChecked == true) return 1;
            if (Option2.IsChecked == true) return 2;
            if (Option3.IsChecked == true) return 3;

            return -1;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (isFinished)
            {
                return;
            }

            int selectedAnswerIndex = GetSelectedAnswerIndex();

            if (selectedAnswerIndex == -1)
            {
                FeedbackText.Text = "Please select an answer.";
                return;
            }

            if (selectedAnswerIndex == questions[currentIndex].CorrectAnswerIndex)
            {
                score++;
            }

            currentIndex++;

            if (currentIndex < questions.Count)
            {
                ShowQuestion();
            }
            else
            {
                FinishQuiz();
            }
        }

        private void FinishQuiz()
        {
            isFinished = true;

            QuizPanel.Visibility = Visibility.Collapsed;
            ResultPanel.Visibility = Visibility.Visible;

            ResultText.Text =
                $"Your score: {score} / {questions.Count}\n" +
                $"Correct answers: {score}\n" +
                $"Incorrect answers: {questions.Count - score}";
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            ResetQuiz();
        }

        private void ResetQuiz()
        {
            currentIndex = 0;
            score = 0;
            isFinished = false;

            ResultText.Text = string.Empty;
            ResultPanel.Visibility = Visibility.Collapsed;
            QuizPanel.Visibility = Visibility.Visible;

            ShowQuestion();
        }
    }
}