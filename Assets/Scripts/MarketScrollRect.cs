using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MarketScrollRect : ScrollRect
{
    [SerializeField] UnityEvent onDragLeft, onDragRight;

    override public void OnBeginDrag(PointerEventData eventData)
    {
        int direction = -(int)Mathf.Sign(eventData.delta.x);

        if (direction < 0) onDragLeft?.Invoke();
        else if (direction > 0) onDragRight?.Invoke();
    }
}

