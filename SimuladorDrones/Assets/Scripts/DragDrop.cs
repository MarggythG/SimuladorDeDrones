using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum MOVEMENT_TYPE {
    UP,
    DOWN,
    RIGHT,
    LEFT,
    FRONT,
    BEHIND   
}
public class DragDrop : MonoBehaviour, IPointerDownHandler,
    IBeginDragHandler, IEndDragHandler, IDragHandler,
    IDropHandler
{

    [SerializeField] private Canvas canvas;
    private RectTransform executeGroup;

    public MOVEMENT_TYPE movementType;

    public GameObject buttonPrefab;
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform startingParent;
    private Vector3 startingPosition;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        executeGroup = GameObject.Find("Ejecutar").GetComponent<RectTransform>();
        startingParent = this.gameObject.transform.parent;
        startingPosition = this.gameObject.transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("OnBeginDrag");

    }

    public void OnDrag(PointerEventData eventData){
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("OnEndDrag");
        if(RectTransformUtility.RectangleContainsScreenPoint(executeGroup, eventData.position, eventData.pressEventCamera))
        {
            GameObject GO = Instantiate(buttonPrefab, executeGroup.transform, false);
            GO.GetComponent<DragDrop>().movementType = movementType;
            GO.GetComponentInChildren<Text>().text = this.GetComponentInChildren<Text>().text;
            this.GetComponent<RectTransform>().position = startingPosition;
            GameObject.Find("MovementManager").GetComponent<MovementManager>().AddMovement(movementType);
        }
        else
        {
            this.gameObject.transform.position = startingPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData){
        Debug.Log("OnDrop");
    }
}

