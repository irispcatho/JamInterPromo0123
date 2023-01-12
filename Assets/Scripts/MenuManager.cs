using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string _playScene;
    [SerializeField] private string _creditsScene;
    [SerializeField] private string _settingsScene;
    
    [SerializeField] private float _scaleDuration = 0.2f;
    [SerializeField] private float _scaleEffect = 1.15f;

    [SerializeField] private Image FadeImage;
    [SerializeField] private Color ImageColor;
    [SerializeField] private float FadeInSpeed;
    [SerializeField] private float FadeOutSpeed;

    private bool _canClick = true;

    
    public float ScaleDuration => _scaleDuration;
    public float ScaleEffect => _scaleEffect; 

    public static MenuManager Instance;

    private void Awake() => Instance = this;

    private void Start()
    {
        // Alpha 1
        FadeImage.DOFade(1f, 0f);
        FadeIn();
        FadeImage.color = ImageColor;
    }

    public void Play() => SceneManager.LoadScene(_playScene);
    public void Settings() => SceneManager.LoadScene(_settingsScene);
    public void Credits() => SceneManager.LoadScene(_creditsScene);
    public void Quit() => Application.Quit();

    public void FadeIn()
    {
        FadeImage.DOFade(0f, FadeInSpeed);
    }
    public void FadeOutPlay()
    {
        if (_canClick)
            FadeImage.DOFade(1f, FadeOutSpeed).OnComplete(Play);
        _canClick = false;
    }
    public void FadeOutSettings()
    {
        if (_canClick)
            FadeImage.DOFade(1f, FadeOutSpeed).OnComplete(Settings);
        _canClick = false;
    }
    public void FadeOuCredits()
    {
        if (_canClick)
            FadeImage.DOFade(1f, FadeOutSpeed).OnComplete(Credits);
        _canClick = false;
    }
    public void FadeOutQuit()
    {
        if (_canClick)
            FadeImage.DOFade(1f, FadeOutSpeed).OnComplete(Quit);
        _canClick = false;
    }

}
