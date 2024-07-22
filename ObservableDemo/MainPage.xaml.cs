using ObservableDemo.Model;

namespace ObservableDemo;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        var customer = new CustomerModel
        {
            FirstName = "Mickey",
            LastName = "Mouse",
            Address = new AddressModel
            {
                Line1 = "c/o Walt Disney Company", Line2 = "500 South Buena Vista Street", City = "Burbank"
            }
        };

        this.BindingContext = new CustomerViewModel { Customer = customer };
    }

  
}