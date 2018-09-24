using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject navigationArea;
    public GameObject upgradeList;
    private Animator anim;
    private AnimationEvents events;

    void Start()
    {
        anim = navigationArea.GetComponent<Animator>();
        events = navigationArea.GetComponent<AnimationEvents>();
    }


    public void showList()
    {
        Util.Log("UIController", "Animation in progress? " + events.animationInProgress);
        if (!events.animationInProgress)
        {
            if (events.navBarOpen)
            {
                anim.Play("UpgradeMenuSlideOut");
            }
            else
            {
                anim.Play("UpgradeMenuSlideIn");
            }
        }
    }
}