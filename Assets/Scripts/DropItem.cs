using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject menu;
    public void OnDrop(PointerEventData eventData)
    {
        var item = DragItem.dragItem;
        var childrens = transform.GetComponentsInChildren<DragItem>();
        var SlotTag = transform.tag;
        if (item != null && childrens.Length == 0)
        {
            item.SetItemToSlot(transform);
            if (tag != "Pocket")
            {
                menu.SendMessage("startDeterminate", transform.name.Substring(transform.name.Length - 1));
            }
        }
        else if (item != null && childrens.Length > 0)
        {
            var slot = item.currentSlot;
            childrens[0].SetItemToSlot(slot);
            item.SetItemToSlot(transform);
        }
    }
}