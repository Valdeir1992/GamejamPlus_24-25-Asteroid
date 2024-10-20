using UnityEngine;

[CreateAssetMenu(menuName ="Rogue Asteroid/Spaceship/Data")]
public class SpaceShipData : ScriptableObject
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _startProjectileSpeed;
    [SerializeField] private float _startFireRate;
    [SerializeField] private float _startAcceleration;
    [SerializeField] private float _startManeuverability;
    [SerializeField] private int _startNumberProjectiles;
    [SerializeField] private int _startDamage;

    public float StartSpeed { get => _startSpeed;}
    public float StartProjectileSpeed { get => _startProjectileSpeed;}
    public float StartFireRate { get => _startFireRate;}
    public float StartAcceleration { get => _startAcceleration;}
    public float StartManeuverability { get => _startManeuverability;}
    public int StartNumberProjectiles { get => _startNumberProjectiles;}
    public int StartDamage { get => _startDamage;}
}
