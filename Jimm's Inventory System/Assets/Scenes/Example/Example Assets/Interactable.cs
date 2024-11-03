using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public float InteractionRadius = 1.5f;
    public LayerMask playermask;
    public UnityEvent OnInteract;
    public string InteractionButtonName;
    public string interactableName = "Workbench";
    public bool InventoryRelated;
    //bool ShownPrompt;
    bool HidPrompt;
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, InteractionRadius);
    }
    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle((Vector2)transform.position, InteractionRadius, playermask))
        {
            //if (!ShownPrompt)
            //{
            Prompter.instance.ShowPrompt($"Use '{InteractionButtonName}' to interact with {interactableName}");
            HidPrompt = false;
            //ShownPrompt = true;
            //}
            if (Input.GetButtonDown(InteractionButtonName))
            {
                OnInteract.Invoke();
                if (InventoryRelated)
                {
                    Prompter.instance.HidePrompt();
                    InventoryUIHandler.instance.tempInteractable = this;
                    InventoryUIHandler.instance.Invoke(nameof(InventoryUIHandler.instance.EnableInventoryOpening), .1f);
                    this.enabled = false;
                    return;
                }
            }
            InventoryUIHandler.instance.CanOpenInventory = false;
        }
        else
        {
            if (!HidPrompt)
            {
                Prompter.instance.HidePrompt();
                //ShownPrompt=false;
                HidPrompt = true;
                InventoryUIHandler.instance.CanOpenInventory = true;
            }
        }
    }
}