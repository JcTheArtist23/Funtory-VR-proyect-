using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackUI : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        GetComponent<Animator>().SetBool("Black", true);
    }
}
