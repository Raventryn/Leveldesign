using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public GameObject pressE;
    public GameObject noKey;
    public AnimationClip fadeToBlack;
    public Animator _fadeToBlackAnimator;
    public GameObject _imageBlack;
    public bool _hasKey;
    public bool _hasNoKey;
    private bool _inRange;


    // Start is called before the first frame update
    void Start()
    {
        _hasKey = false;
        _hasNoKey = true;
        noKey.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _inRange && _hasKey)
        {
            StartCoroutine(WaitForFade());
        }

        if (Input.GetKeyDown(KeyCode.E) && _inRange && _hasKey == false && _hasNoKey == true)
        {
            noKey.gameObject.SetActive(true);
            pressE.gameObject.SetActive(false);
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
        noKey.gameObject.SetActive(false);
        // Start the coroutine to hide the image and then disable it after
    }

    IEnumerator WaitForFade()
    {
        _fadeToBlackAnimator.SetTrigger("FadeAway");

        yield return new WaitForSeconds(fadeToBlack.length);

        SceneManager.LoadScene("Outside");
    }
}

