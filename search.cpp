
#include <bits/stdc++.h>

using namespace std;

    string search(vector<string>&list,string&required){
    for(int i=0;i<list.size();i++){
        if(list[i]==required)
        return required;
    }
    return "-1";
}

int main()
{
    int n;
    cin>>n;
    vector<string>list;
    string required;
    cin>>required;
    for(int i=0;i<n;i++)
    {
        cin>>list[i];
    }
string find = search(list,required);
cout<<find;
    return 0;
}
