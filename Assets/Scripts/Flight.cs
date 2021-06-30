using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{
    [Header("Ship Translation Settings")]
    [Tooltip("How fast the ship goes horizontal based on player input")] [SerializeField] float xThrowStrength = .5f;
    [Tooltip("How fast the ship goes vertical based on player input")] [SerializeField] float yThrowStrength = .5f;
    [Tooltip("How far the ship can travel vertical from the center of the screen")] [SerializeField] float xRange = 3f;
    [Tooltip("How far the ship can travel horizontal from the center of the screen")] [SerializeField] float yRange = .3f;

    [Header("Particle System Array For Lasers")]
    [Tooltip("Import left and right lasers to control emitter modules using a foreach loop")][SerializeField] GameObject[] Lasers;

    [Header("Ship Rotation Settings")]
    [Tooltip("How much the ship will pitch based on a change in Y position in the screen")][SerializeField] float PositionPitchFactor = 5f;
    [Tooltip("How much the ship will YAW based on X position in the screen")] [SerializeField] float PositionYawFactor = 5f;
    [Tooltip("The sum of this value and (PositionPitchFactor) results in the max Pitch")] [SerializeField] float pitchControlFactor = 5f;
    [Tooltip("How much the ship will Roll based on user input (This value is both the strength of roll and how far it will roll)")] [SerializeField] float rollControlFactor = 5f;

    float Horizontal, Vertical;
    





    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }





    void ProcessTranslation()
    {
         Horizontal = Input.GetAxis("Horizontal");
         Vertical = Input.GetAxis("Vertical");

        float xThrow = transform.localPosition.x + xThrowStrength * Horizontal * Time.deltaTime;
        float yThrow = transform.localPosition.y + yThrowStrength * Vertical * Time.deltaTime;

        float ClampedHorizontal = Mathf.Clamp(xThrow, -xRange, xRange);
        float ClampedVertical = Mathf.Clamp(yThrow, -yRange, yRange);

        transform.localPosition = new Vector3(ClampedHorizontal, ClampedVertical, transform.localPosition.z);
    }





    void ProcessRotation()
    {
         Horizontal = Input.GetAxis("Horizontal");
         Vertical = Input.GetAxis("Vertical");

        float pitchDueToPosition = transform.localPosition.y + Vertical * PositionPitchFactor;
        float pitchDueToControl = Vertical * pitchControlFactor;
          float Pitch = pitchDueToPosition + pitchDueToControl;

        float yawDueToPosition = transform.localPosition.x + Horizontal * PositionYawFactor;
          float Yaw = yawDueToPosition;

        float rollDuetoControl = transform.localPosition.z + Horizontal * rollControlFactor;
          float Roll = rollDuetoControl;

        transform.localRotation = Quaternion.Euler(Pitch,Yaw, Roll);
    }





    public void ProcessFiring()
    {
        if (Input.GetButton("Fire3"))
        {
            LasersActivated(true);
        }
        else
        {
            LasersActivated(false);
        }
    }





   void LasersActivated(bool isActivated)
    {
        foreach(GameObject laser in Lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActivated;
        }
    }
   
}



