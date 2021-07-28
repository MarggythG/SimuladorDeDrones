using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        //transform.position, permite obtener la posicion del objeto donde esta este script.    
    //a travez del gameObjetc player puedo obtener la posicion de la esfera.
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate(){
        transform.position = player.transform.position + offset;
    }

}
