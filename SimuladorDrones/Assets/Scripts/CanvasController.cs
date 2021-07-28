using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public RectTransform subMenu;
    float posFinal;
    bool abrirMenu = true;
    public float tiempo = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        posFinal = Screen.width / 10;
        subMenu.position = new Vector3(-posFinal, subMenu.position.y, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Mover(float time, Vector3 posInit, Vector3 posFin)
    {
        float elapsedTime = 0;
        while (elapsedTime < time){
            subMenu.position = Vector3.Lerp(posInit, posFin, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        subMenu.position = posFin;
    }

    void MoverMenu(float time, Vector3 posInit, Vector3 posFin)
    {
        StartCoroutine(Mover(time, posInit, posFin));
    }

    public void BUTTON_Sub_Menu()
    {
        int signo = 1;
        if(!abrirMenu){
            signo = -1;
        }
        MoverMenu (tiempo, subMenu.position, new Vector3(signo * posFinal, subMenu.position.y, 0));
        abrirMenu = !abrirMenu;
    }

}
