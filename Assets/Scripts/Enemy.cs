using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///This class communicates with ScoreBoard Class
public class Enemy : MonoBehaviour
{

    [Tooltip("Assign the explosion particle system to trigger upon enemy death")] [SerializeField] GameObject deathFX;
    [Tooltip("Assign a laser impact perticle system to trigger uppon laser collision with enemy")] [SerializeField] GameObject laserImpactVFX;
   



    [Tooltip("How much the user will gain based on laser impact on enemy")] [SerializeField] float ScorePerHit = 5;
    [Tooltip("How much the user will gain based on kill of an enemy")] [SerializeField] float ScorePerKill = 30;
    [Tooltip("How many laser collisions required to kill enemy")] [SerializeField] int HitPoints = 5;
    [Tooltip("Always keep at zero so KitPoints value is accurate")] [SerializeField] int HitCount;

    ScoreBoard scoreboard; // since scoreBoard is a public class we can create a variable of type ScoreBoard

    GameObject GarbageCollector; // an empty gameobject that will be used as a trash can for our explosion particles keeping the hiearchy from getting cluttered

     void Start()
    {
        //FindObjectOType searches entire project for specified class this will allow the enemy script to find where the scoreboard is so we can update it 
        scoreboard = FindObjectOfType<ScoreBoard>();  

        //FindWithTag is similar to FIndObjectOfType accept that it locates and identifies a gameobject by its specified tag
        GarbageCollector = GameObject.FindWithTag("GarbageCollector");   

        HitCount = 0;
        AddRigidBody();
    }





     void AddRigidBody() // adding rigidbody through code so we don't need ot manually add one for each instance of an enemy we create through editor
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }




    void OnParticleCollision(GameObject other)
    {
        HitCount++; //Each particle collision add 1 to the HitCount
        ProcessHitandKill();
    }






    void ProcessHitandKill()
    {
        if (HitCount > 0 || HitCount == HitPoints)
        {
            ProcessHit();
        }
        if (HitCount > HitPoints)
        {
            ProcessKill();
        }
    }





    void ProcessHit()
    {
        scoreboard.increaseScorebyHit(ScorePerHit);
        GameObject ImpactVFX = Instantiate(laserImpactVFX, transform.position, Quaternion.identity);
        ImpactVFX.transform.parent = GarbageCollector.transform;
    }




   

     void ProcessKill()
    {
        scoreboard.increaseScorebyKill(ScorePerKill);
        GameObject EnemyDeathVFX = Instantiate(deathFX, transform.position, Quaternion.identity); // Instantiate = create + assign value
        EnemyDeathVFX.transform.parent = GarbageCollector.transform;
        Destroy(gameObject);
    }

}
