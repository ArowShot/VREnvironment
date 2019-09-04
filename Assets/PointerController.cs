using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR.Extras;

public class PointerController : MonoBehaviour
{
    public SteamVR_LaserPointer[] LaserPointers;
    
    void Start()
    {
        foreach (var laserPointer in LaserPointers)
        {
            laserPointer.PointerClick += PointerClick;
            laserPointer.PointerIn += PointerEnter;
            laserPointer.PointerOut += PointerLeave;
        }
    }

    void PointerClick(object sender, PointerEventArgs e)
    {
        var interaction = e.target.GetComponents<IVRUIInteraction>();
        foreach (var vruiInteraction in interaction)
        {
            vruiInteraction.Click(sender, e);
        }
    }
    
    void PointerEnter(object sender, PointerEventArgs e)
    {
        var interaction = e.target.GetComponents<IVRUIInteraction>();
        foreach (var vruiInteraction in interaction)
        {
            vruiInteraction.Enter(sender, e);
        }
    }
    
    void PointerLeave(object sender, PointerEventArgs e)
    {
        var interaction = e.target.GetComponents<IVRUIInteraction>();
        foreach (var vruiInteraction in interaction)
        {
            vruiInteraction.Exit(sender, e);
        }
    }
}
