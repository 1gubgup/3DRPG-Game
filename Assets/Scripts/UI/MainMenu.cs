using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class MainMenu : MonoBehaviour
{
    Button newGameButton;
    Button continuButton;
    Button quitButton;

    PlayableDirector director;

    private void Awake()
    {
        newGameButton = transform.GetChild(1).GetComponent<Button>();
        continuButton = transform.GetChild(2).GetComponent<Button>();
        quitButton = transform.GetChild(3).GetComponent<Button>();

        newGameButton.onClick.AddListener(PlayTimeLine);
        continuButton.onClick.AddListener(ContinuGame);
        quitButton.onClick.AddListener(QuitGame);

        director = FindAnyObjectByType<PlayableDirector>();
        director.stopped += NewGame;
    }

    void PlayTimeLine()
    {
        director.Play();
    }

    void NewGame(PlayableDirector obj)
    {
        PlayerPrefs.DeleteAll();
        //转换场景
        SceneController.Instance.TransitionToFirstLevel();
    }

    void ContinuGame()
    {
        //转换场景，读取进度
        SceneController.Instance.TransitionToLoadGame();
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("退出游戏");
    }
}
