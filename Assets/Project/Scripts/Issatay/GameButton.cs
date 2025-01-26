using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GameButton : MonoBehaviour
{
    public Transform gate;  
    public Transform openPosition;   
    public float openSpeed = 2f;
    public Transform buttonVisuial;
    private Vector3 buttonScale;

    private Vector3 closedPosition;
    private int objectsOnButton = 0;

    void Start()
    {
        buttonScale = buttonVisuial.localScale;

        if (gate != null)
            closedPosition = gate.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Button");
        if (other.attachedRigidbody != null)
        {
            objectsOnButton++;
            buttonVisuial.localScale = Vector3.zero;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.attachedRigidbody != null)
        {
            objectsOnButton--;
            buttonVisuial.localScale = buttonScale;

        }
    }

    void Update()
    {
        if (gate != null)
        {
            Vector3 targetPosition = objectsOnButton > 0 ? openPosition.position : closedPosition;
            gate.position = Vector3.MoveTowards(gate.position, targetPosition, openSpeed * Time.deltaTime);
        }
    }

}
