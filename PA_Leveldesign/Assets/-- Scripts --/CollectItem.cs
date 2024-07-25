using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public GameObject pressE;

    public GameObject pickUp;

    public GameObject keySprite;

    private GameObject _key;

    private Teleport _teleport;

    private bool _inRange;



    // Start is called before the first frame update
    void Start()
    {
        _teleport = GameObject.Find("Teleport_Trigger").GetComponent<Teleport>();
        _key = GameObject.Find("Key");
        pressE.gameObject.SetActive(false);
        pickUp.gameObject.SetActive(false);
        keySprite.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _inRange)
        {
            pickUp.gameObject.SetActive(false);
            _teleport._hasKey = true;
            gameObject.SetActive(false);
            _key.SetActive(false);
            keySprite.gameObject.SetActive(true);
            _teleport._hasNoKey = false;
        }
    }

    // On Trigger Enter: enable the 'press E' text and set inRange to true
    private void OnTriggerEnter(Collider other)
    {
        pickUp.gameObject.SetActive(true);
        _inRange = true;
    }

    // On Trigger Exit: set inRange to false, disable both text objects
    private void OnTriggerExit(Collider other)
    {
        _inRange = false;
        pickUp.gameObject.SetActive(false);
        // Start the coroutine to hide the image and then disable it after
    }
}