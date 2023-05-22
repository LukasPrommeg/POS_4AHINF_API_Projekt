package com.example.raceresultapi;

public class Driver {
    int number;
    String name;
    String team;

    public Driver() {};

    public Driver(int number, String name, String team) {
        this.number = number;
        this.name = name;
        this.team = team;
    }
    public int getNumber() {
        return  number;
    }
    public void setNumber(int number) {
        this.number = number;
    }

    public void setName(String name) {
        this.name = name;
    }
    public String getName() {return name;}
    public void setTeam(String team) {
        this.team = team;
    }
    public String getTeam() {return team;}
}
