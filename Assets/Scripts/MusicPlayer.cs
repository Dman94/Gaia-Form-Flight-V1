using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
     void Awake()    // awake is the first function called in the order of execution
    {
        // first thing we do is find how many of these music players exist in our world

        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length; // Checks the array objects of the specified type for how many exist
        
        if(numMusicPlayers > 1) // if there is more than 1 of yourself then destroy yourself
        {
            Destroy(gameObject); 
        }
        else // since the first scene starts at 0 then ticks to 1 Music player found in the world the above IF statement will not execute until after the 1st player death
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
