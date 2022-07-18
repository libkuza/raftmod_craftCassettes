
using HarmonyLib;
using UnityEngine;


public class crafting : Mod {

    public void OnModUnload(){
        Debug.Log("Mod crafting Cassette has been unloaded!");
    }

    public void Start(){

        Item_Base[]
            color_yellow = colorbase("Color_yellow") ,
            color_black = colorbase("Color_Black") ,
            color_white = colorbase("Color_White") ,
            color_blue = colorbase("Color_Blue") ,
            color_red = colorbase("Color_Red") ;


        cassetteRecipe("Cassette_EDM",
            new CostMultiple(blackColor,1),
            new CostMultiple(blueColor,1),
            new CostMultiple(redColor,1));

        cassetteRecipe("Cassette_Classical",
            new CostMultiple(yellowColor,1),
            new CostMultiple(blackColor,1),
            new CostMultiple(redColor,1));
        
        cassetteRecipe("Cassette_Pop",
            new CostMultiple(whiteColor,1),
            new CostMultiple(redColor,2));
        
        cassetteRecipe("Cassette_Elevator",
            new CostMultiple(whiteColor,3));

        cassetteRecipe("Cassette_Rock",
            new CostMultiple(blackColor,3));


        Debug.Log("Mod crafting Cassette has been loaded!");
    }


    /*
     *  Items needed for every cassette.
     */

    private static List<CostMultiple> baseCost = new List<CostMultiple>() {
        new CostMultiple(plastic,4),
        new CostMultiple(copper,1),
        new CostMultiple(board,1),
        new CostMultiple(bolt,2)
    };


    /*
     *  Create a cassette recipe.
     */

    private static void cassetteRecipe(string type,params CostMultiple [] specific){

        var cost = new List<CostMultiple>(baseCost);
        cost.addRange(specific);

        var result = ItemManager.GetItemByName(type);
        recipe(result,1,cost.toArray());
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
