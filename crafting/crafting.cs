using HarmonyLib;
using UnityEngine;


public class crafting : Mod
{
    public void Start()
    {
        Item_Base[] blackColor = new Item_Base[] { ItemManager.GetItemByName("Color_Black") };
        Item_Base[] whiteColor = new Item_Base[] { ItemManager.GetItemByName("Color_White") };
        Item_Base[] redColor = new Item_Base[] { ItemManager.GetItemByName("Color_Red") };
        Item_Base[] blueColor = new Item_Base[] { ItemManager.GetItemByName("Color_Blue") };
        Item_Base[] yellowColor = new Item_Base[] { ItemManager.GetItemByName("Color_Yellow") };

        Item_Base[] board = new Item_Base[] { ItemManager.GetItemByName("CircuitBoard") };
        Item_Base[] plastic = new Item_Base[] { ItemManager.GetItemByName("Plastic") };
        Item_Base[] copper = new Item_Base[] { ItemManager.GetItemByName("CopperIngot") };
        Item_Base[] bolt = new Item_Base[] { ItemManager.GetItemByName("Bolt") };

        CreateRecipe(ItemManager.GetItemByName("Cassette_Rock"), 1, new CostMultiple(blackColor, 3), new CostMultiple(board, 1), new CostMultiple(plastic, 4),  new CostMultiple(bolt, 2), new CostMultiple(copper, 1));
        CreateRecipe(ItemManager.GetItemByName("Cassette_EDM"), 1, new CostMultiple(blackColor, 1), new CostMultiple(blueColor, 1), new CostMultiple(redColor, 1), new CostMultiple(board, 1), new CostMultiple(plastic, 4), new CostMultiple(bolt, 2), new CostMultiple(copper, 1));
        CreateRecipe(ItemManager.GetItemByName("Cassette_Classical"), 1, new CostMultiple(blackColor, 1), new CostMultiple(yellowColor, 1), new CostMultiple(redColor, 1), new CostMultiple(board, 1), new CostMultiple(plastic, 4), new CostMultiple(bolt, 2), new CostMultiple(copper, 1));
        CreateRecipe(ItemManager.GetItemByName("Cassette_Pop"), 1, new CostMultiple(whiteColor, 1), new CostMultiple(redColor, 2), new CostMultiple(board, 1), new CostMultiple(plastic, 4), new CostMultiple(bolt, 2), new CostMultiple(copper, 1));
        CreateRecipe(ItemManager.GetItemByName("Cassette_Elevator"), 1, new CostMultiple(whiteColor, 3), new CostMultiple(board, 1), new CostMultiple(plastic, 4), new CostMultiple(bolt, 2), new CostMultiple(copper, 1));



        Debug.Log("Mod crafting Cassette has been loaded!");
    }

    
    public static void CreateRecipe(Item_Base pResultItem, int pAmount, params CostMultiple[] pCosts)
    {
        Traverse.Create(pResultItem.settings_recipe).Field("newCostToCraft").SetValue(pCosts);
        Traverse.Create(pResultItem.settings_recipe).Field("learned").SetValue(false);
        Traverse.Create(pResultItem.settings_recipe).Field("learnedFromBeginning").SetValue(true);
        Traverse.Create(pResultItem.settings_recipe).Field("craftingCategory").SetValue(CraftingCategory.Decorations);
        Traverse.Create(pResultItem.settings_recipe).Field("amountToCraft").SetValue(pAmount);
    }

    public void OnModUnload()
    {
        Debug.Log("Mod crafting Cassette has been unloaded!");
    }
}