using System;
using UnityEngine;
using UnityEngine.UI;

public class CreditScreenController : MonoBehaviour
{
    public Action OnClose;
    [SerializeField] private Button _btnClose;

    private void Awake()
    {
        _btnClose.onClick.AddListener(Close);
    }
    private void Close()
    {
        OnClose?.Invoke();
        Destroy(gameObject);
    }
}
