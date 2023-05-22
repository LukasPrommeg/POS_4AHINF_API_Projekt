package com.example.raceresultapi;

import org.springframework.data.annotation.Id;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Objects;

public class Rennserie {
    @Id
    public String id;
    public String name;
    public List<Rennen> rennenList = new ArrayList<>();
    public List<Integer> punkteSystem = new ArrayList<>();
    public List<Driver> fahrerfeld = new ArrayList<>();
    public HashMap<Integer, Integer> gesamtWertung = new HashMap<>();

    public Rennserie() {}
    public Rennserie(String name, List<Integer> punkteSystem) {
        this.name = name;
        this.punkteSystem = punkteSystem;
    }
    public void addRennen(Rennen rennen, boolean update) {
        List<Integer> ergebnis = rennen.getErgebnis();
        for (int i = 0; i < punkteSystem.size() && i < ergebnis.size(); i++) {
            int fahrer = ergebnis.get(i);
            int punkte = punkteSystem.get(i);
            if(gesamtWertung.containsKey(fahrer)) {
                gesamtWertung.replace(fahrer, (gesamtWertung.get(fahrer) + punkte));
            }
            else {
                gesamtWertung.put(fahrer, punkte);
            }
        }
        System.out.println(rennen.name);
        if(!update) {
            rennenList.add(rennen);
        }
    }
    public String addDriver(Driver driver) {
        String response = "Added a Driver!";
        boolean exists = false;
        for (Driver fahrer : fahrerfeld) {
            if(fahrer.getNumber() == driver.getNumber()) {
                response = "There is already a Driver with this Number!";
                exists = true;
            }
        }
        if(!exists) {
            fahrerfeld.add(driver);
        }
        return  response;
    }
    public List<Rennen> getRennenList() {
        return rennenList;
    }
    public Rennen getResult(String parameter) {
        for (Rennen rennen: rennenList) {
            if(Objects.equals(rennen.id, parameter)) {
                return rennen;
            }
        }
        return null;
    }
    public List<Driver> getFahrerfeld() {
        return fahrerfeld;
    }
    public Driver getDriver(int number) {
        for (Driver driver : fahrerfeld) {
            if(driver.getNumber() == number) {
                System.out.println(fahrerfeld.contains(driver));
                return driver;
            }
        }
        return null;
    }
    public Boolean removeResult(Rennen rennen) {
        List<Integer> ergebnis = rennen.getErgebnis();
        boolean success = true;
        for (int i = 0; i < punkteSystem.size() && i < ergebnis.size(); i++) {
            int fahrer = ergebnis.get(i);
            int punkte = punkteSystem.get(i);
            if(gesamtWertung.replace(fahrer, (gesamtWertung.get(fahrer) - punkte)) == null) {
                success = false;
            }
        }
        return success;
    }
    public Boolean updateResult(Rennen rennen) {
        for(int i = 0; i < rennenList.size(); i++) {
            if(Objects.equals(rennenList.get(i).id, rennen.id)) {
                removeResult(rennenList.get(i));
                rennenList.set(i, rennen);
                addRennen(rennen, true);
                return true;
            }
        }
        return false;
    }
}
