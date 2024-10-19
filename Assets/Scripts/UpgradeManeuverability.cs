using UnityEngine;

[CreateAssetMenu(menuName = "Rougue Asteroid/Upgrade/Maneuverability")]
public sealed class UpgradeManeuverability : UpgradeSO
{
    [SerializeField] private int _value;

    public override void Upgrade()
    {
        FindAnyObjectByType<StatsController>().AddManeuverability(_value);
    }
}
