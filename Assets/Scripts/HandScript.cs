using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class HandScript : MonoBehaviour
{
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean triggerAction;

    private SteamVR_Behaviour_Pose pose = null;
    private FixedJoint joint = null;

    private Interactable currentInteractable = null;
    private List<Interactable> contacting = new List<Interactable>();

    private void Awake()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        joint = GetComponent<FixedJoint>();
    }

    private void Update()
    {
        if (grabAction.GetStateDown(pose.inputSource))
        {
            Pickup();
        }

        if (grabAction.GetStateUp(pose.inputSource))
        {
            Drop();
        }
        
        if (triggerAction.GetStateDown(pose.inputSource) || triggerAction.GetStateUp(pose.inputSource))
        {
            if (currentInteractable)
            {
                var triggerables = currentInteractable.GetComponents<ITriggerable>();
                foreach (var triggerable in triggerables)
                {
                    triggerable.Trigger(triggerAction.state);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Interactable"))
            return;
        
        contacting.Add(other.gameObject.GetComponent<Interactable>());
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(!other.gameObject.CompareTag("Interactable"))
            return;
        
        contacting.Remove(other.gameObject.GetComponent<Interactable>());
    }

    private void Pickup()
    {
        currentInteractable = GetNearestInteractable();

        if (!currentInteractable)
            return;
        
        if(currentInteractable.ActiveHand)
            currentInteractable.ActiveHand.Drop();

        currentInteractable.transform.position = transform.position;

        var targetBody = currentInteractable.GetComponent<Rigidbody>();
        joint.connectedBody = targetBody;

        currentInteractable.ActiveHand = this;
    }

    private void Drop()
    {
        if (!currentInteractable)
            return;
        
        var targetBody = currentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = pose.GetVelocity();
        targetBody.angularVelocity = pose.GetAngularVelocity();
        
        joint.connectedBody = null;

        currentInteractable.ActiveHand = null;
        currentInteractable = null;

    }

    private Interactable GetNearestInteractable()
    {
        Interactable nearest = null;

        var minDistance = float.MaxValue;
        var distance = 0.0f;

        foreach (var interactable in contacting)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;

                nearest = interactable;
            }
        }

        return nearest;
    }
}
