using System;

namespace AddressBookUsingAdo.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            AddressBookModel addressBookModel = new AddressBookModel();
            addressBookModel.FirstName = "Akash";
            addressBookModel.LastName = "hudge";
            addressBookModel.Address = "Tawarja";
            addressBookModel.City = "latur";
            addressBookModel.State = "Maharashtra";
            addressBookModel.Zip = 413512;
            addressBookModel.PhoneNumber = 8149713160;
            addressBookModel.Email = "dhiraj@gmail.com";
            addressBookModel.AddressBookName = "friend address book";
            addressBookModel.AddressBookType = "Friend";
            addressBookRepo.checkConnection();
            //addressBookRepo.addNewContactToDataBase(addressBookModel);
            //addressBookRepo.UpdateExiContactToDataBase(addressBookModel, "dhiraj");
            //addressBookRepo.deleteExiContactInDataBase("Akash");
            addressBookRepo.personBelongingCityOrState();
        }
    }
}
