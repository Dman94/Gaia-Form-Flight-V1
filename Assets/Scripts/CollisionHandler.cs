using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Header("Invoked Method Values")]
    [Tooltip("Input Value for killing player control  upon collision trigger")] [SerializeField] float KillControl;
    [Tooltip("Input Value for reloading scence upon collision trigger")] [SerializeField] float ReloadScene;
    [SerializeField] ParticleSystem explosion;




   bool isTransitioning;




     void Start()
    {
        isTransitioning = false;
    }








    void OnTriggerEnter(Collider other)
    {
        SendDebugMessage(other);
        StartCrashSequence();
    }


    




    void SendDebugMessage(Collider other)
    {
        Debug.Log($"{this.name} ** Triggered by** {other.gameObject.name}");
    }







    void StartCrashSequence()
    {
        killControl();
        Explosion();
        Invoke("reloadScene", ReloadScene);
    }







     void killControl()
    {
        GetComponent<Flight>().enabled = false;
    }







    void reloadScene()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentBuildIndex);
    }






    void Explosion()
    {
        
        isTransitioning = true;
        if(isTransitioning == true)
        {
          explosion.GetComponentInChildren<ParticleSystem>().Play();
        }
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
      
    }

 



   
    
}
