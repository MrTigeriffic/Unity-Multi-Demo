using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    //TMP text works both in the world UI and Overlay UI
    int _points;
    static int _highScore;
    static ScoreSystem _instance;

    private void Awake() => _instance = this;

    [SerializeField] TMP_Text _text;
    [SerializeField] TMP_Text _highScoreText;

    private void OnEnable()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");//Place above the text as you want to set the highscore value first before 
        _text.SetText(_points.ToString());
        _highScoreText.SetText(_highScore.ToString());
        
    }
    public static void Add(int points)
    {
        _instance.AddPoints(points);
    }

    private void AddPoints(int points)// static makes it no longer recognise the instances in the object. It's just a method on the object unrelated to the rest
    {
        _points += points;
        _text.SetText(_points.ToString());

        if (_points >= _highScore)
        {
            _highScore = _points;
            _highScoreText.SetText(_highScore.ToString());
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
 
    }

}
