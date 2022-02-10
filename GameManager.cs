using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _redWallText, _blueWallText;
    [SerializeField] private GameObject[] _cubsPrefabs;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private int _minCubeCount, _maxCubeCount;

    private int _redScore, _blueScore, _totalScore;
    private int _scoreToWin;


    private void Awake()
    {
        _scoreToWin = Random.Range(_minCubeCount, _maxCubeCount);
    }


    // Start is called before the first frame update
    void Start()
    {
       _totalScore= _redScore = _blueScore = 0;
        if(_victoryPanel !=null)
            _victoryPanel.SetActive(false);

        CubeSpowner();
    }

    // Update is called once per frame
    void Update()
    {
        _redWallText.text = _redScore.ToString();
        _blueWallText.text = _blueScore.ToString();
        GameVictory();
    }

    public void CubeSpowner()
    {
        for(int i=0; i<_scoreToWin; i++)
        {
            int _cubeIndex = Random.Range(0, 2);
           
            float _rndX = Random.Range(-2, 3);
            float _rndY = Random.Range(1, 6);
            float _rndZ = Random.Range(-2, 3);

            Vector3 _whereToSpawn = new Vector3(_rndX, _rndY, _rndZ);
            
            Instantiate(_cubsPrefabs[_cubeIndex], _whereToSpawn , transform.rotation);
        }
    }

    public void GameVictory()
    {
        if (_totalScore == _scoreToWin)
        {
            if(_victoryPanel !=null)
                _victoryPanel.SetActive(true);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RedScoreCounter(int score)
    {
        _redScore += score;
    }

    public void BlueScoreCounter(int score)
    {
        _blueScore += score;
    }

    public void TotalScoreCounter(int score)
    {
        _totalScore += score;
    }

}
