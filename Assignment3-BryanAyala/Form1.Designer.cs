namespace Assignment3_BryanAyala
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
            noteBox = new ListBox();
            startBttn = new Button();
            groupBox1 = new GroupBox();
            problemListBox = new ListBox();
            vitalRichBox = new RichTextBox();
            label7 = new Label();
            removeProblemBttn = new Button();
            label6 = new Label();
            deleteBttn = new Button();
            updateBttn = new Button();
            addNoteBttn = new Button();
            noteRichBox = new RichTextBox();
            label5 = new Label();
            birthDate = new DateTimePicker();
            addProblemBttn = new Button();
            newProblem = new TextBox();
            patientName = new TextBox();
            idBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            notificationLabel = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // noteBox
            // 
            noteBox.FormattingEnabled = true;
            noteBox.ItemHeight = 25;
            noteBox.Location = new Point(41, 78);
            noteBox.Name = "noteBox";
            noteBox.Size = new Size(235, 654);
            noteBox.TabIndex = 0;
            noteBox.SelectedIndexChanged += noteBox_SelectedIndexChanged;
            // 
            // startBttn
            // 
            startBttn.Location = new Point(41, 23);
            startBttn.Name = "startBttn";
            startBttn.Size = new Size(159, 33);
            startBttn.TabIndex = 1;
            startBttn.Text = "Start new note";
            startBttn.UseVisualStyleBackColor = true;
            startBttn.Click += startBttn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(problemListBox);
            groupBox1.Controls.Add(vitalRichBox);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(removeProblemBttn);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(deleteBttn);
            groupBox1.Controls.Add(updateBttn);
            groupBox1.Controls.Add(addNoteBttn);
            groupBox1.Controls.Add(noteRichBox);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(birthDate);
            groupBox1.Controls.Add(addProblemBttn);
            groupBox1.Controls.Add(newProblem);
            groupBox1.Controls.Add(patientName);
            groupBox1.Controls.Add(idBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(304, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1114, 703);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add/Edit/Delete Encounter Note:";
            // 
            // problemListBox
            // 
            problemListBox.FormattingEnabled = true;
            problemListBox.ItemHeight = 25;
            problemListBox.Location = new Point(566, 70);
            problemListBox.Margin = new Padding(4, 5, 4, 5);
            problemListBox.Name = "problemListBox";
            problemListBox.Size = new Size(193, 179);
            problemListBox.TabIndex = 18;
            // 
            // vitalRichBox
            // 
            vitalRichBox.Location = new Point(796, 70);
            vitalRichBox.Name = "vitalRichBox";
            vitalRichBox.Size = new Size(298, 226);
            vitalRichBox.TabIndex = 17;
            vitalRichBox.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(796, 42);
            label7.Name = "label7";
            label7.Size = new Size(58, 25);
            label7.TabIndex = 16;
            label7.Text = "Vitals:";
            // 
            // removeProblemBttn
            // 
            removeProblemBttn.Location = new Point(566, 262);
            removeProblemBttn.Name = "removeProblemBttn";
            removeProblemBttn.Size = new Size(194, 33);
            removeProblemBttn.TabIndex = 15;
            removeProblemBttn.Text = "Remove problem";
            removeProblemBttn.UseVisualStyleBackColor = true;
            removeProblemBttn.Click += removeProblemBttn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(566, 42);
            label6.Name = "label6";
            label6.Size = new Size(91, 25);
            label6.TabIndex = 13;
            label6.Text = "Problems:";
            // 
            // deleteBttn
            // 
            deleteBttn.Location = new Point(337, 652);
            deleteBttn.Name = "deleteBttn";
            deleteBttn.Size = new Size(131, 33);
            deleteBttn.TabIndex = 12;
            deleteBttn.Text = "Delete note";
            deleteBttn.UseVisualStyleBackColor = true;
            deleteBttn.Click += deleteBttn_Click;
            // 
            // updateBttn
            // 
            updateBttn.Location = new Point(169, 652);
            updateBttn.Name = "updateBttn";
            updateBttn.Size = new Size(131, 33);
            updateBttn.TabIndex = 11;
            updateBttn.Text = "Update note";
            updateBttn.UseVisualStyleBackColor = true;
            updateBttn.Click += updateBttn_Click;
            // 
            // addNoteBttn
            // 
            addNoteBttn.Location = new Point(26, 652);
            addNoteBttn.Name = "addNoteBttn";
            addNoteBttn.Size = new Size(111, 33);
            addNoteBttn.TabIndex = 10;
            addNoteBttn.Text = "Add note";
            addNoteBttn.UseVisualStyleBackColor = true;
            addNoteBttn.Click += addNoteBttn_Click;
            // 
            // noteRichBox
            // 
            noteRichBox.Location = new Point(26, 320);
            noteRichBox.Name = "noteRichBox";
            noteRichBox.Size = new Size(1068, 311);
            noteRichBox.TabIndex = 9;
            noteRichBox.Text = "";
            noteRichBox.TextChanged += noteRichBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 282);
            label5.Name = "label5";
            label5.Size = new Size(63, 25);
            label5.TabIndex = 8;
            label5.Text = "Notes:";
            // 
            // birthDate
            // 
            birthDate.Format = DateTimePickerFormat.Custom;
            birthDate.Location = new Point(150, 162);
            birthDate.Name = "birthDate";
            birthDate.Size = new Size(150, 31);
            birthDate.TabIndex = 7;
            // 
            // addProblemBttn
            // 
            addProblemBttn.Location = new Point(420, 213);
            addProblemBttn.Name = "addProblemBttn";
            addProblemBttn.Size = new Size(71, 33);
            addProblemBttn.TabIndex = 3;
            addProblemBttn.Text = "Add";
            addProblemBttn.UseVisualStyleBackColor = true;
            addProblemBttn.Click += addProblemBttn_Click;
            // 
            // newProblem
            // 
            newProblem.Location = new Point(150, 218);
            newProblem.Name = "newProblem";
            newProblem.Size = new Size(253, 31);
            newProblem.TabIndex = 6;
            // 
            // patientName
            // 
            patientName.Location = new Point(150, 105);
            patientName.Name = "patientName";
            patientName.Size = new Size(343, 31);
            patientName.TabIndex = 5;
            // 
            // idBox
            // 
            idBox.Location = new Point(150, 52);
            idBox.Name = "idBox";
            idBox.Size = new Size(150, 31);
            idBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 218);
            label4.Name = "label4";
            label4.Size = new Size(124, 25);
            label4.TabIndex = 3;
            label4.Text = "New problem:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 167);
            label3.Name = "label3";
            label3.Size = new Size(116, 25);
            label3.TabIndex = 2;
            label3.Text = "Date of Birth:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 112);
            label2.Name = "label2";
            label2.Size = new Size(118, 25);
            label2.TabIndex = 1;
            label2.Text = "Patient name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 55);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 0;
            label1.Text = "Note ID:";
            // 
            // notificationLabel
            // 
            notificationLabel.AutoSize = true;
            notificationLabel.Location = new Point(41, 772);
            notificationLabel.Name = "notificationLabel";
            notificationLabel.Size = new Size(0, 25);
            notificationLabel.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1446, 840);
            Controls.Add(notificationLabel);
            Controls.Add(groupBox1);
            Controls.Add(startBttn);
            Controls.Add(noteBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox noteBox;
        private Button startBttn;
        private GroupBox groupBox1;
        private RichTextBox vitalRichBox;
        private Label label7;
        private Button removeProblemBttn;
        private Label label6;
        private Button deleteBttn;
        private Button updateBttn;
        private Button addNoteBttn;
        private RichTextBox noteRichBox;
        private Label label5;
        private DateTimePicker birthDate;
        private Button addProblemBttn;
        private TextBox newProblem;
        private TextBox patientName;
        private TextBox idBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label notificationLabel;
        private ListBox problemListBox;
    }
}