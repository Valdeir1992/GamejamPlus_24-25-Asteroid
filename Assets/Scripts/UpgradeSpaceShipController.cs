using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class UpgradeSpaceShipController : MonoBehaviour
{
    [SerializeField] private UpgradeSO[] _upgrades;
    [SerializeField] private Transform _container;
    [Inject] private UpgradeHUDController _upgradeHUDController;

    private UpgradeSO[] GetUpgrades(int amount)
    {
        return _upgrades.OrderBy(x => Guid.NewGuid()).Take(amount).ToArray();
    }
    public void ShowUpgradeHUD()
    {
        var upgradeHUD = Instantiate(_upgradeHUDController, _container);
        upgradeHUD.ShowCards(GetUpgrades(3));
    }
}
