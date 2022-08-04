
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;

public class crafting : Mod {

    public void OnModUnload(){
        Debug.Log("Mod crafting Cassette has been unloaded!");
    }

    public void Start(){

        Item_Base[]
            color_yellow = itembase("Color_Yellow") ,
            color_black = itembase("Color_Black") ,
            color_white = itembase("Color_White") ,
            color_blue = itembase("Color_Blue") ,
            color_red = itembase("Color_Red") ;


        cassetteRecipe("Cassette_EDM",
            new CostMultiple(color_black,1),
            new CostMultiple(color_blue,1),
            new CostMultiple(color_red,1));

        cassetteRecipe("Cassette_Classical",
            new CostMultiple(color_yellow,1),
            new CostMultiple(color_black,1),
            new CostMultiple(color_red,1));
        
        cassetteRecipe("Cassette_Pop",
            new CostMultiple(color_white,1),
            new CostMultiple(color_red,2));
        
        cassetteRecipe("Cassette_Elevator",
            new CostMultiple(color_white,3));

        cassetteRecipe("Cassette_Rock",
            new CostMultiple(color_black,3));


        Debug.Log("Mod crafting Cassette has been loaded!");
    }


    /*
     *  Items needed for every cassette.
     */

    private static List<CostMultiple> baseCost = new List<CostMultiple>() {
        new CostMultiple(itembase("CircuitBoard"),1),
        new CostMultiple(itembase("CopperIngot"),1),
        new CostMultiple(itembase("Plastic"),4),
        new CostMultiple(itembase("Bolt"),2)
    };


    /*
     *  Create a cassette recipe.
     */

    private static void cassetteRecipe(string type,params CostMultiple [] specific){

        var cost = new List<CostMultiple>(baseCost);
        cost.AddRange(specific);

        var result = ItemManager.GetItemByName(type);
        recipe(result,1,cost.ToArray());
    }


    /*
     *  Create a generic recipe.
     */

    private static void recipe(Item_Base result,int amount,params CostMultiple [] cost){
        
        var recipe = Traverse.Create(result.settings_recipe);
        
        recipe
        .Field("newCostToCraft")
        .SetValue(cost);

        recipe
        .Field("learned")
        .SetValue(false);

        recipe
        .Field("learnedFromBeginning")
        .SetValue(false);

        recipe
        .Field("craftingCategory")
        .SetValue(CraftingCategory.Decorations);

        recipe
        .Field("amountToCraft")
        .SetValue(amount);
    }


    private static Item_Base [] itembase(string name){
        return new Item_Base[] { ItemManager.GetItemByName(name) };
    }
}
