using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public bool canLook = true;
    public GameObject inventory;

    private void Start()
    {
        inventory.SetActive(false);
    }

    public void OnInventoryButton(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            bool isActive = !inventory.activeSelf;
            inventory.SetActive(isActive);
            ToggleCursor(isActive);
        }
    }

    void ToggleCursor(bool isInventoryOpen)
    {
        if (isInventoryOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            canLook = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canLook = true;
        }
    }
}
