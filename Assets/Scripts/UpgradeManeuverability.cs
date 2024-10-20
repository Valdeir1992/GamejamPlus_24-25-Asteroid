using UnityEngine;

[CreateAssetMenu(menuName = "Rogue Asteroid/Upgrade/Maneuverability")]
public sealed class UpgradeManeuverability : UpgradeSO
{
    [SerializeField] private float _value;

    public override void Upgrade()
    {
        FindAnyObjectByType<StatsController>().AddManeuverability(_value);
    }
}
