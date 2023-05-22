package com.example.raceresultapi;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

@Service
public class SerienService {
    @Autowired
    SerienRepository serienRepository;

    public void addResult(String serie, Rennen rennen) {
        Rennserie rennserie = getSeries(serie);
        rennserie.addRennen(rennen, false);
        serienRepository.save(rennserie);
    }
    public String addDriver(String serie, Driver driver) {
        Rennserie rennserie = getSeries(serie);
        String response = rennserie.addDriver(driver);
        serienRepository.save(rennserie);
        return  response;
    }
    public String addSerie(Rennserie rennserie) {
        if(!getAllSeriesNames().contains(rennserie.name)) {
            serienRepository.save(rennserie);
            return "{\"success\": true, \"message\": Series has been added successfully.}";
        }
        else {
            return "{\"success\": false, \"message\": Series with this Name already exists.}";
        }
    }

    public List<Rennserie> getAllSeries() {return this.serienRepository.findAll();}
    public Rennserie getSeries(String name) {return this.serienRepository.findByName(name);}
    public List<String> getAllSeriesNames() {
        List<String> list = new ArrayList<>();
        for (Rennserie serie : this.serienRepository.findAll()) {
            list.add((serie.name));
        }
        return list;
    }
    public List<Rennen> getResults(String serie) {
        Rennserie rennserie = getSeries(serie);
        return rennserie.getRennenList();
    }
    public Rennen getResult(String serie, String parameter) {
        Rennserie rennserie = getSeries(serie);
        return rennserie.getResult(parameter);
    }
    public List<Driver> getDrivers(String serie) {
        Rennserie rennserie = getSeries(serie);
        return rennserie.getFahrerfeld();
    }
    public Driver getDriver(String serie, int number) {
        Rennserie rennserie = getSeries(serie);
        return rennserie.getDriver(number);
    }

    public HashMap<Integer, Integer> getStandings(String serie) {
        Rennserie rennserie = getSeries(serie);
        return rennserie.gesamtWertung;
    }
    public List<Integer> getPunkteSystem(String serie) {
        Rennserie rennserie = getSeries(serie);
        return rennserie.punkteSystem;
    }
    public void deleteSeries(String serie) {
        serienRepository.delete(getSeries(serie));
    }
    public String updateResult(String serie, Rennen rennen) {
        Rennserie rennserie = getSeries(serie);

        if(rennserie.updateResult(rennen)) {
            serienRepository.save(rennserie);
            return "{\"success\": true, \"message\": Result has been updated successfully.}";
        }
        else {
            return "{\"success\": false, \"message\": Couldnt update result.}";
        }
    }
    public String updateDriver(String serie, Driver driver) {
        Rennserie rennserie = getSeries(serie);
        for(int i = 0; i < rennserie.rennenList.size(); i++) {
            if(rennserie.fahrerfeld.get(i).number == driver.number) {
                rennserie.fahrerfeld.set(i, driver);
                serienRepository.save(rennserie);
                return "{\"success\": true, \"message\": Driver has been updated successfully.}";
            }
        }
        return "{\"success\": false, \"message\": Couldnt update Driver.}";
    }
    public String deleteResult(String serie, String id) {
        Rennserie rennserie = getSeries(serie);
        if(rennserie.removeResult(rennserie.getResult(id)) && rennserie.rennenList.remove(rennserie.getResult(id))) {
            serienRepository.save(rennserie);
            return "{\"success\": true, \"message\": Result has been deleted successfully.}";
        }
        else {
            return "{\"success\": false, \"message\": Result wasnt deleted.}";
        }
    }
    public String deleteDriver(String serie, int nr) {
        Rennserie rennserie = getSeries(serie);
        if(rennserie.fahrerfeld.remove(rennserie.getDriver(nr))) {
            serienRepository.save(rennserie);
            return "{\"success\": true, \"message\": Driver has been deleted successfully.}";
        }
        else {
            return "{\"success\": false, \"message\": Driver wasnt deleted.}";
        }
    }
}
