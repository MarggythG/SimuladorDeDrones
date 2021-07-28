using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DroneMovement : MonoBehaviour
{
    private MovementManager movementManager;

    private Vector3 startingPosition;

    public float moveSpeed;

    public static int score = 0;
    public string ScoreString = "Puntos: ";
    public Text TextScore;

    public string nextLevel;

    void Start()
    {
        movementManager = GameObject.Find("MovementManager").GetComponent<MovementManager>();   
        startingPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(TextScore != null){
            TextScore.text = ScoreString + score.ToString();
        }
    }

    public void ExecuteMovement(){
        Restart();
        StartCoroutine(Move());
    }

    public void Restart(){
        StopAllCoroutines();
        this.gameObject.transform.position = startingPosition;
    }

    public IEnumerator Move(){
        foreach (MOVEMENT_TYPE type in movementManager.movements) {
            switch(type){
                case MOVEMENT_TYPE.UP:
                    StartCoroutine(MoveOverSeconds(this.gameObject, new Vector3(this.gameObject.transform.position.x, (this.gameObject.transform.position.y + 10), this.gameObject.transform.position.z), 2)); 
                    break;
                case MOVEMENT_TYPE.DOWN:
                    float destinationY = (this.gameObject.transform.position.y - 10);
                    if(destinationY > 0)
                    {
                        StartCoroutine(MoveOverSeconds(this.gameObject, new Vector3(this.gameObject.transform.position.x, destinationY, this.gameObject.transform.position.z), 2)); 
                    }
                    break;
                case MOVEMENT_TYPE.LEFT:
                    StartCoroutine(MoveOverSeconds(this.gameObject, new Vector3((this.gameObject.transform.position.x - 10), this.gameObject.transform.position.y, this.gameObject.transform.position.z), 2)); 
                    break;
                case MOVEMENT_TYPE.RIGHT:
                    StartCoroutine(MoveOverSeconds(this.gameObject, new Vector3((this.gameObject.transform.position.x + 10), this.gameObject.transform.position.y, this.gameObject.transform.position.z), 2)); 
                    break;
                case MOVEMENT_TYPE.FRONT:
                    StartCoroutine(MoveOverSeconds(this.gameObject, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, (this.gameObject.transform.position.z + 10)), 2)); 
                    break;
                case MOVEMENT_TYPE.BEHIND:
                StartCoroutine(MoveOverSeconds(this.gameObject, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, (this.gameObject.transform.position.z - 10)), 2)); 
                    break;
            }
            yield return new WaitForSecondsRealtime(4);
        }
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 destination, float amountOfTime)
    {
        float elapsedTime = 0;
        Vector3 startingPosition = objectToMove.transform.position;
        while(elapsedTime < amountOfTime)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPosition, destination, (elapsedTime/amountOfTime));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = destination;
        yield return new WaitForSecondsRealtime(1);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Recolectable")) {
            other.gameObject.SetActive(false);
            score += 5;
            if(!string.IsNullOrEmpty(nextLevel))
            {
                if(score >= 25)
                {
                        SceneManager.LoadScene(nextLevel);
                        score=0;
                }
            }
        }
    }
}
