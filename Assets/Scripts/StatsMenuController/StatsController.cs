using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    [SerializeField] private float mFireRate = 3;
    [SerializeField] private float mProjectileSpeed = 2;
    [SerializeField] private int mNumberProjects = 1;
    [SerializeField] private int mDamage = 0;
    [SerializeField] private int mSpeed = 5;
    [SerializeField] private int mLevel = 1;
    [SerializeField] private float mAcceleration = 10;
    [SerializeField] private float mManeuverability = 5; 

   public int NumberProjects { get => mNumberProjects; }
   public float ProjectileSpeed { get => mProjectileSpeed; }
   public int Damage { get => mDamage; }
   public int Level { get => mLevel; }
    public int Speed { get => mSpeed; }
    public float FireRate { get => mFireRate; }
    public float Acceleration { get => mAcceleration; }
    public float Maneuverability { get =>mManeuverability; }

    void Start()
    {

    }

    void AddNumberProjetcs(int numProjetcs)
    {
        mNumberProjects += numProjetcs;
    }

    void AddProjectileSpeed(float speedProjectile)
    {
        mProjectileSpeed += speedProjectile;
    }

    void AddDamage(int numDamage)
    {
        mDamage += numDamage;
    }

    void AddSpeed(int numSpeed)
    {
        mSpeed += numSpeed;
    }

    void AddLevel(int numLevel)
    {
        mLevel += numLevel;
    }
  
    

}
