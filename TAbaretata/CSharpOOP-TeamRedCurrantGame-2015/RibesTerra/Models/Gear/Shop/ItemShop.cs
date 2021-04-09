namespace Models.Gear.Shop
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Models.Gear.Weapons;
    using Models.Gear.Items;
    using Models.Interfaces;

    public class ItemShop : IItemShop
    {
        public GearInStock gearInStock;

        private IEnumerable<IWeapon> weapon = new List<IWeapon>();
        private IEnumerable<IItem> item = new List<IItem>();
        public ItemShop(IEnumerable<IGear> gearInStock)
        {
            this.gearInStock = new GearInStock(weapon, item);
        }

        public IWeapon WeaponUpgrade(IWeapon weapon)
        {
            weapon.AttackPoints += 50;
            if (weapon.AttackPoints > 100)
            {
                weapon.AttackPoints = 100;
            }
            return weapon;
        }

        public IItem ItemUpgrade(IItem item)
        {
            item.DefensePoints += 50;
            if (item.DefensePoints > 100)
            {
                item.DefensePoints = 100;
            }
            return item;
        }

        public override string ToString()
        {
            StringBuilder gearInfo = new StringBuilder();
            foreach (var item in this.weapon)
            {
                gearInfo.AppendFormat(item.ToString());
            }
            return gearInfo.ToString();
        }


    }
}
