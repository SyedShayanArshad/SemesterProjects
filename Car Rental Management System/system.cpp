#include <iostream>
#include<string>
#include<conio.h>
#include<windows.h>
#include<fstream>
#include<iomanip>
using namespace std;
void start();
void customer();
void admin();
void Customer_Menu(const int loginIndex);
void Add_car();
void All_Cars();
void Admin_Menu();
void Available_cars();
void Rent_Car(const int loginIndex);
void generateYourReport(const int loginIndex);
void Return_Car(const int loginIndex);
void Remove_Car();
void AddCustomer();
void create_account();
void Customer_login_option();
void Remove_Customer();
void Update_Customer_Data();
void CustomerReport();
void carReportMenu();
void statusReport();
void maintenanceReport();
void utilizationReport();
void admin_pass_change();
void printReceipt(int car_index, int cus_index, int rHour, int t_price);
string readAdminPass(const string& filename);
void writeAdminPass( string newpass,const string& filename);
int countCarsInFile(const string& filename);
int countCustomerInFile(const string& filename);
int countTransactionDataInFile(const string& filename);
void Search_Customer();
void Search_Car();
void All_Customers();
struct carinfo{
    string car_model;
    int manufacture_year;
    string no_plate;
    string fuel_type;
    string color;
    double price;
    string status;
    int countRent = 0;
    int totalHours = 0;
    int totalIncome = 0;
    int totalMaintain = 0;
};
struct custominfo{
    string username;
    string password;
    string cnic;
    string phoneno;
    string address;
};  
void writeCarToFile(const carinfo* cars, int numCars, const std:: string& filename);
void readCarFromFile(carinfo* cars, int numCars, const std:: string& filename);
void writeCustomerToFile(const custominfo* customers, int numCustomer, const string& filename);
void readCustomerFromFile(custominfo* customers, int numCustomer, const string& filename);
int totalCars;
carinfo *allCars;
int totalCustomers;
custominfo *users;
string admin_id="admin";
int main()
{
    system("color e0");
    totalCars = countCarsInFile("car_data.txt");
    totalCustomers = countCustomerInFile("customer_data.txt");
    allCars= new carinfo[totalCars];
    users= new custominfo[totalCustomers];
    readCarFromFile(allCars, totalCars,"car_data.txt");
    readCustomerFromFile(users, totalCustomers,"customer_data.txt");
    start();
}
void start()
{
    Sleep(300); 
    system("cls");
    cout << "\t\t\t************************************************\n";
    cout << "\t\t\t**** WELCOME TO CAR RENTAL MANAGEMENT SYSTEM ***\n";
    cout << "\t\t\t************************************************\n";
    int choice;
    cout << "1.LOGIN AS ADMIN\n";
    cout << "2.LOGIN AS CUSTOMER\n";
    cout << "0.QUIT\n";
    cout << "Enter Your Choice: ";
    cin >> choice;
    switch (choice)
    {
    case 1:
        admin();
        break;
    case 2:
        Customer_login_option();
        break;
    case 0:
        break;
    default:
        cout << "Invalid Option!!\n";
        start();
        break;
    }
}
void customer()
{
    Sleep(700);
    system("cls");
    string inputname;
    string inputpassword;
    cin.ignore();
    cout<<"\n\n\t\t\t***** CUSTOMER LOGIN PORTAL *****\n\n\n";
    cout << "Enter Username: ";
    getline(cin,inputname);
    cout << "Enter Password: ";
    cin >> inputpassword;
    bool check=false;
    for (int i = 0; i < totalCustomers; i++)
    {
        if (users[i].username==inputname)
        {
            check=true;
            if (users[i].password==inputpassword)
            {
                Customer_Menu(i);
                break;
            }
            else
            {
                cout << "Invalid Password!!\n";
                customer();
            }
        }
    }
    if (check==false)
    {
        cout<<"Invalid UserName! Try Again\n";
        customer();
    }
}
void Customer_Menu(const int loginIndex)
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** WELCOME TO CUSTOMER PORTAL *****\n\n\n";
    int choice;
    cout << "1. To View Available Cars\n";
    cout << "2. To Return Cars\n";
    cout << "3. To Generate your Rental Report\n";
    cout << "4. To Rent a Car\n";
    cout << "0. Logout\n";
    cout << "Enter Your Choice: ";
    cin >> choice;
    switch (choice)
    {
    case 1:
        Sleep(700);
        system("cls");
        Available_cars();
        cout<<"Press Any Key to Go Back.....\n";
        getch();
        Customer_Menu(loginIndex);
        break;
    case 2:
        Return_Car(loginIndex);
        break;
    case 3:
        generateYourReport(loginIndex);
        break;
    case 4:
        Rent_Car(loginIndex);
        break;
    case 0:
        start();
        break;
    default:
        cout << "Invalid Choice!!";
        Customer_Menu(loginIndex);
        break;
    }
}
void writeCarToFile(const carinfo* cars, int numCars, const string& filename)
{
	ofstream outFile(filename);
	if (!outFile)
	{
		cout<<"Unable to open the file for writing.\n";
		return;
	}
	for (int i = 0; i < numCars; i++)
	{
		outFile<<cars[i].car_model<<"\n";
		outFile<<cars[i].manufacture_year<<"\n";
		outFile<<cars[i].no_plate<<"\n";
		outFile<<cars[i].fuel_type<<"\n";
		outFile<<cars[i].color<<"\n";
		outFile<<cars[i].price<<"\n";
		outFile<<cars[i].countRent<<"\n";
		outFile<<cars[i].totalHours<<"\n";
		outFile<<cars[i].totalIncome<<"\n";
		outFile<<cars[i].totalMaintain<<"\n";
		outFile<<cars[i].status<<"\n";
	}
	outFile.close();
}
void readCarFromFile(carinfo* cars, int numCars, const string& filename)
{
	ifstream inFile(filename);
	if (!inFile)
	{
		cout<<"Error: Unable to open file for reading."<<endl;
		return;
	}
	for (int i = 0; i < numCars; i++)
	{
		getline(inFile,cars[i].car_model);
		inFile>>cars[i].manufacture_year;
		inFile.ignore();
		getline(inFile,cars[i].no_plate);
		getline(inFile,cars[i].fuel_type);
		getline(inFile,cars[i].color);
		inFile>>cars[i].price;
        inFile>>cars[i].countRent;
        inFile>>cars[i].totalHours;
        inFile>>cars[i].totalIncome;
        inFile>>cars[i].totalMaintain;
		inFile.ignore();
		getline(inFile,cars[i].status);
	}
	inFile.close();
}
int countCarsInFile(const string& filename)
{
	string a;
	int count=0;
	ifstream inFile(filename);
	if (!inFile)
	{
		cout<<"Error: Unable to open file for reading."<<endl;
		return 0;
	}
	while (!inFile.eof())
	{
		getline(inFile,a);
		count++;
	}
	count=count/11;
	return count;
}
void writeCustomerToFile(const custominfo* customers, int numCustomer, const string& filename)
{
	ofstream outFile(filename);
	if (!outFile)
	{
		cout<<"Unable to open the file for writing.\n";
		return;
	}
	for (int i = 0; i < numCustomer; i++)
	{
		outFile<<customers[i].username<<"\n";
		outFile<<customers[i].password<<"\n";
		outFile<<customers[i].cnic<<"\n";
		outFile<<customers[i].phoneno<<"\n";
		outFile<<customers[i].address<<"\n";
	}
	outFile.close();
}
void readCustomerFromFile(custominfo* customers, int numCustomer, const string& filename)
{
	ifstream inFile(filename);
	if (!inFile)
	{
		cout<<"Error: Unable to open file for reading."<<endl;
		return;
	}
	for (int i = 0; i < numCustomer; i++)
	{
		getline(inFile,customers[i].username);
		inFile>>customers[i].password;
		inFile.ignore();
		getline(inFile,customers[i].cnic);
		getline(inFile,customers[i].phoneno);
		getline(inFile,customers[i].address);
        
	}
	inFile.close();
}
int countCustomerInFile(const string& filename)
{
	string a;
	int count=0;
	ifstream inFile(filename);
	if (!inFile)
	{
		cout<<"Error: Unable to open file for reading."<<endl;
		return 0;
	}
	while (!inFile.eof())
	{
		getline(inFile,a);
		count++;
	}
	count=count/5;
	return count;
}
void Add_car()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** ADD NEW CAR *****\n\n\n";
    carinfo* tempPtr = new carinfo[totalCars+1];
    for (int i = 0; i < totalCars; i++)
    {
        tempPtr[i] = allCars[i];
    }
    cin.ignore();
    cout<<"Enter Data of Car:\n";
	cout<<"Model: ";
	getline(cin,tempPtr[totalCars].car_model);
	cout<<"Manufacture Year: ";
	cin>>tempPtr[totalCars].manufacture_year;
	cin.ignore();	
	cout<<"No Plate: ";
	getline(cin,tempPtr[totalCars].no_plate);
	cout<<"Fuel Type: ";
	getline(cin,tempPtr[totalCars].fuel_type);
	cout<<"Color: ";
	getline(cin,tempPtr[totalCars].color);
	cout<<"Price: ";
	cin>>tempPtr[totalCars].price;
	cin.ignore();
	cout<<"Status: ";
	getline(cin,tempPtr[totalCars].status);
    delete[] allCars;
    allCars = tempPtr;
    totalCars = totalCars + 1;
	writeCarToFile(allCars, totalCars,"car_data.txt");
    cout<<"Your Car has been Added.\n";
    int choice;
    cout<<"Add Another Car?\n";
    do
    {
    cout<<"1. YES\n";
    cout<<"2. Go Back\n";
    cin>>choice;
    switch (choice)
    {
    case 1:
            Add_car();
            break;
        case 2:
            Admin_Menu();
            break;
        default:
            cout<<"Wrong Choice!!\n";
            break;
        }
    } while (choice!=1 && choice !=2);
}
void All_Cars()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** ALL  Cars LIST *****\n\n\n";
    for (int i = 0; i < totalCars; i++)
    {
            cout<<i+1<<".\n";
            cout<<"Model: "<<allCars[i].car_model<<endl;
            cout<<"Manufacture Year: "<<allCars[i].manufacture_year<<endl;
            cout<<"Fuel Type: "<<allCars[i].fuel_type<<endl;
            cout<<"Color: "<<allCars[i].color<<endl;
            cout<<"No Plate: "<<allCars[i].no_plate<<endl;
            cout<<"Price: Rs."<<allCars[i].price<<"/hour"<<endl;
            cout<<"Status: "<<allCars[i].status<<endl;
            cout<<"\t\t\t------------\t\t\t\n";
    }
    cout<<"Press any key to go back!";
    getch();
    Admin_Menu();
}
void Available_cars()
{
    cout<<"Following Cars are Available: \n\n";
    for (int i = 0; i < totalCars; i++)
    {
        if (allCars[i].status=="Available" || allCars[i].status=="available")
        {
            cout<<"Model: "<<allCars[i].car_model<<endl;
            cout<<"Manufacture Year: "<<allCars[i].manufacture_year<<endl;
            cout<<"Fuel Type: "<<allCars[i].fuel_type<<endl;
            cout<<"Color: "<<allCars[i].color<<endl;
            cout<<"No Plate: "<<allCars[i].no_plate<<endl;
            cout<<"Price: Rs."<<allCars[i].price<<"/hour"<<endl;
            cout<<"Status: "<<allCars[i].status<<endl;
            cout<<"\t_____________________\t\n\n";
        }
    }
}
void Rent_Car(const int loginIndex)
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** RENT CAR *****\n\n\n";
    Available_cars();
    int hour,totalprice;
    string plate;
    string date;
    int choice;
    cin.ignore();
    cout<<"Enter No Plate of Car for Rent.";
    getline(cin,plate);
    cout<<"Enter No of Hours for Rent: ";
    cin>>hour;
    cout<<"Enter Date (dd/mm/yyyy): ";
    cin>>date;
    for (int i = 0; i < totalCars; i++)
    {
        if (allCars[i].no_plate==plate)
        {
            totalprice = hour*allCars[i].price;
            cout<<"Your Total Price is "<<totalprice<<endl;
            do
            {
                cout<<"1. Confirm to Rent this Cars\n";
                cout<<"0. Cancel\n";
                cin>>choice;
                if (choice==1)
                {
                    //For report of customer
                    ofstream outFile(users[loginIndex].username+" Report Data.txt", ios:: app);
                    if (!outFile)
	                {   
		                cout<<"Error: Unable to open file for writing."<<endl;
		                return;
	                }
                    outFile<<allCars[i].car_model<<"\n";
                    outFile<<allCars[i].no_plate<<"\n";
                    outFile<<date<<"\n";
                    outFile<<totalprice<<"\n";
                    outFile.close();
                    //
                    allCars[i].totalHours += hour;
                    allCars[i].totalIncome += totalprice;
                    allCars[i].countRent++;
                    //To count maintenance of car
                    int temp = allCars[i].totalHours/15;
                    if (temp !=0)
                    {
                        allCars[i].totalMaintain = temp;
                    }
                    //
                    printReceipt(i, loginIndex, hour, totalprice);
                    // cout<<"Congrats! You have rent this Car.\n";
                    allCars[i].status="Rented";
                    break;
                }

                else if (choice == 0)
                {
                    cout<<"You have cancel to rent this Car.\n";
                    break;
                }
                else
                {
                    cout<<"Wrong Option! Enter Again..\n";
                } 
                
            }while (choice !=1 || choice !=0);   
        }
    }    
    writeCustomerToFile(users,totalCustomers,"customer_data.txt");
    writeCarToFile(allCars,totalCars,"car_data.txt");
    cout<<"Press any key to go back!!!\n";
    getch();
    Customer_Menu(loginIndex);
}
int countTransactionDataInFile(const string& filename)
{
	string a;
	int count=0;
	ifstream inFile(filename);
	if (!inFile)
	{
		cout<<"Error: Unable to open file for reading."<<endl;
		return 0;
	}
	while (!inFile.eof())
	{
		getline(inFile,a);
		count++;
	}
	count=count/4;
	return count;
}
void generateYourReport(const int loginIndex)
{
    Sleep(700);
    system("cls");
    int tData= countTransactionDataInFile(users[loginIndex].username+" Report Data.txt");
    double totalMoneySpent=0;
    double moneySpent;
    string date;
    string carName;
    string noPlate;
    ifstream inFile(users[loginIndex].username+" Report Data.txt");
    if (!inFile)
    {   
	    cout<<"Error: Unable to open file for writing."<<endl;
	    return;
    }
    cout<<"\tName: "<<users[loginIndex].username<<endl;
    cout<<"\tCNIC: "<<users[loginIndex].cnic<<endl;
    cout<<"\tTransaction History Report:\n\n";
    cout<<"   |  Date\t\t| Amount Spent\t|  Car Rented\t|  No Plate\t|\n";
    cout<<"   ----------------------------------------------------------------------\n";
    cin.ignore();
    for (int i = 0; i < tData; i++)
    {
        getline(inFile,carName);  
        getline(inFile,noPlate);  
        inFile>>date;
        inFile>>moneySpent;
        totalMoneySpent += moneySpent;
        inFile.ignore();
        cout<<"   |  "<<date<<"\t| "<<moneySpent<<"\t\t|  "<<carName<<"\t|  "<<noPlate<<"\t|\n";
        cout<<"   ----------------------------------------------------------------------\n";
    }
    cout<<"Total Money Spend: "<<totalMoneySpent<<endl;
    cout<<"Press any key to Back.....\n";
    getch();
    Customer_Menu(loginIndex);
}
void Admin_Menu()
{
    Sleep(700);
    system("cls");
    int choice;
    cout<<"\n\n\t\t\t***** WELCOME TO ADMIN PORTAL *****\n\n\n";
    cout<<"1. Change Your Password\n";
    cout<<"2. Add new Customer\n";
    cout<<"3. Remove a Customer\n";
    cout<<"4. Update Customer Data\n";
    cout<<"5. Add new Car\n";
    cout<<"6. Remove a Car\n";
    cout<<"7. Reports Related to Customers\n";
    cout<<"8. Reports Related to Cars\n";
    cout<<"9. Search a Customer\n";
    cout<<"10. Search a Car\n";
    cout<<"11. View All Customer\n";
    cout<<"12. View All Cars\n";
    cout<<"0. Logout\n";
    cout<<"Enter Your Choice: ";
    cin>>choice;
    switch (choice)
    {
    case 1:
        admin_pass_change();
        break;
    case 2:
        AddCustomer();
        break;
    case 3:
        Remove_Customer();
        break;
    case 4:
        Update_Customer_Data();
        break;
    case 5:
        Add_car();
        break;
    case 6:
        Remove_Car();
        break;
    case 7:
        CustomerReport();
        break;
    case 8:
        carReportMenu();
        break;
    case 9:
        Search_Customer();
    case 10:
        Search_Car();
    case 11:
        All_Customers();
        break;
    case 12:
        All_Cars();
        break;
    case 0:
        start();
        break;
    default:
        break;
    }
}
void admin()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** ADMIN LOGIN PORTAL *****\n\n\n";
    string name;
    string pass;
    cout<<"Enter User Name: ";
    cin>>name;
    cout<<"Enter Password: ";
    cin>>pass;
    if (name==admin_id)
    {
        if (pass==readAdminPass("admin_password.txt"))
        {
            Admin_Menu();
        }
        else
        {
            cout<<"Wrong Password! Enter Again.\n";
            admin();
        }
    }
    else
    {
            cout<<"Wrong User Name! Enter Again.\n";
            admin();
    }
}
void Return_Car(const int loginIndex)
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** Return Car *****\n\n\n";
    string no;
    cin.ignore();
    cout<<"Enter The No Plate of Car: ";
    getline(cin,no);
    for (int i = 0; i < totalCars; i++)
    {
        if (allCars[i].no_plate==no)
        {
            allCars[i].status="Available";
            cout<<"You have Return Car Successfully.\n";
            break;
        }
    }
    writeCarToFile(allCars,totalCars,"car_data.txt");
    cout<<"Press any key to go back!!!\n";
    getch();
    Customer_Menu(loginIndex);
}
void Remove_Car()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** REMOVE A CAR *****\n\n\n";
    string plate;
	int delIndex;
    cin.ignore();
    cout<<"Enter No Plate To Remove The Car: ";
    getline(cin,plate);
    for (int i = 0; i < totalCars; i++)
    {
        if (allCars[i].no_plate==plate)
        {
            delIndex=i;
            break;
        }
    }
    if (totalCars <= 0 || delIndex < 0 || delIndex >= totalCars)
    {
        cout << "Invalid index or empty array.";
        return;
    }
    carinfo* tempPtr = new carinfo[totalCars-1];
    int j=0;
    for (int i = 0; i < totalCars; i++)
    {
        if (i==delIndex)
        {
            cout<<"The car has been Removed.\n";
            continue;
        }
        tempPtr[j]=allCars[i];
        j++;
    }
    delete[] allCars;
    allCars= tempPtr;
    totalCars=totalCars-1;
	writeCarToFile(allCars, totalCars,"car_data.txt");
    cout<<"Press any key to go back!!!\n";
    getch();
    Admin_Menu();
}
void AddCustomer()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** ADD NEW CUSTOMER *****\n\n\n";
    custominfo* tempPtr = new custominfo[totalCustomers+1];
    for (int i = 0; i < totalCustomers; i++)
    {
        tempPtr[i] = users[i];
    }
    cin.ignore();
    cout<<"Enter Data of Customer:\n";
	cout<<"Username: ";
	getline(cin,tempPtr[totalCustomers].username);
	cout<<"Password: ";
	cin>>tempPtr[totalCustomers].password;
	cin.ignore();	
	cout<<"CNIC (xxxxx-xxxxxxx-x): ";
	getline(cin,tempPtr[totalCustomers].cnic);
	cout<<"Phone No: ";
	getline(cin,tempPtr[totalCustomers].phoneno);
	cout<<"Address: ";
	getline(cin,tempPtr[totalCustomers].address);
    delete[] users;
    users = tempPtr;
    totalCustomers = totalCustomers + 1;
	writeCustomerToFile(users, totalCustomers,"customer_data.txt");
    cout<<"The Customer has been Added.\n";
    int choice;
    cout<<"Add Another Customer?\n";
    do
    {
    cout<<"1. YES\n";
    cout<<"2. Go Back\n";
    cin>>choice;
    switch (choice)
    {
    case 1:
            AddCustomer();
            break;
        case 2:
            Admin_Menu();
            break;
        default:
            cout<<"Wrong Choice!!\n";
            break;
        }
        } while (choice!=1 && choice !=2);    
}
void create_account()
{
    Sleep(700);
    system("cls");
    custominfo* tempPtr = new custominfo[totalCustomers+1];
    for (int i = 0; i < totalCustomers; i++)
    {
        tempPtr[i] = users[i];
    }
    cin.ignore();
    cout<<"\n\n\t\t\t***** CREATE YOUR ACCOUNT *****\n\n\n";
    cout<<"Enter Your Details:\n";
	cout<<"Username: ";
	getline(cin,tempPtr[totalCustomers].username);
	cout<<"Password: ";
	cin>>tempPtr[totalCustomers].password;
	cin.ignore();	
	cout<<"CNIC (xxxxx-xxxxxxx-x): ";
	getline(cin,tempPtr[totalCustomers].cnic);
	cout<<"Phone No: ";
	getline(cin,tempPtr[totalCustomers].phoneno);
	cout<<"Address: ";
	getline(cin,tempPtr[totalCustomers].address);
    delete[] users;
    users = tempPtr;
    totalCustomers = totalCustomers + 1;
	writeCustomerToFile(users, totalCustomers,"customer_data.txt");
    cout<<"Your Account has been Created.\n";
    int choice;
    do
    {
    cout<<"1. Go to Customer Login Page\n";
    cout<<"2. Quit\n";
    cin>>choice;
    switch (choice)
    {
    case 1:
        customer();
        break;
    case 2:
        break;
    default:
        cout<<"Wrong Choice!!\n";
        break;
    }
    } while (choice!=1 && choice !=2);    
}
void Customer_login_option()
{
    Sleep(700);
    system("cls");
    int choice;
    cout<<"\n\n\t\t\t***** CUSTOMER LOGIN OPTION *****\n\n\n";
    cout<<"1. Already Have an account?\n";
    cout<<"2. Create Account.\n";
    cout<<"0. Back\n";
    cout<<"Enter Your Choice: ";
    cin>>choice;
    switch (choice)
    {
    case 1:
        customer();
        break;
    case 2:
        create_account();
        break;
    case 0:
        start();
        break;
    default:
        break;
    }
}
void Remove_Customer()
{
    string cnic_no;
    cin.ignore();
    cout<<"Enter CNIC No of Customer you want to Remove. ";
    bool check=false;
    while (check!=true)
    {
        getline(cin,cnic_no);
        for (int i = 0; i < 50; i++)
        {
            if (users[i].cnic==cnic_no)
            {
                users[i].username="empty";
                users[i].password="";
                users[i].cnic="";
                users[i].phoneno="";
                users[i].address="";
                cout<<"This Customer has been Removed.\n";
                check=true;
                break;
            }   
        }
        if(check==false)
        {
            cout<<"Wrong CNIC...Enter Again: ";
        }
    }
    cout<<"Press any key to go back!!!\n";
    getch();
    Admin_Menu();
}
void Update_Customer_Data()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** CHANGE CUSTOMER DATA *****\n\n\n";
    string cnic;
    int num;
    cin.ignore();
    cout<<"Enter CNIC of Customer to Change its Info (xxxxx-xxxxxxx-x): ";
    getline(cin,cnic);
    for (int i = 0; i < totalCustomers; i++)
    {
        if (users[i].cnic==cnic)
        {
            cout<<"1. User Name: "<<users[i].username<<endl;
            cout<<"2. Password: "<<users[i].password<<endl;
            cout<<"3. CNIC: "<<users[i].cnic<<endl;
            cout<<"4. Phone No: "<<users[i].phoneno<<endl;
            cout<<"5. Address: "<<users[i].address<<endl;
            cout<<"Enter No to Change Data: ";
            cin>>num;
            cin.ignore();
            switch (num)
            {
            case 1:
                cout<<"Ener New User Name: ";
                getline(cin,users[i].username);
                cout<<"User Name has been Updated.\n";
                cout<<"Press any key to go back!";
                getch();
                Admin_Menu();
                break;
            case 2:
                cout<<"Ener New Password: ";
                getline(cin,users[i].password);
                cout<<"Password has been Updated.\n";
                cout<<"Press any key to go back!";
                getch();
                Admin_Menu();
                break;
            case 3:
                cout<<"Ener New CNIC: ";
                getline(cin,users[i].cnic);
                cout<<"CNIC has been Updated.\n";
                cout<<"Press any key to go back!";
                getch();
                Admin_Menu();
                break;
            case 4:
                cout<<"Ener New Phone No: ";
                getline(cin,users[i].phoneno);
                cout<<"Password has been Updated.\n";
                cout<<"Press any key to go back!";
                getch();
                Admin_Menu();
                break;
            case 5:
                cout<<"Ener New Address: ";
                getline(cin,users[i].address);
                cout<<"Address has been Updated.\n";
                break;
            default:
                break;
            }
            break;
        }        
    }
    writeCustomerToFile(users,totalCustomers,"customer_data.txt");
    cout<<"Press any key to go back!";
    getch();
    Admin_Menu();
}
void CustomerReport()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** ADD NEW CUSTOMER *****\n\n\n";
    for (int i = 0; i < totalCustomers; i++)
    {
        ifstream inFile(users[i].username+" Report Data.txt");
        if (!inFile)
        {
            cout<<"\t\t\t----------\t\t\t\n";
            cout<<"Customer "<<i+1<<":\n\n";   
            cout<<users[i].username<<" has no Transaction History.\n\n";
        }
        if (inFile)
        {
            cout<<"\t\t\t----------\t\t\t\n";
            cout<<"Customer "<<i+1<<":\n\n";   
            int tData= countTransactionDataInFile(users[i].username+" Report Data.txt");
            double totalMoneySpent=0;
            double moneySpent;
            string date;
            string carName;
            string noPlate;
            ifstream inFile(users[i].username+" Report Data.txt");
            if (!inFile)
            {   
	        cout<<"Error: Unable to open file for writing."<<endl;
	        return;
            }
            cout<<"\tName: "<<users[i].username<<endl;
            cout<<"\tCNIC: "<<users[i].cnic<<endl;
            cout<<"\tTransaction History Report:\n\n";
            cout<<"   |  Date\t\t| Amount Spent\t|  Car Rented\t|  No Plate\t|\n";
            cout<<"   ----------------------------------------------------------------------\n";
            cin.ignore();
            for (int i = 0; i < tData; i++)
            {
                getline(inFile,carName);  
                getline(inFile,noPlate);  
                inFile>>date;
                inFile>>moneySpent;
                totalMoneySpent += moneySpent;
                inFile.ignore();
                cout<<"   |  "<<date<<"\t| "<<moneySpent<<"\t\t|  "<<carName<<"\t|  "<<noPlate<<"\t|\n";
                cout<<"   ----------------------------------------------------------------------\n";
            }
            cout<<"Total Money Spend: "<<totalMoneySpent<<endl;            
        }
    }    
    cout<<"Press any key to Back.....\n";
    getch();
    Admin_Menu();
}
void statusReport()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** INVENTORY STATUS REPORT *****\n\n\n";
    cout<<"   |  Name\t\t| NO Plate\t|  Status\t|  Time Rented  |  Timed Maintenance\t|\n";
    cout<<"   ----------------------------------------------------------------------------------------------\n";
    for (int i = 0; i < totalCars; i++)
    {
        cout<<"   |  "<<allCars[i].car_model<<"\t| "<<allCars[i].no_plate<<"\t|  "<<allCars[i].status<<"\t|\t"<<allCars[i].countRent<<"\t  |\t     "<<allCars[i].totalMaintain<<"\t        |\n";
        cout<<"   ----------------------------------------------------------------------------------------------\n";
    }
    cout<<"Press any key to Go Back....\n";
    getch();
    carReportMenu();
}
void maintenanceReport()
{
    Sleep(700);
    system("cls");
    int index;
    int hours=0;
    bool check = false;
    cout<<"\n\n\t\t\t***** MAINTENANCE REPORT *****\n\n\n";
    for (int i = 0; i < totalCars; i++)
    {
        if (allCars[i].totalHours%15<5 && allCars[i].totalHours >15)
        {
            hours = allCars[i].totalHours;
            index = i;
            cout<<"Following Car was sent recently for Maintenance:\n\n";
            cout<<"\tModel: "<<allCars[index].car_model<<endl;
            cout<<"\tNo Plate: "<<allCars[index].no_plate<<endl;
            cout<<"\tFuel Type: "<<allCars[index].fuel_type<<endl;
            cout<<"\tManufacture Year: "<<allCars[index].manufacture_year<<endl;
            cout<<"\tNo of Times Maintain: "<<allCars[index].totalMaintain<<endl;
            check = true;
        }
    }
    if (check = false)
    {
        cout<<"Sorry! No Car was recently for maintenance.\n";
    }
    cout<<"Press any Key to Back.....\n";
    getch();
    carReportMenu();
}
void utilizationReport()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** VEHICLE UTILIZATION REPORT *****\n\n\n";
    cout<<"   |  Name\t\t| NO Plate\t|  Time Rented\t|  Total Rent Hours  |  Total Income\t|\n";
    cout<<"   ----------------------------------------------------------------------------------------------\n";
    for (int i = 0; i < totalCars; i++)
    {
        cout<<"   |  "<<allCars[i].car_model<<"\t| "<<allCars[i].no_plate<<"\t|  \t"<<allCars[i].countRent<<"\t|\t  "<<allCars[i].totalHours<<"\t    |\t     "<<allCars[i].totalIncome<<"\t        |\n";
        cout<<"   ----------------------------------------------------------------------------------------------\n";
    }
    cout<<"Press any key to go Back.....\n";
    getch();
    carReportMenu();
}
void carReportMenu()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** ADD NEW CUSTOMER *****\n\n\n";
    int choice;
    cout<<"1. Inventory Status Report\n";
    cout<<"2. Maintenance Report\n";
    cout<<"3. Vehicle Utilization Report\n";
    cout<<"0. Go Back\n";
    cout<<"Enter Your Choice: ";
    cin>>choice;
    switch (choice)
    {
    case 1:
        statusReport();
        break;
    case 2:
        maintenanceReport();
        break;
    case 3:
        utilizationReport();
        break;
    case 0:
        Admin_Menu();
        break;
        default:
        break;
    }

}
void admin_pass_change()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** CHANGE YOUR PASSWORD *****\n\n\n";
    string old_pass;
    string new_pass;
    cout<<"Enter Old Password: ";
    cin>>old_pass;
    cout<<"Enter New Password: ";
    cin>>new_pass;
    if(old_pass==readAdminPass("admin_password.txt"))
    {
        writeAdminPass( new_pass,"admin_password.txt");
        cout<<"Your Password has been changed successfully.\n";
        cout<<"Press any key to go back!";
        getch();
        Admin_Menu();
    }
    else
    {
        cout<<"Old Password is wrong!!\n";
        admin_pass_change();
    }
}
string readAdminPass(const string& filename)
{
    string check;
    ifstream inFile(filename);
    if (!inFile)
    {
        cout<<"Admin Password File is not open.\n";
        return "";
    }
    getline(inFile,check);
    return check;
}
void writeAdminPass( string newpass,const string& filename)
{
    ofstream outFile(filename);
    if (!outFile)
    {
        cout<<"Admin Password File is not open.\n";
        return;
    }
    outFile<< newpass;
    return;
}
void printReceipt(int car_index, int cus_index, int rHour, int t_price)
{
    Sleep(700);
    system("cls");
    cout << "  -------------------------------------------" << endl;
    cout << "              CAR RENTAL RECEIPT             " << endl;
    cout << "  -------------------------------------------" << endl;
    cout << "Car Information:" << endl;
    cout << setw(20) << left << "  Model: " << allCars[car_index].car_model << endl;
    cout << setw(20) << left << "  Year: " << allCars[car_index].manufacture_year << endl;
    cout << setw(20) << left << "  Plate Number: " << allCars[car_index].no_plate << endl;
    cout << setw(20) << left << "  Fuel Type: " << allCars[car_index].fuel_type << endl;
    cout << setw(20) << left << "  Color: " << allCars[car_index].color << endl;
    cout << setw(20) << left << "  Base Rate: " << allCars[car_index].price << " pprice" << endl;
    cout << "\nCustomer Information:" << endl;
    cout << setw(20) << left << "  Name: " << users[cus_index].username << endl;
    cout << setw(20) << left << "  CNIC: " << users[cus_index].cnic << endl;
    cout << setw(20) << left << "  Phone Number: " << users[cus_index].phoneno << endl;
    cout << setw(20) << left << "  Address: " << users[cus_index].address << endl;
    cout << "\nRental Summary:" << endl;
    cout << setw(20) << left << "  Rented Hours: " << rHour << "   hours" << endl;
    cout << setw(20) << left << "  Total Cost: " << t_price << endl;
    cout << "\n  Thank you for choosing our car rental service!" << endl;
    cout << "  -------------------------------------------" << endl;
}
void Search_Customer()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** SEARCH A CUSTOMER *****\n\n\n";
    string cnic;
    int num;
    bool check = false;
    cin.ignore();
    cout<<"Enter CNIC of Customer to Search (xxxxx-xxxxxxx-x): ";
    getline(cin,cnic);
    for (int i = 0; i < totalCustomers; i++)
    {
        if (users[i].cnic==cnic)
        {
            cout<<" User Name: "<<users[i].username<<endl;
            cout<<" Password: "<<users[i].password<<endl;
            cout<<" CNIC: "<<users[i].cnic<<endl;
            cout<<" Phone No: "<<users[i].phoneno<<endl;
            cout<<" Address: "<<users[i].address<<endl;
            check = true;
            break;
        }
    }
    if (check == false)
    {
        cout<<"Sorry, Customer not found.\n";
    }
        cout<<"Press any key to go back!";
    getch();
    Admin_Menu();
}
void Search_Car()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** SEARCH A CAR *****\n\n\n";
    string noplate;
    int num;
    bool check = false;
    cin.ignore();
    cout<<"Enter No Plate to Search (ABC XXXX): ";
    getline(cin,noplate);
    for (int i = 0; i < totalCars; i++)
    {
        if (allCars[i].no_plate==noplate)
        {
            cout<<"Model: "<<allCars[i].car_model<<endl;
            cout<<"Manufacture Year: "<<allCars[i].manufacture_year<<endl;
            cout<<"Fuel Type: "<<allCars[i].fuel_type<<endl;
            cout<<"Color: "<<allCars[i].color<<endl;
            cout<<"No Plate: "<<allCars[i].no_plate<<endl;
            cout<<"Price: Rs."<<allCars[i].price<<"/hour"<<endl;
            cout<<"Status: "<<allCars[i].status<<endl;
            check = true;
            break;
        }
    }
    if (check == false)
    {
        cout<<"Sorry, Car not found.\n";
    }
        cout<<"Press any key to go back!";
    getch();
    Admin_Menu();
}
void All_Customers()
{
    Sleep(700);
    system("cls");
    cout<<"\n\n\t\t\t***** ALL CUSTOMERS LIST *****\n\n\n";
    for (int i = 0; i < totalCustomers; i++)
    {
            cout<<i+1<<".\n";
            cout<<" User Name: "<<users[i].username<<endl;
            cout<<" Password: "<<users[i].password<<endl;
            cout<<" CNIC: "<<users[i].cnic<<endl;
            cout<<" Phone No: "<<users[i].phoneno<<endl;
            cout<<" Address: "<<users[i].address<<endl;
            cout<<"\t\t\t------------\t\t\t\n";
    }
    cout<<"Press any key to go back!";
    getch();
    Admin_Menu();
}  