# QuizChallenge

A desktop quiz application built with C#, WPF, and XAML using .NET 8.
Users answer multiple-choice questions and see their final score.

## Features

- 10 predefined questions with four options and one correct answer each.
- One question displayed at a time with a progress indicator.
- Answer selection required before continuing.
- One point awarded for each correct answer.
- Final score with correct and incorrect answer totals.
- Restart button that resets the quiz.
- Dark interface with highlighted answer cards.

## Requirements

- Windows
- .NET 8 SDK
- Visual Studio 2022 with the ".NET desktop development" workload

No database, API keys, or external services are required.

## How to Run

1. Clone this repository or download and extract the ZIP.
2. Open `QuizChallenge.sln` in Visual Studio.
3. Build the solution using **Build > Build Solution**.
4. Press **F5** to run the application.

## How to Play

1. Select one of the four answers.
2. Click **Next** to submit your answer and continue.
3. Click **Finish** on the last question to see your results.
4. Click **Restart** to begin a new attempt.

Each correct answer earns one point.
Incorrect answers earn no points and do not deduct points.

## Project Structure

| File | Purpose |
|------|---------|
| `Question.cs` | Defines the question text, options, and correct answer index. |
| `QuestionBank.cs` | Stores and provides the predefined questions. |
| `MainWindow.xaml` | Defines the interface and visual styles. |
| `MainWindow.xaml.cs` | Handles question navigation, validation, scoring, and restart. |

## Changing the Questions

Edit the question records in `QuestionBank.cs`.

Each question must contain:
- `Text`: the question text.
- `Options`: exactly four answer choices.
- `CorrectAnswerIndex`: the position of the correct answer, from 0 to 3.

Example:

    new Question
    {
        Text = "What is the capital of Hungary?",
        Options = new[] { "Vienna", "Budapest", "Prague", "Warsaw" },
        CorrectAnswerIndex = 1
    }

The progress indicator and maximum score automatically adapt to the
number of questions. Keep at least 10 questions to meet the project requirements.

## Manual Testing

- Clicking Next without selecting an answer displays a warning.
- Moving to the next question clears the previous selection.
- Rapidly clicking Next twice does not skip an unanswered question.
- Completing the final question displays the results.
- Restart returns to the first question and resets the score.
- A test with nine correct answers and one incorrect answer produces 9/10.
