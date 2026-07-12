#ifndef FILE_H
#define FIle_H
#include <iostream>
#include <fstream>
#include <string.h>
#include <string>
using namespace std;
class customer;
class transportation;
class hotel;
class tourguide;
class customerManager;
class HotelManager;
class TransportManager;
class BookingManager;
class tourGuideManager;
class TourPackage;
class Feedback;
class Writing
{
public:
    static void writeCustomerToFile(customer *CustomerArray, int customerSize, const string &filename);
    static void writevehicleToFile(transportation *transportArray, int transportSize, const string &filename);
    static void writehotelsToFile(hotel *hotelArray, int hotelSize, const string &filename);
    static void writetourguideToFile(tourguide *tourguideArray, int tourguideSize, const string &filename);
    static void writetourpkgToFile(TourPackage *tourPackageArray, int tourPackageSize, const string &filename);
    static void readCustomerFromFile(customer *customerArray, int customerSize, const string &filename);
    static void readhotelsfromFile(hotel *hotelArray, int hotelSize, const string &filename);
    static void readVehiclefromFile(transportation *transportArray, int transportSize, const string &filename);
    static void readtourguidefromFile(tourguide *tourguideArray, int tourguideSize, const string &filename);
    static void readtourpkgfromFile(TourPackage *tourPackageArray, int tourPackageSize, const string &filename);
    static void readcustmermanagerfromfile(customerManager *myCustomerManager, const string &filename);
    static void readHotelmanagerfromfile(HotelManager* myHotelManager, const string& filename);
    static void readtransportmanagerfromfile(TransportManager* myTransportManager, const string& filename);
    static void readbookingmanagerfromfile(BookingManager* myBookingManager, const string& filename);
    static void readtourguidemanagerfromfile(tourGuideManager* myTourguideManager, const string& filename);
    static int countTotalBookedTourfromfile(const string &filename);
    static void writeTotalBookedTourfromfile(int totalTourBooked, const string &filename);
    static int countCustomerInFile(const string &filename);
    static int countVehiclesInFile(const string &filename);
    static int countHotelsInFile(const string &filename);
    static int countTourPackageInFile(const string &filename);
    static int countTourGuideInFile(const string &filename);
};
#endif