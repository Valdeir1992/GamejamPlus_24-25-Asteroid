using UnityEngine;

[CreateAssetMenu(menuName = "Rougue Asteroid/Upgrade/Fire rate")]
public sealed class UpgradeFireRate : UpgradeSO
{
    [SerializeField] private float _value;

    public override void Upgrade()
    {
        FindAnyObjectByType<StatsController>().AddFireRate(_value);
    }
}
