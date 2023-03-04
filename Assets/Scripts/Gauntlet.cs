using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauntlet : MonoBehaviour
{
     [SerializeField] private Animator anim;

    bool closed;

     void Start()
    {
        if(!anim)
        anim = GetComponent<Animator>();   
    }

    //maybe remove extra closed checks if unnecessary
    public void FistOpen()
    {
        if(closed)
        anim.SetBool("CloseFist", false);
        closed = false;
    }
    public void FistClose()
    {
        if(!closed)
        anim.SetBool("CloseFist", true);
        closed = true;
    }
}
