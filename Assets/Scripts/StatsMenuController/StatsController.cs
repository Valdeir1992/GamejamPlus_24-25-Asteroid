using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    [SerializeField] private float mFireRate = 3;
    [SerializeField] private float mProjectileSpeed = 2;
    [SerializeField] private int mNumberProjects = 1;
    [SerializeField] private int mDamage = 0;
    [SerializeField] private float mSpeed = 5;
    [SerializeField] private int mLevel = 1;
    [SerializeField] private float mAcceleration = 10;
    [SerializeField] private float mManeuverability = 5; 

   public int NumberProjects { get => mNumberProjects; }
   public float ProjectileSpeed { get => mProjectileSpeed; }
   public int Damage { get => mDamage; }
   public int Level { get => mLevel; }
    public float Speed { get => mSpeed; }
    public float FireRate { get => mFireRate; }
    public float Acceleration { get => mAcceleration; }
    public float Maneuverability { get =>mManeuverability; }

    public void AddFireRate(float fireRate)
    {
        mFireRate += fireRate;
    }
    public void AddNumberProjetcs(int numProjetcs)
    {
        mNumberProjects += numProjetcs;
    }

    public void AddProjectileSpeed(float speedProjectile)
    {
        mProjectileSpeed += speedProjectile;
    }

    public void AddDamage(int numDamage)
    {
        mDamage += numDamage;
    }
    public void AddManeuverability(float maneuverability)
    {
        mManeuverability += maneuverability;
    }

    public void AddSpeed(float numSpeed)
    {
        mSpeed += numSpeed;
    }

    public void AddLevel(int numLevel)
    {
        mLevel += numLevel;
    }
  
    

}
