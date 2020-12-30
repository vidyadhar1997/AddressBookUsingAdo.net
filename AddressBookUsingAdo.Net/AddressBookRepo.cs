using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookUsingAdo.Net
{
    public class AddressBookRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=address_book_services;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public SqlCommand SqlCommand { get; private set; }

        /// <summary>
        /// Checks the connection.
        /// </summary>
        public void checkConnection()
        {
            try
            {
                this.connection.Open();
                Console.WriteLine("connection established");
                this.connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        /// <summary>
        /// Adds the new contact to data base.
        /// </summary>
        /// <param name="addressBookModel">The address book model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool addNewContactToDataBase(AddressBookModel addressBookModel)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("SpAddAddressBookDetails", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", addressBookModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", addressBookModel.LastName);
                    cmd.Parameters.AddWithValue("@Address", addressBookModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressBookModel.City);
                    cmd.Parameters.AddWithValue("@State", addressBookModel.State);
                    cmd.Parameters.AddWithValue("@Zip", addressBookModel.Zip);
                    cmd.Parameters.AddWithValue("@PhoneNumber", addressBookModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", addressBookModel.Email);
                    cmd.Parameters.AddWithValue("@AddressBookName", addressBookModel.AddressBookName);
                    cmd.Parameters.AddWithValue("@AddressBookType", addressBookModel.AddressBookType);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Updates the exi contact to data base.
        /// </summary>
        /// <param name="addressBookModel">The address book model.</param>
        /// <param name="firstName">The first name.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateExiContactToDataBase(AddressBookModel addressBookModel, string firstName)
        {
            try
            {
                using (this.connection)
                {
                    string query = @"update Address_Book set last_name=@LastName,address=@Address,city=@City,
                    state=@State,zip=@Zip,phone_number=@PhoneNumber,email=@Email,address_book_name=@AddressBookName,
                    address_book_type=@AddressBookType  where first_name=@firstName";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", addressBookModel.LastName);
                    cmd.Parameters.AddWithValue("@Address", addressBookModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressBookModel.City);
                    cmd.Parameters.AddWithValue("@State", addressBookModel.State);
                    cmd.Parameters.AddWithValue("@Zip", addressBookModel.Zip);
                    cmd.Parameters.AddWithValue("@PhoneNumber", addressBookModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", addressBookModel.Email);
                    cmd.Parameters.AddWithValue("@AddressBookName", addressBookModel.AddressBookName);
                    cmd.Parameters.AddWithValue("@AddressBookType", addressBookModel.AddressBookType);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Deletes the exi contact in data base.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool deleteExiContactInDataBase(string firstName)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("SpAddAddressBookDetailsForDelete", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Persons the state of the belonging city or.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void personBelongingCityOrState()
        {
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"select * from Address_Book where city='amravati' Or state='andhra';";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            addressBookModel.FirstName = sqlDataReader.GetString(0); ;
                            addressBookModel.LastName = sqlDataReader.GetString(1);
                            addressBookModel.Address = sqlDataReader.GetString(2);
                            addressBookModel.City = sqlDataReader.GetString(3);
                            addressBookModel.State = sqlDataReader.GetString(4);
                            addressBookModel.Zip = sqlDataReader.GetInt64(5);
                            addressBookModel.PhoneNumber = sqlDataReader.GetInt64(6);
                            addressBookModel.Email = sqlDataReader.GetString(7);
                            addressBookModel.AddressBookName = sqlDataReader.GetString(8);
                            addressBookModel.AddressBookType = sqlDataReader.GetString(9);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", addressBookModel.FirstName, addressBookModel.LastName, addressBookModel.Address, addressBookModel.City, addressBookModel.State, addressBookModel.Zip, addressBookModel.PhoneNumber, addressBookModel.Email, addressBookModel.AddressBookName, addressBookModel.AddressBookType);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Count By City AndState
        /// </summary>
        public void CountByCityAndState()
        {
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    using (SqlCommand command = new SqlCommand(
                        @"select city,COUNT(city)from Address_Book group by city;
                        select state, COUNT(state)from Address_Book group by state; ", connection))
                    {
                        this.connection.Open();
                        using (SqlDataReader sqlDataReader = command.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                addressBookModel.City = sqlDataReader.GetString(0);
                                int countCIty = sqlDataReader.GetInt32(1);
                                Console.WriteLine("{0},{1}", addressBookModel.City, countCIty);
                                Console.WriteLine("\n");
                            }
                            if (sqlDataReader.NextResult())
                            {
                                while (sqlDataReader.Read())
                                {
                                    addressBookModel.State = sqlDataReader.GetString(0);
                                    int stateCount = sqlDataReader.GetInt32(1);
                                    Console.WriteLine("{0},{1}", addressBookModel.State, stateCount);
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// sorted Alphabetically By First Name
        /// </summary>
        public void sortedAlphabeticallyByFirstName()
        {
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"select * from Address_Book where city='latur' order by first_name;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            addressBookModel.FirstName = sqlDataReader.GetString(0); ;
                            addressBookModel.LastName = sqlDataReader.GetString(1);
                            addressBookModel.Address = sqlDataReader.GetString(2);
                            addressBookModel.City = sqlDataReader.GetString(3);
                            addressBookModel.State = sqlDataReader.GetString(4);
                            addressBookModel.Zip = sqlDataReader.GetInt64(5);
                            addressBookModel.PhoneNumber = sqlDataReader.GetInt64(6);
                            addressBookModel.Email = sqlDataReader.GetString(7);
                            addressBookModel.AddressBookName = sqlDataReader.GetString(8);
                            addressBookModel.AddressBookType = sqlDataReader.GetString(9);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", addressBookModel.FirstName, addressBookModel.LastName, addressBookModel.Address, addressBookModel.City, addressBookModel.State, addressBookModel.Zip, addressBookModel.PhoneNumber, addressBookModel.Email, addressBookModel.AddressBookName, addressBookModel.AddressBookType);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Identify AddressBook With Name And Type
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="addressType"></param>
        /// <param name="adressName"></param>
        /// <returns></returns>
        public bool identifyAddressBookWithNameAndType(string firstName,string addressType,string adressName)
        {
            try
            {
                using (this.connection)
                {
                    string query = @"update Address_Book set address_book_name=@AddressBookName , address_book_type=@AddressBookType where first_name=@FirstName;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@AddressBookType", addressType);
                    cmd.Parameters.AddWithValue("@AddressBookName", adressName);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Get Number Of Person Count By Type
        /// </summary>
        public void getNumberOfPersonCountByType()
        {
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    using (SqlCommand command = new SqlCommand(
                        @"select count(address_book_type) as 'number_of_contacts' from Address_Book where address_book_type='Friends';
                        select count(address_book_type) as 'number_of_contacts' from Address_Book where address_book_type='Family';", connection))
                    {
                        this.connection.Open();
                        using (SqlDataReader sqlDataReader = command.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            { 
                                var count = sqlDataReader.GetInt32(0);
                                Console.WriteLine("Number of person belonging to adress book type friend = {0}",count);
                                Console.WriteLine("\n");
                            }
                            if (sqlDataReader.NextResult())
                            {
                                while (sqlDataReader.Read())
                                {
                                    var count = sqlDataReader.GetInt32(0);
                                    Console.WriteLine("Number of person belonging to adress book type family= {0}", count);
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}


