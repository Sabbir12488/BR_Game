using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Add Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";   // name of the item
    public Sprite icon = null;             // The Icon
    public bool isDefaultItem = false;     // if the item is default Item or not

    public virtual void Use()
    {
        // Use the item
        Debug.Log("Using " + name);
    }
}
