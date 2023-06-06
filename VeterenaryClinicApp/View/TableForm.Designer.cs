namespace VeterenaryClinicApp
{
    partial class TableForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nameTable = new System.Windows.Forms.Label();
            this.counter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fieldsList = new System.Windows.Forms.ComboBox();
            this.labelField = new System.Windows.Forms.Label();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.labelValue = new System.Windows.Forms.Label();
            this.removeByFieldButton = new System.Windows.Forms.Button();
            this.labelTemp = new System.Windows.Forms.Label();
            this.labelSign = new System.Windows.Forms.Label();
            this.signList = new System.Windows.Forms.ComboBox();
            this.labelTemp2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(826, 292);
            this.dataGridView1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.SkyBlue;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(12, 402);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 34);
            this.button3.TabIndex = 3;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(819, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(121, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Удалить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.SkyBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(230, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 34);
            this.button2.TabIndex = 6;
            this.button2.Text = "Редактировать";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nameTable
            // 
            this.nameTable.AutoSize = true;
            this.nameTable.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTable.Location = new System.Drawing.Point(321, 9);
            this.nameTable.Name = "nameTable";
            this.nameTable.Size = new System.Drawing.Size(65, 24);
            this.nameTable.TabIndex = 7;
            this.nameTable.Text = "label2";
            this.nameTable.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // counter
            // 
            this.counter.AutoSize = true;
            this.counter.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.counter.Location = new System.Drawing.Point(149, 63);
            this.counter.Name = "counter";
            this.counter.Size = new System.Drawing.Size(41, 16);
            this.counter.TabIndex = 8;
            this.counter.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Количество записей:";
            // 
            // fieldsList
            // 
            this.fieldsList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.fieldsList.FormattingEnabled = true;
            this.fieldsList.Location = new System.Drawing.Point(348, 417);
            this.fieldsList.Name = "fieldsList";
            this.fieldsList.Size = new System.Drawing.Size(121, 21);
            this.fieldsList.TabIndex = 11;
            this.fieldsList.SelectedIndexChanged += new System.EventHandler(this.fieldsList_SelectedIndexChanged);
            // 
            // labelField
            // 
            this.labelField.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelField.AutoSize = true;
            this.labelField.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelField.Location = new System.Drawing.Point(345, 400);
            this.labelField.Name = "labelField";
            this.labelField.Size = new System.Drawing.Size(33, 13);
            this.labelField.TabIndex = 13;
            this.labelField.Text = "Поля";
            // 
            // valueBox
            // 
            this.valueBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.valueBox.Location = new System.Drawing.Point(624, 417);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(104, 20);
            this.valueBox.TabIndex = 14;
            // 
            // labelValue
            // 
            this.labelValue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelValue.AutoSize = true;
            this.labelValue.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelValue.Location = new System.Drawing.Point(621, 400);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(55, 13);
            this.labelValue.TabIndex = 15;
            this.labelValue.Text = "Значение";
            // 
            // removeByFieldButton
            // 
            this.removeByFieldButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeByFieldButton.BackColor = System.Drawing.Color.SkyBlue;
            this.removeByFieldButton.FlatAppearance.BorderSize = 0;
            this.removeByFieldButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeByFieldButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeByFieldButton.Location = new System.Drawing.Point(734, 402);
            this.removeByFieldButton.Name = "removeByFieldButton";
            this.removeByFieldButton.Size = new System.Drawing.Size(104, 36);
            this.removeByFieldButton.TabIndex = 16;
            this.removeByFieldButton.Text = "Удалить по полю";
            this.removeByFieldButton.UseVisualStyleBackColor = false;
            this.removeByFieldButton.Click += new System.EventHandler(this.removeByFieldButton_Click);
            // 
            // labelTemp
            // 
            this.labelTemp.AutoSize = true;
            this.labelTemp.Location = new System.Drawing.Point(14, 475);
            this.labelTemp.Name = "labelTemp";
            this.labelTemp.Size = new System.Drawing.Size(46, 13);
            this.labelTemp.TabIndex = 17;
            this.labelTemp.Text = "Шаблон";
            this.labelTemp.Visible = false;
            // 
            // labelSign
            // 
            this.labelSign.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelSign.AutoSize = true;
            this.labelSign.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelSign.Location = new System.Drawing.Point(482, 400);
            this.labelSign.Name = "labelSign";
            this.labelSign.Size = new System.Drawing.Size(32, 13);
            this.labelSign.TabIndex = 19;
            this.labelSign.Text = "Знак";
            // 
            // signList
            // 
            this.signList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.signList.FormattingEnabled = true;
            this.signList.Items.AddRange(new object[] {
            ">",
            "=",
            "<",
            ">=",
            "<="});
            this.signList.Location = new System.Drawing.Point(485, 417);
            this.signList.Name = "signList";
            this.signList.Size = new System.Drawing.Size(121, 21);
            this.signList.TabIndex = 18;
            this.signList.SelectedIndexChanged += new System.EventHandler(this.signList_SelectedIndexChanged);
            // 
            // labelTemp2
            // 
            this.labelTemp2.AutoSize = true;
            this.labelTemp2.Location = new System.Drawing.Point(66, 475);
            this.labelTemp2.Name = "labelTemp2";
            this.labelTemp2.Size = new System.Drawing.Size(46, 13);
            this.labelTemp2.TabIndex = 20;
            this.labelTemp2.Text = "Шаблон";
            this.labelTemp2.Visible = false;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.labelTemp2);
            this.Controls.Add(this.labelSign);
            this.Controls.Add(this.signList);
            this.Controls.Add(this.labelTemp);
            this.Controls.Add(this.removeByFieldButton);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.valueBox);
            this.Controls.Add(this.labelField);
            this.Controls.Add(this.fieldsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.counter);
            this.Controls.Add(this.nameTable);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TableForm";
            this.Text = "TableForm";
            this.Load += new System.EventHandler(this.TableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label nameTable;
        private System.Windows.Forms.Label counter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fieldsList;
        private System.Windows.Forms.Label labelField;
        private System.Windows.Forms.TextBox valueBox;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Button removeByFieldButton;
        private System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.Label labelSign;
        private System.Windows.Forms.ComboBox signList;
        private System.Windows.Forms.Label labelTemp2;
    }
}