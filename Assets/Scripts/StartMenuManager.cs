using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;
    [SerializeField] private InputField playerName;

    private void Start()
    {
        bestScoreText.text = "Best Score : " + DataStorageManager.Instance.bestScorePlayerName + " : " + DataStorageManager.Instance.bestScore;
    }

    public void StartGame()
    {
        DataStorageManager.Instance.currentPlayer = playerName.text;
        SceneManager.LoadScene(1);
    }
}
