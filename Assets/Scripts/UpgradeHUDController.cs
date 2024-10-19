using UnityEngine;
using Zenject;

public class UpgradeHUDController : MonoBehaviour
{
    [Inject(Id ="Card Background")] private Sprite _cardSprite;
    [Inject] private CardUIController _cardUIPrefab;
    [SerializeField] private Transform _container;
    public void ShowCards(UpgradeSO[] upgradeSOs)
    {
        foreach(var upgrade in upgradeSOs)
        {
            var cardUI = Instantiate(_cardUIPrefab, _container);
            cardUI.SetupCard(_cardSprite, upgrade);
        }
    }
}
