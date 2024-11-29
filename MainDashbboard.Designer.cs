namespace MLMS2
{
    partial class MainDashbboard
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.paymentButton = new System.Windows.Forms.Button();
            this.reserveButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.memberButton = new System.Windows.Forms.Button();
            this.issueButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inputsuggestionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.suggestionLlabel = new System.Windows.Forms.Label();
            this.contactLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.paymentButton);
            this.groupBox1.Controls.Add(this.reserveButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.memberButton);
            this.groupBox1.Controls.Add(this.issueButton);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(901, 355);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Book Details";
            // 
            // paymentButton
            // 
            this.paymentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentButton.Location = new System.Drawing.Point(481, 283);
            this.paymentButton.Margin = new System.Windows.Forms.Padding(4);
            this.paymentButton.Name = "paymentButton";
            this.paymentButton.Size = new System.Drawing.Size(347, 49);
            this.paymentButton.TabIndex = 10;
            this.paymentButton.Text = "Make payment";
            this.paymentButton.UseVisualStyleBackColor = true;
            this.paymentButton.Click += new System.EventHandler(this.paymentButton_Click);
            // 
            // reserveButton
            // 
            this.reserveButton.Font = new System.Drawing.Font("Elephant", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reserveButton.Location = new System.Drawing.Point(32, 199);
            this.reserveButton.Margin = new System.Windows.Forms.Padding(4);
            this.reserveButton.Name = "reserveButton";
            this.reserveButton.Size = new System.Drawing.Size(796, 59);
            this.reserveButton.TabIndex = 7;
            this.reserveButton.Text = "Reserve book";
            this.reserveButton.UseVisualStyleBackColor = true;
            this.reserveButton.Click += new System.EventHandler(this.reserveButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Elephant", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(32, 41);
            this.addButton.Margin = new System.Windows.Forms.Padding(4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(796, 55);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add book";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // memberButton
            // 
            this.memberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberButton.Location = new System.Drawing.Point(32, 283);
            this.memberButton.Margin = new System.Windows.Forms.Padding(4);
            this.memberButton.Name = "memberButton";
            this.memberButton.Size = new System.Drawing.Size(413, 49);
            this.memberButton.TabIndex = 2;
            this.memberButton.Text = "Add member";
            this.memberButton.UseVisualStyleBackColor = true;
            this.memberButton.Click += new System.EventHandler(this.memberButton_Click);
            // 
            // issueButton
            // 
            this.issueButton.Font = new System.Drawing.Font("Elephant", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueButton.Location = new System.Drawing.Point(32, 121);
            this.issueButton.Margin = new System.Windows.Forms.Padding(4);
            this.issueButton.Name = "issueButton";
            this.issueButton.Size = new System.Drawing.Size(796, 55);
            this.issueButton.TabIndex = 5;
            this.issueButton.Text = "Issue book";
            this.issueButton.UseVisualStyleBackColor = true;
            this.issueButton.Click += new System.EventHandler(this.issueButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Pink;
            this.groupBox2.Controls.Add(this.inputsuggestionRichTextBox);
            this.groupBox2.Controls.Add(this.suggestionLlabel);
            this.groupBox2.Controls.Add(this.contactLabel);
            this.groupBox2.Controls.Add(this.emailLabel);
            this.groupBox2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 376);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(901, 142);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Any doubts?";
            // 
            // inputsuggestionRichTextBox
            // 
            this.inputsuggestionRichTextBox.Location = new System.Drawing.Point(530, 36);
            this.inputsuggestionRichTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.inputsuggestionRichTextBox.Name = "inputsuggestionRichTextBox";
            this.inputsuggestionRichTextBox.Size = new System.Drawing.Size(323, 82);
            this.inputsuggestionRichTextBox.TabIndex = 3;
            this.inputsuggestionRichTextBox.Text = "";
            // 
            // suggestionLlabel
            // 
            this.suggestionLlabel.AutoSize = true;
            this.suggestionLlabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suggestionLlabel.Location = new System.Drawing.Point(339, 70);
            this.suggestionLlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.suggestionLlabel.Name = "suggestionLlabel";
            this.suggestionLlabel.Size = new System.Drawing.Size(195, 23);
            this.suggestionLlabel.TabIndex = 2;
            this.suggestionLlabel.Text = "Any suggestions:";
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactLabel.Location = new System.Drawing.Point(20, 95);
            this.contactLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(248, 23);
            this.contactLabel.TabIndex = 1;
            this.contactLabel.Text = "Contact: 0111223344";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(20, 49);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(267, 23);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "Enquiries: abc@dodo.au";
            // 
            // MainDashbboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 532);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainDashbboard";
            this.Text = "Main Dashbboard";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button paymentButton;
        private System.Windows.Forms.Button reserveButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button memberButton;
        private System.Windows.Forms.Button issueButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox inputsuggestionRichTextBox;
        private System.Windows.Forms.Label suggestionLlabel;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.Label emailLabel;
    }
}