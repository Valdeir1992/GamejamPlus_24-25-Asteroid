using UnityEngine;

[CreateAssetMenu(menuName ="Rogue Asteroid/Upgrade/Speed")]
public sealed class UpgradeSpeed : UpgradeSO
{
    [SerializeField] private float _value;

    public override void Upgrade()
    {
        FindAnyObjectByType<StatsController>().AddSpeed(_value);
    }
}
