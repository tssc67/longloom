using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Structure
{
    //public Rigidbody2D bullet;              // Prefab of bullet.
    //public float speed;     				// The speed the bullet will fire at.

    //public int maxBullet;
    //public int currentBullet;
    //public int maxCooldownTime;
    //public int cooldownTime;
    //public Battery battery;
    //public bool isWired;
    //public PowerPlant powerplant;

    //public bool direction; // left=false, right=true
    //public double energyConsumptionRate;
    //public bool isWorking;
    //public double atkPower;

    //void start()
    //{

    //}

    //void update()
    //{
    //    if (!battery.isEmpty)
    //    {
    //        battery.consume(energyConsumptionRate);
    //        isWorking = true;
    //    }
    //    else
    //    {
    //        isWorking = false;
    //    } 

    //    if (/*refill bullet trigger*/)
    //    {
    //        refillBullet(inventory);
    //    }

    //    if (/*change battery trigger*/)
    //    {
    //        changeBattery(bat);
    //    }
        
    //    if (isWorking && cooldownTime >= maxCooldownTime && isEnemyInRange())
    //    {
    //        fire();
    //        cooldownTime = 0;
    //    }
    //    else if (cooldownTime < maxCooldownTime)
    //    {
    //        cooldownTime++;
    //    }
    //}

    //bool isEnemyInRange()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        if (direction && GameLogic.Enemy.getObjectAt(this.position.x + i, this.position.y) != null)
    //        {
    //            return true;
    //        }
    //        else if (!direction && GameLogic.Enemy.getObjectAt(this.position.x - i, this.position.y) != null)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //void fire()
    //{
    //    if (direction) // facing right
    //    {
    //        // ... instantiate the rocket facing right and set it's velocity to the right. 
    //        Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
    //        bulletInstance.velocity = new Vector2(speed, 0);
    //    }
    //    else
    //    {
    //        // Otherwise instantiate the rocket facing left and set it's velocity to the left.
    //        Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
    //        bulletInstance.velocity = new Vector2(-speed, 0);
    //    }
    //}

    //void refillBullet(Inventory inv)
    //{
    //    int refillAmount = min(inv.bullet, maxBullet - currentBullet);
    //    inv.reduceBullet(refillAmount);
    //    bullet += refillAmount;
    //}

    //void changeBattery(Battery bat)
    //{
    //    battery = bat;
    //}
}
