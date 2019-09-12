using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour, ITriggerable
{
    public GameObject HideNormally;
    
    public void Trigger(bool down)
    {
        HideNormally.SetActive(!HideNormally.active);
    }
}
