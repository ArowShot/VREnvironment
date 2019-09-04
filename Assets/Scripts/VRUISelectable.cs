using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class VRUISelectable : MonoBehaviour, IVRUIInteraction
{
    private BoxCollider boxCollider;
    private RectTransform rectTransform;
    
    public Vector3 sizeOverride;
    
    private void OnEnable()
    {
        ValidateCollider();
    }

    private void OnValidate()
    {
        ValidateCollider();
    }

    private void ValidateCollider()
    {
        rectTransform = GetComponent<RectTransform>();

        boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider>();
        }

        if (sizeOverride != Vector3.zero)
        {
            boxCollider.size = sizeOverride;
        } else
        {
            boxCollider.size = rectTransform.sizeDelta;
        }
    }

    public void Click(object sender, PointerEventArgs e)
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            var current = EventSystem.current;
            ExecuteEvents.Execute(current.currentSelectedGameObject, new PointerEventData(current), ExecuteEvents.submitHandler);
        }
    }

    public void Enter(object sender, PointerEventArgs e)
    {
        var button = e.target.GetComponent<Selectable>();
        if (button != null)
        {
            button.Select();
            Debug.Log("HandlePointerIn", e.target.gameObject);
        }
    }

    public void Exit(object sender, PointerEventArgs e)
    {
        var button = e.target.GetComponent<Selectable>();
        if (button != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            Debug.Log("HandlePointerOut", e.target.gameObject);
        }
    }
}