#include<bits/stdc++.h>
using namespace std;

#include<bits/stdc++.h>
using namespace std;

class GreaterThanStrategy {
private:
    int threshold;

public:
    void setThreshold(int value) {
        this->threshold = value;
    }

    bool invoke(int num) {
        return num > threshold;
    }
};

class IntegerListFilterController {
private:
    GreaterThanStrategy GTS;

public:
    vector<int> filter(const vector<int>& numbers) {
        GTS.setThreshold(10);
        vector<int> result;
        for (const auto& num : numbers) {
            if (GTS.invoke(num)) {
                result.push_back(num);
            }
        }
        return result;
    }
};

int main() {
    vector<int> numbers = {5, 12, 8, 15, 3, 20};

    IntegerListFilterController integerFilterController;

    vector<int> numbersGreaterThanTen = integerFilterController.filter(numbers);

    for (const auto& item : numbersGreaterThanTen) {
        cout << item << " ";
    }
    cout << endl;

    return 0;
}

// class IntegerFilter {
// public:
//      IntegerFilter(const vector<int>& numbers) : numbers(numbers) {}

//     vector<int> filter(const function<bool(int)>& greaterThanTen) {
//         vector<int> result;
//         for (const auto& num : numbers) {
//             if (greaterThanTen(num)) {
//                 result.push_back(num);
//             }
//         }
//         return result;
//     }

//     void printToConsole(const vector<int>& vec) const {
//         for (const auto& item : vec) {
//             cout << item << ", ";
//         }
//         cout << std::endl;
//     }

//     static function<bool(int)> greaterThanTen() {
//         return [](int num) { return num > 10; };
//     }

// private:
//     vector<int> numbers;
// };

// int main() {
//     vector<int> numbers = {5, 12, 8, 15, 3, 20};

//     IntegerFilter integerFilter(numbers);

//     auto greaterThanTen = IntegerFilter::greaterThanTen();

//     vector<int> numbersGreaterThanTen = integerFilter.filter(greaterThanTen);

//     integerFilter.printToConsole(numbersGreaterThanTen);

//     return 0;
// }
