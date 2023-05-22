package com.example.raceresultapi;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;

@CrossOrigin
@RestController
public class SerienController {

    @Autowired
    SerienService serienService;

    @RequestMapping(method = RequestMethod.POST, value = "/addSeries")
    public String addSeries(@RequestBody Rennserie rennserie) {
        return serienService.addSerie(rennserie);
    }
    @RequestMapping(method = RequestMethod.GET, value = "/getSeries")
    public List<Rennserie> getAllSeries() {
        return serienService.getAllSeries();
    }
    @RequestMapping(method = RequestMethod.GET, value = "/{name}")
    public Rennserie getSeries(@PathVariable String name) {
        return serienService.getSeries(name);
    }
    @RequestMapping(method = RequestMethod.GET, value = "/getSeriesNames")
    public List<String> getSeriesName() {
        return serienService.getAllSeriesNames();
    }
    @RequestMapping(method = RequestMethod.DELETE, value = "/{serie}/delete")
    public String deleteSeries(@PathVariable String serie) {
        serienService.deleteSeries(serie);
        return "{\"success\":true}";
    }

    @RequestMapping(method= RequestMethod.POST, value="/{serie}/addResult")
    public String addResult(@PathVariable String serie, @RequestBody Rennen rennen) {
        serienService.addResult(serie, rennen);
        String response = "{\"success\": true, \"message\": Result has been added successfully.}";
        return response;
    }
    @RequestMapping(method = RequestMethod.GET, value = "/{serie}/getResults")
    public List<Rennen> getResults(@PathVariable String serie) {
        return serienService.getResults(serie);
    }
    @RequestMapping(method = RequestMethod.GET, value = "/{serie}/getResult/{parameter}")
    public Rennen getResult(@PathVariable String serie, @PathVariable String parameter) {
        return serienService.getResult(serie, parameter);
    }
    @RequestMapping(method = RequestMethod.PUT, value = "{serie}/updateResult")
    public String updateResult(@PathVariable String serie, @RequestBody Rennen rennen) {
        return serienService.updateResult(serie, rennen);
    }
    @RequestMapping(method = RequestMethod.DELETE, value = "{serie}/deleteResult/{id}")
    public String deleteResult(@PathVariable String serie, @PathVariable String id) {
        return serienService.deleteResult(serie, id);
    }

    @RequestMapping(method= RequestMethod.POST, value="/{serie}/addDriver")
    public String addDriver(@PathVariable String serie, @RequestBody Driver driver) {
        String response = "{\"success\": true, \"message\":";
        response += serienService.addDriver(serie, driver);
        response += "}";
        return response;
    }
    @RequestMapping(method = RequestMethod.GET, value = "/{serie}/getDrivers")
    public List<Driver> getDrivers(@PathVariable String serie) {
        return serienService.getDrivers(serie);
    }
    @RequestMapping(method = RequestMethod.GET, value = "/{serie}/getDriver/{number}")
    public Driver getDriver(@PathVariable String serie, @PathVariable int number) {
        return serienService.getDriver(serie, number);
    }
    @RequestMapping(method = RequestMethod.PUT, value = "{serie}/updateDriver")
    public String updateDriver(@PathVariable String serie, @RequestBody Driver driver) {
        return serienService.updateDriver(serie, driver);
    }
    @RequestMapping(method = RequestMethod.DELETE, value = "{serie}/deleteDriver/{number}")
    public String deleteDriver(@PathVariable String serie, @PathVariable int number) {
        return serienService.deleteDriver(serie, number);
    }

    @RequestMapping(method = RequestMethod.GET, value = "/{serie}/getStandings")
    public HashMap<Integer, Integer> getStandings(@PathVariable String serie) {
        return serienService.getStandings(serie);
    }
    @RequestMapping(method = RequestMethod.GET, value = "/{serie}/getPunkteSystem")
    public List<Integer> getPunkteSystem(@PathVariable String serie) {
        return serienService.getPunkteSystem(serie);
    }

    @RequestMapping(method = RequestMethod.GET, value = "/state")
    public String getState() {
        return "{\\\"success\\\": true, \\\"message\\\": Das Service ist verfügbar!}";
    }
}
