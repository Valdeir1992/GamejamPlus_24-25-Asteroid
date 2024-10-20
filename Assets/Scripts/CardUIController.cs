using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CardUIController : MonoBehaviour,IPointerClickHandler
{
    public Action OnClick;
    [SerializeField] private Image _background;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _descriptionView;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

    public void SetupCard(UpgradeSO upgrade)
    {
        OnClick += upgrade.Upgrade; 
        _icon.sprite = upgrade.Icon;
        _descriptionView.text = upgrade.Description;
    }
}
