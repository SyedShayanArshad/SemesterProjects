#include <iostream>
#include <fstream>
#include <string>
#include <conio.h>
#include "file.h";
using namespace std;
class customer;
void CustomerMainMenu();
void mainMenu();
void ManagerLoginMenu();
class Feedback
{
private:
    int feedbackID = 0;
    int customerID;
    int tourID;
    double rating;
    string comments;
    string feedbackDate;

public:
    Feedback()
    {
        feedbackID++;
    }
    int getFeedbackID()
    {
        return feedbackID;
    }
    int getCustomerID()
    {
        return customerID;
    }
    int getTourID()
    {
        return tourID;
    }
    double getRating()
    {
        return rating;
    }
    string getFeedback()
    {
        return comments;
    }
    string getFeedbackDate()
    {
        return feedbackDate;
    }
    void setFeedbackID(int id)
    {
        feedbackID = id;
    }
    void setCustomerID(int id)
    {
        customerID = id;
    }
    void setTourID(int id)
    {
        tourID = id;
    }
    void setRating(double rt)
    {
        rating = rt;
    }
    void setFeedback(string cmt)
    {
        comments = cmt;
    }
    void setFeedbackDate(string date)
    {
        feedbackDate = date;
    }
};
class customer
{
private:
    int customerid = Writing::countCustomerInFile("Customers.txt");
    string Name;
    int password;
    string email;
    string contact;
    string address;
    int TourBooked = 0;

public:
    customer(string n, int p, string e, string c, string ad) : Name(n), password(p), email(e), contact(c), address(ad)
    {
        customerid++;
    }
    void setCustomerID(int id)
    {
        customerid = id;
    }
    void incrementTourBooked()
    {
        TourBooked++;
    }
    void setTourBooked(int t)
    {
        TourBooked = t;
    }
    int getTourBooked()
    {
        return TourBooked;
    }
    customer() {}
    int getCustomerId()
    {
        return customerid;
    }
    int getPassword()
    {
        return password;
    }
    string getName()
    {
        return Name;
    }
    string getEmail()
    {
        return email;
    }
    string getContactNo()
    {
        return contact;
    }
    string getAddress()
    {
        return address;
    }
    void setPassword(int p)
    {
        password = p;
    }
    void setName(string newFirstName)
    {
        Name = newFirstName;
    }
    void setEmail(string newEmail)
    {
        email = newEmail;
    }
    void setContactNo(string newContactNo)
    {
        contact = newContactNo;
    }
    void setAddress(string newAddress)
    {
        address = newAddress;
    }
    void CustomerFeedback()
    {
        Feedback myFeedback;
        int cusID, tID;
        string fBT;
        double rat;
        int comt;
        cout << "\t\tCustomer Feedback Portal\t\t\n";
        if (TourBooked < 1)
        {
            cout << "Sorry,You didnot have Booked any Tour\n";
            return;
        }
        myFeedback.setCustomerID(getCustomerId());
        cout << "Enter Your Tour ID: ";
        cin >> tID;
        myFeedback.setTourID(tID);
        cout << "How was Your Tour: ";
        cout << "1.Excellent\n2.Good\n3.Average\n4.Below Average\n5.Bad";
        cout<<"Enter Your Choice: ";
        cin >> comt;
        switch (comt)
        {
        case 1:
            myFeedback.setFeedback("Excellent");
            break;
        case 2:
            myFeedback.setFeedback("Good");
            break;
        case 3:
            myFeedback.setFeedback("Average");
            break;
        case 4:
            myFeedback.setFeedback("BelowAverage");
            break;
        case 5:
            myFeedback.setFeedback("Bad");
            break;

        default:
            cout << "wrong Choice...";
            CustomerFeedback();
            break;
        }
        cout << "Give Rating out of 5: ";
        cin >> rat;
        myFeedback.setRating(rat);
        cout << "Enter Today Date(DD/MM/YYYY): ";
        cin >> fBT;
        myFeedback.setFeedbackDate(fBT);
        cout << "Feedback has been given successfully.\n";
    }
    void displayInfo()
    {
        cout << "\tMy Information\t\n";
        cout << "Customer ID: " << customerid << endl;
        cout << "Name: " << Name << endl;
        cout << "Password" << password << endl;
        cout << "Email: " << email << endl;
        cout << "Contact: " << contact << endl;
        cout << "Address: " << address << endl;
        cout << "TourBooked: " << TourBooked << endl;
    }
    void updateInfo()
    {
        cout << "\t\t\tUPDATE CUSTOMER DETAIL\t\t\n";
        int pass;
        string N, em, cont, add;
        cout << "Enter New Name: ";
        cin >> N;
        setName(N);
        cout << "Enter New Contact No: ";
        cin >> cont;
        setContactNo(cont);
        cout << "Enter New Address: ";
        cin >> add;
        setAddress(add);
        cout << "Enter New Email: ";
        cin >> em;
        setEmail(em);
        cout << "Enter New Password: ";
        cin >> pass;
        setPassword(pass);
        cout << "Details have been Updated successfully.\n";
    }
    void bookingmenu(customer &obj);
};
int customerSize = Writing::countCustomerInFile("Customers.txt");
customer *customerArray = new customer[customerSize];
void CustomerMenu(customer &obj);
class Payment
{
private:
    int paymentID = 0;
    int bookingID = 0;
    double amount;
    string paymentDate;
    bool paymentStatus;

public:
    Payment()
    {
        paymentID++;
        bookingID++;
    }
    int getPaymentID()
    {
        return paymentID;
    }
    int getBookingID()
    {
        return bookingID;
    }
    double getAmount()
    {
        return amount;
    }
    string getPaymentDate()
    {
        return paymentDate;
    }
    bool getPaymentStatus()
    {
        return paymentStatus;
    }
    void setBookingID(int id)
    {
        bookingID = id;
    }
    void setAmount(double amt)
    {
        amount = amt;
    }
    void setPaymentDate(string date)
    {
        paymentDate = date;
    }
    void setPaymentStatus(bool status)
    {
        paymentStatus = status;
    }
};
class Discount
{
private:
    string discountCode;
    double discountPercent;
    double discountAmount;

public:
    Discount(string dc, double dp) : discountCode(dc), discountPercent(dp) {}
    Discount() {}
    void setDiscountPercent(double percent)
    {
        discountPercent = percent;
    }
    string getDiscountCode()
    {
        return discountCode;
    }
    int getDiscountPercent()
    {
        return discountPercent;
    }
    double getDiscountAmount()
    {
        return discountAmount;
    }
    double getFinalAmount()
    {
        return discountAmount;
    }
    void setDiscountCode(string code)
    {
        discountCode = code;
    }
    void calculateDiscountAmount(double packagePrice)
    {
        double temp;
        temp = ((100 - discountPercent) / 100.00) * packagePrice;
        discountAmount = temp;
    }
};
Discount *myDiscount;
class TourPackage
{
private:
    int packageID = Writing::countTourPackageInFile("Tour Packages.txt");
    string packageName;
    string destination;
    string description;
    int duration;
    double price;

public:
    TourPackage(){};
    TourPackage(string a, string b, int c, string d, double e)
    {
        packageName = a;
        destination = b;
        duration = c;
        description = d;
        price = e;
        packageID++;
    }
    void setPackageID(int pid)
    {
        packageID = pid;
    }
    int getPackageID()
    {
        return packageID;
    }
    string getPackageName()
    {
        return packageName;
    }
    string getDestination()
    {
        return destination;
    }
    string getDescription()
    {
        return description;
    }
    double getPrice()
    {
        return price;
    }
    int getDuration()
    {
        return duration;
    }
    void setPackageName(string name)
    {
        packageName = name;
    }
    void setDestination(string des)
    {
        destination = des;
    }
    void setDescription(string desc)
    {
        description = desc;
    }
    void setPrice(double prc)
    {
        price = prc;
    }
    void setDuration(int dur)
    {
        duration = dur;
    }
};
int tourPackageSize = Writing::countTourPackageInFile("Tour Packages.txt");
TourPackage *tourPackageArray = new TourPackage[tourPackageSize];
class tourguide
{
private:
    int guideid = Writing::countTourGuideInFile("Tour Guiders.txt");
    string Name;
    string contactnumber;
    string email;
    string languagespoken;

public:
    tourguide(string n, string cno, string e, string lang) : Name(n), contactnumber(cno), email(e), languagespoken(lang)
    {
        guideid++;
    }
    tourguide() {}
    void setGuideId(int id)
    {
        guideid = id;
    }
    int getGuideId()
    {
        return guideid;
    }
    string getName()
    {
        return Name;
    }
    string getContactNumber()
    {
        return contactnumber;
    }
    string getEmail()
    {
        return email;
    }

    string getLanguageSpoken()
    {
        return languagespoken;
    }
    void setName(string newFirstName)
    {
        Name = newFirstName;
    }
    void setContactNumber(string newContactNumber)
    {
        contactnumber = newContactNumber;
    }
    void setEmail(string newEmail)
    {
        email = newEmail;
    }
    void setLanguageSpoken(string newLanguageSpoken)
    {
        languagespoken = newLanguageSpoken;
    }
};
class transportation
{
private:
    int vehicleId = Writing::countVehiclesInFile("Transport Information.txt");
    string vehicletype;
    string vehicleName;
    int capacity;
    string registrationNo;
    string driverName;

public:
    transportation() {}
    transportation(string vName, string vtype, int capac, string rNo, string dName) : vehicleName(vName), vehicletype(vtype),
                                                                                      capacity(capac), registrationNo(rNo), driverName(dName)
    {
        vehicleId++;
    }
    void setVehicleId(int newVehicleId)
    {
        vehicleId = newVehicleId;
    }

    void setVehicleType(string v)
    {
        vehicletype = v;
    }

    void setCapacity(int newCapacity)
    {
        capacity = newCapacity;
    }

    void setRegistrationNo(string newRegistrationNo)
    {
        registrationNo = newRegistrationNo;
    }

    void setDriverName(string newDriverName)
    {
        driverName = newDriverName;
    }
    void setVehicleName(string newVehicleName)
    {
        vehicleName = newVehicleName;
    }
    string getVehicleName()
    {
        return vehicleName;
    }
    int getVehicleId()
    {
        return vehicleId;
    }
    string getVehicleType()
    {
        return vehicletype;
    }

    int getCapacity()
    {
        return capacity;
    }

    string getRegistrationNo()
    {
        return registrationNo;
    }

    string getDriverName()
    {
        return driverName;
    }
};
class hotel
{
    int hotelId = Writing::countHotelsInFile("Hotels.txt");
    int tourIDAssigned;
    string hotelName;
    string location;
    double rating;
    string contactNumber;

public:
    hotel(){};
    hotel(string na, string la, double ra, string co, int tid)
    {
        hotelName = na;
        location = la;
        rating = ra;
        tourIDAssigned = tid;
        contactNumber = co;
        hotelId++;
    }
    void settourIDAssigned(int tourAssign)
    {
        tourIDAssigned = tourAssign;
    }
    int gettourIDAssigned()
    {
        return tourIDAssigned;
    }
    int gethotelid()
    {
        return hotelId;
    }
    string getHotelName()
    {
        return hotelName;
    }
    string getHotelContact()
    {
        return contactNumber;
    }
    string getHotelLocation()
    {
        return location;
    }
    double getHotelRating()
    {
        return rating;
    }
    void setHotelID(int id)
    {
        hotelId = id;
    }
    void setHotelName(string n)
    {
        hotelName = n;
    }
    void setHotelContact(string cno)
    {
        contactNumber = cno;
    }
    void setHotelLocation(string l)
    {
        location = l;
    }
    void setRating(double r)
    {
        rating = r;
    }
};
int hotelSize = Writing::countHotelsInFile("Hotels.txt");
hotel *hotelArray = new hotel[hotelSize];
int transportSize = Writing::countVehiclesInFile("Transport Information.txt");
transportation *transportArray = new transportation[transportSize];
int tourguideSize = Writing::countTourGuideInFile("Tour Guiders.txt");
tourguide *tourguideArray = new tourguide[tourguideSize];
class TourBooking
{
    string HotelName;
    string VehicleName;
    int bookingID = 0;
    Discount *Dis = new Discount;
    Payment *Pay = new Payment;
    TourPackage *TPack = new TourPackage;
    customer *custom = new customer;

public:
    TourBooking(customer C, TourPackage &T, string HotelN, string VehicleN)
    {
        custom = &C;
        TPack = &T;
        HotelName = HotelN;
        VehicleName = VehicleN;
        bookingID++;
        Dis = myDiscount;
        Pay->setAmount(T.getPrice());
    }
    TourBooking() {}
    void setBookPaymentDate(string d)
    {
        Pay->setPaymentDate(d);
    }
    void setBookPaymentStatus(bool status)
    {
        Pay->setPaymentStatus(status);
    }
    string getBookingHotelName()
    {
        return HotelName;
    }
    string getBookingVehicle()
    {
        return VehicleName;
    }
    double calculateTotalPrice()
    {
    }
    int getbookingID()
    {
        return bookingID;
    }
    void setbookingID(int newbookingID)
    {
        bookingID = newbookingID;
    }
    customer *getBookingCustomer()
    {
        return custom;
    }
    Payment *getBookingPayment()
    {
        return Pay;
    }
    TourPackage *getBookingPackage()
    {
        return TPack;
    }
};
int TourBookedSize = Writing::countTotalBookedTourfromfile("Total Tour Booked.txt");
class Manager
{
protected:
    int managerID = 0;
    string name;
    int password;
    string address;
    string role;
    string CNIC;
    string contactNo;

public:
    Manager(string n, int pass, string add, string cnic, string contact, string rle) : name(n), password(pass), address(add),
                                                                                       CNIC(cnic), role(rle), contactNo(contact)
    {
        managerID++;
    }
    Manager() {}
    int getManagerPassword()
    {
        return password;
    }
    int getManagerID()
    {
        return managerID;
    }
    string getManagerName()
    {
        return name;
    }
    string getManagerRole()
    {
        return role;
    }
    string getManagerAddress()
    {
        return address;
    }
    string getManagerCNIC()
    {
        return CNIC;
    }
    string getMContactNo()
    {
        return contactNo;
    }
    void setManagerPassword(int newPassword)
    {
        password = newPassword;
    }
    void setManagerName(string &newName)
    {
        name = newName;
    }
    void setManagerID(int newManagerID)
    {
        managerID = newManagerID;
    }
    void setManagerRole(string &newRole)
    {
        role = newRole;
    }

    void setManagerAddress(string &newAddress)
    {
        address = newAddress;
    }
    void setManagerCNIC(string &newCNIC)
    {
        CNIC = newCNIC;
    }
    void setManagerContactNo(string &newContactNo)
    {
        contactNo = newContactNo;
    }
    void display()
    {
        cout << "\t\t\tMANAGER DETAILS\t\t\n";
        cout << "Manager ID: " << managerID << endl;
        cout << "Name: " << name << endl;
        cout << "CNIC: " << CNIC << endl;
        cout << "Password: " << password << endl;
        cout << "Address: " << address << endl;
        cout << "Role: " << role << endl;
        cout << "Contact No: " << contactNo << endl;
    }
    bool Login()
    {
        while (true)
        {
            system("cls");
            string n;
            int pass;
            cout << "Enter Name: " << endl;
            cin >> n;
            cout << "Enter password: " << endl;
            cin >> pass;
            if (n == name && pass == password)
            {
                cout << "Logged In successfully!" << endl;
                return true;
            }
            else
            {
                cout << "Invalid username or password" << endl;
            }
        }
    }
};
class TransportManager : public Manager
{
public:
    TransportManager(){};
    TransportManager(string name, int pas, string adress, string cn, string cont, string rol) : Manager(name, pas, adress, cn, cont, rol) {}
    void Menu()
    {
        system("cls");
        int choice;
        cout << "\t\t\tWelcome to Transport Manager Portal\t\t\t\n";
        cout << "1. Add Transport\n";
        cout << "2. Update Transport Details\n";
        cout << "3. Delete Transport\n";
        cout << "4. Display All Vehicles\n";
        cout << "5. Display your Information\n";
        cout << "0. Logouts\n";
        cout << "Enter your Choice: ";
        cin >> choice;
        switch (choice)
        {
        case 1:
            addVehicle();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 2:
            updateVehicleDetails();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 3:
            deleteVehicle();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 4:
            DisplayAllVehicles();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 5:
            display();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 0:
            ManagerLoginMenu();
            break;
        default:
            break;
        }
    }
    void DisplayAllVehicles()
    {
        system("cls");
        cout << "\t\t\tAll Vehicles\t\n";
        for (int i = 0; i < transportSize; i++)
        {
            cout << "Vehicle ID: " << transportArray[i].getVehicleId() << endl;
            cout << "Vehicle Name: " << transportArray[i].getVehicleName() << endl;
            cout << "Registration No: " << transportArray[i].getRegistrationNo() << endl;
            cout << "Vehicle Type: " << transportArray[i].getVehicleType() << endl;
            cout << "Driver Name: " << transportArray[i].getDriverName() << endl;
        }
    }
    void updateTransportManagerDetail(const string &filename)
    {
        system("cls");
        cout << "Update Detail\n";
        cout << "Enter Name\n";
        cin >> name;
        cout << "Enter Password\n";
        cin >> password;
        cout << "Enter Address\n";
        cin >> address;
        cout << "Enter Role\n";
        cin >> role;
        cout << "Enter CNIC\n";
        cin >> CNIC;
        cout << "Enter Conatct\n";
        cin >> contactNo;
        ofstream outFile(filename);
        if (!outFile)
        {
            cout << "Unable to open the file for writing.\n";
            return;
        }
        else
        {
            outFile << getManagerPassword() << "\n";
            outFile << getManagerID() << "\n";
            outFile << getManagerRole() << "\n";
            outFile << getManagerName() << "\n";
            outFile << getManagerCNIC() << "\n";
            outFile << getMContactNo() << "\n";
        }
        outFile.close();
    }
    static void addVehicle()
    {
        system("cls");
        cout << "\t\t\tADD VEHICLE\t\t\n";
        int c;
        string vn, vt, rn, dn;
        cout << "Enter Vehicle details:\n";
        cout << "Enter Vehicle Name: ";
        cin >> vn;
        cout << "Enter Vehicle Type: ";
        cin >> vt;
        cout << "Capacity of Vehicle: ";
        cin >> c;
        cout << "Enter Registration No: ";
        cin >> rn;
        cout << "Enter Driver Name: ";
        cin >> dn;
        transportation *tempPtr = new transportation[transportSize + 1];
        for (int i = 0; i < transportSize; i++)
        {
            tempPtr[i] = transportArray[i];
        }
        tempPtr[transportSize] = transportation(vn, vt, c, rn, dn);
        delete[] transportArray;
        transportArray = tempPtr;
        transportSize = transportSize + 1;
        cout << "Added Successfully.\n";
        Writing::writevehicleToFile(transportArray, transportSize, "Transport Information.txt");
    }
    static void updateVehicleDetails()
    {
        system("cls");
        int vId, c;
        string vn, vt, rn, dn;
        cout << "\t\t\tUpdate Details\t\t\n";
        cout << "Enter Vehicle ID: ";
        cin >> vId;
        for (int i = 0; i < transportSize; i++)
        {
            if (transportArray[i].getVehicleId() == vId)
            {
                cout << "Enter Vehicle Name: ";
                cin >> vn;
                cout << "Enter Vehicle Type: ";
                cin >> vt;
                cout << "Capacity of Vehicle: ";
                cin >> c;
                cout << "Enter Registration No: ";
                cin >> rn;
                cout << "Enter Driver ID: ";
                cin >> dn;
                transportArray[i] = transportation(vn, vt, c, rn, dn);
                cout << "Details has been updated Successfully.\n";
                cout << "Press any Key to Go Back..\n";
                _getch();
                break;
            }
        }
        Writing::writevehicleToFile(transportArray, transportSize, "Transport Information.txt");
    }
    static void deleteVehicle()
    {
        system("cls");
        cout << "\t\tREMOVE A VEHICLE\t\n";
        int id;
        int delIndex;
        cout << "Enter ID of vehicle: ";
        cin >> id;
        for (int i = 0; i < transportSize; i++)
        {
            if (transportArray[i].getVehicleId() == id)
            {
                delIndex = i;
                break;
            }
        }
        if (delIndex < 0 || delIndex >= transportSize)
        {
            cout << "Invalid index or empty array.\n";
            return;
        }
        transportation *tempPtr = new transportation[transportSize - 1];
        int j = 0;
        for (int i = 0; i < transportSize; i++)
        {
            if (i == delIndex)
            {
                cout << "Vehicle have been Removed.\n";
                continue;
            }
            tempPtr[j] = transportArray[i];
            j++;
        }
        delete[] transportArray;
        transportArray = tempPtr;
        transportSize = transportSize - 1;
        Writing::writevehicleToFile(transportArray, transportSize, "Transport Information.txt");
    }
};
TransportManager *myTransportManager = new TransportManager;
class tourGuideManager : public Manager
{
private:
public:
    tourGuideManager(string name, int pas, string adress, string cn, string cont, string rol) : Manager(name, pas, adress, cn, cont, rol) {}
    tourGuideManager() {}
    void Menu()
    {
        int choice;
        cout << "\t\t\tWelcome to TourGuide Manager Portal\t\t\t\n";
        cout << "1. Add TourGuide\n";
        cout << "2. Update TourGuide Details\n";
        cout << "3. Delete TourGuide\n";
        cout << "4. Display All TourGuide\n";
        cout << "5. Display your Information\n";
        cout << "0. Logouts\n";
        cout << "Enter your Choice: ";
        cin >> choice;
        switch (choice)
        {
        case 1:
            addGuideManager();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 2:
            updateTourGuideDetail();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 3:
            deleteGuideManager();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 4:
            DisplayTourGuide();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 5:
            display();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 0:
            ManagerLoginMenu();
            break;
        default:
            break;
        }
    }
    void DisplayTourGuide()
    {
        for (int i = 0; i < tourguideSize; i++)
        {
            cout << "TourGuide ID: " << tourguideArray[i].getGuideId() << endl;
            cout << "TourGuide Name: " << tourguideArray[i].getName() << endl;
            cout << "Email: " << tourguideArray[i].getEmail() << endl;
            cout << "Spoken language: " << tourguideArray[i].getLanguageSpoken() << endl;
            cout << "Contact No: " << tourguideArray[i].getContactNumber() << endl;
        }
    }
    void updateTourGuideManagerDetail(const string &filename)
    {
        system("cls");
        cout << "Update Detail\n";
        cout << "Enter Name\n";
        cin >> name;
        cout << "Enter Password\n";
        cin >> password;
        cout << "Enter Address\n";
        cin >> address;
        cout << "Enter Role\n";
        cin >> role;
        cout << "Enter CNIC\n";
        cin >> CNIC;
        cout << "Enter Conatct\n";
        cin >> contactNo;
        ofstream outFile(filename);
        if (!outFile)
        {
            cout << "Unable to open the file for writing.\n";
            return;
        }
        else
        {
            outFile << getManagerPassword() << "\n";
            outFile << getManagerID() << "\n";
            outFile << getManagerRole() << "\n";
            outFile << getManagerName() << "\n";
            outFile << getManagerCNIC() << "\n";
            outFile << getMContactNo() << "\n";
        }
        outFile.close();
    }
    static void addGuideManager()
    {
        string Name;
        string ContactNum;
        string email;
        string langspoke;
        cout << "Enter Tour Guider Details:\n";
        cout << "Enter Name: ";
        cin >> Name;
        cout << "Enter Contact No: ";
        cin >> ContactNum;
        cout << "Enter Email: ";
        cin >> email;
        cout << "Enter Language Spoke: ";
        cin >> langspoke;
        tourguide *tempPtr = new tourguide[tourguideSize + 1];
        for (int i = 0; i < tourguideSize; i++)
        {
            tempPtr[i] = tourguideArray[i];
        }
        tempPtr[tourguideSize] = tourguide(Name, ContactNum, email, langspoke);
        delete[] tourguideArray;
        tourguideArray = tempPtr;
        tourguideSize = tourguideSize + 1;
        cout << "Added Successfully.\n";
        Writing::writetourguideToFile(tourguideArray, tourguideSize, "Tour Guiders.txt");
    }
    static void updateTourGuideDetail()
    {
        int gId;
        string N, contact, em, lang;
        cout << "\t\t\tUpdate Details\t\t\n";
        cout << "Enter TourGuide ID: ";
        cin >> gId;
        for (int i = 0; i < tourguideSize; i++)
        {
            if (tourguideArray[i].getGuideId() == gId)
            {
                cout << "Enter Name: ";
                cin >> N;
                cout << "Enter Contact No: ";
                cin >> contact;
                cout << "Enter Email: ";
                cin >> em;
                cout << "Enter Language Spoke: ";
                cin >> lang;
                tourguideArray[i] = tourguide(N, contact, em, lang);
                cout << "Details has been updated Successfully.\n";
                cout << "Press any Key to Go Back..\n";
                _getch();
                break;
            }
        }
        Writing::writetourguideToFile(tourguideArray, tourguideSize, "Tour Guiders.txt");
    }
    static void deleteGuideManager()
    {
        system("cls");
        cout << "\t\tREMOVE A TOUR GUIDE\t\n";
        int id;
        int delIndex;
        cout << "Enter ID of TourGuider: ";
        cin >> id;
        for (int i = 0; i < tourguideSize; i++)
        {
            if (tourguideArray[i].getGuideId() == id)
            {
                delIndex = i;
                break;
            }
        }
        if (delIndex < 0 || delIndex >= tourguideSize)
        {
            cout << "Invalid index or empty array.\n";
            return;
        }
        tourguide *tempPtr = new tourguide[tourguideSize - 1];
        int j = 0;
        for (int i = 0; i < tourguideSize; i++)
        {
            if (i == delIndex)
            {
                cout << "Tour Guide have been Removed.\n";
                continue;
            }
            tempPtr[j] = tourguideArray[i];
            j++;
        }
        delete[] tourguideArray;
        tourguideArray = tempPtr;
        tourguideSize = tourguideSize - 1;
        Writing::writetourguideToFile(tourguideArray, tourguideSize, "Tour Guiders.txt");
    }
};
tourGuideManager *myTourGuideManager = new tourGuideManager;
class customerManager : public Manager, public customer
{
private:
public:
    customerManager(){};
    customerManager(string name, int pas, string adress, string cn, string cont, string rol) : Manager(name, pas, adress, cn, cont, rol) {}
    void Menu()
    {
        system("cls");
        int choice;
        cout << "\t\t\tWelcome to Customer Manager Portal\t\t\t\n";
        cout << "1. Add Customer\n";
        cout << "2. Update Customer Details\n";
        cout << "3. Delete Customer\n";
        cout << "4. Display All Customer\n";
        cout << "5. Display your Information\n";
        cout << "0. Logouts\n";
        cout << "Enter your Choice: ";
        cin >> choice;
        switch (choice)
        {
        case 1:
            addcustommer();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 2:
            updateCustomerDetail();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 3:
            deleteCustomer();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 4:
            DisplayCustomerDetails();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 5:
            display();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 0:
            ManagerLoginMenu();
            break;
        default:
            break;
        }
    }
    void DisplayCustomerDetails()
    {
        system("cls");
        cout << "\t\t\tALL CUSTOMERS\t\t\n";
        for (int i = 0; i < customerSize; i++)
        {
            cout << "Customer ID: " << customerArray[i].getCustomerId() << endl;
            cout << "Customer Name: " << customerArray[i].getName() << endl;
            cout << "Customer Password: " << customerArray[i].getPassword() << endl;
            cout << "Customer Email: " << customerArray[i].getEmail() << endl;
            cout << "Contact No: " << customerArray[i].getContactNo() << endl;
            cout << "Address: " << customerArray[i].getAddress() << endl;
        }
    }
    void updateCustomerManagerDetail(const string &filename)
    {
        system("cls");
        cout << "Update Detail\n";
        cout << "Enter Name\n";
        cin >> name;
        cout << "Enter Password\n";
        cin >> Manager::password;
        cout << "Enter Address\n";
        cin >> Manager::address;
        cout << "Enter Role\n";
        cin >> role;
        cout << "Enter CNIC\n";
        cin >> CNIC;
        cout << "Enter Contact\n";
        cin >> contactNo;
        ofstream outFile(filename);
        if (!outFile)
        {
            cout << "Unable to open the file for writing.\n";
            return;
        }
        else
        {
            outFile << getManagerPassword() << "\n";
            outFile << getManagerID() << "\n";
            outFile << getManagerRole() << "\n";
            outFile << getManagerName() << "\n";
            outFile << getManagerCNIC() << "\n";
            outFile << getMContactNo() << "\n";
        }
        outFile.close();
    }
    static void addcustommer()
    {
        system("cls");
        string N;
        string em;
        int pass;
        string cont;
        string add;
        cout << "Enter Customer Detial:\n";
        cout << "Enter Name: " << endl;
        cin >> N;
        cout << "Enter Password: " << endl;
        cin >> pass;
        cout << "Enter Email: " << endl;
        cin >> em;
        cout << "Enter Contact: " << endl;
        cin >> cont;
        cout << "Enter Address: " << endl;
        cin >> add;
        customer *tempPtr = new customer[customerSize + 1];
        for (int i = 0; i < customerSize; i++)
        {
            tempPtr[i] = customerArray[i];
        }
        tempPtr[customerSize] = customer(N, pass, em, cont, add);
        delete[] customerArray;
        customerArray = tempPtr;
        customerSize = customerSize + 1;
        Writing::writeCustomerToFile(customerArray, customerSize, "Customers.txt");
        cout << "Added Successfully.\n";
    }
    static void deleteCustomer()
    {
        system("cls");
        cout << "\t\tREMOVE A CUSTOMER\t\n";
        int id;
        int delIndex;
        cout << "Enter ID: ";
        cin >> id;
        for (int i = 0; i < customerSize; i++)
        {
            if (customerArray[i].getCustomerId() == id)
            {
                delIndex = i;
                break;
            }
        }
        if (delIndex < 0 || delIndex >= customerSize)
        {
            cout << "Invalid index or empty array.\n";
            return;
        }
        customer *tempPtr = new customer[customerSize - 1];
        int j = 0;
        for (int i = 0; i < customerSize; i++)
        {
            if (i == delIndex)
            {
                cout << "The Customer has been Removed.\n";
                continue;
            }
            tempPtr[j] = customerArray[i];
            j++;
        }
        delete[] customerArray;
        customerArray = tempPtr;
        customerSize = customerSize - 1;
        Writing::writeCustomerToFile(customerArray, customerSize, "Customers.txt");
    }
    static void updateCustomerDetail()
    {
        int pass, cID;
        string N, em, cont, add;
        cout << "\t\t\tUPDATE DETAILS\t\t\n";
        cout << "Enter customer ID: ";
        cin >> cID;
        for (int i = 0; i < customerSize; i++)
        {
            if (customerArray[i].getCustomerId() == cID)
            {
                customerArray[i].updateInfo();
                break;
            }
        }
        Writing::writeCustomerToFile(customerArray, customerSize, "Customers.txt");
    }
};
customerManager *myCustomerManager = new customerManager;
class HotelManager : public Manager
{
public:
    HotelManager(){};
    HotelManager(string name, int pas, string adress, string cn, string cont, string rol) : Manager(name, pas, adress, cn, cont, rol) {}
    void Menu()
    {
        int choice;
        cout << "\t\t\tWelcome to Hotel Manager Portal\t\t\t\n";
        cout << "1. Add Hotel\n";
        cout << "2. Update Hotel Details\n";
        cout << "3. Delete Hotel\n";
        cout << "4. Display All Hotels\n";
        cout << "5. Display your Information\n";
        cout << "0. Logouts\n";
        cout << "Enter your Choice: ";
        cin >> choice;
        switch (choice)
        {
        case 1:
            addHotel();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 2:
            updatehotel();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 3:
            deleteHotel();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 4:
            DisplayHotelDetails();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 5:
            display();
            cout << "Press Any Key to Go Back...\n";
            getch();
            Menu();
            break;
        case 0:
            ManagerLoginMenu();
            break;
        default:
            break;
        }
    }
    void DisplayHotelDetails()
    {
        for (int i = 0; i < hotelSize; i++)
        {
            cout << "Hotel ID: " << hotelArray[i].gethotelid() << endl;
            cout << "Hotel Name: " << hotelArray[i].getHotelName() << endl;
            cout << "Tour ID Asigned: " << hotelArray[i].gettourIDAssigned() << endl;
            cout << "Rating: " << hotelArray[i].getHotelRating() << endl;
            cout << "Location: " << hotelArray[i].getHotelLocation() << endl;
            cout << "Contact No " << hotelArray[i].getHotelContact() << endl;
        }
    }
    void updateHotelManagerDetail(const string &filename)
    {
        system("cls");
        cout << "Update Detail\n";
        cout << "Enter Name\n";
        cin >> name;
        cout << "Enter Password\n";
        cin >> password;
        cout << "Enter Address\n";
        cin >> address;
        cout << "Enter Role\n";
        cin >> role;
        cout << "Enter CNIC\n";
        cin >> CNIC;
        cout << "Enter Conatct\n";
        cin >> contactNo;
        ofstream outFile(filename);
        if (!outFile)
        {
            cout << "Unable to open the file for writing.\n";
            return;
        }
        else
        {
            outFile << getManagerPassword() << "\n";
            outFile << getManagerID() << "\n";
            outFile << getManagerRole() << "\n";
            outFile << getManagerName() << "\n";
            outFile << getManagerCNIC() << "\n";
            outFile << getMContactNo() << "\n";
        }
        outFile.close();
    }
    static void addHotel()
    {
        string a;
        string b;
        double c;
        string d;
        int e;
        cout << "Hotel Name: ";
        cin >> a;
        cout << "Assigned Tour Id: ";
        cin >> e;
        cout << "Enter location: ";
        cin >> b;
        cout << "Enter Ratings: ";
        cin >> c;
        cin.ignore();
        cout << "Enter Contact number: ";
        cin >> d;
        hotel *hoteltemp = new hotel[hotelSize + 1];
        for (int i = 0; i < hotelSize; i++)
        {
            hoteltemp[i] = hotelArray[i];
        }
        hoteltemp[hotelSize] = hotel(a, b, c, d, e);
        delete hotelArray;
        hotelArray = hoteltemp;
        hotelSize = hotelSize + 1;
        cout << "Hotel Added Successfully\n";
        Writing::writehotelsToFile(hotelArray, hotelSize, "Hotels.txt");
    }
    static void updatehotel()
    {
        int nid, tID;
        string hname, loca, cont;
        double rat;
        cout << "\t\tUpdate Details\n";
        cout << "Enter Hotel ID\n";
        cin >> nid;
        for (int i = 0; i < hotelSize; i++)
        {
            if (hotelArray[i].gethotelid() == nid)
            {
                cout << "Enter Hotel Name: ";
                cin >> hname;
                cout << "Enter TourID Assigned: ";
                cin >> tID;
                cout << "Enter location: ";
                cin >> loca;
                cout << "Enter Ratings: ";
                cin >> rat;
                cout << "Enter Contact number: ";
                cin >> cont;
                hotelArray[i] = hotel(hname, loca, rat, cont, tID);
                cout << "Detail Has been Updated Successfully\n";
                cout << "Press any key to go back\n";
                _getch();
                break;
            }
        }
        Writing::writehotelsToFile(hotelArray, hotelSize, "Hotels.txt");
    }
    static void deleteHotel()
    {
        int id;
        int tempIndex;
        cout << "Enter the ID of the Hotel you want to Remove\n";
        cin >> id;
        for (int i = 0; i < hotelSize; i++)
        {
            if (hotelArray[i].gethotelid() == id)
            {
                tempIndex = i;
                break;
            }
        }
        if (tempIndex < 0 || tempIndex >= hotelSize)
        {
            cout << "Invalid Hotel Id\n";
            return;
        }
        hotel *temphotel = new hotel[hotelSize - 1];
        int a = 0;
        for (int i = 0; i < hotelSize; i++)
        {
            if (i = tempIndex)
            {
                cout << "Hotel Removed Successfully\n";
                continue;
            }
            temphotel[a] = hotelArray[i];
            a++;
        }
        delete[] hotelArray;
        hotelArray = temphotel;
        hotelSize = hotelSize - 1;
        Writing::writehotelsToFile(hotelArray, hotelSize, "Hotels.txt");
    }
};
HotelManager *myHotelManager = new HotelManager;

class BookingManager : public Manager
{
public:
    BookingManager(){};
    BookingManager(string name, int pas, string adress, string cn, string cont, string rol) : Manager(name, pas, adress, cn, cont, rol) {}
    void Menu()
    {
        system("cls");
        int choice;
        cout << "\t\t\tWelcome to Hotel Manager Portal\t\t\t\n";
        cout << "1. Add Tour Package\n";
        cout << "2. Update Tour Package\n";
        cout << "3. Remove Tour Package\n";
        cout << "4. Add Discount\n";
        cout << "5. Update Discount\n";
        cout << "6. View Total Bookings\n";
        cout << "7. Display All Tour Pakages\n";
        cout << "8. Update Your Information\n";
        cout << "9. Display Your Information\n";
        cout << "10. Update Customer Manager\n";
        cout << "11. Update TourGuide Manager\n";
        cout << "12. Update Transportation Manager\n";
        cout << "13. Update Hotel Manager\n";
        cout << "0. Logouts\n";
        cout << "Enter your Choice: ";
        cin >> choice;
        switch (choice)
        {
        case 1:
            addTourPackage();
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
            break;
        case 2:
            updateTourPackage();
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
            _getch();
            break;
        case 3:
            deleteTourPackage();
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
            break;
        case 4:
            addDiscount();
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
            break;
        case 5:
            updateDiscount();
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
            break;
        case 6:
            system("cls");
            cout << "Total Bookings are: " << TourBookedSize<<endl;
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
            break;
        case 7:
            displayTourPackages();
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
            break;
        case 8:
            updateBookingManagerInfo("BookingManagerDetials");
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
            break;
        case 9:
            this->display();
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
            break;
        case 10:
            myCustomerManager->updateCustomerManagerDetail("CustomerManagerDetail");
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
            break;
        case 11:
            myTourGuideManager->updateTourGuideManagerDetail("TourGuideManagerDetail");
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
            break;
        case 12:
            myTransportManager->updateTransportManagerDetail("TransportManagerDetail");
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
            break;
        case 13:
            myHotelManager->updateHotelManagerDetail("HotelManagerDetail");
            cout << "Press Any key to go Back....\n";
            _getch();
            Menu();
        case 0:
            mainMenu();
            break;
        default:
            break;
        }
    }
    static void BookTour(TourBooking myobj)
    {
        string guideName;
        string lang;
        bool isFound = false;
        bool isDiscount = false;
        bool isBook = false;
        cout << "Enter Language to get TourGuide: ";
        cin >> lang;
        for (int i = 0; i < tourguideSize; i++)
        {
            if (lang == tourguideArray[i].getLanguageSpoken())
            {
                cout << "Tour Guide Assigned.\n";
                guideName = tourguideArray[i].getName();
                isFound = true;
                break;
            }
        }
        if (isFound == false)
        {
            guideName = "Null";
            cout << "Sorry, we can't provide you tour guider because our tour guider can't understand this Language.\n";
        }
        cout << "Press any key to Next step....";
        getch();
        cout << "\t\t\tDiscount Section\t\t\n";
        int tempchoice;
        cout << "1. Enter Discount Code to get Discount.\n";
        cout << "2. Don't have code. Move to Next Step\n";
        cout << "Enter your Choice.\n";
        cin >> tempchoice;
        if (tempchoice == 1)
        {
            string code;
            cout << "Enter Code: ";
            cin >> code;
            if (code == myDiscount->getDiscountCode())
            {
                myDiscount->calculateDiscountAmount(myobj.getBookingPackage()->getPrice());
                cout << "You have given " << myDiscount->getDiscountPercent() << " Percent Discount.\n";
                cout << "Press any key to Next step....";
                getch();
                isDiscount = true;
                cout << "Your Total Amount For this Tour is " << myDiscount->getDiscountAmount() << endl;
                cout << "Are You Sure to Book this Tour? \n";
                cout << "1. Yes\n2. No\n";
                cin >> tempchoice;
                switch (tempchoice)
                {
                case 1:
                    isBook = true;
                    break;
                case 2:
                    cout << "You have cancel The Booking.\n";
                    CustomerMenu(*myobj.getBookingCustomer());
                default:
                    break;
                }
            }
            else
            {
                cout << "Wrong Discount Code.\n";
            }
        }
        else
        {
            cout << "Your Total Amount For this Tour is " << myobj.getBookingPayment()->getAmount() << endl;
            cout << "Are You Sure to Book this Tour? \n";
            cout << "1. Yes\n2. No\n";
            cin >> tempchoice;
            switch (tempchoice)
            {
            case 1:
                isBook = true;
                break;
            case 2:
                cout << "You have cancel The Booking.\n";
                CustomerMenu(*myobj.getBookingCustomer());
            default:
                break;
            }
        }
        if (isBook == true)
        {
            cout << "------------------------------------------------------------" << endl;
            cout << "|                    TOUR BOOKING RECEIPT                  |" << endl;
            cout << "------------------------------------------------------------" << endl;
            cout << "| Customer Information:                                   |" << endl;
            cout << "| ID: " << myobj.getBookingCustomer()->getCustomerId() << endl;
            cout << "| Name: " << myobj.getBookingCustomer()->getName() << endl;
            cout << "| Email: " << myobj.getBookingCustomer()->getEmail() << endl;
            cout << "| Contact No: " << myobj.getBookingCustomer()->getContactNo() << endl;
            cout << "| Address: " << myobj.getBookingCustomer()->getAddress() << endl;
            cout << "------------------------------------------------------------" << endl;
            cout << "| Tour Details:                                           |" << endl;
            cout << "| Tour ID: " << myobj.getBookingPackage()->getPackageID() << endl;
            cout << "| Tour Name: " << myobj.getBookingPackage()->getPackageName() << endl;
            cout << "| Tour Destination: " << myobj.getBookingPackage()->getDestination() << endl;
            cout << "| Tour Duration(In Days): " << myobj.getBookingPackage()->getDuration() << endl;
            cout << "| Tour Price: " << myobj.getBookingPackage()->getPrice() << endl;
            cout << "| Vehicle Use: " << myobj.getBookingVehicle() << endl;
            cout << "| Hotel Name: " << myobj.getBookingHotelName() << endl;
            cout << "| Guider Assign: " << guideName << endl;
            cout << "------------------------------------------------------------" << endl;
            cout << "| Payment Details:                                        |" << endl;
            cout << "| Total Price: $ " << myobj.getBookingPayment()->getAmount() << endl;
            if (isDiscount == true)
            {
                cout << "| Discount Applied: $" << myDiscount->getDiscountPercent() << endl;
                cout << "| Discount Code: " << myDiscount->getDiscountCode() << endl;
                cout << "| Final Amount Paid:- $" << myDiscount->getDiscountAmount() << endl;
            }
            else
            {
                cout << "| Discount Applied: "
                     << "Null" << endl;
                cout << "| Discount Code: "
                     << "Null" << endl;
                cout << "| Final Amount Paid: $" << myobj.getBookingPayment()->getAmount() << endl;
            }
            cout << "------------------------------------------------------------" << endl;
            cout << "| Thank you for choosing our tour service!                |" << endl;
            cout << "| For any inquiries, please contact us at [Contact Info]. |" << endl;
            cout << "------------------------------------------------------------" << endl;
            myobj.getBookingCustomer()->incrementTourBooked();
            Writing::writeCustomerToFile(customerArray, customerSize, "Customers.txt");
            TourBookedSize++;
            Writing::writeTotalBookedTourfromfile(TourBookedSize, "Total Tour Booked.txt");
            getch();
        }
    }
    void addDiscount()
    {
        system("cls");
        string dCode;
        int dPercent;
        cout << "\t\t\tAdd Discount\t\t\n";
        cout << "Enter Discount Code: ";
        cin >> dCode;
        cout << "Enter Percentage of Discount: ";
        cin >> dPercent;
        myDiscount = new Discount(dCode, dPercent);
        cout << "Discount has been Created.\n";
    }
    void updateDiscount()
    {
        system("cls");
        string dCode;
        int dPercent;
        cout << "\t\t\tAdd Discount\t\t\n";
        cout << "Enter Discount Code: ";
        cin >> dCode;
        cout << "Enter Percentage of Discount: ";
        cin >> dPercent;
        myDiscount->setDiscountCode(dCode);
        myDiscount->setDiscountPercent(dPercent);
        cout << "Discount has been Updated.\n";
    }
    void updateBookingManagerInfo(const string &filename)
    {
        system("cls");
        cout << "Update Detail\n";
        cout << "Enter Name\n";
        cin >> name;
        cout << "Enter Password\n";
        cin >> password;
        cout << "Enter Address\n";
        cin >> address;
        cout << "Enter Role\n";
        cin >> role;
        cout << "Enter CNIC\n";
        cin >> CNIC;
        cout << "Enter Contact\n";
        cin >> contactNo;
        ofstream outFile(filename);
        if (!outFile)
        {
            cout << "Unable to open the file for writing.\n";
            return;
        }
        else
        {
            outFile << getManagerPassword() << "\n";
            outFile << getManagerID() << "\n";
            outFile << getManagerRole() << "\n";
            outFile << getManagerName() << "\n";
            outFile << getManagerCNIC() << "\n";
            outFile << getMContactNo() << "\n";
        }
        outFile.close();
        cout << "Booking Manager Info Updated Successfully\n";
    }
    static void displayTourPackages()
    {
        system("cls");
        cout << "\t\tTour Packages\t\t\n";
        for (int i = 0; i < tourPackageSize; i++)
        {
            cout << "Package ID: " << tourPackageArray[i].getPackageID() << endl;
            cout << "Package Name: " << tourPackageArray[i].getPackageName() << endl;
            cout << "Designation: " << tourPackageArray[i].getDestination() << endl;
            cout << "Description: " << tourPackageArray[i].getDescription() << endl;
            cout << "Package Price: " << tourPackageArray[i].getPrice() << endl;
        }
    }
    void addTourPackage()
    {
        system("cls");
        cout << "\t\t\tADD NEW TOUR PACKAGE\t\t\n";
        string pkgname;
        string dest;
        string desc;
        double pri;
        int dura;
        cout << "Enter Pakage Name\n";
        cin >> pkgname;
        cout << "Enter Destination" << endl;
        cin >> dest;
        cout << "Enter Duration\n";
        cin >> dura;
        cout << "Enter Description" << endl;
        cin >> desc;
        cout << "Enter Total Price" << endl;
        cin >> pri;
        TourPackage *temparr = new TourPackage[tourPackageSize + 1];
        for (int i = 0; i < tourPackageSize; i++)
        {
            temparr[i] = tourPackageArray[i];
        }

        temparr[tourPackageSize] = TourPackage(pkgname, dest, dura, desc, pri);
        delete[] tourPackageArray;
        tourPackageArray = temparr;
        tourPackageSize = tourPackageSize + 1;
        cout << "Tour Added Successfully\n";
        Writing::writetourpkgToFile(tourPackageArray, tourPackageSize, "Tour Packages.txt");
    }
    void deleteTourPackage()
    {
        system("cls");
        int tid;
        string pkgname;
        string dest;
        string desc;
        double pri;
        int dura;
        int tempIndex;
        cout << "\t\tDelete Tour\n";
        cout << "Enter tout ID" << endl;
        cin >> tid;
        for (int i = 0; i < tourPackageSize; i++)
        {
            if (tourPackageArray[i].getPackageID() == tid)
            {
                tempIndex = i;
                break;
            }
        }
        TourPackage *temparr = new TourPackage[tourPackageSize + 1];
        int j = 0;
        for (int i = 0; i < tourPackageSize; i++)
        {
            if (tempIndex == i)
            {
                continue;
            }
            temparr[j] = tourPackageArray[i];
            j++;
        }
        delete[] tourPackageArray;
        tourPackageArray = temparr;
        tourPackageSize = tourPackageSize + 1;
        cout << "Tour Deleted Successfully\n";
        Writing::writetourpkgToFile(tourPackageArray, tourPackageSize, "Tour Packages.txt");
    }
    void updateTourPackage()
    {
        system("cls");
        int tid;
        string pkgname;
        string dest;
        string desc;
        double pri;
        int dura;
        cout << "\t\tUpdate Tour Package" << endl;
        cout << "Enter Tour ID\n";
        cin >> tid;
        for (int i = 0; i < tourPackageSize; i++)
        {
            if (tourPackageArray[i].getPackageID() == tid)
            {
                cout << "Enter Pakage Name\n";
                cin >> pkgname;
                cout << "Enter Destination" << endl;
                cin >> dest;
                cout << "Enter Duration\n";
                cin >> dura;
                cout << "Enter Description" << endl;
                cin >> desc;
                cout << "Enter Total Price" << endl;
                cin >> pri;
                tourPackageArray[i] = TourPackage(pkgname, dest, dura, desc, pri);
                cout << "Details Updated Successfully\n";
                cout << "Press Any key to go back\n";
                _getch();
                break;
            }
        }
        Writing::writetourpkgToFile(tourPackageArray, tourPackageSize, "Tour Packages.txt");
    }
};
BookingManager *myBookingManager = new BookingManager;
void Writing::writeCustomerToFile(customer *CustomerArray, int customerSize, const string &filename)
{
    ofstream outFile(filename);
    if (!outFile)
    {
        cout << "Unable to open the file for writing.\n";
        return;
    }
    for (int i = 0; i < customerSize; i++)
    {
        outFile << customerArray[i].getCustomerId() << "\n";
        outFile << customerArray[i].getName() << "\n";
        outFile << customerArray[i].getPassword() << "\n";
        outFile << customerArray[i].getEmail() << "\n";
        outFile << customerArray[i].getContactNo() << "\n";
        outFile << customerArray[i].getAddress() << "\n";
        outFile << customerArray[i].getTourBooked() << "\n";
    }
    outFile.close();
}
void Writing::writevehicleToFile(transportation *transportArray, int transportSize, const string &filename)
{
    ofstream outFile(filename);
    if (!outFile.is_open())
    {
        cout << "Unable to open the file for writing.\n";
        return;
    }
    for (int i = 0; i < transportSize; i++)
    {
        outFile << transportArray[i].getVehicleId() << endl;
        outFile << transportArray[i].getVehicleName() << endl;
        outFile << transportArray[i].getVehicleType() << endl;
        outFile << transportArray[i].getCapacity() << endl;
        outFile << transportArray[i].getRegistrationNo() << endl;
        outFile << transportArray[i].getDriverName() << endl;
    }
    outFile.close();
}

void Writing::writehotelsToFile(hotel *hotelArray, int hotelSize, const string &filename)
{
    ofstream outFile(filename);
    if (!outFile.is_open())
    {
        cout << "Unable to open the file for writing.\n";
        return;
    }
    for (int i = 0; i < hotelSize; i++)
    {
        outFile << hotelArray[i].gettourIDAssigned() << endl;
        outFile << hotelArray[i].gethotelid() << endl;
        outFile << hotelArray[i].getHotelName() << endl;
        outFile << hotelArray[i].getHotelContact() << endl;
        outFile << hotelArray[i].getHotelLocation() << endl;
        outFile << hotelArray[i].getHotelRating() << endl;
    }
    outFile.close();
}

void Writing::writetourguideToFile(tourguide *tourguideArray, int tourguideSize, const string &filename)
{
    ofstream outFile(filename);
    if (!outFile.is_open())
    {
        cout << "Unable to open the file for writing.\n";
        return;
    }
    for (int i = 0; i < tourguideSize; i++)
    {
        outFile << tourguideArray[i].getGuideId() << endl;
        outFile << tourguideArray[i].getName() << endl;
        outFile << tourguideArray[i].getContactNumber() << endl;
        outFile << tourguideArray[i].getEmail() << endl;
        outFile << tourguideArray[i].getLanguageSpoken() << endl;
    }
    outFile.close();
}

void Writing::writetourpkgToFile(TourPackage *tourPackageArray, int tourPackageSize, const string &filename)
{
    ofstream outFile(filename);
    if (!outFile.is_open())
    {
        cout << "Unable to open the file for writing.\n";
        return;
    }
    for (int i = 0; i < tourPackageSize; i++)
    {
        outFile << tourPackageArray[i].getPackageID() << endl;
        outFile << tourPackageArray[i].getPackageName() << endl;
        outFile << tourPackageArray[i].getDestination() << endl;
        outFile << tourPackageArray[i].getDescription() << endl;
        outFile << tourPackageArray[i].getDuration() << endl;
        outFile << tourPackageArray[i].getPrice() << endl;
    }
    outFile.close();
}
void Writing::writeTotalBookedTourfromfile(int totalTourBooked, const string &filename)
{
 ofstream outFile(filename);
    if (!outFile.is_open())
    {
        cout << "Unable to open the file for writing Total Tour Booked.\n";
        return;
    }    int id;
    outFile<< totalTourBooked;
}
int Writing::countTotalBookedTourfromfile(const string &filename)
{
    ifstream inFile(filename);
    if (!inFile)
    {
        cout << "Error: Unable to open file for reading  Total Tour Booked." << endl;
        return 0;
    }
    int id;
    inFile >> id;
    return id;
}
void Writing::readCustomerFromFile(customer *customerArray, int customerSize, const string &filename)
{
    ifstream inFile(filename);
    if (!inFile)
    {
        cout << "Error: Unable to open file for reading  Customer." << endl;
        return;
    }
    for (int i = 0; i < customerSize; i++)
    {
        string name, address, contact, email;
        int password, id, tbook;
        inFile >> id >> name >> password >> email >> contact >> address >> tbook;
        customerArray[i].setCustomerID(id);
        customerArray[i].setName(name);
        customerArray[i].setPassword(password);
        customerArray[i].setEmail(email);
        customerArray[i].setContactNo(contact);
        customerArray[i].setAddress(address);
        customerArray[i].setTourBooked(tbook);
    }
    inFile.close();
}
void Writing::readhotelsfromFile(hotel *hotelArray, int hotelSize, const string &filename)
{
    ifstream inFile(filename);
    if (!inFile.is_open())
    {
        cout << "Unable to open the file for Reading Hotels.\n";
        return;
    }
    for (int i = 0; i < hotelSize; i++)
    {
        int hotelId;
        int tourIDAssigned;
        string hotelName;
        string location;
        double rating;
        string contactNumber;
        inFile >> tourIDAssigned >> hotelId >> hotelName >> contactNumber >> location >> rating;
        hotelArray[i].settourIDAssigned(tourIDAssigned);
        hotelArray[i].setHotelID(hotelId);
        hotelArray[i].setHotelName(hotelName);
        hotelArray[i].setHotelContact(contactNumber);
        hotelArray[i].setHotelLocation(location);
        hotelArray[i].setRating(rating);
    }
    inFile.close();
}
void Writing::readVehiclefromFile(transportation *transportArray, int transportSize, const string &filename)
{
    ifstream inFile(filename);
    if (!inFile.is_open())
    {
        cout << "Unable to open the file for Reading Transport Information.\n";
        return;
    }
    for (int i = 0; i < hotelSize; i++)
    {
        int vehicleId;
        string vehicletype;
        string vehicleName;
        int capacity;
        string registrationNo;
        string driverName;
        inFile >> vehicleId >> vehicleName >> vehicletype >> capacity >> registrationNo >> driverName;
        transportArray[i].setVehicleId(vehicleId);
        transportArray[i].setVehicleName(vehicleName);
        transportArray[i].setVehicleType(vehicletype);
        transportArray[i].setCapacity(capacity);
        transportArray[i].setRegistrationNo(registrationNo);
        transportArray[i].setDriverName(driverName);
    }
    inFile.close();
}
void Writing::readtourguidefromFile(tourguide *tourguideArray, int tourguideSize, const string &filename)
{
    ifstream inFile(filename);
    if (!inFile.is_open())
    {
        cout << "Unable to open the file for Reading Tour Guider.\n";
        return;
    }
    for (int i = 0; i < tourguideSize; i++)
    {
        int guideid;
        string Name;
        string contactnumber;
        string email;
        string languagespoken;
        inFile >> guideid >> Name >> contactnumber >> email >> languagespoken;
        tourguideArray[i].setGuideId(guideid);
        tourguideArray[i].setName(Name);
        tourguideArray[i].setContactNumber(contactnumber);
        tourguideArray[i].setEmail(email);
        tourguideArray[i].setLanguageSpoken(languagespoken);
    }
    inFile.close();
}
void Writing::readtourpkgfromFile(TourPackage *tourPackageArray, int tourPackageSize, const string &filename)
{
    ifstream inFile(filename);
    if (!inFile.is_open())
    {
        cout << "Unable to open the file for Reading Tour Packages.\n";
        return;
    }
    for (int i = 0; i < tourPackageSize; i++)
    {
        int packageID;
        string packageName;
        string destination;
        string description;
        double price;
        int duration;
        inFile >> packageID >> packageName >> destination >> description >> duration >> price;

        tourPackageArray[i].setPackageID(packageID);
        tourPackageArray[i].setPackageName(packageName);
        tourPackageArray[i].setDestination(destination);
        tourPackageArray[i].setDescription(description);
        tourPackageArray[i].setDuration(duration);
        tourPackageArray[i].setPrice(price);
    }
    inFile.close();
}
void Writing::readcustmermanagerfromfile(customerManager *myCustomerManager, const string &filename)
{
    ifstream inFile(filename);
    if (!inFile)
    {
        cout << "Unable to open the file for Reading Customer Manager.\n";
        return;
    }
    else
    {

        string na, ad, ro, cnic, cno;
        int pa, id;
        inFile >> id >> na >> pa >> cnic >> ro >> cno >> ad;
        myCustomerManager->setManagerID(id);
        myCustomerManager->setManagerName(na);
        myCustomerManager->setManagerPassword(pa);
        myCustomerManager->setManagerCNIC(cnic);
        myCustomerManager->setManagerRole(ro);
        myCustomerManager->setManagerContactNo(cno);
        myCustomerManager->setManagerAddress(ad);
    }
    inFile.close();
}
void Writing::readHotelmanagerfromfile(HotelManager *myHotelManager, const string &filename)
{
    ifstream inFile(filename);
    if (!inFile)
    {
        cout << "Unable to open the file for Reading Hotel Manager.\n";
        return;
    }
    else
    {

        string na, ad, ro, cnic, cno;
        int pa, id;
        inFile >> id >> na >> pa >> cnic >> ro >> cno >> ad;
        myHotelManager->setManagerID(id);
        myHotelManager->setManagerName(na);
        myHotelManager->setManagerPassword(pa);
        myHotelManager->setManagerCNIC(cnic);
        myHotelManager->setManagerRole(ro);
        myHotelManager->setManagerContactNo(cno);
        myHotelManager->setManagerAddress(ad);
    }
    inFile.close();
}
void Writing::readtransportmanagerfromfile(TransportManager *myTransportManager, const string &filename)
{
    ifstream inFile(filename);
    if (!inFile)
    {
        cout << "Unable to open the file for Reading Transport Manager.\n";
        return;
    }
    else
    {

        string na, ad, ro, cnic, cno;
        int pa, id;
        inFile >> id >> na >> pa >> cnic >> ro >> cno >> ad;
        myTransportManager->setManagerID(id);
        myTransportManager->setManagerName(na);
        myTransportManager->setManagerPassword(pa);
        myTransportManager->setManagerCNIC(cnic);
        myTransportManager->setManagerRole(ro);
        myTransportManager->setManagerContactNo(cno);
        myTransportManager->setManagerAddress(ad);
    }
    inFile.close();
}
void Writing::readbookingmanagerfromfile(BookingManager *myBookingManager, const string &filename)
{
    ifstream inFile(filename);
    if (!inFile)
    {
        cout << "Unable to open the file for Reading Booking Manager.\n";
        return;
    }
    else
    {

        string na, ad, ro, cnic, cno;
        int pa, id;
        inFile >> id >> na >> pa >> cnic >> ro >> cno >> ad;
        myBookingManager->setManagerID(id);
        myBookingManager->setManagerName(na);
        myBookingManager->setManagerPassword(pa);
        myBookingManager->setManagerCNIC(cnic);
        myBookingManager->setManagerRole(ro);
        myBookingManager->setManagerContactNo(cno);
        myBookingManager->setManagerAddress(ad);
    }
    inFile.close();
}
void Writing::readtourguidemanagerfromfile(tourGuideManager *myTourguideManager, const string &filename)
{
    ifstream inFile(filename);
    if (!inFile)
    {
        cout << "Unable to open the file for Reading Tour Guide Manager.\n";
        return;
    }
    else
    {

        string na, ad, ro, cnic, cno;
        int pa, id;
        inFile >> id >> na >> pa >> cnic >> ro >> cno >> ad;
        myTourguideManager->setManagerID(id);
        myTourguideManager->setManagerName(na);
        myTourguideManager->setManagerPassword(pa);
        myTourguideManager->setManagerCNIC(cnic);
        myTourguideManager->setManagerRole(ro);
        myTourguideManager->setManagerContactNo(cno);
        myTourguideManager->setManagerAddress(ad);
    }
    inFile.close();
}
int Writing::countCustomerInFile(const string &filename)
{
    string a;
    int count = 0;
    ifstream inFile(filename);
    if (!inFile)
    {
        cout << "Error: Unable to open file for Counting Customer." << endl;
        return 0;
    }
    while (!inFile.eof())
    {
        getline(inFile, a);
        count++;
    }
    count = count / 7;
    return count;
}
int Writing::countVehiclesInFile(const string &filename)
{
    string a;
    int count = 0;
    ifstream inFile(filename);
    if (!inFile)
    {
        cout << "Error: Unable to open file for Counting Vehicles." << endl;
        return 0;
    }
    while (!inFile.eof())
    {
        getline(inFile, a);
        count++;
    }
    count = count / 6;
    return count;
}
int Writing::countHotelsInFile(const string &filename)
{
    string a;
    int count = 0;
    ifstream inFile(filename);
    if (!inFile)
    {
        cout << "Error: Unable to open file for Counting Hotels." << endl;
        return 0;
    }
    while (!inFile.eof())
    {
        getline(inFile, a);
        count++;
    }
    count = count / 6;
    return count;
}
int Writing::countTourPackageInFile(const string &filename)
{
    string a;
    int count = 0;
    ifstream inFile(filename);
    if (!inFile)
    {
        cout << "Error: Unable to open file for Counting Tour Packages." << endl;
        return 0;
    }
    while (!inFile.eof())
    {
        getline(inFile, a);
        count++;
    }
    count = count / 6;
    return count;
}
int Writing::countTourGuideInFile(const string &filename)
{
    string a;
    int count = 0;
    ifstream inFile(filename);
    if (!inFile)
    {
        cout << "Error: Unable to open file for Counting Tour Guide." << endl;
        return 0;
    }
    while (!inFile.eof())
    {
        getline(inFile, a);
        count++;
    }
    count = count / 5;
    return count;
}
void customer::bookingmenu(customer &obj)
{
    TourBooking *myTourBooking;
    int tpID;
    string htlname;
    string vname;
    cout << "\t\t\tBook A Tour\t\t\n";
    cout << "t\tTour Package Selection\t\t\n";
    BookingManager::displayTourPackages();
    cout << "\t\tEnter Tour PackageID for Booking: ";
    cin >> tpID;
    for (int i = 0; i < tourPackageSize; i++)
    {
        if (tpID == tourPackageArray[i].getPackageID())
        {
            cout << "Tour Selected Successfully.\n";
            cout << "Press any key to continue....";
            getch();
            cout << "\t\tHotel Selection\t\t\n";
            for (int i = 0; i < hotelSize; i++)
            {
                cout << i + 1 << ".\n";
                cout << "Hotel Name: " << hotelArray[i].getHotelName() << "\n";
                cout << "Hotel Rating: " << hotelArray[i].getHotelRating() << "\n";
                cout << "-----------------------------------------------\n";
            }
            cout << "Enter Hotel Name for Booking: ";
            cin >> htlname;
            for (int i = 0; i < hotelSize; i++)
            {
                if (hotelArray[i].getHotelName() == htlname && hotelArray[i].gettourIDAssigned() == tourPackageArray[i].getPackageID())
                {
                    cout << "Hotel Selected Successfully\n";
                    cout << "Press any key to continue....";
                    getch();
                    cout << "\t\tTransport Selection\t\t\n";
                    for (int i = 0; i < transportSize; i++)
                    {
                        cout << i + 1 << ".\n";
                        cout << "Vehicle Name: " << transportArray[i].getVehicleName() << "\n";
                        cout << "Vehicle Type: " << transportArray[i].getVehicleType() << "\n";
                        cout << "Capacity: " << transportArray[i].getCapacity() << "\n";
                        cout << "-----------------------------------------\n";
                    }
                    cout << "Enter Vehicle Name for Booking: ";
                    cin >> vname;
                    for (int i = 0; i < transportSize; i++)
                    {
                        if (transportArray[i].getVehicleName() == vname)
                        {
                            cout << "Vehicle Selected Successfully\n";
                            cout << "Press any key to Continue...\n";
                            getch();
                            myTourBooking = new TourBooking(obj, tourPackageArray[i], htlname, vname);
                            BookingManager::BookTour(*(myTourBooking));
                        }
                        else
                        {
                            cout << "Invalid Name or Hotel Not in Range\n";
                            cout << "Press Key To Go Back.\n";
                            getch();
                            CustomerMenu(obj);
                        }
                    }
                }
                else
                {
                    cout << "Invalid Name or Hotel Not in Range\n";
                    cout << "Press Key To Go Back.\n";
                    getch();
                    CustomerMenu(obj);
                }
            }
        }
        else
        {
            cout << "Invalid TourID...\n";
            cout << "Press Key To Go Back.\n";
            getch();
            CustomerMenu(obj);
        }
    }
}
void mainMenu()
{
    int choice;
    cout << "\t\t\tWelcome to Tour Management System\t\t\t\n";
    cout << "1. Login As Manager\n";
    cout << "2. Login As Customer\n";
    cout << "0. Quit\n";
    cin >> choice;
    switch (choice)
    {
    case 1:
        ManagerLoginMenu();
        break;
    case 2:
        CustomerMainMenu();
        break;
    case 0:
        // Quit
        break;
    default:
        cout << "Wrong Option!!\n";
        mainMenu();
        break;
    }
}
class CustomerLogin
{
private:
public:
    static void Login()
    {
        bool isLogin = false;
        while (true)
        {
            system("cls");
            string n;
            int password;
            cout << "Enter Customer Name: " << endl;
            cin >> n;
            cout << "Enter password: " << endl;
            cin >> password;
            for (int i = 0; i < customerSize; i++)
            {
                if (n == customerArray[i].getName() && password == customerArray[i].getPassword())
                {
                    cout << "Logged In successfully!" << endl;
                    CustomerMenu(customerArray[i]);
                    isLogin = true;
                    return;
                }
            }
            if (isLogin == false)
            {
                cout << "Invalid username or password" << endl;
                Login();
            }
        }
    }
};
void CustomerMenu(customer &obj)
{
    int choice;
    cout << "\t\t\tWelcome To Customer Portal\t\t\t\n";
    cout << "1.View all available Tours\n";
    cout << "2.Book a Tour\n";
    cout << "3.Show Your Information\n";
    cout << "4.Update Your Information\n";
    cout << "5.Give Your Feedback\n";
    cout << "0.LogOut\n";
    cout << "Enter Your choice: ";
    cin >> choice;
    switch (choice)
    {
    case 1:
        BookingManager::displayTourPackages();
        cout << "Press any key to Go Back..\n";
        _getch();
        CustomerMenu(obj);
        break;
    case 2:
        obj.bookingmenu(obj);
        cout << "Press any key to Go Back..\n";
        _getch();
        CustomerMenu(obj);
        break;
    case 3:
        obj.displayInfo();
        cout << "Press any key to Go Back..\n";
        _getch();
        CustomerMenu(obj);
        break;
    case 4:
        obj.updateInfo();
        Writing::writeCustomerToFile(customerArray, customerSize, "Customers");
        cout << "Press any key to Go Back..\n";
        _getch();
        CustomerMenu(obj);
    case 5:
        obj.CustomerFeedback();
        cout << "Press any key to Go Back..\n";
        _getch();
        CustomerMenu(obj);
    case 0:
        mainMenu();
        break;
    }
}
void CustomerMainMenu()
{
    int choice;
    cout << "Welcome to customer menu\n";
    cout << "1. Already Have Account\n";
    cout << "2. Create a New Account\n";
    cout << "Enter Your Choice: \n";
    cin >> choice;
    switch (choice)
    {
    case 1:
        CustomerLogin::Login();
        break;
    case 2:
        customerManager::addcustommer();
        cout << "Press any key to Login..\n";
        getch();
        CustomerLogin::Login();
        break;
    default:
        cout << "Invalid Choice\n";
        CustomerMainMenu();
        break;
    }
}
void ManagerLoginMenu()
{
    system("cls");
    cout << "\t\tWelcome to Managers Login\t\n";
    int choice;
    cout << "1. Login As a Booking Manager.\n";
    cout << "2. Login As a Customer Manager.\n";
    cout << "3. Login As a Transportation Manager.\n";
    cout << "4. Login As a Hotel Manager.\n";
    cout << "5. Login As a TourGuide Manager.\n";
    cout << "0. Go Back.\n";
    cout << "Enter Your Choice: ";
    cin >> choice;
    switch (choice)
    {
    case 1:
        if (myBookingManager->Login() == true)
        {
            myBookingManager->Menu();
        }
        break;
    case 2:
        if (myCustomerManager->Login() == true)
        {
            myCustomerManager->Menu();
        }
        break;
    case 3:
        if (myTransportManager->Login() == true)
        {
            myTransportManager->Menu();
        }
        break;
    case 4:
        if (myHotelManager->Login() == true)
        {
            myHotelManager->Menu();
        }
        break;
    case 5:
        if (myTourGuideManager->Login() == true)
        {
            myTourGuideManager->Menu();
        }
        break;
    case 0:
        mainMenu();
        break;

    default:
        break;
    }
}
string sendfeedback()
{
    string temp;
    cout << "\t\t\tGive Your Feedback\n";
    cout << "Excellent\n";
    cout << "Good\n";
    cout << "Average\n";
    cout << "Bad\n";
    cout << "Enter Your FeedBack: ";
    cin >> temp;
    return temp;
}
int main()
{
    Writing::readcustmermanagerfromfile(myCustomerManager, "Customer Manager Detail.txt");
    Writing::readHotelmanagerfromfile(myHotelManager, "Hotel Manager Detail.txt");
    Writing::readtransportmanagerfromfile(myTransportManager, "Transport Manager Detail.txt");
    Writing::readbookingmanagerfromfile(myBookingManager, "Booking Manager Detail.txt");
    Writing::readtourguidemanagerfromfile(myTourGuideManager, "TourGuide Manager Detail.txt");
    Writing::readCustomerFromFile(customerArray, customerSize, "Customers.txt");
    Writing::readhotelsfromFile(hotelArray, hotelSize, "Hotels.txt");
    Writing::readtourguidefromFile(tourguideArray, tourguideSize, "Tour Guiders.txt");
    Writing::readtourpkgfromFile(tourPackageArray, tourPackageSize, "Tour Packages.txt");
    Writing::readVehiclefromFile(transportArray, transportSize, "Transport Information.txt");
    mainMenu();
}