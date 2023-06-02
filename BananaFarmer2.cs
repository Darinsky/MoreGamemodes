using BTD_Mod_Helper.Api.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreGameModes
{
    public class BananaFarmer2 : ModTower
    {



        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.BananaFarmer;
        public override string Icon => VanillaSprites.BananaFarmerIcon;


        public override int Cost => 200;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Infinite Range Banana Farmer";

        public override bool DontAddToShop => true;

        public override string Portrait => VanillaSprites.BananaFarmerPortrait;
       





        //public override ParagonMode ParagonMode => ParagonMode.Base000;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {

            towerModel.range = 250;
            towerModel.IsUpgradeUnlocked(0, 0);
          //  towerModel.GetAttackModel().range = 250;




        }



    }
}
