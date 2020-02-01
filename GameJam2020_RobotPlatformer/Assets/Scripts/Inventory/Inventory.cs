using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    private List<GameObject> _inventorySlots;

    void Start()
    {
        // Init Inventory Slots
        _inventorySlots = new List<GameObject> {
            GameObject.FindGameObjectWithTag("Slot0"),
            GameObject.FindGameObjectWithTag("Slot1"),
            GameObject.FindGameObjectWithTag("Slot2"),
            GameObject.FindGameObjectWithTag("Slot3"),
            GameObject.FindGameObjectWithTag("Slot4")
        };
    }


    public void addInventoryItem(BaseModule baseModule)
    {
        if (baseModule == null || !isNewItem(baseModule))
        {
            return;
        }

        var gameObject = getFirstEmptySlot();
        setItemSlotModule(gameObject, baseModule);
    }


    public BaseModule getSelectedModule()
    {
        foreach(var inventorySlot in _inventorySlots)
        {
            var button = inventorySlot.transform.GetChild(0)?.gameObject.GetComponent<Button>();

        }

        return null;
    }

    /// <summary>
    /// Determins if the item passed in is already in the inventory.
    /// </summary>
    /// <param name="baseModule"></param>
    /// <returns></returns>
    private bool isNewItem(BaseModule baseModule)
    {
        // Check each Inventory Slot, if the names match, we already have this item.
        // Ends early if null detected. 
        foreach (var slotObject in _inventorySlots)
        {
            var oldItem = getSlotObjectModule(slotObject);
            if (oldItem == null)
            {
                return true;
            }

            if (oldItem.name == baseModule.name)
            {
                return false;
            }
        }

        return true;
    }


    private GameObject getFirstEmptySlot()
    {
        foreach(var inventorySlot in _inventorySlots)
        {
            if (slotIsEmpty(inventorySlot))
            {
                return inventorySlot;
            }
        }

        return null;
    }


    /// <summary>
    /// Checks to see if the provided slot is empty
    /// </summary>
    /// <param name="slotObject">Inventory Bar slot</param>
    /// <returns>If empty - true. If not empty false</returns>
    private bool slotIsEmpty(GameObject slotObject)
    {
        return getSlotObjectModule(slotObject) == null;
    }

    /// <summary>
    /// Get the Slot Object Modlue
    /// </summary>
    /// <param name="gameObject">Slot Object</param>
    /// <returns>The moldule contained in the inventory slot</returns>
    private BaseModule getSlotObjectModule(GameObject gameObject)
    {
        var slot = gameObject.GetComponentInChildren<Slot>();
        if (slot == null)
        {
            return null;
        }

        return slot.module;
    }


    private void setItemSlotModule(GameObject gameObject, BaseModule baseModule)
    {
        if (gameObject == null || baseModule == null)
        {
            return;
        }

        var slot = gameObject.GetComponentInChildren<Slot>();
        var button = gameObject.gameObject.GetComponentInChildren<Button>();
        var image = button.gameObject.GetComponentsInChildren<Image>();
        Debug.Log(image[1].sprite);

        image[1].sprite = Resources.Load<Sprite>(baseModule.spritePath);
        slot.module = baseModule;
    }
}
