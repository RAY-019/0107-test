using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIEventListener : EventTrigger
{
    public delegate void VoidDelegate(GameObject go);
    public delegate void VectorDelegate(GameObject go, Vector2 screenPosition);
    public delegate void BoolDelegate(GameObject go, bool value);
    public VoidDelegate onClick;
    public VoidDelegate onDown;
    public VoidDelegate onUp;
    public BoolDelegate onHover;
    public VectorDelegate onBeginDrag;
    public VectorDelegate onDrag;
    public VectorDelegate onEndDrag;

    static public UIEventListener Get(GameObject go)
    {
        PhysicsRaycaster raycaster = Camera.main.gameObject.GetComponent<PhysicsRaycaster>();
        if (raycaster == null) raycaster = Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        UIEventListener listener = go.GetComponent<UIEventListener>();
        if (listener == null) listener = go.AddComponent<UIEventListener>();
        return listener;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null) onClick.Invoke(gameObject);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (onDown != null) onDown.Invoke(gameObject);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (onUp != null) onUp.Invoke(gameObject);
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (onHover != null) onHover.Invoke(gameObject, true);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (onHover != null) onHover.Invoke(gameObject, false);
    }
    public override void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 position;
        Canvas canvas = FindObjectOfType<Canvas>();
        RectTransform rect = canvas.GetComponent<RectTransform>();
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, eventData.position, canvas.worldCamera, out position))
        {
            if (onBeginDrag != null) onBeginDrag.Invoke(gameObject, position);
        }
    }
    public override void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        Canvas canvas = FindObjectOfType<Canvas>();
        RectTransform rect = canvas.GetComponent<RectTransform>();
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, eventData.position, canvas.worldCamera, out position))
        {
            if (onDrag != null) onDrag.Invoke(gameObject, position);
        }
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        Vector2 position;
        Canvas canvas = FindObjectOfType<Canvas>();
        RectTransform rect = canvas.GetComponent<RectTransform>();
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, eventData.position, canvas.worldCamera, out position))
        {
            if (onEndDrag != null) onEndDrag.Invoke(gameObject, position);
        }
    }
}
