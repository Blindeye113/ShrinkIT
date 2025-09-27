using ShrinkIT.Data;
using ShrinkIT.Domain;
using ShrinkIT.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrinkIT;

public partial class Client_Management : Form
{
    private readonly IClientRepository _clientRepository;
    private readonly IMedicalAidRepository _medicalAidRepository;
    private Client _selectedClient;

    public Client_Management()
    {
        InitializeComponent();
        string connectionString = "Data Source=InvoiceApp.db;Version=3;";
        _clientRepository = new ClientRepository();
        _medicalAidRepository = new MedicalAidRepository();

        LoadClients();
    }

    private void LoadClients()
    {
        var clients = _clientRepository.GetAllClients();
        if (clients == null || clients.Count <= 0)
        {
            dgvClients.DataSource = new List<Client>(){new Client() { ClientID = 1, FirstName = "Test1", LastName = "Test1", Email = "Test1@test.com", Phone = "0123456789" },
                                                        new Client() { ClientID = 2, FirstName = "Test2", LastName = "Test2", Email = "Test2@test.com", Phone = "0123456879" }};
            return;
        }
        dgvClients.DataSource = clients;
    }

    private void ClearForm()
    {
        txtFirstName.Clear();
        txtLastName.Clear();
        txtEmail.Clear();
        txtPhone.Clear();
        txtMedicalAidName.Clear();
        txtMedicalAidNumber.Clear();
        _selectedClient = null;
    }

    private void btnAddClient_Click(object sender, EventArgs e)
    {
        var client = new Client
        {
            FirstName = txtFirstName.Text,
            LastName = txtLastName.Text,
            Email = txtEmail.Text,
            Phone = txtPhone.Text
        };

        _clientRepository.AddClient(client);
        LoadClients();
        ClearForm();
    }

    private void btnUpdateClient_Click(object sender, EventArgs e)
    {
        if (_selectedClient == null)
        {
            MessageBox.Show("Please select a client to update.");
            return;
        }

        _selectedClient.FirstName = txtFirstName.Text;
        _selectedClient.LastName = txtLastName.Text;
        _selectedClient.Email = txtEmail.Text;
        _selectedClient.Phone = txtPhone.Text;

        _clientRepository.UpdateClient(_selectedClient);
        LoadClients();
        ClearForm();
    }

    private void btnDeleteClient_Click(object sender, EventArgs e)
    {
        if (_selectedClient == null)
        {
            MessageBox.Show("Please select a client to delete.");
            return;
        }

        _clientRepository.DeleteClient(_selectedClient.ClientID);
        LoadClients();
        ClearForm();
    }

    private void btnAddMedicalAid_Click(object sender, EventArgs e)
    {
        if (_selectedClient == null)
        {
            MessageBox.Show("Please select a client to add medical aid.");
            return;
        }

        var medicalAid = new MedicalAid
        {
            ClientID = _selectedClient.ClientID,
            MedicalAidName = txtMedicalAidName.Text,
            MedicalAidNumber = txtMedicalAidNumber.Text
        };

        _medicalAidRepository.AddMedicalAid(medicalAid);
        LoadClients();
    }

    private void btnUpdateMedicalAid_Click(object sender, EventArgs e)
    {
        if (_selectedClient == null)
        {
            MessageBox.Show("Please select a client to update medical aid.");
            return;
        }

        var medicalAid = _medicalAidRepository.GetMedicalAidByClientId(_selectedClient.ClientID);
        if (medicalAid == null)
        {
            MessageBox.Show("No medical aid found for the selected client.");
            return;
        }

        medicalAid.MedicalAidName = txtMedicalAidName.Text;
        medicalAid.MedicalAidNumber = txtMedicalAidNumber.Text;

        _medicalAidRepository.UpdateMedicalAid(medicalAid);
        LoadClients();
    }

    private void btnDeleteMedicalAid_Click(object sender, EventArgs e)
    {
        if (_selectedClient == null)
        {
            MessageBox.Show("Please select a client to delete medical aid.");
            return;
        }

        var medicalAid = _medicalAidRepository.GetMedicalAidByClientId(_selectedClient.ClientID);
        if (medicalAid == null)
        {
            MessageBox.Show("No medical aid found for the selected client.");
            return;
        }

        _medicalAidRepository.DeleteMedicalAid(medicalAid.MedicalAidID);
        LoadClients();
        ClearForm();
    }

    private void dgvClients_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvClients.SelectedRows.Count > 0)
        {
            var selectedRow = dgvClients.SelectedRows[0];
            _selectedClient = (Client)selectedRow.DataBoundItem;

            txtFirstName.Text = _selectedClient.FirstName;
            txtLastName.Text = _selectedClient.LastName;
            txtEmail.Text = _selectedClient.Email;
            txtPhone.Text = _selectedClient.Phone;

            // Load medical aid for the selected client
            var medicalAid = _medicalAidRepository.GetMedicalAidByClientId(_selectedClient.ClientID);
            if (medicalAid != null)
            {
                txtMedicalAidName.Text = medicalAid.MedicalAidName;
                txtMedicalAidNumber.Text = medicalAid.MedicalAidNumber;
            }
            else
            {
                txtMedicalAidName.Clear();
                txtMedicalAidNumber.Clear();
            }
        }
    }
}
