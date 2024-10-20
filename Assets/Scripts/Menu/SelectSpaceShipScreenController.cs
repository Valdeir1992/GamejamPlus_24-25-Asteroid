using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectSpaceShipScreenController : MonoBehaviour
{
    public Action OnSelect;
    [SerializeField] private Transform _container;

    private void Awake()
    {
        for (int index = 0; index < _container.childCount; index++)
        {
            _container.GetChild(index).GetComponent<Button>().onClick.AddListener(() =>
            {
                OnSelect?.Invoke();
            });
        }
    }
    public void SelectSpaceShip(string name)
    {
        PlayerPrefs.SetString("SpaceShip", name);
    }
}
