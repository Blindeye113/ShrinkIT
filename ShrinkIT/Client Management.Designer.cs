namespace ShrinkIT;

partial class Client_Management
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
        dgvClients = new DataGridView();
        label1 = new Label();
        txtFirstName = new TextBox();
        label2 = new Label();
        txtLastName = new TextBox();
        txtEmail = new TextBox();
        txtPhone = new TextBox();
        lblMedicalAid = new Label();
        txtMedicalAidName = new TextBox();
        txtMedicalAidNumber = new TextBox();
        btnAddClient = new Button();
        btnUpdateClient = new Button();
        btnDeleteClient = new Button();
        btnDeleteMedicalAid = new Button();
        btnUpdateMedicalAid = new Button();
        btnAddMedicalAid = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
        SuspendLayout();
        // 
        // dgvClients
        // 
        dgvClients.AllowUserToAddRows = false;
        dgvClients.AllowUserToDeleteRows = false;
        dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvClients.EditMode = DataGridViewEditMode.EditProgrammatically;
        dgvClients.Location = new Point(305, 37);
        dgvClients.MultiSelect = false;
        dgvClients.Name = "dgvClients";
        dgvClients.ReadOnly = true;
        dgvClients.Size = new Size(556, 401);
        dgvClients.TabIndex = 0;
        dgvClients.SelectionChanged += dgvClients_SelectionChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        label1.Location = new Point(305, 6);
        label1.Name = "label1";
        label1.Size = new Size(76, 28);
        label1.TabIndex = 1;
        label1.Text = "Clients";
        // 
        // txtFirstName
        // 
        txtFirstName.Location = new Point(25, 70);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.PlaceholderText = "First Name";
        txtFirstName.Size = new Size(200, 23);
        txtFirstName.TabIndex = 2;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        label2.Location = new Point(25, 37);
        label2.Name = "label2";
        label2.Size = new Size(55, 21);
        label2.TabIndex = 3;
        label2.Text = "Client";
        // 
        // txtLastName
        // 
        txtLastName.Location = new Point(25, 99);
        txtLastName.Name = "txtLastName";
        txtLastName.PlaceholderText = "Last Name";
        txtLastName.Size = new Size(200, 23);
        txtLastName.TabIndex = 4;
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(25, 128);
        txtEmail.Name = "txtEmail";
        txtEmail.PlaceholderText = "Email";
        txtEmail.Size = new Size(200, 23);
        txtEmail.TabIndex = 5;
        // 
        // txtPhone
        // 
        txtPhone.Location = new Point(25, 157);
        txtPhone.Name = "txtPhone";
        txtPhone.PlaceholderText = "Phone";
        txtPhone.Size = new Size(200, 23);
        txtPhone.TabIndex = 6;
        // 
        // lblMedicalAid
        // 
        lblMedicalAid.AutoSize = true;
        lblMedicalAid.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblMedicalAid.Location = new Point(25, 255);
        lblMedicalAid.Name = "lblMedicalAid";
        lblMedicalAid.Size = new Size(101, 21);
        lblMedicalAid.TabIndex = 7;
        lblMedicalAid.Text = "Medical Aid";
        // 
        // txtMedicalAidName
        // 
        txtMedicalAidName.Location = new Point(25, 279);
        txtMedicalAidName.Name = "txtMedicalAidName";
        txtMedicalAidName.PlaceholderText = "Medical Aid Name";
        txtMedicalAidName.Size = new Size(200, 23);
        txtMedicalAidName.TabIndex = 8;
        // 
        // txtMedicalAidNumber
        // 
        txtMedicalAidNumber.Location = new Point(25, 308);
        txtMedicalAidNumber.Name = "txtMedicalAidNumber";
        txtMedicalAidNumber.PlaceholderText = "Medical Aid Number";
        txtMedicalAidNumber.Size = new Size(200, 23);
        txtMedicalAidNumber.TabIndex = 9;
        // 
        // btnAddClient
        // 
        btnAddClient.Location = new Point(25, 186);
        btnAddClient.Name = "btnAddClient";
        btnAddClient.Size = new Size(63, 23);
        btnAddClient.TabIndex = 10;
        btnAddClient.Text = "Add";
        btnAddClient.UseVisualStyleBackColor = true;
        btnAddClient.Click += btnAddClient_Click;
        // 
        // btnUpdateClient
        // 
        btnUpdateClient.Location = new Point(94, 186);
        btnUpdateClient.Name = "btnUpdateClient";
        btnUpdateClient.Size = new Size(63, 23);
        btnUpdateClient.TabIndex = 11;
        btnUpdateClient.Text = "Update";
        btnUpdateClient.UseVisualStyleBackColor = true;
        btnUpdateClient.Click += btnUpdateClient_Click;
        // 
        // btnDeleteClient
        // 
        btnDeleteClient.Location = new Point(162, 186);
        btnDeleteClient.Name = "btnDeleteClient";
        btnDeleteClient.Size = new Size(63, 23);
        btnDeleteClient.TabIndex = 12;
        btnDeleteClient.Text = "Delete";
        btnDeleteClient.UseVisualStyleBackColor = true;
        btnDeleteClient.Click += btnDeleteClient_Click;
        // 
        // btnDeleteMedicalAid
        // 
        btnDeleteMedicalAid.Location = new Point(162, 337);
        btnDeleteMedicalAid.Name = "btnDeleteMedicalAid";
        btnDeleteMedicalAid.Size = new Size(63, 23);
        btnDeleteMedicalAid.TabIndex = 15;
        btnDeleteMedicalAid.Text = "Delete";
        btnDeleteMedicalAid.UseVisualStyleBackColor = true;
        btnDeleteMedicalAid.Click += btnDeleteMedicalAid_Click;
        // 
        // btnUpdateMedicalAid
        // 
        btnUpdateMedicalAid.Location = new Point(94, 337);
        btnUpdateMedicalAid.Name = "btnUpdateMedicalAid";
        btnUpdateMedicalAid.Size = new Size(63, 23);
        btnUpdateMedicalAid.TabIndex = 14;
        btnUpdateMedicalAid.Text = "Update";
        btnUpdateMedicalAid.UseVisualStyleBackColor = true;
        btnUpdateMedicalAid.Click += btnUpdateMedicalAid_Click;
        // 
        // btnAddMedicalAid
        // 
        btnAddMedicalAid.Location = new Point(25, 337);
        btnAddMedicalAid.Name = "btnAddMedicalAid";
        btnAddMedicalAid.Size = new Size(63, 23);
        btnAddMedicalAid.TabIndex = 13;
        btnAddMedicalAid.Text = "Add";
        btnAddMedicalAid.UseVisualStyleBackColor = true;
        btnAddMedicalAid.Click += btnAddMedicalAid_Click;
        // 
        // Client_Management
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(873, 450);
        Controls.Add(btnDeleteMedicalAid);
        Controls.Add(btnUpdateMedicalAid);
        Controls.Add(btnAddMedicalAid);
        Controls.Add(btnDeleteClient);
        Controls.Add(btnUpdateClient);
        Controls.Add(btnAddClient);
        Controls.Add(txtMedicalAidNumber);
        Controls.Add(txtMedicalAidName);
        Controls.Add(lblMedicalAid);
        Controls.Add(txtPhone);
        Controls.Add(txtEmail);
        Controls.Add(txtLastName);
        Controls.Add(label2);
        Controls.Add(txtFirstName);
        Controls.Add(label1);
        Controls.Add(dgvClients);
        Name = "Client_Management";
        Text = "Client_Management";
        ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView dgvClients;
    private Label label1;
    private TextBox txtFirstName;
    private Label label2;
    private TextBox txtLastName;
    private TextBox txtEmail;
    private TextBox txtPhone;
    private Label lblMedicalAid;
    private TextBox txtMedicalAidName;
    private TextBox txtMedicalAidNumber;
    private Button btnAddClient;
    private Button btnUpdateClient;
    private Button btnDeleteClient;
    private Button btnDeleteMedicalAid;
    private Button btnUpdateMedicalAid;
    private Button btnAddMedicalAid;
}