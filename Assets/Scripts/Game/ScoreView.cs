using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _textScore;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += OnScoreChange;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= OnScoreChange;
    }

    private void OnScoreChange(int score)
    {
        _textScore.text = score.ToString();
    }
}