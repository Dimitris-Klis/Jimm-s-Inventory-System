using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelter : MonoBehaviour
{
    public string WorkstationName;
    public InventorySystem.InventoryItem Input;
    public InventorySystem.InventoryItem Fuel;
    public InventorySystem.InventoryItem Output;

    public float FuelAmount;
    public float ProgressAmount;
    public SmeltingRecipe currentRecipe;
    public SpriteRenderer furnace_renderer;
    public Sprite NormalFurnace;
    public Sprite LitFurnace;
    SmeltingRecipe[] recipes;
    bool smelting;

    private void Start()
    {
        recipes = InventoryUIHandler.instance.smeltingSystem.GetRecipes(WorkstationName);
    }


    /// <summary>
    /// Opens the smelter UI.
    /// </summary>
    public void OpenSmelter()
    {
        if (InventoryUIHandler.instance.smeltingSystem.selectedSmelter == this) return;
        InventoryUIHandler.instance.smeltingSystem.OpenSmelter(this);
        InventoryUIHandler.instance.OpenInventoryWithSmelter();
        InventoryUIHandler.instance.smeltingSystem.SetProgress_UI(ProgressAmount);
        InventoryUIHandler.instance.smeltingSystem.SetFuel_UI(FuelAmount);
    }

    /// <summary>
    /// Starts smelting the input if the recipe is valid, there's fuel and an available ouput.
    /// </summary>
    public void Smelt()
    {
        if (smelting) return;
        currentRecipe = GetRecipe(Input.item);
        //if there's a recipe with the input's item, fuel and an available output
        if
            (
                currentRecipe != null &&

                !smelting &&
                (FuelAmount > 0 || (Fuel.amount > 0 && Fuel.item != null && Fuel.item.Fuel)) &&

                (Input.amount >= currentRecipe.Ingredient.amount && Input.item != null) &&
                Output.amount + currentRecipe.ResultAmount <= currentRecipe.Result.StackSize
            )
        {
            //Remove the required amount from the input
            Input.amount -= currentRecipe.Ingredient.amount;
            //set smelting to true
            smelting = true;
            //Update slots and sliders
            if (InventoryUIHandler.instance.smeltingSystem.selectedSmelter == this)
            {
                InventoryUIHandler.instance.smeltingSystem.UpdateSlotsUI(this);
                InventoryUIHandler.instance.smeltingSystem.SetMaxProgress_UI(currentRecipe.CookTime);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (smelting)
        {
            furnace_renderer.sprite = LitFurnace;
            //If fuelAmount runs out and there's still fuel in the fuel slot.
            if (FuelAmount <= 0 && Fuel.amount > 0 && Fuel.item != null && Fuel.item.Fuel)
            {
                //Restore the fuelAmount
                FuelAmount = Fuel.item.FuelTime;
                //Remove 1 item from the fuel slot.
                Fuel.amount--;
                //Update slots and sliders.
                if (InventoryUIHandler.instance.smeltingSystem.selectedSmelter == this)
                {
                    InventoryUIHandler.instance.smeltingSystem.SetMaxFuel_UI(Fuel.item.FuelTime);
                    InventoryUIHandler.instance.smeltingSystem.UpdateSlotsUI(this);
                }
            }
            //Otherwise if there's fuel and the output is available
            if (FuelAmount > 0 &&
                ((Output.item == null || Output.amount == 0) ||
                (Output.item == currentRecipe.Result && Output.amount + currentRecipe.ResultAmount <= currentRecipe.Result.StackSize)))
            {
                //Update sliders
                if(InventoryUIHandler.instance.smeltingSystem.selectedSmelter == this)
                {
                    InventoryUIHandler.instance.smeltingSystem.SetProgress_UI(ProgressAmount);
                    InventoryUIHandler.instance.smeltingSystem.SetFuel_UI(FuelAmount);
                }
                
                //Progress goes up
                ProgressAmount += Time.deltaTime;
                //Fuel goes down
                FuelAmount -= Time.deltaTime;

                //If progress reaches max
                if (ProgressAmount >= currentRecipe.CookTime)
                {
                    //Add item to output
                    Output.item = currentRecipe.Result;
                    Output.amount += currentRecipe.ResultAmount;
                    //Reset progress to 0 and Update Progress Slider
                    ProgressAmount = 0;
                    if (InventoryUIHandler.instance.smeltingSystem.selectedSmelter == this)
                    {
                        //Update Slots & Progress Slider
                        InventoryUIHandler.instance.smeltingSystem.UpdateSlotsUI(this);

                        InventoryUIHandler.instance.smeltingSystem.SetProgress_UI(ProgressAmount);
                    }
                    smelting = false;
                }
            }
        }
        else
        {
            //If QueuedSmelting is 0 and nothingthere is false, try smelting.
            if (CanSmelt(Input.item))
                Smelt();
            else furnace_renderer.sprite = NormalFurnace;
        }
    }
    bool CanSmelt(Item item)
    {
        SmeltingRecipe rec = GetRecipe(item);
        return rec != null && item != null && Input.amount >= rec.Ingredient.amount && Output.amount + rec.ResultAmount <= rec.Result.StackSize;
    }
    SmeltingRecipe GetRecipe(Item ingredient)
    {
        for (int i = 0; i < recipes.Length; i++)
        {
            var cwr = recipes[i];
            if (ingredient == cwr.Ingredient.item)
            {
                return cwr;
            }
        }
        return null;
    }
}