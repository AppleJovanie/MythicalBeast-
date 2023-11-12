using UnityEngine;
using UnityEngine.EventSystems;

public class CombinationSlot : MonoBehaviour, IDropHandler
{
    public float snapDistance = 50f; // Adjust this value based on your desired snapping sensitivity

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        if (dropped != null)
        {
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

            if (draggableItem != null)
            {
                // If the item is dropped outside the combination slot
                if (draggableItem.parentAfterDrag != transform)
                {
                    // Return the item to its original position
                    dropped.transform.SetParent(draggableItem.parentAfterDrag);
                    dropped.transform.position = draggableItem.parentAfterDrag.position;
                }
                else
                {
                    // Snap the item to the combination slot if it's close enough
                    SnapToSlot(draggableItem);
                }

                draggableItem.parentAfterDrag = transform;
                dropped.transform.SetParent(transform);
            }
        }
    }

    private void SnapToSlot(DraggableItem draggableItem)
    {
        // Calculate the distance between the draggable item and the combination slot
        float distance = Vector2.Distance(draggableItem.transform.position, transform.position);

        // If the distance is within the snap threshold, snap the item to the combination slot
        if (distance < snapDistance)
        {
            draggableItem.transform.position = transform.position;
        }
    }
}
