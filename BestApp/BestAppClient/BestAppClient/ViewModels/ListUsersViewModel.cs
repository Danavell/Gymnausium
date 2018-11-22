﻿using BestAppClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BestAppClient.ViewModels
{
    public class ListUsersViewModel
    {
        public ObservableCollection<User> UserCollection { get; set; } = new ObservableCollection<User>();

        public ListUsersViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                User user = new InternalInfoUser();
                user.First_Name = "Pickle Rick " + i.ToString();
                user.Age = i;
                user.Description = "Icon.png";
                UserCollection.Add(user);
            }
        }
    }
}
