using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TeleportChurch : MonoBehaviour
{
    public GameObject pressE;
    private bool _inRange;

    private void Start()
    {
        pressE.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _inRange)
        {
            SceneManager.LoadScene("Grave");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        pressE.gameObject.SetActive(true);
        _inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _inRange = false;
        pressE.gameObject.SetActive(false);
        // Start the coroutine to hide the image and then disable it after
    }
}
