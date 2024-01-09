#include <bits/stdc++.h>

using namespace std;

static bool Criteria(int element){
    if(element>10){
    return true;
    }
    return false;
}

std::vector<int> filterFunction(const vector<int> &list) {
    std::vector<int>filteredArray;
    for(auto const &element: list){
        if(Criteria(element)){
            filteredArray.push_back(element);
        }
    }
    return filteredArray;
}

int main()
{
    int size_of_Array;
    cin>>size_of_Array;
    
    vector<int>list(size_of_Array);
    
    for(int ele=0;ele<size_of_Array;ele++){
        cin>>list[ele];
    }
    vector<int>answer = filterFunction(list);
    for(auto ele : answer){
        cout<<ele<<" ";
    }
    return 0;
}
