using UnityEngine;

[CreateAssetMenu(menuName = "Rogue Asteroid/Upgrade/Damage")]
public sealed class UpgradeDamage : UpgradeSO
{
    [SerializeField] private int _value;

    public override void Upgrade()
    {
        FindAnyObjectByType<StatsController>().AddDamage(_value);
    }
}
