using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossLasers : MonoBehaviour
{
    [SerializeField] GameObject Target;

    // Update is called once per frame
    void Update()
    {
      
        transform.LookAt(Target.transform.position);
    }
}
