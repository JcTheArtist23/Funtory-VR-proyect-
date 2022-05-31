using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteUI : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        StartCoroutine("WhiteAnimTime");
    }

    private IEnumerator WhiteAnimTime()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetBool("White", true);
        SceneSelector.canUseUI = true;
    }
}
