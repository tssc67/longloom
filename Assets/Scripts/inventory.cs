using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum ItemType
    {
        Iron,
        Oil,
        Bullet,
        PowerPlant,
        Smelter,
        Wire,
        Turret,
        Barricade
    };
    protected int[] items;
    List<Battery> batteries = new List<Battery>();

	void Start()
    {
        items = new int[]
        {
            0, 
            0,
            0,
            1,
            1,
            0,
            0,
            0
        };
    }

    void Update()
    {

    }

    void addItem(ItemType itemType,int amount)
    {
        if (amount > 0) items[(int)itemType] += amount;
    }

    void reduceItem(ItemType itemType,int amount)
    {
        if (amount < 0) return;
        int newAmount = items[(int)itemType] - amount;
        if (newAmount < 0) newAmount = 0;
        amount = newAmount;
    }
    //void addIron(int amount)
    //{
    //    if (amount > 0) iron += amount;
    //}

    //void addOil(int amount)
    //{
    //    if (amount > 0) oil += amount;
    //}

    //void addBullet(int amount)
    //{
    //    if (amount > 0) bullet += amount;
    //}

    //void addPowerplant(int amount)
    //{
    //    if (amount > 0) powerplant += amount;
    //}

    //void addSmelter(int amount)
    //{
    //    if (amount > 0) smelter += amount;
    //}

    //void addWire(int amount)
    //{
    //    if (amount > 0) wire += amount;
    //}

    //void addTurret(int amount)
    //{
    //    if (amount > 0) turret += amount;
    //}

    //void addBarricade(int amount)
    //{
    //    if (amount > 0) barricade += amount;
    //}

    //void reduceIron(int amount)
    //{
    //    if (amount > 0 && iron >= amount) iron -= amount;
    //    else if (iron < amount) iron = 0;
    //}

    //void reduceOil(int amount)
    //{
    //    if (amount > 0 && oil >= amount) oil -= amount;
    //    else if (oil < amount) oil = 0;
    //}

    //void reduceBullet(int amount)
    //{
    //    if (amount > 0 && bullet >= amount) bullet -= amount;
    //    else if (bullet < amount) bullet = 0;
    //}

    //void reducePowerplant(int amount)
    //{
    //    if (amount > 0 && powerplant >= amount) powerplant -= amount;
    //    else if (powerplant < amount) powerplant = 0;
    //}

    //void reduceSmelter(int amount)
    //{
    //    if (amount > 0 && smelter >= amount) smelter -= amount;
    //    else if (smelter < amount) smelter = 0;
    //}

    //void reduceWire(int amount)
    //{
    //    if (amount > 0 && wire >= amount) wire -= amount;
    //    else if (wire < amount) wire = 0;
    //}

    //void reduceTurret(int amount)
    //{
    //    if (amount > 0 && turret >= amount) turret -= amount;
    //    else if (turret < amount) turret = 0;
    //}

    //void reduceBarricade(int amount)
    //{
    //    if (amount > 0 && barricade >= amount) barricade -= amount;
    //    else if (barricade < amount) barricade = 0;
    //}

    //void addBattery(Battery bat)
    //{
    //    batteries.Add(bat);
    //}

    //void removeBattery(int index)
    //{
    //    batteries.RemoveAt(index);
    //}
}
