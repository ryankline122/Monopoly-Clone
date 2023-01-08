using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{
    bool onGround;
    public int value;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            onGround = false;
        }
    }

    public bool OnGround()
    {
        return onGround;
    }
}
