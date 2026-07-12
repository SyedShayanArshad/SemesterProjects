#include <iostream>
using namespace std;
#include <fstream>
#include <conio.h>
#include <string>
#include <iomanip>
#include <cstdlib>
#include "tabulate.h"
using namespace tabulate;
void AdminMainMenu();
void UserLoginMenu();
void UserMainMenu();
void mainMenu();
void updateDataInFileHandling();
template <typename T>
class Node
{
public:
    T data;
    Node* next;
    Node(T val)
    {
        data = val;
        next = NULL;
    }
};
template <typename T>
class myStack
{
public:
    Node<T>* head;
    myStack()
    {
        head = NULL;
    }
    bool isEmpty()
    {
        return head == NULL;
    }
    T top()
    {
        if (isEmpty())
        {
            throw runtime_error("Stack is empty");
        }
        return head->data;
    }
    int size()
    {
        int count = 0;
        Node<T>* temp = head;
        while (temp != NULL)
        {
            count++;
            temp = temp->next;
        }
        return count;
    }

    void display()
    {
        if (isEmpty())
        {
            cout << "Stack is empty" << endl;
            return;
        }
        Node<T>* temp = head;
        while (temp != NULL)
        {
            cout << temp->data << " ";
            temp = temp->next;
        }
        cout << endl;
    }

    void push(T value)
    {
        Node<T>* temp = new Node<T>(value);
        temp->next = head;
        head = temp;
    }

    T pop()
    {
        if (isEmpty())
        {
            throw runtime_error("Stack underflow");
        }
        Node<T>* delNode = head;
        T delData = delNode->data;
        head = head->next;
        delete delNode;
        return delData;
    }

};
template <typename T>
class myQueue
{
private:
    Node<T>* front;
    Node<T>* rear;
    int count;

    void clearQueue()
    {
        while (!empty())
        {
            dequeue();
        }
    }

    void deepCopy(const myQueue<T>& other)
    {
        Node<T>* current = other.front;
        while (current)
        {
            enqueue(current->data);
            current = current->next;
        }
    }

public:
    myQueue() : front(NULL), rear(NULL), count(0) {}
    myQueue(const myQueue<T>& other) : front(NULL), rear(NULL), count(0)
    {
        deepCopy(other);
    }
    myQueue<T>& operator=(const myQueue<T>& other)
    {
        if (this != &other)
        {
            clearQueue();
            deepCopy(other);
        }
        return *this;
    }
    bool empty()
    {
        return count == 0;
    }
    int size()
    {
        return count;
    }
    void enqueue(T value)
    {
        Node<T>* newNode = new Node<T>(value);
        if (empty())
        {
            front = newNode;
        }
        else
        {
            rear->next = newNode;
        }
        rear = newNode;
        count++;
    }
    void dequeue()
    {
        if (empty())
        {
            throw runtime_error("Queue underflow: cannot dequeue from an empty queue.");
        }
        Node<T>* delNode = front;
        front = front->next;
        delete delNode;
        count--;
        if (front == NULL)
        {
            rear = NULL;
        }
    }
    T frontData()
    {
        if (empty())
        {
            throw runtime_error("Queue is empty: cannot access front element.");
        }
        return front->data;
    }
};
template <typename T>
class BNode
{
public:
    T data;
    BNode* left;
    BNode* right;
    BNode* parent;
    BNode(T val)
    {
        data = val;
        left = right = parent = nullptr;
    }
};
class Slot
{
private:
    string date;
    string time;
    bool isBook;

public:
    Slot(string date, string time)
    {
        this->date = date;
        this->time = time;
        this->isBook = false;
    }
    Slot()
    {
        date = "";
        time = "";
        isBook = false;
    }
    void displaySlots()
    {
        cout << "Slot Details:\n";
        cout << "Date: " << date << endl;
        cout << "Time: " << time << endl;
        cout << "Booked: " << (isBook ? "Yes" : "No") << endl;
    }
    void saveToFile(ofstream& outFile)
    {
        outFile << date << endl;
        outFile << time << endl;
        outFile << isBook << endl;
    }
    void loadFromFile(ifstream& inFile)
    {
        getline(inFile, date);
        getline(inFile, time);
        inFile >> isBook;
        inFile.ignore();
    }
    string getDate()
    {
        return date;
    }
    string getTime()
    {
        return time;
    }
    bool isBooked()
    {
        return isBook;
    }
    void setBooked(bool B)
    {
        isBook = B;
    }
};
template <typename T>
class BST
{
public:
    BNode<T>* root;
    BST()
    {
        root = nullptr;
    }
    BNode<T>* insert(T val, BNode<T>* Node)
    {
        if (Node == nullptr)
        {
            return new BNode<T>(val);
        }
        if (val.getDate() < Node->data.getDate() ||
            (val.getDate() == Node->data.getDate() && val.getTime() < Node->data.getTime()))
        {
            Node->left = insert(val, Node->left);
            Node->left->parent = Node;
        }
        else if (val.getDate() > Node->data.getDate() ||
            (val.getDate() == Node->data.getDate() && val.getTime() > Node->data.getTime()))
        {
            Node->right = insert(val, Node->right);
            Node->right->parent = Node;
        }
        else
        {
            cout << "Cannot insert duplicate value: " << val.getDate() << " " << val.getTime() << endl;
        }
        return Node;
    }
    BNode<T>* search(string date, string time, BNode<T>* Node)
    {
        if (Node == nullptr)
        {
            return nullptr;
        }
        if (Node->data.getDate() == date && Node->data.getTime() == time)
        {
            return Node;
        }
        else if (date < Node->data.getDate() || (date == Node->data.getDate() && time < Node->data.getTime()))
        {
            return search(date, time, Node->left);
        }
        else
        {
            return search(date, time, Node->right);
        }
    }
    void insertSlot(T val)
    {
        root = insert(val, root);
    }
    BNode<T>* searchSlot(string date, string time)
    {
        return search(date, time, root);
    }
    void viewInOrder(BNode<T>* Node)
    {
        if (Node != nullptr)
        {
            viewInOrder(Node->left);
            Node->data.displaySlots();
            cout << "--------------------\n";
            viewInOrder(Node->right);
        }
    }
    T Max(BNode<T>* Node)
    {
        if (Node == nullptr)
        {
            throw runtime_error("Tree is empty");
        }
        while (Node->right != nullptr)
        {
            Node = Node->right;
        }
        return Node->data;
    }
    T Min(BNode<T>* Node)
    {
        if (Node == nullptr)
        {
            throw runtime_error("Tree is empty");
        }
        while (Node->left != nullptr)
        {
            Node = Node->left;
        }
        return Node->data;
    }
    BNode<T>* searchNode(T val, BNode<T>* Node)
    {
        if (Node == nullptr)
        {
            return nullptr;
        }
        if (Node->data == val)
        {
            return Node;
        }
        else if (val < Node->data)
        {
            return searchNode(val, Node->left);
        }
        else
        {
            return searchNode(val, Node->right);
        }
    }

    void deleteFun(BNode<T>* Node, T value)
    {
        BNode<T>* targetNode = searchNode(value, Node);

        if (targetNode == nullptr)
        {
            cout << "Value not found in the tree." << endl;
            return;
        }
        if (targetNode->left == nullptr && targetNode->right == nullptr)
        {
            if (targetNode == root)
            {
                root = nullptr;
            }
            else
            {
                if (targetNode->parent->left == targetNode)
                {
                    targetNode->parent->left = nullptr;
                }
                else
                {
                    targetNode->parent->right = nullptr;
                }
            }
            delete targetNode;
        }
        else if (targetNode->left == nullptr || targetNode->right == nullptr)
        {
            BNode<T>* child = (targetNode->left != nullptr) ? targetNode->left : targetNode->right;

            if (targetNode == root)
            {
                root = child;
            }
            else
            {
                if (targetNode->parent->left == targetNode)
                {
                    targetNode->parent->left = child;
                }
                else
                {
                    targetNode->parent->right = child;
                }
            }
            child->parent = targetNode->parent;
            delete targetNode;
        }
        else
        {
            BNode<T>* successor = targetNode->right;
            while (successor->left != nullptr)
            {
                successor = successor->left;
            }

            targetNode->data = successor->data;
            deleteFun(successor, successor->data);
        }
    }
    int height(BNode<T>* Node)
    {
        if (Node == nullptr)
        {
            return 0;
        }
        int leftHeight = height(Node->left);
        int rightHeight = height(Node->right);
        return max(leftHeight, rightHeight) + 1;
    }

    void printInOrder()
    {
        viewInOrder(root);
        cout << endl;
    }
    int getHeight()
    {
        return height(root);
    }
    void save(BNode<T>* Node, ofstream& outFile)
    {
        if (Node != nullptr)
        {
            save(Node->left, outFile);
            Node->data.saveToFile(outFile);
            save(Node->right, outFile);
        }
    }
    void saveToFile(string filename)
    {
        ofstream outFile(filename);
        if (!outFile)
        {
            cout << "Error opening file for writing: " << filename << endl;
            return;
        }
        save(root, outFile);
        outFile.close();
    }
    void loadFromFile(string filename)
    {
        ifstream inFile(filename);
        if (!inFile)
        {
            cout << "Error opening file for reading: " << filename << endl;
            return;
        }

        while (!inFile.eof())
        {
            Slot slot;
            slot.loadFromFile(inFile);
            if (slot.getDate() != "" && slot.getTime() != "")
            {
                insertSlot(slot);
            }
        }
        inFile.close();
    }
};
BST<Slot>* SlotTree = new BST<Slot>();
int countUserInFile(const string& filename)
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
class User
{
private:
    static int userIDCounter;
    int userID;
    string username;
    string password;
    string name;
    string email;
    string address;
    string phoneNo;

public:
    User* next;
    User() { next = NULL; }
    User(string uName, string pass, string n, string e, string ad, string phone)
    {
        userID = ++userIDCounter;
        next = NULL;
        username = uName;
        password = pass;
        name = n;
        email = e;
        address = ad;
        phoneNo = phone;
    }
    bool isLogin(string uName, string pwd)
    {
        return (username == uName && password == pwd);
    }
    void loadFromFile(ifstream& inFile)
    {
        inFile >> userID;
        inFile.ignore();
        getline(inFile, username);
        getline(inFile, password);
        getline(inFile, name);
        getline(inFile, email);
        getline(inFile, address);
        getline(inFile, phoneNo);
    }
    void saveToFile(ofstream& outFile)
    {
        outFile << userID << endl
            << username << endl
            << password << endl
            << name << endl
            << email << endl
            << address << endl
            << phoneNo << endl;
    }
    void updateProfile()
    {
        int option;
        cout << "\t\t\tUpdate Your Information\t\t\t\n";
        cout << "Please select the following number to update.\n";
        cout << "1. Username\n 2. Password: \n 3. Name\n 4. Email\n 5.Address\n 6.Phone Number\n";
        cout << "Enter your choice: ";
        cin >> option;
        switch (option)
        {
        case 1:
            cout << "Enter new username: ";
            cin >> username;
            break;
        case 2:
            cout << "Enter new password: ";
            cin >> password;
            break;
        case 3:
            cout << "Enter new name: ";
            cin.ignore();
            getline(cin, name);
            break;
        case 4:
            cout << "Enter new email: ";
            cin >> email;
            break;
        case 5:
            cout << "Enter new address: ";
            cin.ignore();
            getline(cin, address);
            break;
        case 6:
            cout << "Enter new phone number (xxxx-xxxxxxx): ";
            cin >> phoneNo;
            break;
        default:
            cout << "Invalid choice!";
        }
        updateDataInFileHandling();
        cout << "\nProfile updated successfully!\n";
        cout << "Press any key to continue...\n";
        _getch();
    }
    void displayInformation()
    {
        cout << "\t\t\tUser Information.\n";
        cout << "User ID: " << userID << endl;
        cout << "Name: " << name << endl;
        cout << "Email: " << email << endl;
        cout << "Address: " << address << endl;
        cout << "Phone: " << phoneNo << endl;
        cout << "Username: " << username << endl;
        cout << "Password: " << password << endl;
    }
    int getUserID() { return userID; }
    string getEmail() { return email; }
    string getAddress() { return address; }
    string getPhoneNO() { return phoneNo; }
    string getUserName() { return username; }
    string getName() { return name; }
    string getPassword() { return password; }
    void setUserID(int u) { userID = u; }
};
int User::userIDCounter = countUserInFile("Users.txt");
class UsersList
{
public:
    User* head;
    UsersList() { head = NULL; }
    void insertUser(User* U)
    {
        if (head == NULL)
        {
            head = U;
        }
        else
        {
            User* temp = head;
            while (temp->next != NULL)
            {
                temp = temp->next;
            }
            temp->next = U;
        }
    }
    void loadUsers(const string& filename)
    {
        ifstream inFile(filename);
        if (!inFile)
        {
            cout << "No user file found. Starting fresh." << endl;
            return;
        }
        while (!inFile.eof())
        {
            User* U = new User();
            U->loadFromFile(inFile);
            if (inFile)
            {
                insertUser(U);
            }
        }
        inFile.close();
    }
    void saveUsers(const string& filename)
    {
        ofstream outFile(filename);
        User* temp = head;
        while (temp != NULL)
        {
            temp->saveToFile(outFile);
            temp = temp->next;
        }
        outFile.close();
    }
    User* findUser(string username, string password)
    {
        User* temp = head;
        while (temp != NULL)
        {
            if (temp->isLogin(username, password))
                return temp;
            temp = temp->next;
        }
        return NULL;
    }
    User* findUserByID(int userID)
    {
        User* temp = head;
        while (temp != nullptr)
        {
            if (temp->getUserID() == userID)
                return temp;
            temp = temp->next;
        }
        return nullptr;
    }
    void display()
    {
        system("cls");
        Table usersTable;
        cout << "\t\t\tAll Users\n";
        usersTable.add_row({ "ID", "Name", "Email", "Address", "Phone", "Username", "Password" });
        for (size_t i = 0; i < 7; ++i)
        {
            usersTable[0][i].format().font_color(Color::red).font_align(FontAlign::center).font_style({ FontStyle::bold });
        }
        User* temp = head;
        while (temp != NULL)
        {
            usersTable.add_row({ std::to_string(temp->getUserID()),
                                temp->getName(),
                                temp->getEmail(),
                                temp->getAddress(),
                                temp->getPhoneNO(),
                                temp->getUserName(),
                                temp->getPassword() });

            temp = temp->next;
        }
        cout << usersTable << endl;
    }
};
UsersList* AllUsersList = new UsersList();
User* LoginUser = NULL;
class StatusNode
{
public:
    string status;
    StatusNode* next;
    StatusNode* adj;
    StatusNode(string s)
    {
        status = s;
        next = nullptr;
        adj = nullptr;
    }
    void addTransition(StatusNode* toStatus)
    {
        StatusNode* temp = adj;
        while (temp != nullptr)
        {
            if (temp == toStatus)
                return;
            temp = temp->next;
        }
        StatusNode* newAdjNode = new StatusNode(toStatus->status);
        newAdjNode->next = adj;
        adj = newAdjNode;
    }
};

class StatusGraph
{
private:
    StatusNode* head;

public:
    StatusGraph()
    {
        head = nullptr;
    }
    ~StatusGraph()
    {
        while (head != nullptr)
        {
            StatusNode* temp = head;
            head = head->next;
            delete temp;
        }
    }
    void addStatus(string status)
    {
        if (findStatus(status) == nullptr)
        {
            StatusNode* newNode = new StatusNode(status);
            newNode->next = head;
            head = newNode;
        }
    }

    void addTransition(string fromStatus, string toStatus)
    {
        StatusNode* from = findStatus(fromStatus);
        StatusNode* to = findStatus(toStatus);
        if (from != nullptr && to != nullptr)
        {
            from->addTransition(to);
        }
        else
        {
            cout << "Error: One or both statuses not found.\n";
        }
    }
    void displayNextStatuses(string currentStatus)
    {
        StatusNode* current = findStatus(currentStatus);
        if (current == nullptr)
        {
            cout << "Error: Status '" << currentStatus << "' not found.\n";
            return;
        }
        if (current->adj == nullptr)
        {
            cout << "No further stages available from '" << currentStatus << "'.\n";
            return;
        }
        cout << "Next Possible Stages from '" << currentStatus << "': ";
        StatusNode* adj = current->adj;
        while (adj != nullptr)
        {
            cout << adj->status << " ";
            adj = adj->next;
        }
        cout << endl;
    }
    string getNextStatus(string currentStatus)
    {
        StatusNode* current = findStatus(currentStatus);
        if (current == nullptr)
        {
            cout << "Error: Status '" << currentStatus << "' not found.\n";
            return "";
        }
        StatusNode* adjacent = current->adj;
        if (adjacent == nullptr)
        {
            cout << "No further status transitions available from '" << currentStatus << "'.\n";
            return "";
        }
        cout << "Select the next status from the following options:\n";
        int count = 0;
        StatusNode* temp = adjacent;
        while (temp != nullptr)
        {
            count++;
            cout << count << ". " << temp->status << endl;
            temp = temp->next;
        }
        int choice;
        do
        {
            cout << "Enter your choice (1-" << count << "): ";
            cin >> choice;
            if (choice < 1 || choice > count)
                cout << "Invalid choice. Please try again.\n";
        } while (choice < 1 || choice > count);
        temp = adjacent;
        for (int i = 1; i < choice; i++)
        {
            temp = temp->next;
        }
        return temp->status;
    }
    StatusNode* findStatus(string status)
    {
        StatusNode* temp = head;
        while (temp != nullptr)
        {
            if (temp->status == status)
                return temp;
            temp = temp->next;
        }
        return nullptr;
    }
    void printGraph()
    {
        StatusNode* temp = head;
        while (temp != nullptr)
        {
            cout << "Status: " << temp->status << " can transition to: ";
            StatusNode* adj = temp->adj;
            while (adj != nullptr)
            {
                cout << adj->status << " ";
                adj = adj->next;
            }
            cout << endl;
            temp = temp->next;
        }
    }
};
StatusGraph* setupStatusGraph()
{
    StatusGraph* statusGraph = new StatusGraph();
    statusGraph->addStatus("Booked");
    statusGraph->addStatus("In Progress");
    statusGraph->addStatus("Verified");
    statusGraph->addStatus("Rejected");

    statusGraph->addTransition("Booked", "In Progress");
    statusGraph->addTransition("In Progress", "Verified");
    statusGraph->addTransition("In Progress", "Rejected");

    return statusGraph;
}
StatusGraph* myStatusGraph = setupStatusGraph();
class Appointment
{
private:
    static int appointmentCounter;
    int appointmentID;
    Slot appointmentSlot;
    User* appointmentUser;
    string status;
    string documentPath;
    bool isUrgent;
    StatusGraph* statusGraph;

public:
    Appointment(Slot slot, User* user, bool urgent, string docPath, StatusGraph* graph)
    {
        appointmentID = ++appointmentCounter;
        appointmentSlot = slot;
        appointmentUser = user;
        isUrgent = urgent;
        documentPath = docPath;
        status = "Booked";
        statusGraph = graph;
    }
    Appointment() {};
    Slot getSlot() const
    {
        return appointmentSlot;
    }
    User* getUser() const
    {
        return appointmentUser;
    }
    int getAppointmentID()
    {
        return appointmentID;
    }
    string getStatus() const
    {
        return status;
    }
    void setStatus(string s)
    {
        status = s;
    }
    string getDocumentPath() const
    {
        return documentPath;
    }
    void setDocumentPath(string docPath)
    {
        documentPath = docPath;
    }
    bool getIsUrgent() const
    {
        return isUrgent;
    }
    void displayAppointmentDetails()
    {
        cout << "Appointment Details:" << endl;
        appointmentSlot.displaySlots();
        cout << "User ID: " << appointmentUser->getUserID() << endl;
        cout << "Username: " << appointmentUser->getUserName() << endl;
        cout << "Status: " << status << endl;
        cout << "Document Path: " << documentPath << endl;
        cout << "Urgency: " << (isUrgent ? "Yes" : "No") << endl;
    }
};
int Appointment::appointmentCounter = 0;
int partitionByDate(Appointment* appointments, int size)
{
    int mid = size / 2;
    int index = 0;
    swap(appointments[0], appointments[mid]);
    for (int k = 1; k < size; k++) {
        if (appointments[k].getSlot().getDate() < appointments[0].getSlot().getDate()) {
            index++;
            swap(appointments[k], appointments[index]);
        }
    }
    swap(appointments[0], appointments[index]);
    return index;
}
void SortByDate(Appointment* appointments, int size)
{
    int index;
    if (size > 1) {
        index = partitionByDate(appointments, size);
        SortByDate(appointments, index);
        SortByDate(appointments + index + 1, size - index - 1);
    }
}
int partitionByTime(Appointment* appointments, int size)
{
    int mid = size / 2;
    int index = 0;
    swap(appointments[0], appointments[mid]);
    for (int k = 1; k < size; k++) {
        if (appointments[k].getSlot().getTime() < appointments[0].getSlot().getTime()) {
            index++;
            swap(appointments[k], appointments[index]);
        }
    }
    swap(appointments[0], appointments[index]);
    return index;
}
void SortByTime(Appointment* appointments, int size)
{
    int index;
    if (size > 1) {
        index = partitionByTime(appointments, size);
        SortByTime(appointments, index);
        SortByTime(appointments + index + 1, size - index - 1);
    }
}
class AppointmentQueue
{
private:
    myQueue<Appointment> normalQueue;
    myQueue<Appointment> urgentQueue;
    myQueue<Slot> urgentSlotsQueue;
    const int maxUrgentAppointments = 5;

public:
    AppointmentQueue() {}
    void addUrgentSlot(Slot& urgentSlot)
    {
        if (urgentSlotsQueue.size() >= maxUrgentAppointments)
        {
            cout << "Maximum urgent slots for the day reached.\n";
            return;
        }
        urgentSlotsQueue.enqueue(urgentSlot);
        saveUrgentSlotsToFile();
    }
    bool addAppointment(Appointment appointment)
    {
        if (appointment.getIsUrgent())
        {
            if (urgentQueue.size() < maxUrgentAppointments)
            {
                urgentQueue.enqueue(appointment);
                cout << "Urgent Appointment Added!" << endl;
                return true;
            }
            else
            {
                cout << "Cannot add more urgent appointments for today." << endl;
                return false;
            }
        }
        else
        {
            normalQueue.enqueue(appointment);
            cout << "Normal Appointment Added!" << endl;
            return true;
        }
    }
    void UpdateAppointmentStatus(myQueue<Appointment>& queue)
    {
        if (queue.empty())
        {
            cout << "No appointments to process.\n";
            return;
        }
        int queueSize = queue.size();
        for (int i = 0; i < queueSize; i++)
        {
            Appointment app = queue.frontData();
            queue.dequeue();
            if (app.getStatus() == "Verified" || app.getStatus() == "Rejected" || app.getStatus() == "Cancelled")
            {
                queue.enqueue(app);
                continue;
            }
            cout << "\nAppointment:\n";
            app.displayAppointmentDetails();
            const string pathFile = "selected_file_path.txt";
            string filePath = app.getDocumentPath();
            char openChoice;
            cout << "Do you want to open the Document to proceed? (y/n): ";
            cin >> openChoice;
            if (openChoice == 'y' || openChoice == 'Y')
            {
                string command = "start \"\" \"" + filePath + "\"";
                system(command.c_str());
                cout << "Opening file...\n";
            }
            cout << "\nCurrent Status: " << app.getStatus() << endl;
            string nextStatus = myStatusGraph->getNextStatus(app.getStatus());
            if (!nextStatus.empty())
            {
                app.setStatus(nextStatus);
                cout << "Status updated to: " << nextStatus << endl;
            }
            else
            {
                cout << "No further status transitions available.\n";
            }
            queue.enqueue(app);
            char continueChoice;
            if (i < queueSize - 1)
            {
                cout << "\nDo you want to continue to the next appointment? (y/n): ";
                cin >> continueChoice;

                if (continueChoice == 'n' || continueChoice == 'N')
                {
                    cout << "Stopping appointment processing.\n";
                    break;
                }
            }
        }
    }
    void UpdateAppointmentStatus()
    {
        system("cls");
        cout << "\t\t\tAdmin: Update Appointment Status\n";

        cout << "\nProcessing Urgent Appointments...\n";
        UpdateAppointmentStatus(urgentQueue);

        cout << "\nProcessing Normal Appointments...\n";
        UpdateAppointmentStatus(normalQueue);

        saveAppointmentsToFile();

        cout << "All appointments have been processed or the process was stopped by the user.\n";
        cout << "Press any key to return to the admin menu...\n";
        _getch();
    }
    void trackYourAppointment()
    {
        system("cls");
        cout << "\t\t\tTrack Your Appointment Status\n";
        bool hasAppointments = false;
        myQueue<Appointment> tempUrgentQueue = urgentQueue;
        myQueue<Appointment> tempNormalQueue = normalQueue;
        while (!tempUrgentQueue.empty())
        {
            Appointment app = tempUrgentQueue.frontData();
            tempUrgentQueue.dequeue();
            if (app.getUser() == LoginUser && app.getStatus() != "Verified" && app.getStatus() != "Rejected" && app.getStatus() != "Cancelled")
            {
                cout << "\nUrgent Appointment Found:\n";
                app.displayAppointmentDetails();
                myStatusGraph->displayNextStatuses(app.getStatus());
                hasAppointments = true;
            }
        }
        while (!tempNormalQueue.empty())
        {
            Appointment app = tempNormalQueue.frontData();
            tempNormalQueue.dequeue();
            if (app.getUser() == LoginUser && app.getStatus() != "Verified" && app.getStatus() != "Rejected")
            {
                cout << "\nNormal Appointment Found:\n";
                app.displayAppointmentDetails();
                myStatusGraph->displayNextStatuses(app.getStatus());
                hasAppointments = true;
            }
        }
        if (!hasAppointments)
        {
            cout << "You have no pending appointments to track.\n";
        }
        cout << "Press any key to go back.\n";
        _getch();
    }
    void cancelAppointment()
    {
        system("cls");
        cout << "\t\t\tCancel Appointment\n";
        Table appointmentsTable;
        appointmentsTable.add_row({ "ID", "Date", "Time", "Type", "Status", "Document Path" });
        for (size_t i = 0; i < 6; ++i)
        {
            appointmentsTable[0][i].format().font_color(Color::red).font_align(FontAlign::center).font_style({ FontStyle::bold });
        }
        bool hasAppointments = false;
        myQueue<Appointment> tempUrgentQueue = urgentQueue;
        myQueue<Appointment> tempNormalQueue = normalQueue;
        while (!tempUrgentQueue.empty())
        {
            Appointment app = tempUrgentQueue.frontData();
            tempUrgentQueue.dequeue();
            if (app.getUser() == LoginUser && app.getStatus() != "Verified" && app.getStatus() != "Rejected" && app.getStatus() != "Cancelled")
            {
                appointmentsTable.add_row({ std::to_string(app.getUser()->getUserID()),
                                           app.getSlot().getDate(),
                                           app.getSlot().getTime(),
                                           "Urgent",
                                           app.getStatus(),
                                           app.getDocumentPath() });
                hasAppointments = true;
            }
        }
        while (!tempNormalQueue.empty())
        {
            Appointment app = tempNormalQueue.frontData();
            tempNormalQueue.dequeue();
            if (app.getUser() == LoginUser && app.getStatus() != "Verified" && app.getStatus() != "Rejected" && app.getStatus() != "Cancelled")
            {
                appointmentsTable.add_row({ std::to_string(app.getUser()->getUserID()),
                                           app.getSlot().getDate(),
                                           app.getSlot().getTime(),
                                           "Normal",
                                           app.getStatus(),
                                           app.getDocumentPath() });
                hasAppointments = true;
            }
        }
        if (!hasAppointments)
        {
            cout << "You have no appointments to cancel.\n";
            cout << "Press any key to go back.\n";
            _getch();
            return;
        }
        cout << "\nYour Booked Appointments:\n";
        cout << appointmentsTable << endl;
        char confirm;
        cout << "\nDo you want to cancel an appointment? (Y/N): ";
        cin >> confirm;

        if (confirm != 'Y' && confirm != 'y')
        {
            cout << "\nCancellation process aborted. Returning to the Main Menu...\n";
            cout << "Press any key to continue...\n";
            _getch();
            return;
        }
        string date, time;
        cout << "\nEnter the Date of the Appointment to Cancel (DD-MM-YYYY): ";
        cin >> date;
        cout << "Enter the Time of the Appointment to Cancel (HH:MM): ";
        cin >> time;
        bool isCancelled = false;
        myQueue<Appointment> updatedUrgentQueue, updatedNormalQueue;
        while (!urgentQueue.empty())
        {
            Appointment app = urgentQueue.frontData();
            urgentQueue.dequeue();
            if (app.getUser() == LoginUser && app.getSlot().getDate() == date && app.getSlot().getTime() == time)
            {
                cout << "\nAppointment Marked as 'Cancelled' (Urgent).\n";
                app.setStatus("Cancelled");
                app.getSlot().setBooked(false);
                isCancelled = true;
            }
            updatedUrgentQueue.enqueue(app);
        }
        while (!normalQueue.empty())
        {
            Appointment app = normalQueue.frontData();
            normalQueue.dequeue();

            if (app.getUser() == LoginUser && app.getSlot().getDate() == date && app.getSlot().getTime() == time)
            {
                cout << "\nAppointment Marked as 'Cancelled' (Normal).\n";
                app.setStatus("Cancelled");
                app.getSlot().setBooked(false);
                isCancelled = true;
            }
            updatedNormalQueue.enqueue(app);
        }
        urgentQueue = updatedUrgentQueue;
        normalQueue = updatedNormalQueue;
        if (!isCancelled)
        {
            cout << "\nNo matching appointment found. Please check the Date and Time.\n";
        }
        saveAppointmentsToFile();
        SlotTree->saveToFile("NormalSlots.txt");
        saveUrgentSlotsToFile();
        cout << "\nPress any key to return to the menu...\n";
        _getch();
    }

    void bookNewAppointment()
    {
        system("cls");
        char appointmentType;
        cout << "Do you want an Urgent appointment or Normal appointment? (u/n): ";
        cin >> appointmentType;

        if (appointmentType == 'u' || appointmentType == 'U')
        {
            if (urgentSlotsQueue.empty())
            {
                cout << "No urgent slots available at the moment.\n";
                return;
            }
            Slot urgentSlot = urgentSlotsQueue.frontData();
            urgentSlotsQueue.dequeue();
            cout << "Urgent Slot Details:\n";
            urgentSlot.displaySlots();
            cout << "\nUrgent appointments cost 50% more than normal appointments.\n";
            cout << "Do you want to book this appointment? (y/n): ";
            char confirm;
            cin >> confirm;
            if (confirm == 'y' || confirm == 'Y')
            {
                cin.ignore();
                string documentPath;
                cout << "Enter the document path for verification: ";
                getline(cin, documentPath);
                Appointment newAppointment(urgentSlot, LoginUser, true, documentPath, myStatusGraph);
                if (addAppointment(newAppointment))
                {
                    cout << "Your urgent appointment has been successfully booked!\n";
                    newAppointment.displayAppointmentDetails();
                    saveUrgentSlotsToFile();
                }
            }
            else
            {
                cout << "You have canceled the urgent appointment booking.\n";
            }
        }
        else if (appointmentType == 'n' || appointmentType == 'N')
        {
            cout << "Available Normal Slots:\n";
            SlotTree->printInOrder();
            string date, time;
            cout << "\nEnter the date of the appointment (DD-MM-YYYY): ";
            cin >> date;
            cout << "Enter the time of the appointment (HH:MM): ";
            cin >> time;
            BNode<Slot>* selectedSlot = SlotTree->searchSlot(date, time);
            if (selectedSlot == nullptr || selectedSlot->data.isBooked())
            {
                cout << "Slot is not available or already booked.\n";
                return;
            }
            cout << "Selected Slot Details:\n";
            selectedSlot->data.displaySlots();
            cout << "Do you want to book this slot? (y/n): ";
            char confirm;
            cin >> confirm;
            if (confirm == 'y' || confirm == 'Y')
            {
                cin.ignore();
                string documentPath;
                cout << "Enter the document path for verification: ";
                getline(cin, documentPath);
                Appointment newAppointment(selectedSlot->data, LoginUser, false, documentPath, myStatusGraph);
                if (addAppointment(newAppointment))
                {
                    selectedSlot->data.setBooked(true);
                    SlotTree->saveToFile("NormalSlots.txt");
                    cout << "Your normal appointment has been successfully booked!\n";
                    newAppointment.displayAppointmentDetails();
                }
            }
            else
            {
                cout << "You have canceled the normal appointment booking.\n";
            }
        }
        else
        {
            cout << "Invalid choice. Please try again.\n";
        }
        saveAppointmentsToFile();
    }
    void saveUrgentSlotsToFile()
    {
        ofstream outFile("UrgentSlots.txt");

        if (!outFile.is_open())
        {
            cout << "Error: Could not open file for saving urgent slots.\n";
            return;
        }
        myQueue<Slot> tempQueue = urgentSlotsQueue;
        while (!tempQueue.empty())
        {
            Slot slot = tempQueue.frontData();
            slot.saveToFile(outFile);
            tempQueue.dequeue();
        }
        outFile.close();
    }
    void loadUrgentSlotsFromFile()
    {
        ifstream inFile("UrgentSlots.txt");

        if (!inFile.is_open())
        {
            cout << "Error: Could not open file for loading urgent slots.\n";
            return;
        }
        while (inFile.peek() != EOF)
        {
            Slot slot;
            slot.loadFromFile(inFile);
            urgentSlotsQueue.enqueue(slot);
        }
        inFile.close();
    }
    void saveAppointmentsToFile()
    {
        ofstream urgentFile("UrgentAppointments.txt");
        ofstream normalFile("NormalAppointments.txt");
        myQueue<Appointment> urgentTemp = urgentQueue;
        while (!urgentTemp.empty())
        {
            Appointment app = urgentTemp.frontData();
            urgentTemp.dequeue();
            urgentFile << app.getSlot().getDate() << endl;
            urgentFile << app.getSlot().getTime() << endl;
            urgentFile << app.getUser()->getUserID() << endl;
            urgentFile << app.getStatus() << endl;
            urgentFile << app.getDocumentPath() << endl;
            urgentFile << (app.getIsUrgent() ? "Yes" : "No") << endl;
        }
        myQueue<Appointment> normalTemp = normalQueue;
        while (!normalTemp.empty())
        {
            Appointment app = normalTemp.frontData();
            normalTemp.dequeue();
            normalFile << app.getSlot().getDate() << endl;
            normalFile << app.getSlot().getTime() << endl;
            normalFile << app.getUser()->getUserID() << endl;
            normalFile << app.getStatus() << endl;
            normalFile << app.getDocumentPath() << endl;
            normalFile << (app.getIsUrgent() ? "Yes" : "No") << endl;
        }
        urgentFile.close();
        normalFile.close();
    }
    void loadAppointmentsFromFile()
    {
        ifstream urgentFile("UrgentAppointments.txt");
        ifstream normalFile("NormalAppointments.txt");
        string date, time, status, documentPath, isUrgentStr;
        int userID;
        while (getline(urgentFile, date))
        {
            getline(urgentFile, time);
            urgentFile >> userID;
            urgentFile.ignore();
            getline(urgentFile, status);
            getline(urgentFile, documentPath);
            getline(urgentFile, isUrgentStr);
            Slot urgentSlot(date, time);
            User* user = (userID != -1) ? AllUsersList->findUserByID(userID) : nullptr;
            Appointment newAppointment(urgentSlot, user, (isUrgentStr == "Yes"), documentPath, myStatusGraph);
            newAppointment.setStatus(status);
            urgentQueue.enqueue(newAppointment);
        }
        while (getline(normalFile, date))
        {
            getline(normalFile, time);
            normalFile >> userID;
            normalFile.ignore();
            getline(normalFile, status);
            getline(normalFile, documentPath);
            getline(normalFile, isUrgentStr);
            BNode<Slot>* slotNode = SlotTree->searchSlot(date, time);
            User* user = AllUsersList->findUserByID(userID);
            if (slotNode != nullptr && user != nullptr)
            {
                Appointment newAppointment(slotNode->data, user, false, documentPath, myStatusGraph);
                newAppointment.setStatus(status);
                normalQueue.enqueue(newAppointment);
            }
        }
        urgentFile.close();
        normalFile.close();
    }
    void displayAppointments()
    {
        system("cls");
        cout << "\t\t\tAppointments List\n";
        Table appointmentsTable;
        appointmentsTable.add_row({ "User ID", "User Name", "Type", "Document Path", "Date", "Time", "Status" });
        for (size_t i = 0; i < 7; i++)
        {
            appointmentsTable[0][i].format().font_color(Color::red).font_align(FontAlign::center).font_style({ FontStyle::bold });
        }
        Appointment appointments[200];
        int appointmentCount = 0;
        myQueue<Appointment> tempQueue = urgentQueue;
        while (!tempQueue.empty())
        {
            Appointment app = tempQueue.frontData();
            tempQueue.dequeue();
            if (app.getStatus() != "Verified" && app.getStatus() != "Rejected")
            {
                appointments[appointmentCount++] = app;
            }
        }
        tempQueue = normalQueue;
        while (!tempQueue.empty())
        {
            Appointment app = tempQueue.frontData();
            tempQueue.dequeue();
            if (app.getStatus() != "Verified" && app.getStatus() != "Rejected")
            {
                appointments[appointmentCount++] = app;
            }
        }
        for (int i = 0; i < appointmentCount; i++)
        {
            appointmentsTable.add_row({
                std::to_string(appointments[i].getUser()->getUserID()),
                appointments[i].getUser()->getUserName(),
                appointments[i].getIsUrgent() ? "Urgent" : "Normal",
                appointments[i].getDocumentPath(),
                appointments[i].getSlot().getDate(),
                appointments[i].getSlot().getTime(),
                appointments[i].getStatus(),
                });
        }
        if (appointmentCount == 0)
        {
            cout << "\nNo Pending Appointments Found.\n";
        }
        else
        {
            cout << appointmentsTable << endl;
        }
        cout << "1. Sort by Date\n";
        cout << "2. Sort by Time\n";
        cout << "3. Go back\n";
        cout << "Enter your choice: ";
        int choice;
        cin >> choice;

        if (choice == 1)
        {
            SortByDate(appointments, appointmentCount);
        }
        else if (choice == 2)
        {
            SortByTime(appointments, appointmentCount);
        }
        else if (choice == 3)
        {
            return;
        }
        else
        {
            cout << "Invalid option selected. Returning to main menu.\n";
            return;
        }
        Table sortedAppointmentsTable;
        sortedAppointmentsTable.add_row({ "User ID", "User Name", "Type", "Document Path", "Date", "Time", "Status" });
        for (size_t i = 0; i < 7; i++)
        {
            sortedAppointmentsTable[0][i].format().font_color(Color::red).font_align(FontAlign::center).font_style({ FontStyle::bold });
        }
        for (int i = 0; i < appointmentCount; i++)
        {
            sortedAppointmentsTable.add_row({
                std::to_string(appointments[i].getUser()->getUserID()),
                appointments[i].getUser()->getUserName(),
                appointments[i].getIsUrgent() ? "Urgent" : "Normal",
                appointments[i].getDocumentPath(),
                appointments[i].getSlot().getDate(),
                appointments[i].getSlot().getTime(),
                appointments[i].getStatus(),
                });
        }
        cout << "\nSorted Appointments:\n";
        cout << sortedAppointmentsTable << endl;
        cout << "Press any key to go back.\n";
        _getch();
    }
    void displayUrgentSlots()
    {
        cout << "\t\t\tUrgent Slots\n";
        myQueue<Slot> temp = urgentSlotsQueue;
        while (!temp.empty())
        {
            temp.frontData().displaySlots();
            cout << "--------------------\n";
            temp.dequeue();
        }
    }
    void displayAllAppointmentsReport()
    {
        system("cls");
        cout << "\t\t\tAppointments Report\n";
        Table appointmentsTable;
        appointmentsTable.add_row({ "User ID", "User Name", "Type", "Document Path", "Date", "Time", "Status" });
        for (size_t i = 0; i < 7; ++i)
        {
            appointmentsTable[0][i]
                .format()
                .font_color(Color::red)
                .font_align(FontAlign::center)
                .font_style({ FontStyle::bold });
        }
        Appointment appointments[200];
        int appointmentCount = 0;
        myQueue<Appointment> tempUrgentQueue = urgentQueue;
        while (!tempUrgentQueue.empty())
        {
            Appointment app = tempUrgentQueue.frontData();
            tempUrgentQueue.dequeue();

            if (app.getStatus() == "Verified" || app.getStatus() == "Rejected" || app.getStatus() == "Cancelled")
            {
                appointments[appointmentCount++] = app;
            }
        }
        myQueue<Appointment> tempNormalQueue = normalQueue;
        while (!tempNormalQueue.empty())
        {
            Appointment app = tempNormalQueue.frontData();
            tempNormalQueue.dequeue();

            if (app.getStatus() == "Verified" || app.getStatus() == "Rejected")
            {
                appointments[appointmentCount++] = app;
            }
        }
        for (int i = 0; i < appointmentCount; i++)
        {
            appointmentsTable.add_row({ std::to_string(appointments[i].getUser()->getUserID()),
                                       appointments[i].getUser()->getUserName(),
                                       appointments[i].getIsUrgent() ? "Urgent" : "Normal",
                                       appointments[i].getDocumentPath(),
                                       appointments[i].getSlot().getDate(),
                                       appointments[i].getSlot().getTime(),
                                       appointments[i].getStatus() });
        }
        if (appointmentCount == 0)
        {
            cout << "\nNo appointments found with Verified, Rejected, or Cancelled status.\n";
        }
        else
        {
            cout << appointmentsTable << endl;
            cout << "1. Sort by Date\n";
            cout << "2. Sort by Time\n";
            cout << "3. Go back\n";
            cout << "Enter your choice: ";
            int choice;
            cin >> choice;
            if (choice == 1)
            {
                SortByDate(appointments, appointmentCount);
            }
            else if (choice == 2)
            {
                SortByTime(appointments, appointmentCount);
            }
            else if (choice == 3)
            {
                return;
            }
            else
            {
                cout << "Invalid option selected. Returning to main menu.\n";
                return;
            }
            Table sortedAppointmentsTable;
            sortedAppointmentsTable.add_row({ "User ID", "User Name", "Type", "Document Path", "Date", "Time", "Status" });
            for (size_t i = 0; i < 7; ++i)
            {
                sortedAppointmentsTable[0][i]
                    .format()
                    .font_color(Color::red)
                    .font_align(FontAlign::center)
                    .font_style({ FontStyle::bold });
            }
            for (int i = 0; i < appointmentCount; i++)
            {
                sortedAppointmentsTable.add_row({ std::to_string(appointments[i].getUser()->getUserID()),
                                                 appointments[i].getUser()->getUserName(),
                                                 appointments[i].getIsUrgent() ? "Urgent" : "Normal",
                                                 appointments[i].getDocumentPath(),
                                                 appointments[i].getSlot().getDate(),
                                                 appointments[i].getSlot().getTime(),
                                                 appointments[i].getStatus() });
            }
            cout << "\nSorted Appointments Report:\n";
            cout << sortedAppointmentsTable << endl;
        }
        cout << "Press any key to go back.\n";
        _getch();
    }

    void displayUserAppointmentsReport()
    {
        system("cls");
        cout << "\t\t\tYour Appointment Report\n";
        Table reportTable;
        reportTable.add_row({ "Appointment Type", "Document Path", "Date", "Time", "Status" });
        for (size_t i = 0; i < 5; ++i)
        {
            reportTable[0][i]
                .format()
                .font_color(Color::red)
                .font_align(FontAlign::center)
                .font_style({ FontStyle::bold });
        }
        Appointment userAppointments[200];
        int appointmentCount = 0;
        myQueue<Appointment> tempUrgentQueue = urgentQueue;
        while (!tempUrgentQueue.empty())
        {
            Appointment app = tempUrgentQueue.frontData();
            tempUrgentQueue.dequeue();

            if (app.getUser() == LoginUser && (app.getStatus() == "Verified" || app.getStatus() == "Rejected" || app.getStatus() == "Cancelled"))
            {
                userAppointments[appointmentCount++] = app;
            }
        }
        myQueue<Appointment> tempNormalQueue = normalQueue;
        while (!tempNormalQueue.empty())
        {
            Appointment app = tempNormalQueue.frontData();
            tempNormalQueue.dequeue();

            if (app.getUser() == LoginUser && (app.getStatus() == "Verified" || app.getStatus() == "Rejected" || app.getStatus() == "Cancelled"))
            {
                userAppointments[appointmentCount++] = app;
            }
        }
        for (int i = 0; i < appointmentCount; i++)
        {
            reportTable.add_row({ userAppointments[i].getIsUrgent() ? "Urgent" : "Normal",
                                 userAppointments[i].getDocumentPath(),
                                 userAppointments[i].getSlot().getDate(),
                                 userAppointments[i].getSlot().getTime(),
                                 userAppointments[i].getStatus() });
        }
        if (appointmentCount == 0)
        {
            cout << "\nYou have no appointments with Verified, Rejected, or Cancelled status.\n";
        }
        else
        {
            cout << reportTable << endl;
            cout << "1. Sort by Date\n";
            cout << "2. Sort by Time\n";
            cout << "3. Go back\n";
            cout << "Enter your choice: ";
            int choice;
            cin >> choice;
            if (choice == 1)
            {
                SortByDate(userAppointments, appointmentCount);
            }
            else if (choice == 2)
            {
                SortByTime(userAppointments, appointmentCount);
            }
            else if (choice == 3)
            {
                return;
            }
            else
            {
                cout << "Invalid option selected. Returning to main menu.\n";
                return;
            }
            Table sortedReportTable;
            sortedReportTable.add_row({ " Appointment Type", "Document Path", "Date", "Time", "Status" });
            for (size_t i = 0; i < 5; ++i)
            {
                sortedReportTable[0][i]
                    .format()
                    .font_color(Color::red)
                    .font_align(FontAlign::center)
                    .font_style({ FontStyle::bold });
            }
            for (int i = 0; i < appointmentCount; i++)
            {
                sortedReportTable.add_row({ userAppointments[i].getIsUrgent() ? "Urgent" : "Normal",
                                           userAppointments[i].getDocumentPath(),
                                           userAppointments[i].getSlot().getDate(),
                                           userAppointments[i].getSlot().getTime(),
                                           userAppointments[i].getStatus() });
            }
            cout << "\nSorted User Appointments Report:\n";
            cout << sortedReportTable << endl;
        }
        cout << "Press any key to go back.\n";
        _getch();
    }
};
AppointmentQueue appointmentQueue;
class ActionTracker {
private:
    myStack<string> actionStack;

public:
    void AddAction(const string& action) {
        actionStack.push(action);
    }
    void displayActionHistory() {
        system("cls");
        cout << "\t\t\tAction History\n";
        if (actionStack.isEmpty()) {
            cout << "No actions performed yet." << endl;
        }
        else {
            Node<string>*temp = actionStack.head;
            cout << "Recent actions performed:" << endl;
            while (temp!=nullptr) {
                cout << "- " << temp->data << endl;
                temp = temp->next;
            }
        }
        cout << "Press any key to go back.";
        _getch();
    }
    void clearActions() {
        while (!actionStack.isEmpty()) {
            actionStack.pop();
        }
    }
};
ActionTracker adminActionTracker;
ActionTracker userActionTracker;

void createUser()
{
    system("cls");
    cin.ignore();
    string username, password, name, email, address, phoneNo;
    cout << "\t\t\tEnter New User Information" << endl;
    cout << "Enter Name: ";
    getline(cin, name);
    cout << "Enter Username: ";
    cin >> username;
    cout << "Enter Password: ";
    cin >> password;
    cout << "Enter Email: ";
    cin >> email;
    cout << "Enter Phone Number: ";
    cin >> phoneNo;
    cout << "Enter Address: ";
    cin.ignore();
    getline(cin, address);
    User* newUser = new User(username, password, name, email, address, phoneNo);
    AllUsersList->insertUser(newUser);
    AllUsersList->saveUsers("Users.txt");
    cout << "User Account Created Successfully.\n"
        << endl;
    cout << "Press any key to continue...\n";
    _getch();
    UserLoginMenu();
}
void userLogin()
{
    cout << "\t\t\tUser Login Menu\n";
    string username, password;
    cout << "Enter Username: ";
    cin >> username;
    cout << "Enter Password: ";
    cin >> password;
    LoginUser = AllUsersList->findUser(username, password);
    if (LoginUser)
    {
        cout << "Login Successful!\n";
        UserMainMenu();
    }
    else
    {
        cout << "Invalid Credentials!\n";
        userLogin();
    }
}
void UserLoginMenu()
{
    system("cls");
    int choice;
    cout << "\t\t\tWelcome to User Login Menu\t\t\t\n";
    cout << "1. Already Have Account\n";
    cout << "2. Create a New Account\n";
    cout << "Enter Your Choice: ";
    cin >> choice;
    switch (choice)
    {
    case 1:
        userLogin();
        break;
    case 2:
        createUser();
        break;
    default:
        cout << "Invalid choice!";
        UserLoginMenu();
    }
}
class Admin
{
private:
    string username;
    string password;
    myStack<string> actions;

public:
    Admin()
    {
        ReadAdminCredentials("adminCredentials.txt");
    }
    void ReadAdminCredentials(const string& filename)
    {
        ifstream inFile(filename);
        if (!inFile)
        {
            cout << "Unable to open the file for Reading Credentials.\n";
        }
        else
        {
            inFile >> username >> password;
            inFile.close();
        }
    }
    void writeAdminCredentials(const string& filename)
    {
        ofstream outFile(filename);
        if (!outFile)
        {
            cout << "Unable to open the file for Writing Credentials.\n";
        }
        else
        {
            outFile << username << "\n"
                << password;
            outFile.close();
        }
    }
    bool isLogin(string username, string password)
    {
        if (this->username == username && this->password == password)
        {
            return true;
        }
        return false;
    }
    void updateInformation()
    {
        system("cls");
        cout << "\t\t\tUpdate Your Information\t\t\t\n";
        cout << " Enter username: ";
        cin >> username;
        cout << "Enter password: ";
        cin >> password;
        writeAdminCredentials("adminCredentials.txt");
        cout << "Information Updated Successfully.\n";
        cout << "Press any key to Go Back.....";
        _getch();
    }
    void displayInformation()
    {
        system("cls");
        cout << "\t\t\tYour Information\t\t\t\n";
        cout << "Username: " << username << endl;
        cout << "Password: " << password << endl;
        cout << "Press any key to Go Back.....";
        _getch();
    }
    void addAppointmentSlot()
    {
        system("cls");
        string date, time;
        cout << "Enter Appointment Date (DD-MM-YYYY): ";
        cin >> date;
        cout << "Enter Appointment Time (HH:MM): ";
        cin >> time;
        Slot newSlot(date, time);
        SlotTree->insertSlot(newSlot);
        SlotTree->saveToFile("NormalSlots.txt");
        cout << "Appointment slot added successfully!" << endl;
        cout << "Press any key to continue...";
        _getch();
    }
    void addUrgentAppointmentsForDate()
    {
        system("cls");
        string date;
        cout << "Enter the date for urgent appointments (DD-MM-YYYY): ";
        cin >> date;
        string times[5] = { "10:00", "12:00", "14:00", "16:00", "17:00" };

        for (int i = 0; i < 5; i++)
        {
            Slot urgentSlot(date, times[i]);
            appointmentQueue.addUrgentSlot(urgentSlot);
        }
        cout << "Urgent slots for " << date << " have been added successfully.\n";
        cout << "Press any key to continue...";
        _getch();
    }
};
Admin myAdmin;

void UserMainMenu()
{
    int choice;
    do
    {
        system("cls");
        cout << "\t\t\tWelcome to User Portal\t\t\t\n";
        cout << "1. View All Slots\n";
        cout << "2. Book an Appointment\n";
        cout << "3. Cancel an Appointment\n";
        cout << "4. Show Your Information\n";
        cout << "5. Update Your Information\n";
        cout << "6. Track Your Appointment\n";
        cout << "7. View Your Appointments Reports\n";
        cout << "8. View Action History\n";
        cout << "0. LogOut\n";
        cout << "Enter Your choice: ";
        cin >> choice;

        switch (choice)
        {
        case 1:
            system("cls");
            SlotTree->printInOrder();
            userActionTracker.AddAction("User viewed All Slots.");
            cout << "Press any key to go back.\n";
            _getch();
            break;

        case 2:
            appointmentQueue.bookNewAppointment();
            userActionTracker.AddAction("User booked a new appointment.");
            cout << "Press any key to return to the menu...";
            _getch();
            break;

        case 3:
            appointmentQueue.cancelAppointment();
            userActionTracker.AddAction("User canceled an appointment.");
            break;

        case 4:
            system("cls");
            LoginUser->displayInformation();
            userActionTracker.AddAction("User viewed his Information.");
            cout << "Press any key to go back.\n";
            _getch();
            break;
        case 5:
            LoginUser->updateProfile();
            userActionTracker.AddAction("User updated their profile.");
            break;
        case 6:
            appointmentQueue.trackYourAppointment();
            userActionTracker.AddAction("User tracked his Appointment.");
            break;
        case 7:
            appointmentQueue.displayUserAppointmentsReport();
            userActionTracker.AddAction("User viewed his Appointment Report.");
            break;
        case 8:
            userActionTracker.displayActionHistory();
            break;
        case 0:
            cout << "Logging out...\n";
            userActionTracker.clearActions();
            break;
        default:
            cout << "Invalid choice! Please try again.\n";
            _getch();
            break;
        }
    } while (choice != 0);
    mainMenu();
}
void AdminLoginMenu()
{
    system("cls");
    string username;
    string password;
    cout << "\t\t\tAdmin Login Menu\t\t\t\n";
    cout << "Enter Admin Username: ";
    cin >> username;
    cout << "Enter Admin Password: ";
    cin >> password;
    if (myAdmin.isLogin(username, password))
    {
        AdminMainMenu();
    }
    else
    {
        cout << "Invalid Username or Password.\n";
        AdminLoginMenu();
    }
}
void AdminMainMenu()
{
    int choice;
    do
    {
        system("cls");
        cout << "\t\t\tWelcome to Admin Portal\t\t\t\n";
        cout << "1. Add Appointment Slots.\n";
        cout << "2. View All Appointment Slots.\n";
        cout << "3. View All Booked Appointments\n";
        cout << "4. Update Appointment Status\n";
        cout << "5. Add Urgent Appointment Detail\n";
        cout << "6. Show Your Information\n";
        cout << "7. Update Your Information\n";
        cout << "8. Show All Users\n";
        cout << "9. View All Appointments Reports\n";
        cout << "10. View Action History\n";
        cout << "0. LogOut\n";
        cout << "Enter Your choice: ";
        cin >> choice;
        switch (choice)
        {
        case 1:
            myAdmin.addAppointmentSlot();
            adminActionTracker.AddAction("Admin added an appointment slot.");
            break;
        case 2:
            system("cls");
            cout << "\t\t\tSlots List\n";
            appointmentQueue.displayUrgentSlots();
            cout << "\t\t\tNormal Slots\n";
            SlotTree->printInOrder();
            cout << "Press any key to go back.\n";
            _getch();
            adminActionTracker.AddAction("Admin Viewed All Slots.");
            break;
        case 3:
            appointmentQueue.displayAppointments();
            adminActionTracker.AddAction("Admin Viewed All Booked Appointments.");

            break;
        case 4:
            appointmentQueue.UpdateAppointmentStatus();
            adminActionTracker.AddAction("Admin updated appointment status.");
            break;
        case 5:
            myAdmin.addUrgentAppointmentsForDate();
            adminActionTracker.AddAction("Admin added urgent appointment details.");
            cout << "Press any key to return to the menu...";
            _getch();
            break;
        case 6:
            myAdmin.displayInformation();
            adminActionTracker.AddAction("Admin viewed his information.");

            break;
        case 7:
            myAdmin.updateInformation();
            adminActionTracker.AddAction("Admin updated his information.");
            break;
        case 8:
            AllUsersList->display();
            adminActionTracker.AddAction("Admin viewed All Users.");
            cout << "Press any key to go back.\n";
            _getch();
            break;
        case 9:
            appointmentQueue.displayAllAppointmentsReport();
            adminActionTracker.AddAction("Admin viewed Appointment Report.");
            break;
        case 10:
            adminActionTracker.displayActionHistory();
            break;

        case 0:
            cout << "Logging out...\n";
            adminActionTracker.clearActions();
            break;
        default:
            cout << "Invalid choice! Please try again.\n";
            _getch();
            break;
        }
    } while (choice != 0);
    mainMenu();
}
void mainMenu()
{
    system("cls");
    int choice;
    cout << "\t\t\tWelcome to Document Verification System\t\t\t\n";
    cout << "1. Login As An Admin\n";
    cout << "2. Login As a User\n";
    cout << "0. Quit\n";
    cin >> choice;
    switch (choice)
    {
    case 1:
        AdminLoginMenu();
        break;
    case 2:
        UserLoginMenu();
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
void updateDataInFileHandling()
{
    AllUsersList->saveUsers("Users.txt");
}
int main()
{
    system("color B0");
    AllUsersList->loadUsers("Users.txt");
    SlotTree->loadFromFile("NormalSlots.txt");
    appointmentQueue.loadUrgentSlotsFromFile();
    appointmentQueue.loadAppointmentsFromFile();
    mainMenu();
    AllUsersList->saveUsers("Users.txt");
    appointmentQueue.saveUrgentSlotsToFile();
    appointmentQueue.saveAppointmentsToFile();
    return 0;
}