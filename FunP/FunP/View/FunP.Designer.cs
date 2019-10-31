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
            this.getDataButton.Location = new System.Drawing.Point(181, 45);
            this.getDataButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.getDataButton.Name = "getDataButton";
            this.getDataButton.Size = new System.Drawing.Size(266, 23);
            this.getDataButton.TabIndex = 0;
            this.getDataButton.Text = "Get data";
            this.getDataButton.UseVisualStyleBackColor = true;
            this.getDataButton.Click += new System.EventHandler(this.getDataButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(181, 78);
            this.editButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(123, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit row";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(7, 77);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(167, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add row";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(324, 78);
            this.removeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(123, 23);
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
            this.reqResultsList.ItemHeight = 16;
            this.reqResultsList.Location = new System.Drawing.Point(6, 19);
            this.reqResultsList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.reqResultsList.Name = "reqResultsList";
            this.reqResultsList.Size = new System.Drawing.Size(630, 212);
            this.reqResultsList.TabIndex = 4;
            // 
            // RequestGroup
            // 
            this.RequestGroup.Controls.Add(this.reqResultsList);
            this.RequestGroup.Location = new System.Drawing.Point(13, 129);
            this.RequestGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RequestGroup.Name = "RequestGroup";
            this.RequestGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RequestGroup.Size = new System.Drawing.Size(642, 228);
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
            this.GetGroup.Location = new System.Drawing.Point(13, 12);
            this.GetGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GetGroup.Name = "GetGroup";
            this.GetGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GetGroup.Size = new System.Drawing.Size(453, 111);
            this.GetGroup.TabIndex = 6;
            this.GetGroup.TabStop = false;
            this.GetGroup.Text = "Get";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last line to show";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First line to show";
            // 
            // lastIndexText
            // 
            this.lastIndexText.Location = new System.Drawing.Point(406, 19);
            this.lastIndexText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lastIndexText.Name = "lastIndexText";
            this.lastIndexText.Size = new System.Drawing.Size(41, 20);
            this.lastIndexText.TabIndex = 1;
            // 
            // firstIndexText
            // 
            this.firstIndexText.Location = new System.Drawing.Point(266, 19);
            this.firstIndexText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.firstIndexText.Name = "firstIndexText";
            this.firstIndexText.Size = new System.Drawing.Size(41, 20);
            this.firstIndexText.TabIndex = 1;
            // 
            // requestSheetList
            // 
            this.requestSheetList.FormattingEnabled = true;
            this.requestSheetList.Location = new System.Drawing.Point(6, 19);
            this.requestSheetList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.requestSheetList.Name = "requestSheetList";
            this.requestSheetList.Size = new System.Drawing.Size(167, 82);
            this.requestSheetList.TabIndex = 0;
            // 
            // newLineTypeList
            // 
            this.newLineTypeList.FormattingEnabled = true;
            this.newLineTypeList.Location = new System.Drawing.Point(7, 19);
            this.newLineTypeList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.newLineTypeList.Name = "newLineTypeList";
            this.newLineTypeList.Size = new System.Drawing.Size(167, 56);
            this.newLineTypeList.TabIndex = 0;
            // 
            // AddGroup
            // 
            this.AddGroup.Controls.Add(this.newLineTypeList);
            this.AddGroup.Controls.Add(this.addButton);
            this.AddGroup.Location = new System.Drawing.Point(474, 13);
            this.AddGroup.Name = "AddGroup";
            this.AddGroup.Size = new System.Drawing.Size(182, 110);
            this.AddGroup.TabIndex = 7;
            this.AddGroup.TabStop = false;
            this.AddGroup.Text = "Add";
            // 
            // FunP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 370);
            this.Controls.Add(this.AddGroup);
            this.Controls.Add(this.GetGroup);
            this.Controls.Add(this.RequestGroup);
            this.Margin = new System.Windows.Forms.Padding(2);
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

