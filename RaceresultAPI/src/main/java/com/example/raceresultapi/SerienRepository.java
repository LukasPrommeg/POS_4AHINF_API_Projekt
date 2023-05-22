package com.example.raceresultapi;

import org.springframework.data.mongodb.repository.MongoRepository;

import java.util.List;

public interface SerienRepository extends MongoRepository<Rennserie, String> {
    public Rennserie findByName(String name);
}
