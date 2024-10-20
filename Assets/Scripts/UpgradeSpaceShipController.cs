using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class UpgradeSpaceShipController : MonoBehaviour
{
    [SerializeField] private UpgradeSO[] _upgrades; 
    [Inject] private UpgradeHUDController _upgradeHUDController;
    private XPController _xpController;

    private void Awake()
    {
        _xpController = FindAnyObjectByType<XPController>();
        _xpController.OnLevelUp += ctx =>
        {
            ShowUpgradeHUD();
        };
    }

    private UpgradeSO[] GetUpgrades(int amount)
    {
        return _upgrades.OrderBy(x => Guid.NewGuid()).Take(amount).ToArray();
    }
    public void ShowUpgradeHUD()
    {
        var upgradeHUD = Instantiate(_upgradeHUDController);
        upgradeHUD.ShowCards(GetUpgrades(3));
    }
}
