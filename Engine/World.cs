using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Engine
{
    public static class World // static list variables to read from in the program
    {
        public static readonly List<Item > Items = new List<Item>();
        public static readonly List<Enemy> Enemies = new List<Enemy>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        //
        // Item IDs
        //
        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVENTURER_PASS = 10;
        //
        // Monster IDs
        //
        public const int ENEMY_ID_RAT = 1;
        public const int ENEMY_ID_SNAKE = 2;
        public const int ENEMY_ID_GIANT_SPIDER = 3;
        //
        // Quest IDs
        //
        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;
        //
        // Location IDs
        //
        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;
        //
        // Population of World
        //
        static World() // static constructor, executed when World class is called, automatically populates all lists on first execution
        {
            PopulateItems();
            PopulateEnemies();
            PopulateQuests();
            PopulateLocations();
        }
        //
        // Methods for Population
        //

        private static void PopulateItems() // Creates items with specific stats // Method type: private - only "visible" in this class, static - ="object", void - no returned value
        {
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rusty sword", "Rusty swords", 0, 5)); // ID, name, name plural, mindmg, maxdmg
            Items.Add(new Item(ITEM_ID_RAT_TAIL, "Rat tail", "Rat tails"));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, "Piece of fur", "Pieces of fur"));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake fang", "Snake fangs"));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, "Snakeskin", "Snakeskins"));
            Items.Add(new Weapon(ITEM_ID_CLUB, "Club", "Clubs", 3, 10));
            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Healing potion", "Healing potions", 5));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, "Spider fang", "Spider fangs"));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, "Spider silk", "Spider silks"));
            Items.Add(new Item(ITEM_ID_ADVENTURER_PASS, "Adventurer pass", "Adventurer passes"));
        }
        private static void PopulateEnemies() // Creates enemies with specific stats
        {
            Enemy rat = new Enemy(ENEMY_ID_RAT, "Rat", 5, 3, 10, 3, 3); // ID, name, maxdmg, rewardxp, rewardgold, currenthp, maxhp
            rat.LootTable.Add(new DropItem(ItemByID(ITEM_ID_RAT_TAIL), 75, false));
            rat.LootTable.Add(new DropItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 75, true));

            Enemy snake = new Enemy(ENEMY_ID_SNAKE, "Snake", 5, 3, 10, 3, 3);
            snake.LootTable.Add(new DropItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            snake.LootTable.Add(new DropItem(ItemByID(ITEM_ID_SNAKESKIN), 75, true));

            Enemy giantSpider = new Enemy(ENEMY_ID_GIANT_SPIDER, "Giant spider", 20, 5, 40, 10, 10);
            giantSpider.LootTable.Add(new DropItem(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
            giantSpider.LootTable.Add(new DropItem(ItemByID(ITEM_ID_SPIDER_SILK), 25, false));

            Enemies.Add(rat);
            Enemies.Add(snake);
            Enemies.Add(giantSpider);
        }
        private static void PopulateQuests() // Creates specific quests
        {
            Quest clearAlchemistGarden =
                new Quest(
                    QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    "Clear the alchemist's garden",
                    "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a healing potion and 10 gold pieces.", 20, 10);

            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_RAT_TAIL), 3));

            clearAlchemistGarden.rewardItemOfQuest = ItemByID(ITEM_ID_HEALING_POTION);

            Quest clearFarmersField =
                new Quest(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    "Clear the farmer's field",
                    "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold pieces.", 20, 20);

            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 3));

            clearFarmersField.rewardItemOfQuest = ItemByID(ITEM_ID_ADVENTURER_PASS);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }
        private static void PopulateLocations()
        {
            //
            // Location creation
            //
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.");

            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town square", "You see a fountain.");

            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's hut", "There are many strange plants on the shelves.");
            alchemistHut.givenQuestLoc = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's garden", "Many plants are growing here.");
            alchemistsGarden.placedEnemyLoc = EnemiesByID(ENEMY_ID_RAT);


            Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse", "There is a small farmhouse, with a farmer in front.");
            farmhouse.givenQuestLoc = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

            Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's field", "You see rows of vegetables growing here.");
            farmersField.placedEnemyLoc = EnemiesByID(ENEMY_ID_SNAKE);


            Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard post", "There is a large, tough-looking guard here.", ItemByID(ITEM_ID_ADVENTURER_PASS));

            Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge", "A stone bridge crosses a wide river.");

            Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering covering the trees in this forest.");
            spiderField.placedEnemyLoc = EnemiesByID(ENEMY_ID_GIANT_SPIDER);

            //
            // Location stitching
            //
            home.northOfLoc = townSquare;

            townSquare.northOfLoc = alchemistHut;
            townSquare.southOfLoc = home;
            townSquare.eastOfLoc = guardPost;
            townSquare.westOfLoc = farmhouse;

            farmhouse.eastOfLoc = townSquare;
            farmhouse.westOfLoc = farmersField;

            farmersField.eastOfLoc = farmhouse;

            alchemistHut.southOfLoc = townSquare;
            alchemistHut.northOfLoc = alchemistsGarden;

            alchemistsGarden.southOfLoc = alchemistHut;

            guardPost.eastOfLoc = bridge;
            guardPost.westOfLoc = townSquare;

            bridge.westOfLoc = guardPost;
            bridge.eastOfLoc = spiderField;

            spiderField.westOfLoc = bridge;
            //
            // Add the locations to the static list
            //
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
            //
            //
            //
        }

        //
        // "search List for ID x" Methods -> Used in "Find object by code name" searches
        //
        public static Item ItemByID(int id) // passed ID for object
        {
            foreach (Item item in Items) // look at each object in the list...
            {
                if (item.ID == id) // ...until it matches the passed ID
                {
                    return item; // return matching object
                }
            }

            return null; // if no matching object is in the list, return nothing
        }
        public static Enemy EnemiesByID(int id)
        {
            foreach (Enemy enemy in Enemies)
            {
                if (enemy.ID == id)
                {
                    return enemy;
                }
            }

            return null;
        }
        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }
        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
        //
        //
        //

    }
}
