//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class InventorySlot : MonoBehaviour, IDropHandler
//{
//    public CombinationItem combinedImagePrefab; // Reference to the prefab of the combined image

//    private DraggableItem firstItem; // Reference to the first item dropped into the slot

//    public void OnDrop(PointerEventData eventData)
//    {
//        GameObject dropped = eventData.pointerDrag;

//        if (dropped != null)
//        {
//            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

//            if (draggableItem != null)
//            {
//                // If the item is dropped outside the inventory slot
//                if (draggableItem.parentAfterDrag != transform)
//                {
//                    // Return the item to its original position
//                    dropped.transform.SetParent(draggableItem.parentAfterDrag);
//                    dropped.transform.position = draggableItem.parentAfterDrag.position;
//                }
//                else
//                {
//                    // This item is dropped into the same slot

//                    // If it's the first item, store the reference
//                    if (firstItem == null)
//                    {
//                        firstItem = draggableItem;
//                    }
//                    else
//                    {
//                        // This is the second item, combine them

//                        // Instantiate a new combined image
//                        CombinationItem combinedImage = Instantiate(combinedImagePrefab, transform.position, Quaternion.identity);

//                        // Set the combined image's texture or properties based on the combination logic
//                        combinedImage.combinedRawImage.texture = CombineTextures(firstItem.rawImage.texture, draggableItem.rawImage.texture);

//                        // Destroy the original items
//                        Destroy(firstItem.gameObject);
//                        Destroy(draggableItem.gameObject);

//                        // Reset the firstItem reference
//                        firstItem = null;
//                    }
//                }

//                draggableItem.parentAfterDrag = transform;
//                dropped.transform.SetParent(transform);
//            }
//        }
//    }

//    private Texture2D CombineTextures(Texture2D firstTexture, Texture2D secondTexture)
//    {
//        // Add your combination logic here
//        // This is a simple example assuming a horizontal combination of two textures
//        // You should customize this based on your specific requirements

//        int width = firstTexture.width + secondTexture.width;
//        int height = Mathf.Max(firstTexture.height, secondTexture.height);

//        Texture2D combinedTexture = new Texture2D(width, height);

//        // Copy the pixels from the first texture
//        combinedTexture.SetPixels(0, 0, firstTexture.width, firstTexture.height, firstTexture.GetPixels());

//        // Copy the pixels from the second texture
//        combinedTexture.SetPixels(firstTexture.width, 0, secondTexture.width, secondTexture.height, secondTexture.GetPixels());

//        combinedTexture.Apply();

//        return combinedTexture;
//    }
//}
