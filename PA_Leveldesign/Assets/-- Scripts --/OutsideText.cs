using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideText : MonoBehaviour
{
    public GameObject outsideText;



    private void OnTriggerStay(Collider other)
    {
        outsideText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        outsideText.SetActive(false);
        Destroy(gameObject);
    }
}
