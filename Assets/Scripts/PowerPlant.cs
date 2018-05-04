using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlant : Structure {
    PowerPlant()
    {
        inventoryId = 4;
    }
    void Start()
    {

    }
    void Update()
    {

    }
 //   public GameObject batteryPrefab;
 //   int hp = 2000;
 //   bool isAlive = true;
 //   bool isWorking = false;
 //   double tank = 0.0;
 //   double chargeProgress = 0.0;
 //   // Use this for initialization
 //   void Start () {

 //   }
	
	//// Update is called once per frame
	//void Update () {
 //       if (isWorking)
 //       {
 //           ChargeBattery();
 //       }
 //   }
    

 //   void ChargeBattery(){
 //       if (chargeProgress >= 1)
 //       {
 //           isWorking = false;
 //           chargeProgress = 1.0;
 //       }
 //       else
 //       {
 //           isWorking = true;
 //           tank -= 0.15;
 //           if (tank < 0) tank = 0.0;
 //           chargeProgress += 0.05;
 //       }

 //   }

 //   void FillTank(PlayerController player){
 //       if (tank >= 300)
 //       {
 //           //can't fill
 //       }
 //       else
 //       {
 //           if (player.inventory.oilNo > 0)
 //           {
 //               player.inventory.oilNo--;
 //               tank += 30.0;
 //               isWorking = true;
 //           }
 //           else
 //           {
 //               //can't fill
 //           }
 //       }
 //   }

 //   GameObject GiveBattery(){
 //       GameObject battery;
 //       battery = Instantiate(batteryPrefab) as GameObject;
 //       battery.GetComponent<Battery>().SetLifeTime(chargeProgress * 100);
 //       chargeProgress = 0.0;
 //       isWorking = false;
 //       return battery;
 //   }

}
