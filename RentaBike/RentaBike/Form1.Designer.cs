namespace RentaBike
{
    partial class Form1
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
            this.textBoxSerialNumberInput = new System.Windows.Forms.TextBox();
            this.listBoxOfBikes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRentABike = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBikeDescriptionInput = new System.Windows.Forms.TextBox();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSerialNumberInput
            // 
            this.textBoxSerialNumberInput.Location = new System.Drawing.Point(39, 69);
            this.textBoxSerialNumberInput.Name = "textBoxSerialNumberInput";
            this.textBoxSerialNumberInput.Size = new System.Drawing.Size(194, 27);
            this.textBoxSerialNumberInput.TabIndex = 0;
            this.textBoxSerialNumberInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // listBoxOfBikes
            // 
            this.listBoxOfBikes.FormattingEnabled = true;
            this.listBoxOfBikes.ItemHeight = 20;
            this.listBoxOfBikes.Location = new System.Drawing.Point(39, 124);
            this.listBoxOfBikes.Name = "listBoxOfBikes";
            this.listBoxOfBikes.Size = new System.Drawing.Size(508, 304);
            this.listBoxOfBikes.TabIndex = 1;
            this.listBoxOfBikes.SelectedIndexChanged += new System.EventHandler(this.listBoxOfBikes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serial number";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonRentABike
            // 
            this.buttonRentABike.Location = new System.Drawing.Point(603, 124);
            this.buttonRentABike.Name = "buttonRentABike";
            this.buttonRentABike.Size = new System.Drawing.Size(139, 93);
            this.buttonRentABike.TabIndex = 3;
            this.buttonRentABike.Text = "Rent a Bike";
            this.buttonRentABike.UseVisualStyleBackColor = true;
            this.buttonRentABike.Click += new System.EventHandler(this.rentabike);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description bike";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxBikeDescriptionInput
            // 
            this.textBoxBikeDescriptionInput.Location = new System.Drawing.Point(341, 69);
            this.textBoxBikeDescriptionInput.Name = "textBoxBikeDescriptionInput";
            this.textBoxBikeDescriptionInput.Size = new System.Drawing.Size(206, 27);
            this.textBoxBikeDescriptionInput.TabIndex = 5;
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(603, 329);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(139, 99);
            this.buttonReturn.TabIndex = 6;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.textBoxBikeDescriptionInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRentABike);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxOfBikes);
            this.Controls.Add(this.textBoxSerialNumberInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxSerialNumberInput;
        private ListBox listBoxOfBikes;
        private Label label1;
        private Button buttonRentABike;
        private Label label2;
        private TextBox textBoxBikeDescriptionInput;
        private Button buttonReturn;
    }
}