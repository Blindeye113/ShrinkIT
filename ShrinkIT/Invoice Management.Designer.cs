namespace ShrinkIT;

partial class Invoice_Management
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
        lblClient = new Label();
        lblInvoiceDate = new Label();
        cmbClients = new ComboBox();
        dtpInvoiceDate = new DateTimePicker();
        btnCreateInvoice = new Button();
        btnUpdateInvoice = new Button();
        btnDeleteInvoice = new Button();
        btnClear = new Button();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        cmbItems = new ComboBox();
        txtQuantity = new TextBox();
        txtLineTotal = new TextBox();
        txtPrice = new TextBox();
        btnAddItem = new Button();
        btnRemoveItem = new Button();
        dgvInvoiceItems = new DataGridView();
        btnPreviewInvoice = new Button();
        dgvInvoices = new DataGridView();
        btnSaveInvoice = new Button();
        label5 = new Label();
        txtTotalAmount = new TextBox();
        ((System.ComponentModel.ISupportInitialize)dgvInvoiceItems).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvInvoices).BeginInit();
        SuspendLayout();
        // 
        // lblClient
        // 
        lblClient.AutoSize = true;
        lblClient.Location = new Point(12, 10);
        lblClient.Name = "lblClient";
        lblClient.Size = new Size(38, 15);
        lblClient.TabIndex = 0;
        lblClient.Text = "Client";
        // 
        // lblInvoiceDate
        // 
        lblInvoiceDate.AutoSize = true;
        lblInvoiceDate.Location = new Point(12, 54);
        lblInvoiceDate.Name = "lblInvoiceDate";
        lblInvoiceDate.Size = new Size(72, 15);
        lblInvoiceDate.TabIndex = 1;
        lblInvoiceDate.Text = "Invoice Date";
        // 
        // cmbClients
        // 
        cmbClients.FormattingEnabled = true;
        cmbClients.Location = new Point(12, 28);
        cmbClients.Name = "cmbClients";
        cmbClients.Size = new Size(200, 23);
        cmbClients.TabIndex = 3;
        cmbClients.SelectedIndexChanged += cmbClients_SelectedIndexChanged;
        // 
        // dtpInvoiceDate
        // 
        dtpInvoiceDate.Location = new Point(12, 72);
        dtpInvoiceDate.Name = "dtpInvoiceDate";
        dtpInvoiceDate.Size = new Size(200, 23);
        dtpInvoiceDate.TabIndex = 4;
        // 
        // btnCreateInvoice
        // 
        btnCreateInvoice.Location = new Point(11, 145);
        btnCreateInvoice.Name = "btnCreateInvoice";
        btnCreateInvoice.Size = new Size(63, 23);
        btnCreateInvoice.TabIndex = 6;
        btnCreateInvoice.Text = "Create";
        btnCreateInvoice.UseVisualStyleBackColor = true;
        btnCreateInvoice.Click += btnCreateInvoice_Click;
        // 
        // btnUpdateInvoice
        // 
        btnUpdateInvoice.Location = new Point(80, 145);
        btnUpdateInvoice.Name = "btnUpdateInvoice";
        btnUpdateInvoice.Size = new Size(63, 23);
        btnUpdateInvoice.TabIndex = 7;
        btnUpdateInvoice.Text = "Update";
        btnUpdateInvoice.UseVisualStyleBackColor = true;
        btnUpdateInvoice.Click += btnUpdateInvoice_Click;
        // 
        // btnDeleteInvoice
        // 
        btnDeleteInvoice.Location = new Point(149, 145);
        btnDeleteInvoice.Name = "btnDeleteInvoice";
        btnDeleteInvoice.Size = new Size(63, 23);
        btnDeleteInvoice.TabIndex = 8;
        btnDeleteInvoice.Text = "Delete";
        btnDeleteInvoice.UseVisualStyleBackColor = true;
        btnDeleteInvoice.Click += btnDeleteInvoice_Click;
        // 
        // btnClear
        // 
        btnClear.Location = new Point(11, 174);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(196, 23);
        btnClear.TabIndex = 9;
        btnClear.Text = "Clear Form";
        btnClear.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 204);
        label1.Name = "label1";
        label1.Size = new Size(31, 15);
        label1.TabIndex = 10;
        label1.Text = "Item";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 248);
        label2.Name = "label2";
        label2.Size = new Size(53, 15);
        label2.TabIndex = 11;
        label2.Text = "Quantity";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(12, 292);
        label3.Name = "label3";
        label3.Size = new Size(33, 15);
        label3.TabIndex = 12;
        label3.Text = "Price";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(12, 336);
        label4.Name = "label4";
        label4.Size = new Size(57, 15);
        label4.TabIndex = 13;
        label4.Text = "Line Total";
        // 
        // cmbItems
        // 
        cmbItems.FormattingEnabled = true;
        cmbItems.Location = new Point(12, 222);
        cmbItems.Name = "cmbItems";
        cmbItems.Size = new Size(200, 23);
        cmbItems.TabIndex = 14;
        cmbItems.SelectedIndexChanged += cmbItems_SelectedIndexChanged;
        // 
        // txtQuantity
        // 
        txtQuantity.Location = new Point(12, 266);
        txtQuantity.Name = "txtQuantity";
        txtQuantity.Size = new Size(200, 23);
        txtQuantity.TabIndex = 15;
        txtQuantity.TextChanged += txtQuantity_TextChanged;
        // 
        // txtLineTotal
        // 
        txtLineTotal.Location = new Point(12, 354);
        txtLineTotal.Name = "txtLineTotal";
        txtLineTotal.ReadOnly = true;
        txtLineTotal.Size = new Size(200, 23);
        txtLineTotal.TabIndex = 16;
        // 
        // txtPrice
        // 
        txtPrice.Location = new Point(12, 310);
        txtPrice.Name = "txtPrice";
        txtPrice.Size = new Size(200, 23);
        txtPrice.TabIndex = 17;
        txtPrice.TextChanged += txtPrice_TextChanged;
        // 
        // btnAddItem
        // 
        btnAddItem.Location = new Point(12, 383);
        btnAddItem.Name = "btnAddItem";
        btnAddItem.Size = new Size(63, 23);
        btnAddItem.TabIndex = 18;
        btnAddItem.Text = "Add";
        btnAddItem.UseVisualStyleBackColor = true;
        btnAddItem.Click += btnAddItem_Click;
        // 
        // btnRemoveItem
        // 
        btnRemoveItem.Location = new Point(81, 383);
        btnRemoveItem.Name = "btnRemoveItem";
        btnRemoveItem.Size = new Size(63, 23);
        btnRemoveItem.TabIndex = 19;
        btnRemoveItem.Text = "Remove";
        btnRemoveItem.UseVisualStyleBackColor = true;
        btnRemoveItem.Click += btnRemoveItem_Click;
        // 
        // dgvInvoiceItems
        // 
        dgvInvoiceItems.AllowUserToAddRows = false;
        dgvInvoiceItems.AllowUserToDeleteRows = false;
        dgvInvoiceItems.AllowUserToResizeRows = false;
        dgvInvoiceItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvInvoiceItems.Location = new Point(243, 16);
        dgvInvoiceItems.MultiSelect = false;
        dgvInvoiceItems.Name = "dgvInvoiceItems";
        dgvInvoiceItems.Size = new Size(544, 208);
        dgvInvoiceItems.TabIndex = 20;
        dgvInvoiceItems.SelectionChanged += dgvInvoiceItems_SelectionChanged;
        // 
        // btnPreviewInvoice
        // 
        btnPreviewInvoice.Location = new Point(244, 415);
        btnPreviewInvoice.Name = "btnPreviewInvoice";
        btnPreviewInvoice.Size = new Size(544, 23);
        btnPreviewInvoice.TabIndex = 21;
        btnPreviewInvoice.Text = "Preview Selected Invoice";
        btnPreviewInvoice.UseVisualStyleBackColor = true;
        btnPreviewInvoice.Click += btnPreviewInvoice_Click;
        // 
        // dgvInvoices
        // 
        dgvInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvInvoices.Location = new Point(244, 236);
        dgvInvoices.Name = "dgvInvoices";
        dgvInvoices.Size = new Size(544, 167);
        dgvInvoices.TabIndex = 22;
        dgvInvoices.SelectionChanged += dgvInvoices_SelectionChanged;
        // 
        // btnSaveInvoice
        // 
        btnSaveInvoice.Location = new Point(12, 415);
        btnSaveInvoice.Name = "btnSaveInvoice";
        btnSaveInvoice.Size = new Size(196, 23);
        btnSaveInvoice.TabIndex = 23;
        btnSaveInvoice.Text = "Save Selected Invoice";
        btnSaveInvoice.UseVisualStyleBackColor = true;
        btnSaveInvoice.Click += btnSaveInvoice_Click;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(12, 98);
        label5.Name = "label5";
        label5.Size = new Size(32, 15);
        label5.TabIndex = 24;
        label5.Text = "Total";
        // 
        // txtTotalAmount
        // 
        txtTotalAmount.Location = new Point(13, 116);
        txtTotalAmount.Name = "txtTotalAmount";
        txtTotalAmount.ReadOnly = true;
        txtTotalAmount.Size = new Size(200, 23);
        txtTotalAmount.TabIndex = 25;
        // 
        // Invoice_Management
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(txtTotalAmount);
        Controls.Add(label5);
        Controls.Add(btnSaveInvoice);
        Controls.Add(dgvInvoices);
        Controls.Add(btnPreviewInvoice);
        Controls.Add(dgvInvoiceItems);
        Controls.Add(btnRemoveItem);
        Controls.Add(btnAddItem);
        Controls.Add(txtPrice);
        Controls.Add(txtLineTotal);
        Controls.Add(txtQuantity);
        Controls.Add(cmbItems);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(btnClear);
        Controls.Add(btnDeleteInvoice);
        Controls.Add(btnUpdateInvoice);
        Controls.Add(btnCreateInvoice);
        Controls.Add(dtpInvoiceDate);
        Controls.Add(cmbClients);
        Controls.Add(lblInvoiceDate);
        Controls.Add(lblClient);
        Name = "Invoice_Management";
        Text = "Invoice_Management";
        ((System.ComponentModel.ISupportInitialize)dgvInvoiceItems).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvInvoices).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblClient;
    private Label lblInvoiceDate;
    private ComboBox cmbClients;
    private DateTimePicker dtpInvoiceDate;
    private Button btnCreateInvoice;
    private Button btnUpdateInvoice;
    private Button btnDeleteInvoice;
    private Button btnClear;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private ComboBox cmbItems;
    private TextBox txtQuantity;
    private TextBox txtLineTotal;
    private TextBox txtPrice;
    private Button btnAddItem;
    private Button btnRemoveItem;
    private DataGridView dgvInvoiceItems;
    private Button btnPreviewInvoice;
    private DataGridView dgvInvoices;
    private Button btnSaveInvoice;
    private Label label5;
    private TextBox txtTotalAmount;
}