#include <iostream>
#include <cmath>
#include <string>
#include <iomanip>
using namespace std;
int extractLogExponent(const string &fn)
{
    size_t logPosition = fn.find("log");
    if (logPosition == string::npos)
        return 0;
    size_t powerPosition = fn.find("^", logPosition);
    if (powerPosition != string::npos && powerPosition == logPosition + 3)
    {
        size_t startPos = powerPosition + 1;
        bool isNegative = (fn.length() > startPos && fn[startPos] == '-');
        if (isNegative)
            startPos++;
        size_t endPos = fn.find_first_not_of("0123456789", startPos);
        if (endPos == string::npos)
            endPos = fn.length();
        string powerStr = fn.substr(powerPosition + 1, endPos - powerPosition - 1);
        try
        {
            return stoi(powerStr);
        }
        catch (...)
        {
            return isNegative ? -1 : 1;
        }
    }
    return 1;
}
pair<double, int> parseFunction(const string &fn)
{
    double polynomialDegree = 0;
    int logarithmicExponent = 0;
    size_t nPosition = fn.find("n");
    bool hasPolynomial = (nPosition != string::npos);
    if (!hasPolynomial)
    {
        polynomialDegree = 0;
    }
    else if (fn == "n")
    {
        polynomialDegree = 1;
    }
    else if (fn.find("n^") != string::npos)
    {
        size_t pos = fn.find("n^");
        size_t end = fn.find_first_not_of("0123456789.", pos + 2);
        if (end == string::npos)
            end = fn.length();
        try
        {
            polynomialDegree = stod(fn.substr(pos + 2, end - pos - 2));
        }
        catch (...)
        {
            polynomialDegree = 1;
        }
    }
    else if (fn.find("n") != string::npos && fn.find("n^") == string::npos)
    {
        polynomialDegree = 1;
    }
    size_t logPosition = fn.find("log");
    if (logPosition != string::npos)
    {
        logarithmicExponent = extractLogExponent(fn);
        if (!hasPolynomial || logPosition < nPosition)
        {
            polynomialDegree = 0;
        }
    }
    return make_pair(polynomialDegree, logarithmicExponent);
}
bool hasNonPolynomialComponent(const string &fn)
{
    return fn.find("log") != string::npos || fn.find("ln") != string::npos;
}
string solveMasterTheorem(int a, int b, const string &fn)
{
    if (hasNonPolynomialComponent(fn))
    {
        cout << "Function contains non-polynomial terms (logarithmic). Using Extended Master Theorem instead." << endl;
        return "Use Extended Master Theorem";
    }
    double logab = log(a) / log(b);
    cout << "\nUsing Master Theorem to solve the recurrence..." << endl;
    cout << "log_" << b << "(" << a << ") = " << fixed << setprecision(2) << logab << endl;
    auto funcParts = parseFunction(fn);
    double polynomialDegree = funcParts.first;
    cout << "Function analysis: polynomial degree = " << polynomialDegree << endl;
    if (polynomialDegree < logab)
    {
        cout << "Case 1 applies: f(n) = O(n^(log_" << b << "(" << a << ")-ε))" << endl;
        cout << "f(n) grows slower than n^" << logab << endl;
        return "Theta(n^" + to_string(logab) + ")";
    }
    else if (fabs(polynomialDegree - logab) < 0.0001)
    {
        cout << "Case 2 applies: f(n) = Theta(n^log_" << b << "(" << a << "))" << endl;
        return "Theta(n^" + to_string(logab) + " * log(n))";
    }
    else if (polynomialDegree > logab)
    {
        cout << "Case 3 applies: f(n) = Omega(n^(log_" << b << "(" << a << ")+ε))" << endl;
        cout << "f(n) grows faster than n^" << logab << endl;
        return "Theta(" + fn + ")"; 
    }
    return "Cannot determine solution using Master Theorem";
}
string solveExtendedMasterTheorem(int a, int b, const string &fn)
{
    cout << "\nUsing Extended Master Theorem for non-polynomial cases..." << endl;
    double logab = log(a) / log(b);
    cout << "log_" << b << "(" << a << ") = " << fixed << setprecision(2) << logab << endl;
    auto funcParts = parseFunction(fn);
    double polynomialDegree = funcParts.first; 
    int logExponent = funcParts.second;        
    cout << "Function analysis: polynomial degree = " << polynomialDegree << ", log exponent = " << logExponent << endl;
    if (a > pow(b, polynomialDegree))
    {
        cout << "Case 1 applies: a > b^k (" << a << " > " << pow(b, polynomialDegree) << "), dominance of recursive part" << endl;
        return "Theta(n^" + to_string(logab) + ")";
    }
    else if (fabs(a - pow(b, polynomialDegree)) < 0.0001)
    {
        cout << "Case 2 applies: a = b^k (" << a << " = " << pow(b, polynomialDegree) << "), balanced recursive and non-recursive parts" << endl;
        if (logExponent > -1)
        {
            cout << "Subcase 2a: p > -1 (p = " << logExponent << ")" << endl;
            return "Theta(n^" + to_string(polynomialDegree) + " * log^" + to_string(logExponent + 1) + "(n))";
        }
        else if (logExponent == -1)
        {
            cout << "Subcase 2b: p = -1" << endl;
            return "Theta(n^" + to_string(polynomialDegree) + " * loglog(n))";
        }
        else
        {
            cout << "Subcase 2c: p < -1 (p = " << logExponent << ")" << endl;
            return "Theta(n^" + to_string(polynomialDegree) + ")";
        }
    }
    else
    {
        cout << "Case 3 applies: a < b^k (" << a << " < " << pow(b, polynomialDegree) << "), dominance of non-recursive part" << endl;
        if (logExponent >= 0)
        {
            cout << "Subcase 3a: p >= 0 (p = " << logExponent << ")" << endl;
            return "Theta(n^" + to_string(polynomialDegree) + " * log^" + to_string(logExponent) + "(n))";
        }
        else
        {
            cout << "Subcase 3b: p < 0 (p = " << logExponent << ")" << endl;
            return "O(n^" + to_string(polynomialDegree) + ")";
        }
    }
}
string solveDecreasingRecurrence(int a, int b, const string &fn)
{
    cout << "\nUsing Decreasing Recurrence Method to solve T(n) = " << a << "T(n-" << b << ") + " << fn << endl;
    auto functionParts = parseFunction(fn);
    double polynomialDegree = functionParts.first;
    int logExponent = functionParts.second;
    cout << "Function analysis: polynomial degree = " << polynomialDegree << ", log exponent = " << logExponent << endl;
    if (a == 1)
    {
        cout << "Linear decreasing recurrence detected (a = 1)" << endl;
        if (polynomialDegree == 0 && logExponent == 0)
        {
            cout << "T(n) = T(n-" << b << ") + O(1)" << endl;
            return "Theta(n)";
        }
        else if (polynomialDegree > 0 && logExponent == 0)
        {
            cout << "T(n) = T(n-" << b << ") + O(n^" << polynomialDegree << ")" << endl;
            return "Theta(n^" + to_string(polynomialDegree + 1) + ")";
        }
        else if (polynomialDegree == 0 && logExponent > 0)
        {
            cout << "T(n) = T(n-" << b << ") + O(log^" << logExponent << "(n))" << endl;
            return "Theta(n log^" + to_string(logExponent) + "(n))";
        }
        else if (polynomialDegree > 0 && logExponent > 0)
        {
            cout << "T(n) = T(n-" << b << ") + O(n^" << polynomialDegree << " * log^" << logExponent << "(n))" << endl;
            return "Theta(n^" + to_string(polynomialDegree + 1) + " * log^" + to_string(logExponent) + "(n))";
        }
    }
    else if (a > 1)
    {
        cout << "Exponential decreasing recurrence detected (a = " << a << ")" << endl;
        if ((polynomialDegree == 0 && logExponent == 0) || (polynomialDegree <= 1 && logExponent == 0))
        {
            cout << "T(n) = " << a << "T(n-" << b << ") + small work per level" << endl;
            cout << "This forms a geometric series with " << a << "^(n/b) levels" << endl;
            return "Theta(" + to_string(a) + "^(n/" + to_string(b) + "))";
        }
        else if (polynomialDegree > 1 || logExponent > 0)
        {
            cout << "T(n) = " << a << "T(n-" << b << ") + significant work per level" << endl;
            if (polynomialDegree >= log(a) / log(1.5))
            { 
                return "Theta(" + fn + ")";
            }
            else
            {
                return "Theta(" + to_string(a) + "^(n/" + to_string(b) + "))";
            }
        }
    }
    if (a == 2 && b == 1 && fn.find("n-2") != string::npos)
    {
        cout << "Fibonacci-like recurrence detected: T(n) = T(n-1) + T(n-2) + small term" << endl;
        return "Theta(((1+sqrt(5))/2)^n)";
    }
    cout << "General decreasing recurrence analysis:" << endl;
    if (a == 1)
    {
        if (polynomialDegree == 0 && logExponent == 0)
            return "Theta(n)";
        else if (polynomialDegree > 0)
            return "Theta(n^" + to_string(polynomialDegree + 1) + (logExponent > 0 ? " * log^" + to_string(logExponent) + "(n))" : ")");
    }
    else if (a > 1)
    {
        return "Approximately Theta(" + to_string(a) + "^(n/" + to_string(b) + "))";
    }
    return "Cannot determine closed form solution for this decreasing recurrence";
}
string solveMultiwayRecurrence(int a1, int b1, int a2, int b2, const string &fn)
{
    cout << "\n========== Multi-way Recurrence Approximation ==========\n";
    cout << "Solving recurrence of the form T(n) = " << a1 << "T(n/" << b1 << ") + "
         << a2 << "T(n/" << b2 << ") + " << fn << endl
         << endl;
    cout << "Please select an approximation method:" << endl;
    cout << "1. Shallow analysis (fastest completing subproblem, gives Omega bound)" << endl;
    cout << "2. Deep analysis (slowest completing subproblem, gives Big-O bound)" << endl;
    cout << "3. Average approach (sum of a's and average of b's, gives approximation)" << endl;
    int choice;
    cout << "Enter your choice (1-3): ";
    cin >> choice;
    int aValues[2] = {a1, a2};
    int bValues[2] = {b1, b2};
    int effectiveA = 0;
    int effectiveB = 0;
    string boundType;
    switch (choice)
    {
    case 1:
    {
        int maxB = (bValues[0] > bValues[1]) ? 0 : 1;
        effectiveA = aValues[maxB];
        effectiveB = bValues[maxB];
        boundType = "Omega";
        cout << "Using shallow analysis (fastest completing subproblem):" << endl;
        cout << "Selected branch: " << effectiveA << "T(n/" << effectiveB
             << ") as it divides n fastest" << endl;
        cout << "This provides a lower bound (Omega) on the solution" << endl;
        break;
    }
    case 2:
    {
        int minB = (bValues[0] < bValues[1]) ? 0 : 1;
        effectiveA = aValues[minB];
        effectiveB = bValues[minB];
        boundType = "O";
        cout << "Using deep analysis (slowest completing subproblem):" << endl;
        cout << "Selected branch: " << effectiveA << "T(n/" << effectiveB
             << ") as it divides n slowest" << endl;
        cout << "This provides an upper bound (Big-O) on the solution" << endl;
        break;
    }
    case 3:
    {
        effectiveA = aValues[0] + aValues[1];
        effectiveB = (int)((bValues[0] + bValues[1]) / 2);
        boundType = "O";
        cout << "Using average approach:" << endl;
        cout << "Combined a = " << effectiveA << " (sum of a values)" << endl;
        cout << "Average b = " << effectiveB << " (Average of b values)" << endl;
        cout << "This provides an approximate upper bound (Big-O) on the solution" << endl;
        break;
    }
    default:
        return "Invalid choice";
    }
    string result;
    if (hasNonPolynomialComponent(fn))
    {
        result = solveExtendedMasterTheorem(effectiveA, effectiveB, fn);
    }
    else
    {
        result = solveMasterTheorem(effectiveA, effectiveB, fn);
        if (result == "Use Extended Master Theorem")
        {
            result = solveExtendedMasterTheorem(effectiveA, effectiveB, fn);
        }
    }
    if (result.find("Theta(") != string::npos)
    {
        if (boundType == "Omega")
        {
            result = "Omega" + result.substr(5);
        }
        else if (boundType == "O")
        {
            result = "O" + result.substr(5);
        }
    }
    cout << "\nApplying " << (boundType == "Omega" ? "lower" : "upper") << " bound to the result." << endl;
    return result;
}
int main()
{
    cout << "========== Recurrence Relation Solver ==========\n"
         << endl;
    cout << "1. T(n) = aT(n-b) + f(n) [Decreasing Recurrence]" << endl;
    cout << "2. T(n) = aT(n/b) + f(n) [Standard Divide & Conquer]" << endl;
    cout << "3. T(n) = aT(n/b) + a'T(n/b') + f(n) [Multi-way Divide & Conquer]" << endl;
    cout << "Enter your choice (1, 2, or 3): ";
    int choice;
    cin >> choice;
    if (choice < 1 || choice > 3)
    {
        cout << "Invalid choice. Exiting." << endl;
        return 1;
    }
    string result;
    if (choice == 1)
    {
        int a, b;
        string fn;
        cout << "Enter value of a (number of subproblems): ";
        cin >> a;
        if (a <= 0)
        {
            cout << "Error: a must be positive" << endl;
            return 1;
        }
        cout << "Enter value of b (decrease amount): ";
        cin >> b;
        if (b <= 0)
        {
            cout << "Error: b must be positive" << endl;
            return 1;
        }
        cout << "Enter f(n) (use 'n^k' for n raised to power k, 'log^j' for logarithmic power j, or 'n' or '1' for constants): ";
        cin.ignore();
        getline(cin, fn);
        result = solveDecreasingRecurrence(a, b, fn);
        cout << "\n========== Result ==========\n"
             << endl;
        cout << "For the recurrence T(n) = " << a << "T(n-" << b << ") + " << fn << ":" << endl;
    }
    else if (choice == 2)
    {
        int a, b;
        string fn;
        cout << "Enter value of a (number of subproblems): ";
        cin >> a;
        if (a <= 0)
        {
            cout << "Error: a must be positive" << endl;
            return 1;
        }
        cout << "Enter value of b (size divisor): ";
        cin >> b;
        if (b <= 1)
        {
            cout << "Error: b must be greater than 1" << endl;
            return 1;
        }
        cout << "Enter f(n) (use 'n^k' for n raised to power k, 'log^j' for logarithmic power j, or 'n' or '1' for constants): ";
        cin.ignore();
        getline(cin, fn);
        if (hasNonPolynomialComponent(fn))
        {
            result = solveExtendedMasterTheorem(a, b, fn);
        }
        else
        {
            result = solveMasterTheorem(a, b, fn);
            if (result == "Use Extended Master Theorem")
            {
                result = solveExtendedMasterTheorem(a, b, fn);
            }
        }
        cout << "\n========== Result ==========\n"
             << endl;
        cout << "For the recurrence T(n) = " << a << "T(n/" << b << ") + " << fn << ":" << endl;
    }
    else
    {
        int a1, b1, a2, b2;
        string fn;
        cout << "For first subproblem:" << endl;
        cout << "Enter a: ";
        cin >> a1;
        if (a1 <= 0)
        {
            cout << "Error: a must be positive" << endl;
            return 1;
        }
        cout << "Enter b: ";
        cin >> b1;
        if (b1 <= 1)
        {
            cout << "Error: b must be greater than 1" << endl;
            return 1;
        }
        cout << "For second subproblem:" << endl;
        cout << "Enter a': ";
        cin >> a2;
        if (a2 <= 0)
        {
            cout << "Error: a' must be positive" << endl;
            return 1;
        }
        cout << "Enter b': ";
        cin >> b2;
        if (b2 <= 1)
        {
            cout << "Error: b' must be greater than 1" << endl;
            return 1;
        }
        cout << "Enter f(n) (use 'n^k' for n raised to power k, 'log^j' for logarithmic power j, or 'n' or '1' for constants): ";
        cin.ignore();
        getline(cin, fn);
        result = solveMultiwayRecurrence(a1, b1, a2, b2, fn);
        cout << "\n========== Result ==========\n"
             << endl;
        cout << "For the recurrence T(n) = " << a1 << "T(n/" << b1 << ") + "
             << a2 << "T(n/" << b2 << ") + " << fn << ":" << endl;
    }
    cout << "The solution is: " << result << endl;
    return 0;
}