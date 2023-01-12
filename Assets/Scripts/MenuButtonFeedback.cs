using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonFeedback : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Tween _scaleDown;
    private Tween _scaleUp;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _scaleUp?.Kill();
        _scaleUp = transform.DOScale(Vector3.one * MenuManager.Instance.ScaleEffect, MenuManager.Instance.ScaleDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _scaleDown?.Kill();
        _scaleDown = transform.DOScale(Vector3.one, MenuManager.Instance.ScaleDuration);
    }
}