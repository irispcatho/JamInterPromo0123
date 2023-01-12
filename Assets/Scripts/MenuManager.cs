using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string _playScene;
    [SerializeField] private string _creditsScene;
    [SerializeField] private string _settingsScene;
    
    [SerializeField] private float _scaleDuration = 0.2f;
    [SerializeField] private float _scaleEffect = 1.15f;
    
    public float ScaleDuration => _scaleDuration;
    public float ScaleEffect => _scaleEffect; 

    public static MenuManager Instance;

    private void Awake() => Instance = this;

    public void Play() => SceneManager.LoadScene(_playScene);
    public void Settings() => SceneManager.LoadScene(_settingsScene);
    public void Credits() => SceneManager.LoadScene(_creditsScene);
    public void Quit() => Application.Quit();
}
