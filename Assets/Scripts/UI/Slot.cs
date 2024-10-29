using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public ItemData item; 
    public UIInventory inventory;
    public Button button;
    public Image icon; 
    public Text quantityText;

    public int index;
    public bool equipped;
    public int quantity;

    public void Set()
    {
        if (item != null && item.icon != null)
        {
            icon.sprite = item.icon; 
            icon.gameObject.SetActive(true);
            quantityText.text = quantity > 1 ? quantity.ToString() : string.Empty;
        }
        else
        {
            icon.gameObject.SetActive(false);
            quantityText.text = string.Empty;
        }
    }

    public void Clear()
    {
        item = null;
        icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;
    }

    public void OnClickButton()
    {
        inventory.SelectItem(index);
    }
}
