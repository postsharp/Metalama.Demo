﻿namespace MauiDemoApp.Model;

public class CustomerModel : ModelBase
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Mobile { get; set; }
    public string? Email { get; set; }

    public AddressModel? Address { get; set; }
}