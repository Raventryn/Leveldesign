using StarterAssets;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiftPlayer : MonoBehaviour
{
    public float liftHeight = 50f;   // Höhe in Einheiten, die der Spieler schweben soll
    public float liftSpeed = 2f;     // Geschwindigkeit des Schwebens
    private bool isPlayerInTrigger = false; // Überprüft, ob der Spieler im Triggerbereich ist
    private bool isLifting = false;  // Überprüft, ob der Spieler gerade schwebt
    private Transform playerTransform;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private FirstPersonController _firstPersonController;

    private void Start()
    {
        _firstPersonController = GameObject.Find("Player").GetComponent<FirstPersonController>();
    }

    void Update()
    {
        // Überprüfen, ob der Spieler die Taste E drückt und im Trigger ist
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && !isLifting)
        {
            _firstPersonController.enabled = false;
            Debug.Log("E Taste gedrückt, Start Lifting");
            StartLifting();
        }

        // Wenn der Spieler schwebt, bewegen wir ihn nach oben
        if (isLifting)
        {
            Lift();
        }
    }

    private void StartLifting()
    {
        isLifting = true;
        startPosition = playerTransform.position;
        targetPosition = startPosition + Vector3.up * liftHeight;
        Debug.Log("Start Position: " + startPosition + ", Target Position: " + targetPosition);
    }

    private void Lift()
    {
        Vector3 oldPosition = playerTransform.position;
        playerTransform.position = Vector3.MoveTowards(playerTransform.position, targetPosition, liftSpeed * Time.deltaTime);
        Debug.Log($"Lifting: Old Position = {oldPosition}, New Position = {playerTransform.position}");

        if (Vector3.Distance(playerTransform.position, targetPosition) < 0.1f)
        {
            isLifting = false; // Schwebebewegung beenden
            Debug.Log("Ziel erreicht, Lifting beendet");
            SceneManager.LoadScene(0);
        }
    }

    // Überprüfen, ob der Spieler den Trigger betritt
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            playerTransform = other.transform;
            Debug.Log("Player hat den Trigger betreten");
        }
    }

    // Überprüfen, ob der Spieler den Trigger verlässt
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            if (!isLifting)
            {
                playerTransform = null;
            }
            Debug.Log("Player hat den Trigger verlassen");
        }
    }
}
