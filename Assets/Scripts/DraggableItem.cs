using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Transform originalParent;
    private Vector3 originalPosition;
    public Transform parentAfterDrag; // Declare parentAfterDrag here

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
     
        originalPosition = transform.position;

        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        transform.position = originalPosition;
    }
}
