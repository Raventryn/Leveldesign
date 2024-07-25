using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveText : MonoBehaviour
{
    public GameObject graveText;

    private void Start()
    {
        graveText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        graveText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        graveText.SetActive(false);
        Destroy(gameObject);
    }
}
