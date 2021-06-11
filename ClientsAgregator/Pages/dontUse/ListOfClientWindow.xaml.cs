using ClientsAgregator_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for ListOfClientWindow.xaml
    /// </summary>
    public partial class ListOfClientWindow : Window
    {
        public List<ClientDTO> clients;
        public ListOfClientWindow()
        {
            InitializeComponent();

            clients = new List<ClientDTO>
            {
                new ClientDTO
                {
                    Id = 1,
                    FirstName = "Sergei",
                    LastName = "kotov",
                    MiddleName = "Sergeivich",
                    Phone = "38094",
                    Email = "email.com",
                    BulkStatusTitle = "1",
                    Male = "Мужик",
                    СommentAboutСlient = "Бла бла бла"
                },
                new ClientDTO
                {
                    Id = 2,
                    FirstName = "Sergei1",
                    LastName = "kotov1",
                    MiddleName = "Sergeivich1",
                    Phone = "380941",
                    Email = "email.com1",
                    BulkStatusTitle = "1",
                    Male = "Мужик1",
                    СommentAboutСlient = "Бла бла бла1"
                },
            };

            for (int i = 0; i < clients.Count; i++)
            {
                clientsGrid.Items.Add(clients[i]);
            }
        }

      

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = clientsGrid.SelectedIndex;
            clientsGrid.Items.RemoveAt(index);
        }
    }
}

