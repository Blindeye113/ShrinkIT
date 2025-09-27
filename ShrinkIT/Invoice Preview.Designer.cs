namespace ShrinkIT;

partial class Invoice_Preview
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
        label3 = new Label();
        label4 = new Label();
        txtInvoiceID = new TextBox();
        txtClientName = new TextBox();
        txtInvoiceDate = new TextBox();
        txtTotalAmount = new TextBox();
        dgvInvoiceItems = new DataGridView();
        btnSaveInvoice = new Button();
        btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvInvoiceItems).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 14);
        label1.Name = "label1";
        label1.Size = new Size(59, 15);
        label1.TabIndex = 0;
        label1.Text = "Invoice ID";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(139, 14);
        label2.Name = "label2";
        label2.Size = new Size(73, 15);
        label2.TabIndex = 1;
        label2.Text = "Client Name";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(267, 14);
        label3.Name = "label3";
        label3.Size = new Size(72, 15);
        label3.TabIndex = 2;
        label3.Text = "Invoice Date";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(12, 418);
        label4.Name = "label4";
        label4.Size = new Size(79, 15);
        label4.TabIndex = 3;
        label4.Text = "Total Amount";
        // 
        // txtInvoiceID
        // 
        txtInvoiceID.Location = new Point(11, 32);
        txtInvoiceID.Name = "txtInvoiceID";
        txtInvoiceID.Size = new Size(122, 23);
        txtInvoiceID.TabIndex = 4;
        // 
        // txtClientName
        // 
        txtClientName.Location = new Point(139, 32);
        txtClientName.Name = "txtClientName";
        txtClientName.Size = new Size(122, 23);
        txtClientName.TabIndex = 5;
        // 
        // txtInvoiceDate
        // 
        txtInvoiceDate.Location = new Point(267, 32);
        txtInvoiceDate.Name = "txtInvoiceDate";
        txtInvoiceDate.Size = new Size(122, 23);
        txtInvoiceDate.TabIndex = 6;
        // 
        // txtTotalAmount
        // 
        txtTotalAmount.Location = new Point(97, 415);
        txtTotalAmount.Name = "txtTotalAmount";
        txtTotalAmount.Size = new Size(130, 23);
        txtTotalAmount.TabIndex = 7;
        // 
        // dgvInvoiceItems
        // 
        dgvInvoiceItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvInvoiceItems.Location = new Point(11, 61);
        dgvInvoiceItems.Name = "dgvInvoiceItems";
        dgvInvoiceItems.Size = new Size(378, 348);
        dgvInvoiceItems.TabIndex = 8;
        // 
        // btnSaveInvoice
        // 
        btnSaveInvoice.Location = new Point(314, 415);
        btnSaveInvoice.Name = "btnSaveInvoice";
        btnSaveInvoice.Size = new Size(75, 23);
        btnSaveInvoice.TabIndex = 9;
        btnSaveInvoice.Text = "Save";
        btnSaveInvoice.UseVisualStyleBackColor = true;
        btnSaveInvoice.Click += btnSaveInvoice_Click;
        // 
        // btnClose
        // 
        btnClose.Location = new Point(233, 415);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(75, 23);
        btnClose.TabIndex = 10;
        btnClose.Text = "Close";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;
        // 
        // Invoice_Preview
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(411, 450);
        Controls.Add(btnClose);
        Controls.Add(btnSaveInvoice);
        Controls.Add(dgvInvoiceItems);
        Controls.Add(txtTotalAmount);
        Controls.Add(txtInvoiceDate);
        Controls.Add(txtClientName);
        Controls.Add(txtInvoiceID);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Name = "Invoice_Preview";
        Text = "Invoice_Preview";
        ((System.ComponentModel.ISupportInitialize)dgvInvoiceItems).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private TextBox txtInvoiceID;
    private TextBox txtClientName;
    private TextBox txtInvoiceDate;
    private TextBox txtTotalAmount;
    private DataGridView dgvInvoiceItems;
    private Button btnSaveInvoice;
    private Button btnClose;
}