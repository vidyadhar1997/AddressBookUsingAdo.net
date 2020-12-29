using System;

namespace AddressBookUsingAdo.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            addressBookRepo.checkConnection();
        }
    }
}
