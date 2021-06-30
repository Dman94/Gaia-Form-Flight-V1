using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
                                         //This class we attach to the explosion particles gameobject to instruct a self destruct function

    [SerializeField] float timetilDestroy;

     void Start()
    {
        Destroy(gameObject, timetilDestroy);
    }
}
