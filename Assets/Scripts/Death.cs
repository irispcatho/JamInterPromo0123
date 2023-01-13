using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;



public class Death : MonoBehaviour
{
    [SerializeField] private Image FadeImage;
    [SerializeField] private Color ImageColor;
    [SerializeField] private float FadeInSpeed;
    [SerializeField] private float FadeOutSpeed;
    public string TargetScene;


    private void Start()
    {
        // Alpha 1
        FadeImage.DOFade(1f, 0f);
        FadeIn();
        FadeImage.color = ImageColor;
    }

    public void PlayerDeath()
    {
        var Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            if (Player.activeInHierarchy) {
                GoToScene();
                //Player.SetActive(false);
                
            }
        }
    }

    public void FadeIn()
    {
        FadeImage.DOFade(0f, FadeInSpeed);
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(TargetScene);
    }
}
