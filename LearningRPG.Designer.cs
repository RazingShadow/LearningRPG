namespace LearningRPG
{
    partial class LearningRPG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLblHP = new System.Windows.Forms.Label();
            this.txtLblGold = new System.Windows.Forms.Label();
            this.txtLbLXP = new System.Windows.Forms.Label();
            this.txtLblLvl = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblXP = new System.Windows.Forms.Label();
            this.lblLvl = new System.Windows.Forms.Label();
            this.txtLblActionSelection = new System.Windows.Forms.Label();
            this.cboWeapons = new System.Windows.Forms.ComboBox();
            this.cboPotions = new System.Windows.Forms.ComboBox();
            this.btnUseWeapon = new System.Windows.Forms.Button();
            this.btnUsePotion = new System.Windows.Forms.Button();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.rtbLocation = new System.Windows.Forms.RichTextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.dgvQuests = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLblHP
            // 
            this.txtLblHP.AutoSize = true;
            this.txtLblHP.Location = new System.Drawing.Point(14, 16);
            this.txtLblHP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtLblHP.Name = "txtLblHP";
            this.txtLblHP.Size = new System.Drawing.Size(55, 13);
            this.txtLblHP.TabIndex = 0;
            this.txtLblHP.Text = "Hit Points:";
            // 
            // txtLblGold
            // 
            this.txtLblGold.AutoSize = true;
            this.txtLblGold.Location = new System.Drawing.Point(14, 37);
            this.txtLblGold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtLblGold.Name = "txtLblGold";
            this.txtLblGold.Size = new System.Drawing.Size(32, 13);
            this.txtLblGold.TabIndex = 1;
            this.txtLblGold.Text = "Gold:";
            // 
            // txtLbLXP
            // 
            this.txtLbLXP.AutoSize = true;
            this.txtLbLXP.Location = new System.Drawing.Point(14, 60);
            this.txtLbLXP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtLbLXP.Name = "txtLbLXP";
            this.txtLbLXP.Size = new System.Drawing.Size(63, 13);
            this.txtLbLXP.TabIndex = 2;
            this.txtLbLXP.Text = "Experience:";
            // 
            // txtLblLvl
            // 
            this.txtLblLvl.AutoSize = true;
            this.txtLblLvl.Location = new System.Drawing.Point(14, 81);
            this.txtLblLvl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtLblLvl.Name = "txtLblLvl";
            this.txtLblLvl.Size = new System.Drawing.Size(36, 13);
            this.txtLblLvl.TabIndex = 3;
            this.txtLblLvl.Text = "Level:";
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Location = new System.Drawing.Point(82, 15);
            this.lblHP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(0, 13);
            this.lblHP.TabIndex = 4;
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(82, 37);
            this.lblGold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(0, 13);
            this.lblGold.TabIndex = 5;
            // 
            // lblXP
            // 
            this.lblXP.AutoSize = true;
            this.lblXP.Location = new System.Drawing.Point(82, 59);
            this.lblXP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblXP.Name = "lblXP";
            this.lblXP.Size = new System.Drawing.Size(0, 13);
            this.lblXP.TabIndex = 6;
            // 
            // lblLvl
            // 
            this.lblLvl.AutoSize = true;
            this.lblLvl.Location = new System.Drawing.Point(82, 80);
            this.lblLvl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLvl.Name = "lblLvl";
            this.lblLvl.Size = new System.Drawing.Size(0, 13);
            this.lblLvl.TabIndex = 7;
            // 
            // txtLblActionSelection
            // 
            this.txtLblActionSelection.AutoSize = true;
            this.txtLblActionSelection.Location = new System.Drawing.Point(617, 531);
            this.txtLblActionSelection.Name = "txtLblActionSelection";
            this.txtLblActionSelection.Size = new System.Drawing.Size(72, 13);
            this.txtLblActionSelection.TabIndex = 8;
            this.txtLblActionSelection.Text = "Select action:";
            // 
            // cboWeapons
            // 
            this.cboWeapons.FormattingEnabled = true;
            this.cboWeapons.Location = new System.Drawing.Point(369, 559);
            this.cboWeapons.Name = "cboWeapons";
            this.cboWeapons.Size = new System.Drawing.Size(121, 21);
            this.cboWeapons.TabIndex = 9;
            // 
            // cboPotions
            // 
            this.cboPotions.FormattingEnabled = true;
            this.cboPotions.Location = new System.Drawing.Point(369, 593);
            this.cboPotions.Name = "cboPotions";
            this.cboPotions.Size = new System.Drawing.Size(121, 21);
            this.cboPotions.TabIndex = 10;
            // 
            // btnUseWeapon
            // 
            this.btnUseWeapon.Location = new System.Drawing.Point(620, 559);
            this.btnUseWeapon.Name = "btnUseWeapon";
            this.btnUseWeapon.Size = new System.Drawing.Size(75, 23);
            this.btnUseWeapon.TabIndex = 11;
            this.btnUseWeapon.Text = "Attack";
            this.btnUseWeapon.UseVisualStyleBackColor = true;
            this.btnUseWeapon.Click += new System.EventHandler(this.btnUseWeapon_Click);
            // 
            // btnUsePotion
            // 
            this.btnUsePotion.Location = new System.Drawing.Point(620, 593);
            this.btnUsePotion.Name = "btnUsePotion";
            this.btnUsePotion.Size = new System.Drawing.Size(75, 23);
            this.btnUsePotion.TabIndex = 12;
            this.btnUsePotion.Text = "Heal";
            this.btnUsePotion.UseVisualStyleBackColor = true;
            this.btnUsePotion.Click += new System.EventHandler(this.btnUsePotion_Click);
            // 
            // btnNorth
            // 
            this.btnNorth.Location = new System.Drawing.Point(493, 433);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(75, 23);
            this.btnNorth.TabIndex = 13;
            this.btnNorth.Text = "North";
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.Click += new System.EventHandler(this.btnNorth_Click);
            // 
            // btnEast
            // 
            this.btnEast.Location = new System.Drawing.Point(573, 457);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(75, 23);
            this.btnEast.TabIndex = 14;
            this.btnEast.Text = "East";
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.Click += new System.EventHandler(this.btnEast_Click);
            // 
            // btnSouth
            // 
            this.btnSouth.Location = new System.Drawing.Point(493, 487);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(75, 23);
            this.btnSouth.TabIndex = 15;
            this.btnSouth.Text = "South";
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            // 
            // btnWest
            // 
            this.btnWest.Location = new System.Drawing.Point(412, 457);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(75, 23);
            this.btnWest.TabIndex = 16;
            this.btnWest.Text = "West";
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            // 
            // rtbLocation
            // 
            this.rtbLocation.Location = new System.Drawing.Point(347, 19);
            this.rtbLocation.Name = "rtbLocation";
            this.rtbLocation.ReadOnly = true;
            this.rtbLocation.Size = new System.Drawing.Size(360, 105);
            this.rtbLocation.TabIndex = 17;
            this.rtbLocation.Text = "";
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(347, 130);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(360, 286);
            this.rtbMessages.TabIndex = 18;
            this.rtbMessages.Text = "";
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeColumns = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventory.Enabled = false;
            this.dgvInventory.Location = new System.Drawing.Point(16, 130);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.Size = new System.Drawing.Size(312, 309);
            this.dgvInventory.TabIndex = 19;
            // 
            // dgvQuests
            // 
            this.dgvQuests.AllowUserToAddRows = false;
            this.dgvQuests.AllowUserToDeleteRows = false;
            this.dgvQuests.AllowUserToResizeColumns = false;
            this.dgvQuests.AllowUserToResizeRows = false;
            this.dgvQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuests.Enabled = false;
            this.dgvQuests.Location = new System.Drawing.Point(16, 446);
            this.dgvQuests.MultiSelect = false;
            this.dgvQuests.Name = "dgvQuests";
            this.dgvQuests.ReadOnly = true;
            this.dgvQuests.RowHeadersVisible = false;
            this.dgvQuests.Size = new System.Drawing.Size(312, 189);
            this.dgvQuests.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(347, 512);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "TestButton";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LearningRPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 651);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvQuests);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.rtbLocation);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.btnUsePotion);
            this.Controls.Add(this.btnUseWeapon);
            this.Controls.Add(this.cboPotions);
            this.Controls.Add(this.cboWeapons);
            this.Controls.Add(this.txtLblActionSelection);
            this.Controls.Add(this.lblLvl);
            this.Controls.Add(this.lblXP);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblHP);
            this.Controls.Add(this.txtLblLvl);
            this.Controls.Add(this.txtLbLXP);
            this.Controls.Add(this.txtLblGold);
            this.Controls.Add(this.txtLblHP);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LearningRPG";
            this.Text = "LearningRPG";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Text labels
        private System.Windows.Forms.Label txtLblHP;
        private System.Windows.Forms.Label txtLblGold;
        private System.Windows.Forms.Label txtLbLXP;
        private System.Windows.Forms.Label txtLblLvl;
        private System.Windows.Forms.Label txtLblActionSelection;
        //
        // stat labels
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblXP;
        private System.Windows.Forms.Label lblLvl;
        //
        // Select weapon / potion during battle
        private System.Windows.Forms.ComboBox cboWeapons;
        private System.Windows.Forms.ComboBox cboPotions;
        //
        private System.Windows.Forms.Button btnUseWeapon;
        private System.Windows.Forms.Button btnUsePotion;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnWest;
        // Shows status information (location, events)
        private System.Windows.Forms.RichTextBox rtbLocation;
        private System.Windows.Forms.RichTextBox rtbMessages;
        //
        // Shows inventory / active quests
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridView dgvQuests;
        private System.Windows.Forms.Button button1;
        //
    }
}

