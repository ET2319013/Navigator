namespace Routes
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
			label1 = new Label();
			label2 = new Label();
			comboBox1 = new ComboBox();
			comboBox2 = new ComboBox();
			button1 = new Button();
			label3 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(16, 20);
			label1.Name = "label1";
			label1.Size = new Size(46, 20);
			label1.TabIndex = 0;
			label1.Text = "From:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(16, 58);
			label2.Name = "label2";
			label2.Size = new Size(28, 20);
			label2.TabIndex = 1;
			label2.Text = "To:";
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(101, 12);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(151, 28);
			comboBox1.TabIndex = 2;
			// 
			// comboBox2
			// 
			comboBox2.FormattingEnabled = true;
			comboBox2.Location = new Point(101, 50);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new Size(151, 28);
			comboBox2.TabIndex = 3;
			// 
			// button1
			// 
			button1.Location = new Point(305, 31);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 4;
			button1.Text = "Calc";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(16, 120);
			label3.Name = "label3";
			label3.Size = new Size(52, 20);
			label3.TabIndex = 5;
			label3.Text = "Result:";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(417, 159);
			Controls.Add(label3);
			Controls.Add(button1);
			Controls.Add(comboBox2);
			Controls.Add(comboBox1);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "Form1";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private ComboBox comboBox1;
		private ComboBox comboBox2;
		private Button button1;
		private Label label3;
	}
}