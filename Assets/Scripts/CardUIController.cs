using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CardUIController : MonoBehaviour,IPointerClickHandler
{
    private Action OnClick;
    [SerializeField] private Image _background;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _descriptionView;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

    public void SetupCard(Sprite icon, UpgradeSO upgrade)
    {
        OnClick += upgrade.Upgrade;
        _background.sprite = icon;
        _icon.sprite = upgrade.Icon;
        _descriptionView.text = upgrade.Description;
    }
}
