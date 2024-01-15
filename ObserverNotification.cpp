#include <bits/stdc++.h>

class IObserver {
public:
    virtual void update(std::string state) = 0;
};

class Thread {
    int id;
    std::string state;
    std::vector<IObserver*> observers;

    void notifyObservers() {
        for (auto observer : observers) {
            observer->update(state);
        }
    }

public:
    void setId(int threadId) {
        id = threadId;
    }

    void start() {
        state = "starting";
        notifyObservers();
    }

    void abort() {
        state = "aborting";
        notifyObservers();
    }

    void sleep() {
        state = "sleeping";
        notifyObservers();
    }

    void wait() {
        state = "wait";
        notifyObservers();
    }

    void suspended() {
        state = "suspended";
        notifyObservers();
    }

    std::string getState() const {
        return state;
    }

    void subscribe(IObserver* observer) {
        observers.push_back(observer);
    }

    void unsubscribe(IObserver* observer) {
        observers.erase(std::remove(observers.begin(), observers.end(), observer), observers.end());
    }

    int getId() const {
        return id;
    }
};

class ConcreteObserver : public IObserver {
    int threadId;  
public:
    ConcreteObserver(int id) : threadId(id) {}

    void update(std::string state) override {
        std::cout << "Thread " << threadId << " has been updated. New state: " << state << std::endl;
    }
};

int main() {
    Thread myThread;
    myThread.setId(1);

    ConcreteObserver observer1(myThread.getId());
    ConcreteObserver observer2(myThread.getId());

    myThread.subscribe(&observer1);
    myThread.subscribe(&observer2);

    myThread.start();
    myThread.sleep();

    myThread.unsubscribe(&observer1);

    myThread.abort();

    return 0;
}
