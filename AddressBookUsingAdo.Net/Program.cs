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
            addressBookRepo.addNewContactToDataBase(addressBookModel);
            addressBookRepo.UpdateExiContactToDataBase(addressBookModel, "dhiraj");
            addressBookRepo.deleteExiContactInDataBase("Akash");
            addressBookRepo.personBelongingCityOrState();
            addressBookRepo.CountByCityAndState();
            addressBookRepo.sortedAlphabeticallyByFirstName();
            addressBookRepo.identifyAddressBookWithNameAndType("dhiraj", "Friend", "friends address book");
            addressBookRepo.getNumberOfPersonCountByType();

            AddressBookModel addressBookModel1 = new AddressBookModel();
            addressBookModel1.FirstName = "Dhiraj";
            addressBookModel1.LastName = "hudge";
            addressBookModel1.Address = "Tawarja";
            addressBookModel1.City = "latur";
            addressBookModel1.State = "Maharashtra";
            addressBookModel1.Zip = 413512;
            addressBookModel1.PhoneNumber = 8149713160;
            addressBookModel1.Email = "dhiraj@gmail.com";
            addressBookModel1.AddressBookName = "friend address book";
            addressBookModel1.AddressBookType = "Friend";

            addressBookModel1.FirstName = "Dhiraj";
            addressBookModel1.LastName = "hudge";
            addressBookModel1.Address = "Tawarja";
            addressBookModel1.City = "latur";
            addressBookModel1.State = "Maharashtra";
            addressBookModel1.Zip = 413512;
            addressBookModel1.PhoneNumber = 8149713160;
            addressBookModel1.Email = "dhiraj@gmail.com";
            addressBookModel1.AddressBookName = "family address book";
            addressBookModel1.AddressBookType = "Family";
            addressBookRepo.addPersonToBothFriendAndFamily(addressBookModel1);
        }
    }
}
