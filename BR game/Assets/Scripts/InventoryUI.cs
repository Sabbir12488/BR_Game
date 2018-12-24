using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public Transform itemsParent_2;
    public GameObject inventoryUI;
    public GameObject inventory_small_UI;

    Inventory inventory;

    InventorySlot[] slots;
    InventorySlot[] slots_2;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        slots_2 = itemsParent_2.GetComponentsInChildren<InventorySlot>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            inventory_small_UI.SetActive(!inventory_small_UI.activeSelf);
        }
        if(inventoryUI.active)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
	}

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        for (int i = 0; i < slots_2.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots_2[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots_2[i].ClearSlot();
            }
        }
    }
}
