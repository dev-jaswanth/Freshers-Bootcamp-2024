#include <bits/stdc++.h>

std::vector<int> filterFunction(const std::vector<int> &list, std::function<bool(int)> Criteria) {
    std::vector<int> filteredArray;
    for(auto const &element: list){
        if(Criteria(element))
            filteredArray.push_back(element);
    }
    return filteredArray;
}

int main()
{
    std::cout<<"Hello World";
    return 0;
}
