
#include <bits/stdc++.h>

using namespace std;


class Header;
class Footer;
class Hyperlink;
class Paragraph;


class Converter{
public:
    virtual void convert(Header*) = 0;
    virtual void convert(Paragraph*) = 0;
    virtual void convert(Footer*) = 0;
    virtual void convert(Hyperlink*) = 0;
};

class HTMLConverter : public Converter{
    void convert(Header*){
       
    }
    void convert(Paragraph*){
       
    }
    void convert(Footer*){
        
    }
    void convert(Hyperlink*){
        
    }
};


class DocumentPart{
private:
    string name;
    pair<int, int> position;
public:
    virtual void paint() = 0;
    virtual void save() = 0;
    void convert(Converter*);
};

class WordDocument{
private:
    vector<DocumentPart*> partList;
    Converter* converterObjRef;
public:
    void open(){
        for(auto docPart: partList){
            docPart->paint();
        }
    }
    void save(){
        for(auto docPart: partList){
            docPart->save();
        }
    }
    void addPart(DocumentPart* documentPartObjRef) {
        this->partList.push_back(documentPartObjRef);
    }
    void convert(Converter* ConverterRef, HTMLConverter *HTMLConverterObjRef){ // Responsibility of Instantiator of WordDoc object to pass this for Dependency Injection
        converterObjRef = HTMLConverterObjRef;
        for(auto docPart: partList){
            docPart->convert(ConverterRef);
        }
    }
};

class Header : public DocumentPart{
    string title;
    public:
    void convert(Converter* converterRef){
        converterRef->convert(this);
    }
    void paint(){
        // display element
    }
    void save(){
        // save element
    }
};
class Footer : public DocumentPart{
    string text;
    public:
    void convert(Converter *converterRef){
        converterRef->convert(this);
    }
    void paint(){
        // display element
    }
    void save(){
        // save element
    }
};
class Paragraph : public DocumentPart{
    string content;
    int lines;
    public:
    void convert(Converter *converterRef){
        converterRef->convert(this);
    }
    void paint(){
        // display element
    }
    void save(){
        // save element
    }
};
class Hyperlink : public DocumentPart{
    string link;
    public:
    void convert(Converter *converterRef){
        converterRef->convert(this);
    }
    void paint(){
        // display element
    }
    void save(){
        // save element
    }
};






int main()
{
    cout<<"Hello World";

    return 0;
}
