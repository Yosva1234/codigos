namespace Tester
{
    partial class FormTester
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
            this.gbxStart = new System.Windows.Forms.GroupBox();
            this.lblBoss = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.tbxBoss = new System.Windows.Forms.TextBox();
            this.gbxAssign = new System.Windows.Forms.GroupBox();
            this.tbxAssignSubordinate = new System.Windows.Forms.TextBox();
            this.tbxAssignBoss = new System.Windows.Forms.TextBox();
            this.lblAssignSubordinate = new System.Windows.Forms.Label();
            this.btnAssign = new System.Windows.Forms.Button();
            this.lblAssignBoss = new System.Windows.Forms.Label();
            this.gbxOrder = new System.Windows.Forms.GroupBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.tbxOrder = new System.Windows.Forms.TextBox();
            this.tbxSubordinate = new System.Windows.Forms.TextBox();
            this.tbxSuperior = new System.Windows.Forms.TextBox();
            this.lblSubordinate = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.lblOrderSuperior = new System.Windows.Forms.Label();
            this.tabData = new System.Windows.Forms.TabControl();
            this.tbpStructure = new System.Windows.Forms.TabPage();
            this.dgvStructure = new System.Windows.Forms.DataGridView();
            this.ColumnSuperior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIntegrant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StructureError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpOrders = new System.Windows.Forms.TabPage();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.ColumnOrderIntegrant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHasOrder = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxStart.SuspendLayout();
            this.gbxAssign.SuspendLayout();
            this.gbxOrder.SuspendLayout();
            this.tabData.SuspendLayout();
            this.tbpStructure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStructure)).BeginInit();
            this.tbpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxStart
            // 
            this.gbxStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxStart.Controls.Add(this.lblBoss);
            this.gbxStart.Controls.Add(this.btnRestart);
            this.gbxStart.Controls.Add(this.tbxBoss);
            this.gbxStart.Location = new System.Drawing.Point(12, 12);
            this.gbxStart.Name = "gbxStart";
            this.gbxStart.Size = new System.Drawing.Size(528, 54);
            this.gbxStart.TabIndex = 2;
            this.gbxStart.TabStop = false;
            this.gbxStart.Text = "Inicio";
            // 
            // lblBoss
            // 
            this.lblBoss.AutoSize = true;
            this.lblBoss.Location = new System.Drawing.Point(6, 22);
            this.lblBoss.Name = "lblBoss";
            this.lblBoss.Size = new System.Drawing.Size(72, 13);
            this.lblBoss.TabIndex = 3;
            this.lblBoss.Text = "Jefe Supremo";
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestart.Location = new System.Drawing.Point(447, 16);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.Text = "&Reiniciar Jerarquia";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // tbxBoss
            // 
            this.tbxBoss.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxBoss.Location = new System.Drawing.Point(84, 19);
            this.tbxBoss.Name = "tbxBoss";
            this.tbxBoss.Size = new System.Drawing.Size(357, 20);
            this.tbxBoss.TabIndex = 0;
            // 
            // gbxAssign
            // 
            this.gbxAssign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxAssign.Controls.Add(this.tbxAssignSubordinate);
            this.gbxAssign.Controls.Add(this.tbxAssignBoss);
            this.gbxAssign.Controls.Add(this.lblAssignSubordinate);
            this.gbxAssign.Controls.Add(this.btnAssign);
            this.gbxAssign.Controls.Add(this.lblAssignBoss);
            this.gbxAssign.Enabled = false;
            this.gbxAssign.Location = new System.Drawing.Point(12, 72);
            this.gbxAssign.Name = "gbxAssign";
            this.gbxAssign.Size = new System.Drawing.Size(528, 66);
            this.gbxAssign.TabIndex = 3;
            this.gbxAssign.TabStop = false;
            this.gbxAssign.Text = "Asignar Jefe";
            // 
            // tbxAssignSubordinate
            // 
            this.tbxAssignSubordinate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAssignSubordinate.Location = new System.Drawing.Point(311, 28);
            this.tbxAssignSubordinate.Name = "tbxAssignSubordinate";
            this.tbxAssignSubordinate.Size = new System.Drawing.Size(130, 20);
            this.tbxAssignSubordinate.TabIndex = 3;
            // 
            // tbxAssignBoss
            // 
            this.tbxAssignBoss.Location = new System.Drawing.Point(84, 28);
            this.tbxAssignBoss.Name = "tbxAssignBoss";
            this.tbxAssignBoss.Size = new System.Drawing.Size(148, 20);
            this.tbxAssignBoss.TabIndex = 2;
            // 
            // lblAssignSubordinate
            // 
            this.lblAssignSubordinate.AutoSize = true;
            this.lblAssignSubordinate.Location = new System.Drawing.Point(238, 31);
            this.lblAssignSubordinate.Name = "lblAssignSubordinate";
            this.lblAssignSubordinate.Size = new System.Drawing.Size(67, 13);
            this.lblAssignSubordinate.TabIndex = 5;
            this.lblAssignSubordinate.Text = "Subordinado";
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssign.Location = new System.Drawing.Point(447, 26);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.TabIndex = 4;
            this.btnAssign.Text = "&Asignar Jefe";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // lblAssignBoss
            // 
            this.lblAssignBoss.AutoSize = true;
            this.lblAssignBoss.Location = new System.Drawing.Point(51, 31);
            this.lblAssignBoss.Name = "lblAssignBoss";
            this.lblAssignBoss.Size = new System.Drawing.Size(27, 13);
            this.lblAssignBoss.TabIndex = 2;
            this.lblAssignBoss.Text = "Jefe";
            // 
            // gbxOrder
            // 
            this.gbxOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxOrder.Controls.Add(this.lblOrder);
            this.gbxOrder.Controls.Add(this.tbxOrder);
            this.gbxOrder.Controls.Add(this.tbxSubordinate);
            this.gbxOrder.Controls.Add(this.tbxSuperior);
            this.gbxOrder.Controls.Add(this.lblSubordinate);
            this.gbxOrder.Controls.Add(this.btnOrder);
            this.gbxOrder.Controls.Add(this.lblOrderSuperior);
            this.gbxOrder.Enabled = false;
            this.gbxOrder.Location = new System.Drawing.Point(12, 144);
            this.gbxOrder.Name = "gbxOrder";
            this.gbxOrder.Size = new System.Drawing.Size(528, 89);
            this.gbxOrder.TabIndex = 7;
            this.gbxOrder.TabStop = false;
            this.gbxOrder.Text = "Ordenar";
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(32, 57);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(36, 13);
            this.lblOrder.TabIndex = 8;
            this.lblOrder.Text = "Orden";
            // 
            // tbxOrder
            // 
            this.tbxOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxOrder.Location = new System.Drawing.Point(84, 54);
            this.tbxOrder.Name = "tbxOrder";
            this.tbxOrder.Size = new System.Drawing.Size(357, 20);
            this.tbxOrder.TabIndex = 7;
            // 
            // tbxSubordinate
            // 
            this.tbxSubordinate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSubordinate.Location = new System.Drawing.Point(311, 28);
            this.tbxSubordinate.Name = "tbxSubordinate";
            this.tbxSubordinate.Size = new System.Drawing.Size(130, 20);
            this.tbxSubordinate.TabIndex = 6;
            // 
            // tbxSuperior
            // 
            this.tbxSuperior.Location = new System.Drawing.Point(84, 28);
            this.tbxSuperior.Name = "tbxSuperior";
            this.tbxSuperior.Size = new System.Drawing.Size(148, 20);
            this.tbxSuperior.TabIndex = 5;
            // 
            // lblSubordinate
            // 
            this.lblSubordinate.AutoSize = true;
            this.lblSubordinate.Location = new System.Drawing.Point(238, 31);
            this.lblSubordinate.Name = "lblSubordinate";
            this.lblSubordinate.Size = new System.Drawing.Size(67, 13);
            this.lblSubordinate.TabIndex = 5;
            this.lblSubordinate.Text = "Subordinado";
            // 
            // btnOrder
            // 
            this.btnOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder.Location = new System.Drawing.Point(447, 26);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 8;
            this.btnOrder.Text = "&Ordenar";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lblOrderSuperior
            // 
            this.lblOrderSuperior.AutoSize = true;
            this.lblOrderSuperior.Location = new System.Drawing.Point(32, 31);
            this.lblOrderSuperior.Name = "lblOrderSuperior";
            this.lblOrderSuperior.Size = new System.Drawing.Size(46, 13);
            this.lblOrderSuperior.TabIndex = 2;
            this.lblOrderSuperior.Text = "Superior";
            // 
            // tabData
            // 
            this.tabData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabData.Controls.Add(this.tbpStructure);
            this.tabData.Controls.Add(this.tbpOrders);
            this.tabData.Enabled = false;
            this.tabData.Location = new System.Drawing.Point(12, 239);
            this.tabData.Name = "tabData";
            this.tabData.SelectedIndex = 0;
            this.tabData.Size = new System.Drawing.Size(528, 148);
            this.tabData.TabIndex = 8;
            // 
            // tbpStructure
            // 
            this.tbpStructure.Controls.Add(this.dgvStructure);
            this.tbpStructure.Location = new System.Drawing.Point(4, 22);
            this.tbpStructure.Name = "tbpStructure";
            this.tbpStructure.Padding = new System.Windows.Forms.Padding(3);
            this.tbpStructure.Size = new System.Drawing.Size(514, 122);
            this.tbpStructure.TabIndex = 0;
            this.tbpStructure.Text = "Estructura";
            this.tbpStructure.UseVisualStyleBackColor = true;
            // 
            // dgvStructure
            // 
            this.dgvStructure.AllowUserToAddRows = false;
            this.dgvStructure.AllowUserToDeleteRows = false;
            this.dgvStructure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStructure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSuperior,
            this.ColumnIntegrant,
            this.StructureError});
            this.dgvStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStructure.Location = new System.Drawing.Point(3, 3);
            this.dgvStructure.Name = "dgvStructure";
            this.dgvStructure.ReadOnly = true;
            this.dgvStructure.Size = new System.Drawing.Size(508, 116);
            this.dgvStructure.TabIndex = 0;
            // 
            // ColumnSuperior
            // 
            this.ColumnSuperior.HeaderText = "Superior";
            this.ColumnSuperior.Name = "ColumnSuperior";
            this.ColumnSuperior.ReadOnly = true;
            // 
            // ColumnIntegrant
            // 
            this.ColumnIntegrant.HeaderText = "Integrante";
            this.ColumnIntegrant.Name = "ColumnIntegrant";
            this.ColumnIntegrant.ReadOnly = true;
            // 
            // StructureError
            // 
            this.StructureError.HeaderText = "Error";
            this.StructureError.Name = "StructureError";
            this.StructureError.ReadOnly = true;
            // 
            // tbpOrders
            // 
            this.tbpOrders.Controls.Add(this.dgvOrders);
            this.tbpOrders.Location = new System.Drawing.Point(4, 22);
            this.tbpOrders.Name = "tbpOrders";
            this.tbpOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOrders.Size = new System.Drawing.Size(520, 122);
            this.tbpOrders.TabIndex = 1;
            this.tbpOrders.Text = "Órdenes";
            this.tbpOrders.UseVisualStyleBackColor = true;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOrderIntegrant,
            this.ColumnHasOrder,
            this.ColumnOrder,
            this.ColumnWho,
            this.OrderError});
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(3, 3);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.Size = new System.Drawing.Size(514, 116);
            this.dgvOrders.TabIndex = 0;
            // 
            // ColumnOrderIntegrant
            // 
            this.ColumnOrderIntegrant.HeaderText = "Integrante";
            this.ColumnOrderIntegrant.Name = "ColumnOrderIntegrant";
            this.ColumnOrderIntegrant.ReadOnly = true;
            // 
            // ColumnHasOrder
            // 
            this.ColumnHasOrder.HeaderText = "Tiene Orden";
            this.ColumnHasOrder.Name = "ColumnHasOrder";
            this.ColumnHasOrder.ReadOnly = true;
            // 
            // ColumnOrder
            // 
            this.ColumnOrder.HeaderText = "Orden";
            this.ColumnOrder.Name = "ColumnOrder";
            this.ColumnOrder.ReadOnly = true;
            // 
            // ColumnWho
            // 
            this.ColumnWho.HeaderText = "Dada Por";
            this.ColumnWho.Name = "ColumnWho";
            this.ColumnWho.ReadOnly = true;
            // 
            // OrderError
            // 
            this.OrderError.HeaderText = "Error";
            this.OrderError.Name = "OrderError";
            this.OrderError.ReadOnly = true;
            // 
            // FormTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 399);
            this.Controls.Add(this.tabData);
            this.Controls.Add(this.gbxOrder);
            this.Controls.Add(this.gbxAssign);
            this.Controls.Add(this.gbxStart);
            this.Name = "FormTester";
            this.Text = "Jerarquia";
            this.Load += new System.EventHandler(this.FormTester_Load);
            this.gbxStart.ResumeLayout(false);
            this.gbxStart.PerformLayout();
            this.gbxAssign.ResumeLayout(false);
            this.gbxAssign.PerformLayout();
            this.gbxOrder.ResumeLayout(false);
            this.gbxOrder.PerformLayout();
            this.tabData.ResumeLayout(false);
            this.tbpStructure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStructure)).EndInit();
            this.tbpOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxStart;
        private System.Windows.Forms.Label lblBoss;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.TextBox tbxBoss;
        private System.Windows.Forms.GroupBox gbxAssign;
        private System.Windows.Forms.Label lblAssignSubordinate;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Label lblAssignBoss;
        private System.Windows.Forms.TextBox tbxAssignSubordinate;
        private System.Windows.Forms.TextBox tbxAssignBoss;
        private System.Windows.Forms.GroupBox gbxOrder;
        private System.Windows.Forms.TextBox tbxSubordinate;
        private System.Windows.Forms.TextBox tbxSuperior;
        private System.Windows.Forms.Label lblSubordinate;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Label lblOrderSuperior;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.TextBox tbxOrder;
        private System.Windows.Forms.TabControl tabData;
        private System.Windows.Forms.TabPage tbpStructure;
        private System.Windows.Forms.TabPage tbpOrders;
        private System.Windows.Forms.DataGridView dgvStructure;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSuperior;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIntegrant;
        private System.Windows.Forms.DataGridViewTextBoxColumn StructureError;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderIntegrant;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnHasOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWho;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderError;

    }
}

