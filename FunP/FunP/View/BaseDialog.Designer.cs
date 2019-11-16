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
            this.reqResultsList = new System.Windows.Forms.ListBox();
            this.RequestGroup = new System.Windows.Forms.GroupBox();
            this.GetGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lastIndexText = new System.Windows.Forms.TextBox();
            this.firstIndexText = new System.Windows.Forms.TextBox();
            this.requestSheetList = new System.Windows.Forms.ListBox();
            this.newLineTypeList = new System.Windows.Forms.ListBox();
            this.AddGroup = new System.Windows.Forms.GroupBox();
            this.RequestGroup.SuspendLayout();
            this.GetGroup.SuspendLayout();
            this.AddGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // getDataButton
            // 
            this.getDataButton.Location = new System.Drawing.Point(272, 69);
            this.getDataButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.getDataButton.Name = "getDataButton";
            this.getDataButton.Size = new System.Drawing.Size(399, 35);
            this.getDataButton.TabIndex = 0;
            this.getDataButton.Text = "Get data";
            this.getDataButton.UseVisualStyleBackColor = true;
            this.getDataButton.Click += new System.EventHandler(this.getDataButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(272, 120);
            this.editButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(184, 35);
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
            this.addButton.Size = new System.Drawing.Size(250, 35);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add row";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(486, 120);
            this.removeButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(184, 35);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove row";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // reqResultsList
            // 
            this.reqResultsList.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reqResultsList.FormattingEnabled = true;
            this.reqResultsList.HorizontalScrollbar = true;
            this.reqResultsList.ItemHeight = 22;
            this.reqResultsList.Location = new System.Drawing.Point(9, 29);
            this.reqResultsList.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.reqResultsList.Name = "reqResultsList";
            this.reqResultsList.Size = new System.Drawing.Size(1207, 312);
            this.reqResultsList.TabIndex = 4;
            // 
            // RequestGroup
            // 
            this.RequestGroup.Controls.Add(this.reqResultsList);
            this.RequestGroup.Location = new System.Drawing.Point(20, 198);
            this.RequestGroup.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.RequestGroup.Name = "RequestGroup";
            this.RequestGroup.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.RequestGroup.Size = new System.Drawing.Size(1230, 351);
            this.RequestGroup.TabIndex = 5;
            this.RequestGroup.TabStop = false;
            this.RequestGroup.Text = "Request results";
            // 
            // GetGroup
            // 
            this.GetGroup.Controls.Add(this.label2);
            this.GetGroup.Controls.Add(this.label1);
            this.GetGroup.Controls.Add(this.lastIndexText);
            this.GetGroup.Controls.Add(this.removeButton);
            this.GetGroup.Controls.Add(this.firstIndexText);
            this.GetGroup.Controls.Add(this.editButton);
            this.GetGroup.Controls.Add(this.requestSheetList);
            this.GetGroup.Controls.Add(this.getDataButton);
            this.GetGroup.Location = new System.Drawing.Point(20, 18);
            this.GetGroup.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.GetGroup.Name = "GetGroup";
            this.GetGroup.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.GetGroup.Size = new System.Drawing.Size(680, 171);
            this.GetGroup.TabIndex = 6;
            this.GetGroup.TabStop = false;
            this.GetGroup.Text = "Get";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last line to show";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "First line to show";
            // 
            // lastIndexText
            // 
            this.lastIndexText.Location = new System.Drawing.Point(609, 29);
            this.lastIndexText.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lastIndexText.Name = "lastIndexText";
            this.lastIndexText.Size = new System.Drawing.Size(60, 26);
            this.lastIndexText.TabIndex = 1;
            // 
            // firstIndexText
            // 
            this.firstIndexText.Location = new System.Drawing.Point(399, 29);
            this.firstIndexText.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.firstIndexText.Name = "firstIndexText";
            this.firstIndexText.Size = new System.Drawing.Size(60, 26);
            this.firstIndexText.TabIndex = 1;
            // 
            // requestSheetList
            // 
            this.requestSheetList.FormattingEnabled = true;
            this.requestSheetList.ItemHeight = 20;
            this.requestSheetList.Location = new System.Drawing.Point(9, 29);
            this.requestSheetList.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.requestSheetList.Name = "requestSheetList";
            this.requestSheetList.Size = new System.Drawing.Size(248, 124);
            this.requestSheetList.TabIndex = 0;
            // 
            // newLineTypeList
            // 
            this.newLineTypeList.FormattingEnabled = true;
            this.newLineTypeList.ItemHeight = 20;
            this.newLineTypeList.Location = new System.Drawing.Point(10, 29);
            this.newLineTypeList.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.newLineTypeList.Name = "newLineTypeList";
            this.newLineTypeList.Size = new System.Drawing.Size(248, 84);
            this.newLineTypeList.TabIndex = 0;
            // 
            // AddGroup
            // 
            this.AddGroup.Controls.Add(this.newLineTypeList);
            this.AddGroup.Controls.Add(this.addButton);
            this.AddGroup.Location = new System.Drawing.Point(711, 20);
            this.AddGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddGroup.Name = "AddGroup";
            this.AddGroup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddGroup.Size = new System.Drawing.Size(273, 169);
            this.AddGroup.TabIndex = 7;
            this.AddGroup.TabStop = false;
            this.AddGroup.Text = "Add";
            // 
            // FunP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 569);
            this.Controls.Add(this.AddGroup);
            this.Controls.Add(this.GetGroup);
            this.Controls.Add(this.RequestGroup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "FunP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FunP_Load);
            this.RequestGroup.ResumeLayout(false);
            this.GetGroup.ResumeLayout(false);
            this.GetGroup.PerformLayout();
            this.AddGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button getDataButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ListBox reqResultsList;
        private System.Windows.Forms.GroupBox RequestGroup;
        private System.Windows.Forms.GroupBox GetGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lastIndexText;
        private System.Windows.Forms.TextBox firstIndexText;
        private System.Windows.Forms.ListBox requestSheetList;
        private System.Windows.Forms.ListBox newLineTypeList;
        private System.Windows.Forms.GroupBox AddGroup;
    }
}

