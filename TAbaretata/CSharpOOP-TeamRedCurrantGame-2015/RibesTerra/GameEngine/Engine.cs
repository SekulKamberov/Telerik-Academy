namespace GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GameEngine.Factories;

    using Models;
    using Models.Creatures;
    using Models.Interfaces;
    using Models.Gear.Items;
    using Models.Gear.Weapons;
    using Models.Extensions;

    public class Engine
    {
        private static readonly Engine InitialInstance = new Engine();

        //private IEnumerable<ICreature> enemyUnits;
        private ICreature enemyUnit;
        private ICollection<IItem> enemyUnitItem;
        private ICollection<IWeapon> enemyUnitWeapon;

        private ICharacter playerCharacter;
        private ICollection<IItem> playerCharacterItem;
        private ICollection<IWeapon> playerCharacterWeapon;

        private ICreatureFactory creatureFactory;
        private IGearFactory gearFactory;

        public Engine()
        {
            this.creatureFactory = new CreatureFactory();
            this.gearFactory = new GearFactory();

            this.playerCharacterItem = new List<IItem>();
            this.playerCharacterWeapon = new List<IWeapon>();

            this.enemyUnitItem = new List<IItem>();
            this.enemyUnitWeapon = new List<IWeapon>();
        }

        //event 
        public event EventHandler NextLevelReached;

        public static Engine Instance
        {
            get
            {
                return InitialInstance;
            }
        }

        public void ParseCommand(string command)
        {
            if (playerCharacter == null)
            {
                InitializeGameCommand(command);
            }

            ProceedCommand(command);
        }

        private void InitializeGameCommand(string command)
        {
            playerCharacter = InitializeCharacter(command);

            Console.WriteLine(playerCharacter.ToString());

            enemyUnit = InitializeEnemyUnit(enemyUnit);

            HandleBattle(playerCharacter, enemyUnit);
        }

        private ICharacter InitializeCharacter(string command)
        {
            playerCharacter = creatureFactory.CreateCharacter(command, (GenderType)RandomGenerator.Instance.Next(0, 2));

            playerCharacterItem = gearFactory.CreateItemSet("Item", 20, 20, 20);
            playerCharacterWeapon = gearFactory.CreateWeaponSet("Weapon", 20, 20, 20);

            playerCharacter.AddItemsList(playerCharacterItem);
            playerCharacter.AddWeaponList(playerCharacterWeapon);

            return playerCharacter;

        }

        private ICreature InitializeEnemyUnit(ICreature enemyUnit)
        {

            enemyUnit = creatureFactory.CreateEnemy("BadTrainerEnemy", (GenderType)RandomGenerator.Instance.Next(0, 2));

            enemyUnitItem = gearFactory.CreateItemSet("Item", 20, 20, 20);
            enemyUnitWeapon = gearFactory.CreateWeaponSet("Weapon", 20, 20, 20);

            enemyUnit.AddItemsList(enemyUnitItem);
            enemyUnit.AddWeaponList(enemyUnitWeapon);

            return enemyUnit;
        }

        //private ICreature SortEasiestEnemy(IEnumerable<ICreature> enemyUnits)
        //{
        //    return enemyUnits
        //            .OrderBy(e => e.BasePower)
        //            .ThenBy(e => e.BaseHealth)
        //            .FirstOrDefault();
        //}

        //private ICreature SortHardestEnemy(IEnumerable<ICreature> enemyUnits)
        //{
        //    return enemyUnits
        //            .OrderByDescending(e => e.BasePower)
        //            .ThenByDescending(e => e.BaseHealth)
        //            .FirstOrDefault();
        //}

        private void HandleBattle(ICharacter playerCharacter, ICreature enemyUnit)
        {
            if (playerCharacter == null)
            {
                throw new ArgumentNullException("playerCharacter");
            }

            if (enemyUnit == null)
            {
                throw new ArgumentNullException("enemyUnit");
            }

            Console.WriteLine(enemyUnit.ToString());

            var playerAsGameObject = playerCharacter as GameObject;
            var enemyAsGameObject = enemyUnit as GameObject;

            Engine.Instance.NextLevelReached += MoveToNextLevel;

            while (true)
            {
                enemyUnit.BaseHealth -= playerCharacter.BasePower;

                if (enemyUnit.BaseHealth < 0)
                {
                    Console.WriteLine(ConsoleMessageConstants.EnemyTakeDamageMessage, playerAsGameObject.Name, playerCharacter.BasePower, enemyAsGameObject.Name);
                    Console.WriteLine(ConsoleMessageConstants.EnemySlainMessage, enemyAsGameObject.Name);
                    Console.WriteLine(ConsoleMessageConstants.MoveToNextLevelMessage);

                    OnNextLevelReached(EventArgs.Empty);
                    break;
                }
                else
                {
                    Console.WriteLine(ConsoleMessageConstants.EnemyTakeDamageMessage, playerAsGameObject.Name, playerCharacter.BasePower, enemyAsGameObject.Name);
                }

                playerCharacter.BaseHealth -= enemyUnit.BasePower;

                if (playerCharacter.BaseHealth < 0)
                {
                    Console.WriteLine(ConsoleMessageConstants.PlayerTakeDamageMessage, enemyAsGameObject.Name, enemyUnit.BasePower, playerAsGameObject.Name);
                    Console.WriteLine(ConsoleMessageConstants.PlayerSlainMessage, playerAsGameObject.Name);
                    Console.WriteLine(ConsoleMessageConstants.GameOverMessage);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine(ConsoleMessageConstants.PlayerTakeDamageMessage, enemyAsGameObject.Name, enemyUnit.BasePower, playerAsGameObject.Name);
                }
            }
        }

        protected virtual void OnNextLevelReached(EventArgs e)
        {
            if (Engine.Instance.NextLevelReached != null)
            {
                Engine.Instance.NextLevelReached(this, e);
            }
        }

        public void MoveToNextLevel(object sender, EventArgs e)
        {
            this.playerCharacter.BaseHealth += 50;
            this.playerCharacter.BasePower += 50;

            CloneEnemy(enemyUnit);

            //foreach (ICreature enemy in enemyUnits)
            //{
            //    var enemyUnitAsCreature = enemy as ICreature;
            //    if (enemyUnitAsCreature != null)
            //    {
            //        enemyUnitAsCreature.BaseHealth += RandomGenerator.Instance.Next(0, 40);
            //        enemyUnitAsCreature.BasePower += RandomGenerator.Instance.Next(0, 40);
            //    }
            //}
        }

        public ICreature CloneEnemy(ICreature enemy)
        {
            var tempEnemy = enemyUnit as Enemy;
            var tempClonedEnemy = tempEnemy.Clone();
            return enemyUnit = (ICreature)tempClonedEnemy;
        }

        private void ProceedCommand(string command)
        {
            switch (command)
            {
                case "attack":
                    HandleBattle(playerCharacter, enemyUnit);
                    break;
                case "shop":
                default:
                    Console.WriteLine(ConsoleMessageConstants.InvalidCommandMessage, command);
                    Console.ReadLine();
                    break;
            }
        }
    }
}
