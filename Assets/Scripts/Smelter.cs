using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelter : Structure {
    public struct CraftItem{
        public string name;
        public string detail;
        public int ironCost;
        public int itemAmount; // amount of item you get per 1 craft

        public CraftItem(string name, string detail, int ironCost, int itemAmount)
        {
            this.name = name;
            this.detail = detail;
            this.ironCost = ironCost;
            this.itemAmount = itemAmount;
        }
    };

    List<CraftItem> craftList;
	// Use this for initialization
	void Start () {
        craftList = new List<CraftItem>();
        craftList.Add(new CraftItem("bullet", "use to shoot enemy", 10, 30));
        craftList.Add(new CraftItem("powerplant", "use to generate energy and battery from oil", 200, 1));
        craftList.Add(new CraftItem("smelter", "use to craft item from iron", 200, 1));
        craftList.Add(new CraftItem("wire", "use to connect power plant to another building", 5, 1));
        craftList.Add(new CraftItem("turret", "use to attack enemy", 100, 1));
        craftList.Add(new CraftItem("barricade", "use to defend enemy", 80, 1));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void craft(int craftItemIndex, Inventory inv)
    {
        if (craftList[craftItemIndex].ironCost <= inv.iron)
        {
            addItemToInventory(craftItemIndex, inv);
            inv.reduceIron(craftList[craftItemIndex].ironCost);
        }
    }

    void addItemToInventory(int craftItemIndex, Inventory inv)
    {
        if (craftItemIndex == 0)
        {
            inv.addBullet(craftList[craftItemIndex].itemAmount);
        }
        else if (craftItemIndex == 1)
        {
            inv.addPowerplant(craftList[craftItemIndex].itemAmount);
        }
        else if (craftItemIndex == 2)
        {
            inv.addSmelter(craftList[craftItemIndex].itemAmount);
        }
        else if (craftItemIndex == 3)
        {
            inv.addWire(craftList[craftItemIndex].itemAmount);
        }
        else if (craftItemIndex == 4)
        {
            inv.addTurret(craftList[craftItemIndex].itemAmount);
        }
        else if (craftItemIndex == 5)
        {
            inv.addBarricade(craftList[craftItemIndex].itemAmount);
        }

    }


}
