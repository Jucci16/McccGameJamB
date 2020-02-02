using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    private List<GameObject> _inventorySlots;
    private GameObject _selectedInventorySlot;

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

    public void selectModule(int i)
    {
        // Zero based
        i -= 1;
        setItemSlotAsSelected(_inventorySlots[i]);
    }

    /// <summary>
    /// Add a module to the inventory
    /// </summary>
    /// <param name="baseModule">Module you'd like to add to the inventory bar</param>
    public void addModule(BaseModule baseModule)
    {
        // If null or we already have this item, don't add it
        if (baseModule == null || !isNewItem(baseModule))
        {
            return;
        }

        var gameObject = getFirstEmptySlot();
        setItemSlotModule(gameObject, baseModule);
        setItemSlotAsSelected(gameObject);
    }

    /// <summary>
    /// Get selected Module
    /// </summary>
    /// <returns></returns>
    public BaseModule getSelectedModule()
    {
        var slot = _selectedInventorySlot?.GetComponentInChildren<Slot>();


        return slot?.module;
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
            var oldItem = getModuleFromGameObject(slotObject);
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

    /// <summary>
    /// Retrieve the first empty inventory slot. 
    /// If there are no emtpy slots, returns null
    /// </summary>
    /// <returns>First empty slot or null</returns>
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
        return getModuleFromGameObject(slotObject) == null;
    }

    /// <summary>
    /// Get the module from the game object(Inventory slot)
    /// </summary>
    /// <param name="gameObject">Slot Object</param>
    /// <returns>The moldule contained in the inventory slot</returns>
    private BaseModule getModuleFromGameObject(GameObject gameObject)
    {
        var slot = gameObject.GetComponentInChildren<Slot>();
        if (slot == null)
        {
            return null;
        }

        return slot.module;
    }

    /// <summary>
    /// Set the Item slot on the In game graphical object
    /// </summary>
    /// <param name="gameObject">Graphical Slot</param>
    /// <param name="baseModule">Module we're adding to it</param>
    private void setItemSlotModule(GameObject gameObject, BaseModule baseModule)
    {
        if (gameObject == null || baseModule == null)
        {
            return;
        }

        var slot = gameObject.GetComponentInChildren<Slot>();
        var button = gameObject.gameObject.GetComponentInChildren<Button>();
        var image = button.gameObject.GetComponentsInChildren<Image>();
        
        image[1].sprite = Resources.Load<Sprite>(baseModule.spritePath);
        slot.module = baseModule;
    }

    private void setItemSlotAsSelected(GameObject gameObject) 
    {
        var slot = gameObject.GetComponentInChildren<Slot>();
        if (slot.module == null)
        {
            return;
        }

        // Unselect current slot.
        unselectSlot();

        slot.module?.isActive(true);
        slot.changeColor(Color.blue);

        _selectedInventorySlot = gameObject;
    }

    private void unselectSlot()
    {
        var slot = _selectedInventorySlot?.GetComponentInChildren<Slot>();
        if (slot == null)
        {
            return;
        }
        
        slot.module?.isActive(false);
        slot.changeColor(Color.white);

        Debug.Log(slot);
        Debug.Log(slot.module);

        _selectedInventorySlot = null;
    }
}
