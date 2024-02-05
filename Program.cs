using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BANK_APP
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer(); 
            
            Console.Write("Enter your firstName: ");
            customer1.firstName = Console.ReadLine();

            Console.Write("Enter your lastName: ");
            customer1.lastName = Console.ReadLine();

            Console.Write("Your Gender: (M for male and F for female): ");
            customer1.gender = char.Parse(Console.ReadLine());

            if(Char.ToUpper(customer1.gender) == 'M' || Char.ToUpper(customer1.gender) == 'F')
            {
                string newDob = "";
                try
                {
                    Console.Write("Enter your Date of birth (MM-dd-yyyy): ");
                    customer1.dob = DateTime.Parse(Console.ReadLine());
                    newDob = customer1.dob.ToString("MM-dd-yyyy");
                } catch
                {
                    Console.Write("The Date Format you inputed is wrong, Hence you can't proceed with the registration!!!\nHave a Nice Day!!!");
                    return;
                }
                
                int customerAge = customer1.GetAge(customer1.dob);
                if(customerAge < 18)
                {
                    Console.WriteLine("You Must be 18 or above before banking with us\nHave a Wonderful Day!!!");
                } else
                {
                    Console.Write("Enter your gmail: ");
                    customer1.gmail = Console.ReadLine();

                    Console.Write("Enter your phone number: ");
                    customer1.phoneNumber = Console.ReadLine();
                    if(customer1.phoneNumber.Length != 11)
                    {
                        int i = 1;
                        while(i <= 3)
                        {
                            Console.Write("Wrong number!!! Input again: ");
                            customer1.phoneNumber = Console.ReadLine();

                            if(customer1.phoneNumber.Length != 11)
                            {
                                i++;
                                if(i == 4)
                                {
                                    Console.WriteLine("Your phone number is not correct, You wont be able to proceed with the registration!!!");
                                    break;
                                }
                            } else
                            {
                                customer1.PhoneNumberTrier(customer1, customer1.phoneNumber, customerAge, newDob);
                                break;
                            }
                        
                        }
                    } else
                    {
                        Console.Write("How much are you depositing: ");
                        customer1.deposit=double.Parse(Console.ReadLine());
                        if(customer1.deposit < 1000)
                        {
                            Console.Write("You Must have up to 1000 before banking with us\nHave a Wonderful Day!!!"); 
                        } else
                        {
                            string passWord = customer1.GeneratePassword();
                            string acctNum = customer1.GenerateAccountNumber(customer1.phoneNumber);
                            double balance = customer1.BankCommission(customer1.deposit);
                            string bvn = customer1.GenerateBvnNumber();
                            customer1.PrintCustomerDetails(customer1.firstName, customer1.lastName, char.ToUpper(customer1.gender), newDob, customerAge, customer1.gmail, customer1.phoneNumber, balance, acctNum, bvn, passWord);
                            customer1.Withdraw(passWord, balance, customer1);
                        }
                    }
                }
            } else
            {
               Console.WriteLine("Follow instructions!!! You have 3 more chances!!!");
                int i = 1;
                while(i <= 3)
                {
                    Console.Write("Your Gender: (M for male and F for female): ");
                    customer1.gender = char.Parse(Console.ReadLine());
            
                    if(char.ToUpper(customer1.gender) == 'M' || char.ToUpper(customer1.gender) == 'F')
                    {
                        customer1.CustomerDetails(char.ToUpper(customer1.gender), customer1);
                        break;
                    }
                        i++;
                        if(i == 4)
                        {
                            Console.WriteLine("Your gender specification is not available, You wont be able to proceed with the registration!!!");
                            break;
                        }
                } 
            }

            
        }
    }
}
