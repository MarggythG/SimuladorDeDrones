using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementManager : MonoBehaviour
{

    public List<MOVEMENT_TYPE> movements;
    public GameObject movementManager;
    private int isPlaying;
    private DroneMovement droneMovement;

    void Start()
    {
        droneMovement = GameObject.Find("Drone").GetComponent<DroneMovement>();   
    }

    public void AddMovement(MOVEMENT_TYPE type)
    {
        droneMovement.Restart();
        movements.Add(type);
    }

    

}
