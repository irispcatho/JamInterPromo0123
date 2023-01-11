using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanchaCollider : MonoBehaviour
{
    // Variables GD
    [Header("Variables")]
    public GameplayVariable Gameplay;
    private float CurrentGaugeFill;
    private bool IsColliding;
    private int UnitSetup = 10000;

    // Text
    [Header("Text")]
    public Image GaugeImage;

    private void Update()
    {
        CurrentGaugeFill = Mathf.Clamp(CurrentGaugeFill, 0, 1);
        GaugeImage.fillAmount = CurrentGaugeFill;

        if (IsColliding)
        {
            CurrentGaugeFill += Gameplay.GaugeOnPlanchaSpeed / UnitSetup;
        } else
        {
            CurrentGaugeFill -= Gameplay.GaugeSafeZoneSpeed / UnitSetup;
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsColliding = true;
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsColliding = false;
        }

    }
}
