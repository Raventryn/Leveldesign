using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public GameObject pressE;
    public bool _hasKey;
    private bool _inRange;

    // Start is called before the first frame update
    void Start()
    {
        _hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _inRange && _hasKey)
        {
            SceneManager.LoadScene("Outside");
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

