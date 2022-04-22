using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolo : MonoBehaviour
{
    public bool isSprawled;
    public bool canDestroyIt;

    private Rigidbody rbBolo;

    private void Awake()
    {
        rbBolo = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        isSprawled = false;
        canDestroyIt = false;
    }

    private void Update()
    {
        if(isSprawled == true && canDestroyIt == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}
