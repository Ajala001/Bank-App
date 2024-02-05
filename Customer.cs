using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
public class Customer
    {
        private string FirstName;
        private string LastName;
        private char Gender;
        private DateTime Dob;

        private string Gmail;
        private string PhoneNumber;
        private double Deposit;

        public string firstName
        {
            set{FirstName = value;}
            get{return FirstName;}
        }

        public string lastName
        {
            set{LastName = value;}
            get{return LastName;}
        }

        public char gender
        {
            set{Gender = value;}
            get{return Gender;}
        }

        public DateTime dob
        {
            set{Dob = value;}
            get{return Dob;}
        }

        public string gmail
        {
            set{Gmail = value;}
            get{return Gmail;}
        }

        public string phoneNumber
        {
            set{PhoneNumber = value;}
            get{return PhoneNumber;}
        }

        public double deposit
        {
            set{Deposit = value;}
            get{return Deposit;}
        }

// ===============================================GENERATE BVN=======================================================================
        public string GenerateBvnNumber()
        {
            Random rand = new Random();
            return $"{rand.Next(00000, 99999)}{rand.Next(000000, 999999)}";
        }

// ================================================GENERATE PASSWORD==================================================================
        public string GeneratePassword()
        {
            Random rand = new Random();
            return $"{(Char)rand.Next('A', 'Z')}{(Char)rand.Next('A', 'Z')}{rand.Next(00, 100)}{(Char)rand.Next(33, 47)}";
        }

// =================================================GENERATE ACCT NUMBER==============================================================
        public string GenerateAccountNumber(string number)
        {
            string acctNum = "";
            if(number.Length > 10)
            {
                acctNum = number.Substring(1, 10);
            }
                return acctNum;
        }

// =================================================BANK COMMISSION====================================================================
        public double BankCommission(double deposit)
        {
            if(deposit > 1000)
            {
                return deposit - ((deposit / 100) * 2);
            } else
                return deposit;
        }

// ===================================================PRINT CUSTOMER DETAILS===========================================================
        public void PrintCustomerDetails(string firstName, string lastName, char gender, string dob, int age, string gmail, string phoneNumber, double deposit, string acctNum, string bvn, string password)
        {
            if(char.ToUpper(gender) == 'M')
            {
                Console.WriteLine();  // PRINT A LINE BEFORE PRINTING THE CUSTOMER DETAILS
                Console.WriteLine($"Dear Mr. {firstName.ToUpper()} {lastName.ToUpper()}, You've successfully registered with us, below are your details:");
                Console.WriteLine($"Full Name: {firstName} {lastName}\nDate Of Birth: {dob}\nGmail: {gmail}\nPhone number: {phoneNumber}\nBalance: {deposit:n}\nAcct Number: {acctNum}\nBVN: {bvn}\nPassword: {password}");
            } else //(char.ToUpper(gender) == 'F')
            {
                Console.WriteLine();
                Console.WriteLine($"Dear Mrs. {firstName.ToUpper()} {lastName.ToUpper()}, You've successfully registered with us, below are your details:");
                Console.WriteLine($"Full Name: {firstName} {lastName}\nDate Of Birth: {dob}\nGmail: {gmail}\nPhone number: {phoneNumber}\nBalance: {deposit:n}\nAcct Number: {acctNum}\nBVN: {bvn}\nPassword: {password}");
            }
                // Console.Write("Provide your gender before banking with us\nHave a Wonderful Day!!!");
        }

// ======================================================GET AGE======================================================================
        public int GetAge(DateTime dob)
        {
            DateTime date = DateTime.Today;
            int year = date.Year;
            int customerAge = year - dob.Year;

            if(customerAge > 17)
            {
                return customerAge;
            } else
                return customerAge;
        }

// =======================================================CUSTOMER DETAILS============================================================

        public void CustomerDetails(char gender, Customer customer1)
        {
                string newDob = "";
                try
                {
                    Console.Write("Enter your Date of birth (MM-dd-yyyy): ");
                    customer1.dob = DateTime.Parse(Console.ReadLine());
                    newDob = customer1.dob.ToString("MM-dd-yyyy");
                } catch
                {
                    Console.Write("The Date Format you inputed is wrong, Hence you can't proceed with the registration!!!\nhave a Nice Day!!!");
                    return;
                }
                    
                // Console.WriteLine(customer1.GetAge(customer1.dob));  This display the age of the customer.
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
                            customer1.PrintCustomerDetails(customer1.firstName, customer1.lastName, gender, newDob, customerAge, customer1.gmail, customer1.phoneNumber, balance, acctNum, bvn, passWord);

                            customer1.Withdraw(passWord, balance, customer1);
                        }
                    }
                }
        }

// ======================================PHONE NUMBER TRIER=============================================================================

        public void PhoneNumberTrier(Customer customer1, string phoneNumber, int customerAge, string newDob)
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
    
// ========================================WITHDRAW====================================================================================

        public void Withdraw(string passWord, double balance, Customer customer1)
        {
                            Console.WriteLine(); // To leave a line after printing the customer details before printing the next line of code.

                            Console.Write("Do you wish to withdraw?\nEnter 1 if YES, and 2 if NO: ");
                            int userAnswer = int.Parse(Console.ReadLine());

                            switch (userAnswer)
                            {
                                case 1:
                                Console.Write("Enter your Password: ");
                                string userPassword = Console.ReadLine();

                                if(userPassword == passWord)
                                {
                                    Console.Write("How much are you withdrawing: ");
                                    double userWithdraw = double.Parse(Console.ReadLine());

                                    if(balance >= userWithdraw)
                                    {
                                        Console.Write($"Withdrawal Successful\nNew Balance: {balance - userWithdraw:N}");
                                    } else
                                        Console.Write($"Insuffficient Account!!!\nAvailable Balance: {balance:N}\nHave a Nice Day!!!");
                                } else
                                {
                                    int i = 1;
                                    while(i <= 3)
                                    {
                                        Console.Write("Wrong Password!!! Enter again!!!: ");
                                        string userPassword2 = Console.ReadLine();

                                        if(userPassword2 == passWord)
                                        {
                                            Console.Write("How much are you withdrawing: ");
                                            double userWithdraw2 = double.Parse(Console.ReadLine());

                                            if(balance > userWithdraw2)
                                            {
                                                Console.Write($"Withdrawal Successful\nNew Balance: {balance - userWithdraw2:N}");
                                            } else
                                                Console.Write($"Insuffficient Amount!!!\nAvailable Balance: {balance:N}\nHave a Nice Day!!!");
                                                break;
                                        } else
                                            i++;
                                            if(i == 4)
                                            {
                                                Console.Write("Wrong Password!!! Try Next Time\nHave a Wonderful Day!!!");
                                                break;
                                            }

                                    }
                                    
                                }
                                break;
                                case 2:
                                Console.Write("Have a Wonderful Day!!!");
                                break;
                            }

        }
    }

                    