namespace FunP
{
    partial class FunP
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.getDataButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.RequestGroup = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.GetGroup = new System.Windows.Forms.GroupBox();
            this.requestSheetList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lastIndexText = new System.Windows.Forms.TextBox();
            this.firstIndexText = new System.Windows.Forms.TextBox();
            this.newLineTypeList = new System.Windows.Forms.ListBox();
            this.AddGroup = new System.Windows.Forms.GroupBox();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.langComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.weatherButton = new System.Windows.Forms.Button();
            this.RequestGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.GetGroup.SuspendLayout();
            this.AddGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // getDataButton
            // 
            this.getDataButton.Location = new System.Drawing.Point(272, 23);
            this.getDataButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.getDataButton.Name = "getDataButton";
            this.getDataButton.Size = new System.Drawing.Size(115, 35);
            this.getDataButton.TabIndex = 0;
            this.getDataButton.Text = "Get data";
            this.getDataButton.UseVisualStyleBackColor = true;
            this.getDataButton.Click += new System.EventHandler(this.getDataButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(272, 78);
            this.editButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(115, 35);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit row";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(10, 118);
            this.addButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(216, 35);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add row";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(272, 123);
            this.removeButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(115, 35);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove row";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // RequestGroup
            // 
            this.RequestGroup.Controls.Add(this.dataGridView);
            this.RequestGroup.Location = new System.Drawing.Point(15, 193);
            this.RequestGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RequestGroup.Name = "RequestGroup";
            this.RequestGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RequestGroup.Size = new System.Drawing.Size(647, 261);
            this.RequestGroup.TabIndex = 5;
            this.RequestGroup.TabStop = false;
            this.RequestGroup.Text = "Request results";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(6, 19);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(629, 236);
            this.dataGridView.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 469);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // GetGroup
            // 
            this.GetGroup.Controls.Add(this.removeButton);
            this.GetGroup.Controls.Add(this.editButton);
            this.GetGroup.Controls.Add(this.requestSheetList);
            this.GetGroup.Controls.Add(this.getDataButton);
            this.GetGroup.Location = new System.Drawing.Point(15, 14);
            this.GetGroup.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.GetGroup.Name = "GetGroup";
            this.GetGroup.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.GetGroup.Size = new System.Drawing.Size(399, 171);
            this.GetGroup.TabIndex = 6;
            this.GetGroup.TabStop = false;
            this.GetGroup.Text = "Get";
            // 
            // requestSheetList
            // 
            this.requestSheetList.FormattingEnabled = true;
            this.requestSheetList.Location = new System.Drawing.Point(9, 29);
            this.requestSheetList.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.requestSheetList.Name = "requestSheetList";
            this.requestSheetList.Size = new System.Drawing.Size(248, 121);
            this.requestSheetList.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(567, 469);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "till";
            // 
            // lastIndexText
            // 
            this.lastIndexText.Location = new System.Drawing.Point(595, 466);
            this.lastIndexText.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lastIndexText.Name = "lastIndexText";
            this.lastIndexText.Size = new System.Drawing.Size(60, 20);
            this.lastIndexText.TabIndex = 1;
            // 
            // firstIndexText
            // 
            this.firstIndexText.Location = new System.Drawing.Point(495, 466);
            this.firstIndexText.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.firstIndexText.Name = "firstIndexText";
            this.firstIndexText.Size = new System.Drawing.Size(60, 20);
            this.firstIndexText.TabIndex = 1;
            // 
            // newLineTypeList
            // 
            this.newLineTypeList.FormattingEnabled = true;
            this.newLineTypeList.Location = new System.Drawing.Point(10, 29);
            this.newLineTypeList.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.newLineTypeList.Name = "newLineTypeList";
            this.newLineTypeList.Size = new System.Drawing.Size(216, 82);
            this.newLineTypeList.TabIndex = 0;
            // 
            // AddGroup
            // 
            this.AddGroup.Controls.Add(this.newLineTypeList);
            this.AddGroup.Controls.Add(this.addButton);
            this.AddGroup.Location = new System.Drawing.Point(429, 14);
            this.AddGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddGroup.Name = "AddGroup";
            this.AddGroup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddGroup.Size = new System.Drawing.Size(233, 169);
            this.AddGroup.TabIndex = 7;
            this.AddGroup.TabStop = false;
            this.AddGroup.Text = "Add";
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(15, 469);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(75, 23);
            this.saveAsButton.TabIndex = 8;
            this.saveAsButton.Text = "Save as";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // langComboBox
            // 
            this.langComboBox.FormattingEnabled = true;
            this.langComboBox.Location = new System.Drawing.Point(548, 509);
            this.langComboBox.Name = "langComboBox";
            this.langComboBox.Size = new System.Drawing.Size(121, 21);
            this.langComboBox.TabIndex = 9;
            this.langComboBox.SelectedIndexChanged += new System.EventHandler(this.langComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 512);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Language";
            // 
            // weatherButton
            // 
            this.weatherButton.Location = new System.Drawing.Point(15, 519);
            this.weatherButton.Name = "weatherButton";
            this.weatherButton.Size = new System.Drawing.Size(75, 23);
            this.weatherButton.TabIndex = 11;
            this.weatherButton.Text = "Weather";
            this.weatherButton.UseVisualStyleBackColor = true;
            this.weatherButton.Click += new System.EventHandler(this.weatherButton_Click);
            // 
            // FunP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 554);
            this.Controls.Add(this.weatherButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.langComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.lastIndexText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.firstIndexText);
            this.Controls.Add(this.AddGroup);
            this.Controls.Add(this.GetGroup);
            this.Controls.Add(this.RequestGroup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "FunP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FunP_Load);
            this.RequestGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.GetGroup.ResumeLayout(false);
            this.AddGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getDataButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.GroupBox RequestGroup;
        private System.Windows.Forms.GroupBox GetGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lastIndexText;
        private System.Windows.Forms.TextBox firstIndexText;
        private System.Windows.Forms.ListBox requestSheetList;
        private System.Windows.Forms.ListBox newLineTypeList;
        private System.Windows.Forms.GroupBox AddGroup;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox langComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button weatherButton;
    }
}

