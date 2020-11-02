using System;
using System.Collections.Generic;
using System.Windows.Input;
using EIS.ViewModel.Helpers;

namespace EIS.ViewModel.Screen
{
    public interface IAddEmployeeViewModel
    {
        string Name { get; set; }
        string Email { get; set; }
        Sex Gender { get; set; }
        Status Status { get; set; }
        ICommand SaveCommand { get;}
        IEnumerable<KeyValuePair> GenderEnumVal { get; }
        IEnumerable<KeyValuePair> StatusEnumVal { get; }
        bool HasError { get; }
        event EventHandler OnClose;
        void Close();


    }
    public enum Sex
    {
        Male,
        Female
    }

    public enum Status
    {
        Active,
        Inactive
    }
}