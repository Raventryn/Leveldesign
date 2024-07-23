using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GravesInteraction : MonoBehaviour
{
    public GameObject pressE;
    public GameObject text;
    private bool _inRange;

    // Start is called before the first frame update
    void Start()
    {
        pressE.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _inRange)
        {
            pressE.gameObject.SetActive(false);
            text.gameObject.SetActive(true);
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
        text.gameObject.SetActive(false);
        // Start the coroutine to hide the image and then disable it after
    }
}
