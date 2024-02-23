namespace Minesweeper
{
    partial class Minesweeper_mainprogram
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.InfoText = new System.Windows.Forms.Label();
            this.DifficultySelectBox = new System.Windows.Forms.ComboBox();
            this.MarkedTilesInfo = new System.Windows.Forms.Label();
            this.UsedTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(154, 47);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(94, 29);
            this.StartButton.TabIndex = 0;
            this.StartButton.TabStop = false;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // InfoText
            // 
            this.InfoText.AutoSize = true;
            this.InfoText.Location = new System.Drawing.Point(12, 14);
            this.InfoText.Name = "InfoText";
            this.InfoText.Size = new System.Drawing.Size(136, 20);
            this.InfoText.TabIndex = 1;
            this.InfoText.Text = "Select the difficulty";
            // 
            // DifficultySelectBox
            // 
            this.DifficultySelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DifficultySelectBox.FormattingEnabled = true;
            this.DifficultySelectBox.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.DifficultySelectBox.Text = "Easy";
            this.DifficultySelectBox.Location = new System.Drawing.Point(12, 47);
            this.DifficultySelectBox.Name = "DifficultySelectBox";
            this.DifficultySelectBox.Size = new System.Drawing.Size(136, 28);
            this.DifficultySelectBox.TabIndex = 2;
            // 
            // MarkedTilesInfo
            // 
            this.MarkedTilesInfo.AutoSize = true;
            this.MarkedTilesInfo.Location = new System.Drawing.Point(275, 51);
            this.MarkedTilesInfo.Name = "MarkedTilesInfo";
            this.MarkedTilesInfo.Size = new System.Drawing.Size(0, 20);
            this.MarkedTilesInfo.TabIndex = 3;
            // 
            // UsedTime
            // 
            this.UsedTime.AutoSize = true;
            this.UsedTime.Location = new System.Drawing.Point(424, 51);
            this.UsedTime.Name = "UsedTime";
            this.UsedTime.Size = new System.Drawing.Size(0, 20);
            this.UsedTime.TabIndex = 4;
            // 
            // Minesweeper_mainprogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UsedTime);
            this.Controls.Add(this.MarkedTilesInfo);
            this.Controls.Add(this.DifficultySelectBox);
            this.Controls.Add(this.InfoText);
            this.Controls.Add(this.StartButton);
            this.KeyPreview = true;
            this.Name = "Minesweeper_mainprogram";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StartButton;
        private Label InfoText;
        private ComboBox DifficultySelectBox;
        private Label MarkedTilesInfo;
        private Label UsedTime;
    }
}