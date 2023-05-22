package com.example.raceresultapi;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.aggregation.ArrayOperators;

import java.time.LocalTime;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

public class Rennen {
    public void setName(String name) {
        this.name = name;
    }
    public String getName() {return name;}
    public void setOrt(String ort) {
        this.ort = ort;
    }
    public String getOrt() {return ort;}
    public void setTermin(LocalTime termin) {
        this.termin = termin;
    }
    public LocalTime getTermin() {return  termin;}

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    @Id
    String id = UUID.randomUUID().toString();
    String name;
    String ort;
    LocalTime termin;
    List<Integer> ergebnis = new ArrayList<>();

    public Rennen() {}

    public Rennen(String name, String ort, LocalTime termin,List<Integer> ergebnis) {
        this.name = name;
        this.ort = ort;
        this.termin = termin;
        this.ergebnis = ergebnis;
    }

    public void setErgebnis(List<Integer> ergebnis) {
        this.ergebnis = ergebnis;
    }
    public List<Integer> getErgebnis() {
        return ergebnis;
    }
}
