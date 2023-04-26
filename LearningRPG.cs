using Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningRPG
{
    public partial class LearningRPG : Form
    {

        private Player _player;
        private Enemy _currentEnemy;
        public LearningRPG()
        {
            InitializeComponent();

            _player = new Player(0, 0, 1, 10, 10); // set statsStart

            MoveTo(World.LocationByID(World.LOCATION_ID_HOME)); // move to the starting area
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1)); // add a rusty sword to the inventory

            UpdatePlayerInformation();

        }

        private void MoveTo(Location newLoc)
        {
            if (!_player.reqToEnterLocInInventory(newLoc))
            {
                rtbMessages.Text += "You must have a " + newLoc.reqToEnterLoc.Name + " to enter this location." + Environment.NewLine;
                return;
            }

            _player.currentLocation = newLoc; // Update current location

            // Show / hide available movement buttons 
            btnNorth.Visible = (newLoc.northOfLoc != null);
            btnEast.Visible = (newLoc.eastOfLoc != null);
            btnSouth.Visible = (newLoc.southOfLoc != null);
            btnWest.Visible = (newLoc.westOfLoc != null);
            //
            // Display location status
            rtbLocation.Text = newLoc.Name + Environment.NewLine;
            rtbLocation.Text = newLoc.Description + Environment.NewLine;
            //
            // Heal player
            _player.currentHP = _player.maxHP;
            //
            // update HP in UI
            lblHP.Text = _player.currentHP.ToString();
            //

            // Location quest check (Quest available / already received / completed)
            if (newLoc.givenQuestLoc != null)
            {
                bool receivedQuest = _player.receivedQuest(newLoc.givenQuestLoc);
                bool completedQuest = _player.completedQuest(newLoc.givenQuestLoc);

                if (receivedQuest)
                {
                    if (!completedQuest)
                    {
                        bool QuestCompletionItemsInInventory = _player.QuestCompletionItemsInInventory(newLoc.givenQuestLoc);

                        if (QuestCompletionItemsInInventory)
                        {
                            _player.RemoveQuestCompletionItems(newLoc.givenQuestLoc);

                            // Quest rewards
                            rtbMessages.Text += "You receive: " + Environment.NewLine;
                            rtbMessages.Text += newLoc.givenQuestLoc.rewardXP.ToString() + " experience points" + Environment.NewLine;
                            rtbMessages.Text += newLoc.givenQuestLoc.rewardGold.ToString() + " gold" + Environment.NewLine;
                            rtbMessages.Text += newLoc.givenQuestLoc.rewardItemOfQuest.Name + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;

                            _player.XP += newLoc.givenQuestLoc.rewardXP;
                            _player.Gold += newLoc.givenQuestLoc.rewardGold;

                            // add rewardItem to Inventory
                            _player.AddItemToInventory(newLoc.givenQuestLoc.rewardItemOfQuest);

                            // marks the quest as completed
                            _player.SetQuestCompletionStatus(newLoc.givenQuestLoc);
                        }
                    }
                }
                else // player doesnt have the quest yet
                {
                    rtbMessages.Text += "You receive the " + newLoc.givenQuestLoc.Name + " quest." + Environment.NewLine;
                    rtbMessages.Text += newLoc.givenQuestLoc.Description + Environment.NewLine;
                    rtbMessages.Text += "To complete it, return with:" + Environment.NewLine;

                    foreach (QuestCompletionItem qci in newLoc.givenQuestLoc.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text = qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.namePlural + Environment.NewLine;
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;

                    _player.QuestList.Add(new PlayerQuest(newLoc.givenQuestLoc)); // add Quest to QuestList
                } // END OF QUEST CHECK


                if (newLoc.placedEnemyLoc != null) // check if an enemy is present
                {
                    rtbMessages.Text += "You see a " + newLoc.placedEnemyLoc.Name + Environment.NewLine;

                    Enemy standardEnemy = World.EnemiesByID(newLoc.placedEnemyLoc.ID); // creating a new Enemy object with stats from the World.Enemy list

                    _currentEnemy = new Enemy(standardEnemy.ID, standardEnemy.Name, standardEnemy.maxDMG, standardEnemy.rewardXP,
                        standardEnemy.rewardGold, standardEnemy.currentHP, standardEnemy.maxHP);

                    foreach (DropItem dropItem in standardEnemy.LootTable)
                    {
                        _currentEnemy.LootTable.Add(dropItem);
                    }

                    cboWeapons.Visible = true;
                    cboPotions.Visible = true;
                    btnUseWeapon.Visible = true;
                    btnUsePotion.Visible = true;
                }
                else
                {
                    _currentEnemy = null;

                    cboWeapons.Visible = false;
                    cboPotions.Visible = false;
                    btnUseWeapon.Visible = false;
                    btnUsePotion.Visible = false;
                }
            } // END OF ENEMY CHECK

            UpdateUI(); // refresh UI Lists
        }
        
        private void UpdateInventoryListInUI() // refresh Inventory list
        {

            dgvInventory.RowHeadersVisible = false;

            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Quantity";

            dgvInventory.Rows.Clear();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                }
            }
        }

        private void UpdateQuestListInUI() // refresh Quest list
        {
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Done?";

            dgvQuests.Rows.Clear();

            foreach (PlayerQuest playerQuest in _player.QuestList)
            {
                dgvQuests.Rows.Add(new[] { playerQuest.Details.Name, playerQuest.isCompleted.ToString() });
            }
        }

        private void UpdateWeaponListInUI()
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }
            if (weapons.Count == 0) // hides the weapon combobox and "Use" button if player has no weapons
            {
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";

                cboWeapons.SelectedIndex = 0;
            }
        }

        private void UpdatePotionListInUI() // refresh Potion combobox
        {
            List<HealingPotion> healingPotions = new List<HealingPotion>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is HealingPotion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((HealingPotion)inventoryItem.Details);
                    }
                }
            }

            if (healingPotions.Count == 0) // hides the potion combobox and "Use" button if player has no potions
            {
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";

                cboPotions.SelectedIndex = 0;
            }
        }

        private void UpdateUI()
        {
            UpdateInventoryListInUI();
            UpdateQuestListInUI();
            UpdateWeaponListInUI();
            UpdatePotionListInUI();
        }

        private void UpdatePlayerInformation()
        {
            lblHP.Text = _player.currentHP.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblXP.Text = _player.XP.ToString();
            lblLvl.Text = _player.Lvl.ToString();
        }

        public void PlayerHPCheck()
        {
            if (_player.currentHP <= 0) // player death
            {
                rtbMessages.Text += "The " + _currentEnemy.Name + " killed you." + Environment.NewLine;

                MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            }
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem; // get currently selected Weapon from ComboBox

            int dmgToEnemy = RNG.numberBetween(currentWeapon.minDMG, currentWeapon.maxDMG); // damage determination

            _currentEnemy.currentHP -= dmgToEnemy; // apply damage

            rtbMessages.Text += "You hit the " + _currentEnemy.Name + " for " + dmgToEnemy.ToString() + " points." + Environment.NewLine;

            if(_currentEnemy.currentHP <= 0) // check if enemy is dead
            {
                rtbMessages.Text += Environment.NewLine;
                rtbMessages.Text += "You defeated the " + _currentEnemy.Name + Environment.NewLine;

                // receive reward XP / gold
                _player.XP += _currentEnemy.rewardXP;
                rtbMessages.Text += "You gain " + _currentEnemy.rewardXP.ToString() + " experience points" + Environment.NewLine;

                _player.Gold += _currentEnemy.rewardGold;
                rtbMessages.Text += "You receive " + _currentEnemy.rewardGold.ToString() + " gold" + Environment.NewLine;
                //
                // random item drop from enemy loottable
                List<InventoryItem> droppedItems = new List<InventoryItem>();

                droppedItems = _currentEnemy.ItemDropOnDeath(_currentEnemy);

                foreach(InventoryItem inventoryItem in droppedItems) // add dropped Items to inventory
                {
                    _player.AddItemToInventory(inventoryItem.Details);

                    if(inventoryItem.Quantity == 1)
                    {
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                    }
                    else
                    {
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.namePlural + Environment.NewLine;
                    }
                }

                // refreshes player information and controls
                UpdatePlayerInformation();
                UpdateInventoryListInUI();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();
                //

                rtbMessages.Text += Environment.NewLine;

                MoveTo(_player.currentLocation); // heals / spawns new monster
            }

            else // enemy still alive
            {
                int dmgToPlayer = RNG.numberBetween(0, _currentEnemy.maxDMG);

                if (dmgToPlayer == 0)
                {
                    rtbMessages.Text += "The " + _currentEnemy.Name + " missed the attack." + Environment.NewLine;
                }
                else
                {
                    rtbMessages.Text += "The " + _currentEnemy.Name + " did " + dmgToPlayer.ToString() + " points of damage." + Environment.NewLine;
                }

                _player.currentHP -= dmgToPlayer; // subtract dmg amount from player health

                lblHP.Text = _player.currentHP.ToString(); // update HP label (UI)

                PlayerHPCheck();
            }
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {   // heal
            HealingPotion potion = (HealingPotion)cboPotions.SelectedItem; // get currently selected Potion from ComboBox

            _player.PlayerHeal(potion, _player); // heal and remove potion from inventory

            rtbMessages.Text += "You drink a " + potion.Name + Environment.NewLine;

            // enemy turn
            int dmgToPlayer = RNG.numberBetween(0, _currentEnemy.maxDMG); 

            if (dmgToPlayer == 0)
            {
                rtbMessages.Text += "The " + _currentEnemy.Name + " missed the attack." + Environment.NewLine;
            }
            else
            {
                rtbMessages.Text += "The " + _currentEnemy.Name + " did " + dmgToPlayer.ToString() + " points of damage." + Environment.NewLine;
            }

            _player.currentHP -= dmgToPlayer; // subtract dmg amount from player health

            PlayerHPCheck();
            //

            lblHP.Text = _player.currentHP.ToString(); // update HP label (UI)
            UpdateInventoryListInUI();
            UpdatePotionListInUI();

        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.currentLocation.northOfLoc);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.currentLocation.eastOfLoc);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.currentLocation.southOfLoc);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.currentLocation.westOfLoc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
