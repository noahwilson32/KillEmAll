using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBoom : MonoBehaviour
{
    public SpriteRenderer theSR;
    public Sprite spriteIdle;
    public Sprite spriteWalk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BoomController.isWalking)
        {
            StartCoroutine(anim());

        }
        else
        {
            theSR.sprite = spriteIdle;
        }
    }
    IEnumerator anim()
    {
        theSR.sprite = spriteIdle;
        yield return new WaitForSeconds(.1f);
        theSR.sprite = spriteWalk;
    }
}
