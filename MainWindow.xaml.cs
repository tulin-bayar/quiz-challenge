using System.Collections.Generic;
using System.Windows;

namespace QuizChallenge
{
    public partial class MainWindow : Window
    {
        private readonly List<Question> questions = QuestionBank.GetQuestions();

        // -1 means that the question has not been answered.
        private readonly List<int> selectedAnswers = new List<int>();

        private int currentIndex = 0;
        private int score = 0;
        private bool isFinished = false;
        private bool isQuizStarted = false;

        public MainWindow()
        {
            InitializeComponent();

            StartButton.Click += StartButton_Click;
            BackButton.Click += BackButton_Click;
            NextButton.Click += NextButton_Click;
            RestartButton.Click += RestartButton_Click;

            ResetQuiz();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (isQuizStarted || questions.Count == 0)
            {
                return;
            }

            isQuizStarted = true;

            WelcomePanel.Visibility = Visibility.Collapsed;
            ResultPanel.Visibility = Visibility.Collapsed;
            QuizPanel.Visibility = Visibility.Visible;

            ShowQuestion();
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

            ClearAnswerSelection();

            // Restore the answer previously selected for this question.
            int savedAnswer = selectedAnswers[currentIndex];

            if (savedAnswer == 0) Option0.IsChecked = true;
            else if (savedAnswer == 1) Option1.IsChecked = true;
            else if (savedAnswer == 2) Option2.IsChecked = true;
            else if (savedAnswer == 3) Option3.IsChecked = true;

            FeedbackText.Text = string.Empty;

            BackButton.Content = currentIndex == 0 ? "Exit" : "Back";

            NextButton.Content =
                currentIndex == questions.Count - 1 ? "Finish" : "Next";
        }

        private void ClearAnswerSelection()
        {
            Option0.IsChecked = false;
            Option1.IsChecked = false;
            Option2.IsChecked = false;
            Option3.IsChecked = false;
        }

        private int GetSelectedAnswerIndex()
        {
            if (Option0.IsChecked == true) return 0;
            if (Option1.IsChecked == true) return 1;
            if (Option2.IsChecked == true) return 2;
            if (Option3.IsChecked == true) return 3;

            return -1;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isQuizStarted || isFinished)
            {
                return;
            }

            // Exit from the first question returns to the welcome screen.
            if (currentIndex == 0)
            {
                ResetQuiz();
                return;
            }

            // Save the current selection before moving back.
            selectedAnswers[currentIndex] = GetSelectedAnswerIndex();

            currentIndex--;
            ShowQuestion();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isQuizStarted || isFinished)
            {
                return;
            }

            int selectedAnswerIndex = GetSelectedAnswerIndex();

            if (selectedAnswerIndex == -1)
            {
                FeedbackText.Text = "Please select an answer.";
                return;
            }

            selectedAnswers[currentIndex] = selectedAnswerIndex;

            if (currentIndex < questions.Count - 1)
            {
                currentIndex++;
                ShowQuestion();
            }
            else
            {
                FinishQuiz();
            }
        }

        private void FinishQuiz()
        {
            // Calculate the score using the final saved answers.
            score = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (selectedAnswers[i] == questions[i].CorrectAnswerIndex)
                {
                    score++;
                }
            }

            isFinished = true;
            isQuizStarted = false;

            WelcomePanel.Visibility = Visibility.Collapsed;
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
            isQuizStarted = false;

            selectedAnswers.Clear();

            for (int i = 0; i < questions.Count; i++)
            {
                selectedAnswers.Add(-1);
            }

            ClearAnswerSelection();

            FeedbackText.Text = string.Empty;
            ResultText.Text = string.Empty;

            WelcomeDescriptionText.Text = questions.Count > 0
                ? $"{questions.Count} questions. Four options. One correct answer.\n" +
                  "Select an answer for each question and see your final score."
                : "No questions are available yet.";

            StartButton.IsEnabled = questions.Count > 0;

            QuizPanel.Visibility = Visibility.Collapsed;
            ResultPanel.Visibility = Visibility.Collapsed;
            WelcomePanel.Visibility = Visibility.Visible;
        }
    }
}