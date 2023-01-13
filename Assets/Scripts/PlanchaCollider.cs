using System.Collections;
using System.Collections.Generic;
using CMF;
using UnityEngine;
using UnityEngine.UI;

public class PlanchaCollider : MonoBehaviour
{
    // Variables GD
    [Header("Variables")]
    public GameplayVariable Gameplay;
    private float _currentGaugeFill;
    private bool _isColliding;
    private int _unitSetup = 10000;
    public Death Death;

    // Text
    [Header("Text")]
    public Image GaugeImage;

    private void Update()
    {
        _currentGaugeFill = Mathf.Clamp(_currentGaugeFill, 0, 1);
        GaugeImage.fillAmount = _currentGaugeFill;

        if (_isColliding)
        {
            _currentGaugeFill += Gameplay.GaugeOnPlanchaSpeed / _unitSetup;
        } else
        {
            _currentGaugeFill -= Gameplay.GaugeSafeZoneSpeed / _unitSetup;
        }

        if (_currentGaugeFill >= 1)
        {
            // Player Death
            Death.PlayerDeath();
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        AdvancedWalkerController player = collision.GetComponent<AdvancedWalkerController>();
        if (player != null)
        {
            _isColliding = true;
            player._smoke.SetActive(true);
            player._smokeAnimator.SetBool("Burning", true);
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        AdvancedWalkerController player = collision.GetComponent<AdvancedWalkerController>();
        if (player != null)
        {
            _isColliding = false;
            player._smoke.SetActive(false);
            player._smokeAnimator.SetBool("Burning", false);
        }

    }
}
