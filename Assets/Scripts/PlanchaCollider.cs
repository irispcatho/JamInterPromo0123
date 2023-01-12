using System.Collections;
using System.Collections.Generic;
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
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isColliding = true;
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isColliding = false;
        }

    }
}
