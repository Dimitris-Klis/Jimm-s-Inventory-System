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
### Basic Setup:
1. If there isn't one, create a `Resources` folder.
2. In 'Resources', create 3 folders with the following names:
   - Items
   - Recipes
   - Smelting Recipes

In order to create any of the Scriptable Objects, you do the following steps:

`Right Click in the project -> Create -> Jimm's Inventory -> Create Item, Create Recipe, etc.`

Here's a demonstration below:

![image](https://github.com/user-attachments/assets/4a243d8f-dcca-4a86-8884-611a7054ebaf)

---

### Item Creation:
_*Make sure that all your items are in the `Items` folder._

Here's an item:

![image](https://github.com/user-attachments/assets/9db0c9b6-def9-43da-9816-c16440b238c2)

`Name`, `Description` & `Icon` are self explanatory.

`StackSize` limits how much of the same item can be in one slot.

`Fuel` & `FuelTime` are used for the smelting system. Since wood can be used as fuel, I've ticked `Fuel` to `true` and set the `FuelTime` _(which is how many seconds the fuel lasts)_ to a desired amount. 

The variables `Building` and `BuildingPrefab` aren't necessary, though they're there if you want to make a game with building mechanics.

---

### Basic Recipe Creation:
_*Make sure that all your recipes are in the `Recipes` folder._

![image](https://github.com/user-attachments/assets/a89cb109-d3d7-4887-9bc4-2d8f40e26b7a)

`Required Workstation` is what type of crafting station the recipe appears in.

For example, the recipe wouldn't appear if we opened a crafting station with the Workstation name 'Anvil'

'Ingredients' is the required amount of each item to craft said recipe.

'Result' is self explanatory, and 'Result Amount' is how much of the item you get from the crafting recipe.

---

### Smelting Recipe Creation:

_*Make sure that all your recipes are in the `Smelting Recipes` folder._

![image](https://github.com/user-attachments/assets/8e9c6874-606b-4813-bcd0-4906c1f70b94)

`Required Workstation` is the Smelting Station that supports this recipe.

`Ingredient` is the item which will go to the input.

`Cook Time` is the seconds it takes to smelt this item.

`Result` & `Result Amount` are self explanatory.

_Side Note:_ Smelting stations support all fuel.

---

### Smelters:

The Smelter script handles item smelting and has 3 slots: `Input`, `Fuel` and `Output`. \
All you need to worry about, is the `Workstation Name`, `Smelter Renderer`, `Normal Smelter (Sprite)` and `Lit Smelter (Sprite)`.

![image](https://github.com/user-attachments/assets/fbb506a9-4b2a-4afd-8031-59e9a4cec510)

### Chests:

Chests store things. You can dictate how many slots a chest has by simply adding elements to the `Items` array. \
If an element has an item and amount other than `None, 0`, it's added to the chest.

![image](https://github.com/user-attachments/assets/25814feb-b6d7-46de-8be7-2b9d308dfc02)

As you can see in the image below, only 3 items appear in the chest, since we only have 3 elements in the array. \
2 of the slots contain 100 Wood & 100 Rock, since they were set in the image above.

![image](https://github.com/user-attachments/assets/9f1aa24c-5e1b-40b2-b2f0-1924bb076dc9)

### The Hotbar:

All you need to worry about is the `Default Event` & the `Actions` array.

`Actions` takes `Items` & `UnityEvents`. If the selected item in the hotbar is in `Actions`, its `UnityEvent` is triggered. \
Otherwise, if there is no such item in `Actions`, the `Default Event` is triggered instead.

In short, every item you select will trigger a `UnityEvent`.
It's by no means the best way of handling item selection, but it works and allows for easy customizability, albeit a bit tedious.

![image](https://github.com/user-attachments/assets/7e278ff1-3af6-47fd-a145-08473257f9b8)



Anyway, I think that covers everything.

Heads up: The code is by no means perfect and has way too many comments (I found out that that's a bad coding practice a little too late and I can't be bothered to change it ¯\ &#95; (ツ) &#95; /¯ ).

### Extras:
There's a useful Example Scene under `Scenes\Example` and some extra stuff in `Scenes\Example\Example Assets`.
