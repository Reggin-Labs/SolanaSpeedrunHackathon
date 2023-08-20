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

public class OnChain
{
    public string status { get; set; }
    public string mintHash { get; set; }
    public string txId { get; set; }
    public string owner { get; set; }
    public string chain { get; set; }

}

public class Creator
{
    public string address { get; set; }
    public bool verified { get; set; }
    public int share { get; set; }
}

public class File
{
    public string uri { get; set; }
    public string type { get; set; }
}

public class Creators
{
    public Creator[] creator { get; set; }
}

public class Files
{
    public File[] file { get; set; }
    public string category { get; set; }
}

public class Properties
{
    public Files files { get; set; }
    public Creators creators { get; set; }
}

public class Metadata
{
    public string name { get; set; }
    public string symbol { get; set; }
    public string seller_fee_basis_points { get; set; }
    public string description { get; set; }
    public string image { get; set; }
    public string[] attributes { get; set; }
    public Properties properties;
}

public class NFTData
{
    public string id { get; set; }
    public Metadata metadata { get; set; }
    public OnChain onChain { get; set; }
}
