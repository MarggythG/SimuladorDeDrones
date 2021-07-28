using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRecolectables : MonoBehaviour
{
    private Rigidbody rb;
    public Transform particulas;
    private ParticleSystem sistemaParticulas;
    private Vector3 posicion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sistemaParticulas = particulas.GetComponent<ParticleSystem> ();
        sistemaParticulas.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Recolectable")) {
            //Debug.Log("Colision con recolectable");
            Destroy(other.gameObject);
        } else {

        }
    }

}
