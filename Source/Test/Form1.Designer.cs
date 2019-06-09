namespace Test
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbSearchNode = new System.Windows.Forms.TextBox();
            this.btnSearchNodeValue = new System.Windows.Forms.Button();
            this.tbInsert = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnGetPathLength = new System.Windows.Forms.Button();
            this.tbNodeValue = new System.Windows.Forms.TextBox();
            this.tbDel = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.rtb3 = new System.Windows.Forms.RichTextBox();
            this.rtb2 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbSearchNode);
            this.groupBox2.Controls.Add(this.btnSearchNodeValue);
            this.groupBox2.Controls.Add(this.tbInsert);
            this.groupBox2.Controls.Add(this.btnInsert);
            this.groupBox2.Controls.Add(this.btnGetPathLength);
            this.groupBox2.Controls.Add(this.tbNodeValue);
            this.groupBox2.Controls.Add(this.tbDel);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnInit);
            this.groupBox2.Location = new System.Drawing.Point(12, 399);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(795, 100);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TOOL";
            // 
            // tbSearchNode
            // 
            this.tbSearchNode.Location = new System.Drawing.Point(532, 16);
            this.tbSearchNode.Name = "tbSearchNode";
            this.tbSearchNode.Size = new System.Drawing.Size(85, 20);
            this.tbSearchNode.TabIndex = 20;
            this.tbSearchNode.Text = "0";
            // 
            // btnSearchNodeValue
            // 
            this.btnSearchNodeValue.Location = new System.Drawing.Point(532, 42);
            this.btnSearchNodeValue.Name = "btnSearchNodeValue";
            this.btnSearchNodeValue.Size = new System.Drawing.Size(85, 42);
            this.btnSearchNodeValue.TabIndex = 19;
            this.btnSearchNodeValue.Text = "Search node";
            this.btnSearchNodeValue.UseVisualStyleBackColor = true;
            this.btnSearchNodeValue.Click += new System.EventHandler(this.btnSearchNodeValue_Click);
            // 
            // tbInsert
            // 
            this.tbInsert.Location = new System.Drawing.Point(144, 16);
            this.tbInsert.Name = "tbInsert";
            this.tbInsert.Size = new System.Drawing.Size(100, 20);
            this.tbInsert.TabIndex = 18;
            this.tbInsert.Text = "0";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(144, 42);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 42);
            this.btnInsert.TabIndex = 16;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnGetPathLength
            // 
            this.btnGetPathLength.Location = new System.Drawing.Point(403, 41);
            this.btnGetPathLength.Name = "btnGetPathLength";
            this.btnGetPathLength.Size = new System.Drawing.Size(90, 43);
            this.btnGetPathLength.TabIndex = 15;
            this.btnGetPathLength.Text = "Get path length";
            this.btnGetPathLength.UseVisualStyleBackColor = true;
            this.btnGetPathLength.Click += new System.EventHandler(this.btnGetPathLength_Click);
            // 
            // tbNodeValue
            // 
            this.tbNodeValue.Location = new System.Drawing.Point(403, 16);
            this.tbNodeValue.Name = "tbNodeValue";
            this.tbNodeValue.Size = new System.Drawing.Size(90, 20);
            this.tbNodeValue.TabIndex = 14;
            this.tbNodeValue.Text = "0";
            // 
            // tbDel
            // 
            this.tbDel.Location = new System.Drawing.Point(278, 16);
            this.tbDel.Name = "tbDel";
            this.tbDel.Size = new System.Drawing.Size(96, 20);
            this.tbDel.TabIndex = 12;
            this.tbDel.Text = "0";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(278, 42);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(96, 42);
            this.btnDel.TabIndex = 11;
            this.btnDel.Text = "delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(670, 35);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(110, 49);
            this.btnInit.TabIndex = 10;
            this.btnInit.Text = "Rollback";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.rtb3);
            this.groupBox1.Controls.Add(this.rtb2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rtb1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 381);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INFO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Node has left child only";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(361, 292);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(137, 13);
            this.label21.TabIndex = 43;
            this.label21.Text = "Node max value in left child";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(358, 268);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(140, 13);
            this.label22.TabIndex = 44;
            this.label22.Text = "Node min value in right child";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(417, 244);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 13);
            this.label23.TabIndex = 45;
            this.label23.Text = "Node min value";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(681, 322);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(99, 49);
            this.btnShow.TabIndex = 13;
            this.btnShow.Text = "Refresh";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(414, 220);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(84, 13);
            this.label24.TabIndex = 46;
            this.label24.Text = "Node max value";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Node has right child only";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(57, 321);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Node full childs";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(187, 283);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 13);
            this.label15.TabIndex = 37;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(187, 259);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 13);
            this.label16.TabIndex = 38;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(51, 241);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 13);
            this.label17.TabIndex = 39;
            this.label17.Text = "Node has 1 child";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(108, 216);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 13);
            this.label18.TabIndex = 40;
            this.label18.Text = "Leaf";
            // 
            // rtb3
            // 
            this.rtb3.Location = new System.Drawing.Point(504, 198);
            this.rtb3.Name = "rtb3";
            this.rtb3.Size = new System.Drawing.Size(171, 173);
            this.rtb3.TabIndex = 34;
            this.rtb3.Text = "";
            // 
            // rtb2
            // 
            this.rtb2.Location = new System.Drawing.Point(144, 198);
            this.rtb2.Name = "rtb2";
            this.rtb2.Size = new System.Drawing.Size(169, 173);
            this.rtb2.TabIndex = 33;
            this.rtb2.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Count node each floor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Left right node";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Count node";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Node left right";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Left node right";
            // 
            // rtb1
            // 
            this.rtb1.Location = new System.Drawing.Point(144, 19);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(531, 173);
            this.rtb1.TabIndex = 26;
            this.rtb1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 507);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbSearchNode;
        private System.Windows.Forms.Button btnSearchNodeValue;
        private System.Windows.Forms.TextBox tbInsert;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnGetPathLength;
        private System.Windows.Forms.TextBox tbNodeValue;
        private System.Windows.Forms.TextBox tbDel;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RichTextBox rtb3;
        private System.Windows.Forms.RichTextBox rtb2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtb1;
    }
}

