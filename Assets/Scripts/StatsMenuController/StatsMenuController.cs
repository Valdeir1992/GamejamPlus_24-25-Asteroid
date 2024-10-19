using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsMenuController : MonoBehaviour
{

    private float mProjectileSpeed;
    private int mNumberProjects;
    private int mDamage;
    private int mSpeed;
    private int mLevel;

   public int NumberProjects { get => mNumberProjects; }
   public float ProjectileSpeed { get => mProjectileSpeed; }
   public int Damage { get => mDamage; }
   public int Level { get => mLevel; }
    public int Speed { get => Speed; }

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
