# Jimm's Inventory Pack
## Contents
This Inventory Pack Includes:
- Inventory slots (obviously)
- A hotbar
- A Crafting System
- A Chest System
- A Smelting System
- A tooltip
## Documentation
### Item & Recipe Creation:
#### Basic Setup:
1. If there isn't one, create a 'Resources' folder.
2. In 'Resources', create 3 folders with the following names:
   - Items
   - Recipes
   - Smelting Recipes

In order to create any of the Scriptable Objects, you do the following steps:

Right Click in the project -> Create -> Jimm's Inventory -> Create Item, Create Recipe, etc.

Here's a demonstration below:

![image](https://github.com/user-attachments/assets/4a243d8f-dcca-4a86-8884-611a7054ebaf)

#### Item Creation:
Make sure that all your items are in the 'Items' folder.

Here's an item:

![image](https://github.com/user-attachments/assets/9db0c9b6-def9-43da-9816-c16440b238c2)

The variables 'BuildingPrefab' & 'Building' aren't necessary, though they're there if you want to make a game with building mechanics.

'Fuel' & 'FuelTime' are used for the smelting system. Since wood can be used as fuel, I've ticked Fuel to true and set the 'FuelTime' (which is how many seconds the fuel lasts) to a desired amount. 
'Name', 'Description' & 'Icon' are self explanatory.

'StackSize' limits how much of the same item can be in one slot.

#### Basic Recipe Creation:
Make sure that all your recipes are in the 'Recipes' folder.

![image](https://github.com/user-attachments/assets/a89cb109-d3d7-4887-9bc4-2d8f40e26b7a)

'Required Workstation' is what type of crafting station the recipe appears in.

For example, the recipe wouldn't appear if we opened a crafting station with the Workstation name 'Anvil'
