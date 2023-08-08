using UnityEngine;


public class AddressPersonalInfo
{
    public string id {get;set;}
    public string line1 {get;set;}
    public string line2 {get;set;}
    public string city {get;set;}
    public string postalCode {get;set;}
    public string state {get;set;}
    public string country {get;set;}
    public string updated {get;set;}
    public string created {get;set;}
}

public class Address 
{
    public string line1 {get;set;}
    public string line2 {get;set;}
    public string city {get;set;}
    public string postalCode {get;set;}
    public string state {get;set;}
    public string country {get;set;}
}

public class PersonalInfo
{
    public string id {get;set;}
    public string email {get;set;}
    public string firstName {get;set;}
    public string lastName {get;set;}
    public string phoneNumber {get;set;}
    public AddressPersonalInfo addressPersonalInfo {get;set;}
    public string discord {get;set;}
    public string twitter {get;set;}
    public string telegram {get;set;}
  
}

public class CustomerObject
{
    public string solanaPubKey {get;set;}
    public PersonalInfo personalInfo {get;set;}
    public Address address {get;set;}
}
