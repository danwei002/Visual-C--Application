namespace DanielWeiQuizGame
{
    partial class Form1
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
            this.buttonA = new System.Windows.Forms.Button();
            this.buttonD = new System.Windows.Forms.Button();
            this.buttonC = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.ansA = new System.Windows.Forms.TextBox();
            this.ansB = new System.Windows.Forms.TextBox();
            this.ansC = new System.Windows.Forms.TextBox();
            this.ansD = new System.Windows.Forms.TextBox();
            this.questionDisplay = new System.Windows.Forms.TextBox();
            this.nextBtn = new System.Windows.Forms.Button();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.concedeBtn = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreDisplay = new System.Windows.Forms.TextBox();
            this.difficulties = new System.Windows.Forms.CheckedListBox();
            this.reactionBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.reactionBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonA
            // 
            this.buttonA.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonA.Location = new System.Drawing.Point(23, 503);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(154, 70);
            this.buttonA.TabIndex = 2;
            this.buttonA.Text = "A";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.Click += new System.EventHandler(this.buttonA_Click);
            // 
            // buttonD
            // 
            this.buttonD.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonD.Location = new System.Drawing.Point(771, 503);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(154, 70);
            this.buttonD.TabIndex = 4;
            this.buttonD.Text = "D";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.Click += new System.EventHandler(this.buttonD_Click);
            // 
            // buttonC
            // 
            this.buttonC.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonC.Location = new System.Drawing.Point(511, 503);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(154, 70);
            this.buttonC.TabIndex = 5;
            this.buttonC.Text = "C";
            this.buttonC.UseVisualStyleBackColor = true;
            this.buttonC.Click += new System.EventHandler(this.buttonC_Click);
            // 
            // buttonB
            // 
            this.buttonB.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonB.Location = new System.Drawing.Point(259, 503);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(154, 70);
            this.buttonB.TabIndex = 6;
            this.buttonB.Text = "B";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.Click += new System.EventHandler(this.buttonB_Click);
            // 
            // ansA
            // 
            this.ansA.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ansA.Location = new System.Drawing.Point(23, 300);
            this.ansA.Name = "ansA";
            this.ansA.Size = new System.Drawing.Size(154, 53);
            this.ansA.TabIndex = 8;
            // 
            // ansB
            // 
            this.ansB.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ansB.Location = new System.Drawing.Point(259, 300);
            this.ansB.Name = "ansB";
            this.ansB.Size = new System.Drawing.Size(154, 53);
            this.ansB.TabIndex = 9;
            // 
            // ansC
            // 
            this.ansC.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ansC.Location = new System.Drawing.Point(511, 300);
            this.ansC.Name = "ansC";
            this.ansC.Size = new System.Drawing.Size(154, 53);
            this.ansC.TabIndex = 10;
            // 
            // ansD
            // 
            this.ansD.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ansD.Location = new System.Drawing.Point(771, 300);
            this.ansD.Name = "ansD";
            this.ansD.Size = new System.Drawing.Size(154, 53);
            this.ansD.TabIndex = 11;
            // 
            // questionDisplay
            // 
            this.questionDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionDisplay.Location = new System.Drawing.Point(23, 114);
            this.questionDisplay.Name = "questionDisplay";
            this.questionDisplay.Size = new System.Drawing.Size(902, 44);
            this.questionDisplay.TabIndex = 12;
            // 
            // nextBtn
            // 
            this.nextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.Location = new System.Drawing.Point(951, 112);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(108, 47);
            this.nextBtn.TabIndex = 13;
            this.nextBtn.Text = "NEXT";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficultyLabel.Location = new System.Drawing.Point(1319, 9);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(146, 37);
            this.difficultyLabel.TabIndex = 14;
            this.difficultyLabel.Text = "Difficulty:";
            // 
            // concedeBtn
            // 
            this.concedeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.concedeBtn.Location = new System.Drawing.Point(259, 198);
            this.concedeBtn.Name = "concedeBtn";
            this.concedeBtn.Size = new System.Drawing.Size(406, 67);
            this.concedeBtn.TabIndex = 15;
            this.concedeBtn.Text = "Concede Defeat";
            this.concedeBtn.UseVisualStyleBackColor = true;
            this.concedeBtn.Click += new System.EventHandler(this.ConcedeBtn_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scoreLabel.Location = new System.Drawing.Point(16, 26);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(115, 37);
            this.scoreLabel.TabIndex = 16;
            this.scoreLabel.Text = "Score:";
            // 
            // scoreDisplay
            // 
            this.scoreDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scoreDisplay.Location = new System.Drawing.Point(137, 23);
            this.scoreDisplay.Name = "scoreDisplay";
            this.scoreDisplay.Size = new System.Drawing.Size(202, 44);
            this.scoreDisplay.TabIndex = 17;
            // 
            // difficulties
            // 
            this.difficulties.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.difficulties.FormattingEnabled = true;
            this.difficulties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.difficulties.Location = new System.Drawing.Point(1326, 50);
            this.difficulties.Name = "difficulties";
            this.difficulties.Size = new System.Drawing.Size(120, 109);
            this.difficulties.TabIndex = 18;
            this.difficulties.SelectedIndexChanged += new System.EventHandler(this.Difficulties_SelectedIndexChanged);
            // 
            // reactionBox
            // 
            this.reactionBox.Location = new System.Drawing.Point(1046, 183);
            this.reactionBox.Name = "reactionBox";
            this.reactionBox.Size = new System.Drawing.Size(400, 400);
            this.reactionBox.TabIndex = 19;
            this.reactionBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1477, 595);
            this.Controls.Add(this.reactionBox);
            this.Controls.Add(this.difficulties);
            this.Controls.Add(this.scoreDisplay);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.concedeBtn);
            this.Controls.Add(this.difficultyLabel);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.questionDisplay);
            this.Controls.Add(this.ansD);
            this.Controls.Add(this.ansC);
            this.Controls.Add(this.ansB);
            this.Controls.Add(this.ansA);
            this.Controls.Add(this.buttonD);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.buttonA);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.reactionBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonA;
        private System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.TextBox ansA;
        private System.Windows.Forms.TextBox ansB;
        private System.Windows.Forms.TextBox ansC;
        private System.Windows.Forms.TextBox ansD;
        private System.Windows.Forms.TextBox questionDisplay;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Label difficultyLabel;
        private System.Windows.Forms.Button concedeBtn;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.TextBox scoreDisplay;
        private System.Windows.Forms.CheckedListBox difficulties;
        private System.Windows.Forms.PictureBox reactionBox;
    }
}

