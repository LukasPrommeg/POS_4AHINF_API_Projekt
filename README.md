# RaceresultAPI
Dieses Projekt wurde als Semesterprojekt des Faches Programmieren und Softwareentwicklung erarbeitet. Es behandelt das große Thema der REST API's. Im Zusammenspiel mit einer solchen API war eine weitere Anforderung die Erstellung von 2 Clients, welche auf die API zugreifen. Bei diesen 2 Clients handelt es sich um eine WPF-Anwendung und eine Website. 

Meine Idee war eine API, mit welcher man Ergebnisse und Punktestände von Autorennserien erfassen kann. Es soll möglich sein grundlegende Daten über die Rennserie selbst, dessen Rennen und Fahrern zentral zu speichern und zugänglich zu machen. 

## Inhaltsverzeichnis
- [Softwaredesign](#softwaredesign)
- [Beschreibung der Software](#beschreibung-der-software)
- [API Beschreibung](#api-beschreibung)
- [Verwendung der API](#verwendung-der-api)
- [Diagramme](#diagramme)
- [Diskussion](#diskussion)

<br>

## Softwaredesign

```mermaid
graph LR
A(Blazor Webapp) -- Displays Data --> C
B(WPF App) -- Displays and changes Data --> C
C(RaceresultAPI) -- stores Data and gets --> D
D(MongoDB)
```

#### RaceresultAPI
Die RaceresultAPI ist das Kernstück des Projektes. Die API ist in Java programmiert und basiert auf dem Spring Boot Framework. Sie verwaltet alle Daten und speichert diese in eine MongoDB-Datenbank. 

#### Website mit Blazor Webassembly
Die Website dient als einfache Weboberfläche, mit welcher sich einfache Benutzer und Fans des Rennsports die gespeicherten Daten der RaceresultAPI einfach und schön gestaltet anschauen können. Für die Implementierung dieser Website habe ich mich für das Webframework Blazor entschieden, welches auf ASP.NET aufbaut. 

#### WPF Anwendung
Die WPF Anwendung dient als Verwaltungsprogramm der RaceresultAPI. Über die WPF Anwendung können alle Daten einfach hinzugefügt, geändert, gelöscht oder auch nur angezeigt werden. 

## Beschreibung der Software

#### RaceresultAPI
Wie unter dem Punkt [Software Design](#softwar-design) schon kurz angeschrochen wurde das Herz des Projekts, die API, mit Spring Boot umgesetzt. Dafür habe ich folgende Dependencies verwendet: 

```xml 
<dependencies>
        <dependency>
            <groupId>org.springframework.boot</groupId>
            <artifactId>spring-boot-starter-data-mongodb</artifactId>
        </dependency>
        <dependency>
            <groupId>org.springframework.boot</groupId>
            <artifactId>spring-boot-starter-web</artifactId>
        </dependency>
        <dependency>
            <groupId>org.springframework.boot</groupId>
            <artifactId>spring-boot-starter-test</artifactId>
            <scope>test</scope>
        </dependency>
    </dependencies>
```

Um die API verwenden zu können ist es notwendig Endpoints mit den benötigten Funktionen zur Verfügung zu stellen. Im folgenden Codeabschnitt ist die Implementierung des Endpoints <code><b>/state</b></code> zu sehen: 

```java
@RequestMapping(method = RequestMethod.GET, value = "/state")
public String getState() {
	return "{\\\"success\\\": true, \\\"message\\\": Das Service ist verfügbar!}";
}
```

Unter dem Punkt [API Beschreibung](#api-beschreibung) ist die Funktion und Verwendung der einzelnen Endpoints genauer beschrieben.

#### Website mit Blazor Webassembly


#### WPF Anwendung


## API Beschreibung

### Rennserie
<details>
 <summary><code>POST</code> <code><b>/addSeries</b></code> <code>(Fügt eine Serie hinzu)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | Serie          | Requestbody  | object (JSON or YAML)   | N/A  |


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `{"success":"true","message":"Success Message"}`                                              |


</details>
<details>
 <summary><code>GET</code> <code><b>/getSeries</b></code> <code>(Gibt alle Serien zurück)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | None          | -  | -   | N/A  |


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `JSON Liste an Serien`                                              |


</details>
<details>
 <summary><code>GET</code> <code><b>/{Name}</b></code> <code>(Gibt eine Serie zurück)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | {Name} der gewünschten Serie  |


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `JSON Objekt der Serie`                                              |


</details>
<details>
 <summary><code>GET</code> <code><b>/getSeriesNames</b></code> <code>(Gibt die Namen aller Serien zurück)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | None          | -  | -   | N/A  |


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `JSON String-Liste an Seriennamen`                                              |


</details>
<details>
 <summary><code>DELETE</code> <code><b>/{Name}/delete</b></code> <code>(Löscht eine Serie)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | {Name} der gewünschten Serie  |


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `{"success":"true","message":"Success Message"}`                                              |


</details>
<details>
 <summary><code>GET</code> <code><b>/{Serie}/getStandings</b></code> <code>(Gibt den Gesamtstand einer Serie zurück)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | Name der gewünschten {Serie}  |


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `JSON Integer-Hashmap des aktuellen Gesamtstands`                                              |

  
</details>
<details>
 <summary><code>GET</code> <code><b>/{Serie}/getPunkteSystem</b></code> <code>(Gibt das Punktesystem einer Serie zurück)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | Name der gewünschten {Serie}  |


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `JSON Integer-List des Punktesystems`                                              |

  
</details>

### Rennen
<details>
 <summary><code>POST</code> <code><b>/{Serie}/addResult</b></code> <code>(Fügt ein Rennen zu einer Serie hinzu)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | Name der gewünschten {Serie}  |
> | Rennen | Requestbody | object (JSON or YAML) | N/A |   


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `{"success":"true","message":"Success Message"}`                                              |


</details>
<details>

 <summary><code>GET</code> <code><b>/{Serie}/getResults</b></code> <code>(Gibt alle Rennen einer Serie zurück)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | Name der gewünschten {Serie}  |


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `JSON Liste an Rennen`                                              |

  
</details>
<details>
 <summary><code>GET</code> <code><b>/{Serie}/getResult/{id}</b></code> <code>(Gibt ein Rennen einer Serie zurück)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | Name der gewünschten {Serie}  |
> | String          | Path  | String   | {id} des gewünschten Rennens  |


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `JSON Objekt des gewünschten Rennens`                                              |

  
</details>
<details>
 <summary><code>PUT</code> <code><b>/{Serie}/updateResult</b></code> <code>(Updatet ein Rennen einer Serie)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | Name der gewünschten {Serie}  |
> | Rennen | Requestbody | object (JSON or YAML) | N/A |   


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `{"success":"true","message":"Success Message"}`                                              |

  
</details>
<details>
 <summary><code>DELETE</code> <code><b>/{Serie}/deleteResult/{id}</b></code> <code>(Löscht ein Rennen einer Serie)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | Name der gewünschten {Serie}  |
> | String          | Path  | String   | {id} des gewünschten Rennens  |

  
##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `{"success":"true","message":"Success Message"}`                                              |


</details>

### Drivers
<details>
 <summary><code>POST</code> <code><b>/{Serie}/addDriver</b></code> <code>(Fügt einen Fahrer zu einer Serie hinzu)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | Name der gewünschten {Serie}  |
> | Driver | Requestbody | object (JSON or YAML) | N/A |   


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `{"success":"true","message":"Success Message"}`                                              |

  
</details>
<details>
 <summary><code>GET</code> <code><b>/{Serie}/getDrivers</b></code> <code>(Gibt alle Fahrer einer Serie zurück)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | Name der gewünschten {Serie}  |


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `JSON Liste an Fahrern`                                              |

  
  
</details>
<details>
 <summary><code>GET</code> <code><b>/{Serie}/getDriver/{Nr}</b></code> <code>(Gibt einen Fahrer einer Serie zurück)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | Name der gewünschten {Serie}  |
> | String          | Path  | String   | {id} des gewünschten Fahrers  |


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `JSON Objekt des gewünschten Fahrers`                                              |

  
</details>
<details>
 <summary><code>PUT</code> <code><b>/{Serie}/updateDriver</b></code> <code>(Updatet einen Fahrer einer Serie)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | Name der gewünschten {Serie}  |
> | Driver | Requestbody | object (JSON or YAML) | N/A |   


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `{"success":"true","message":"Success Message"}`                                              |

  
</details>
<details>
 <summary><code>DELETE</code> <code><b>/{Serie}/deleteDriver/{Nr}</b></code> <code>(Löscht einen Fahrer einer Serie)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | String          | Path  | String   | Name der gewünschten {Serie}  |
> | String          | Path  | String   | {id} des gewünschten Fahrers  |

  
##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `{"success":"true","message":"Success Message"}`                                              |


</details>

### Verwaltung 
<details>
 <summary><code>GET</code> <code><b>/state</b></code> <code>(Gibt den Status der API zurück)</code></summary>

##### Parameters

> | data type      | type         | format                  | description                                                   |
> |----------------|--------------|-------------------------|---------------------------------------------------------------|
> | None          | -  | -   | N/A  |


##### Responses

> |content-type             | response example / description                                                                |
> |-------------------------|-----------------------------------------------------------------------------------------------|
> |`json string`       | `{"success":"true","message":"Das Service ist verfügbar!"}`  |

  
</details>

### Datentypen
<details>
<summary><code><b>Serie</b></code><code>(Abbildung einer Rennserie)</code></summary>


##### Membervariablen
> | Datentyp | Name | Beschreibung | Required |
> |----------------|--------------|-----------------------|--------------|
> | String          | id  | uniqe, auto generated   | no  |
> | String          | name  | N/A   | yes  |
> | List< Rennen >          | rennenList  | N/A   | no  |
> | List< Integer >          | punkteSystem  | N/A   | yes  |
> | List< Driver >          | fahrerfeld  | N/A   | no  |
> | Hashmap< Integer, Integer >          | gesamtWertung  | N/A   | no  |

##### Example JSON POST
``` json
{
    "name": "WRC",
    "punkteSystem": [
        25,
        18,
        15,
        12,
        10,
        8,
        6,
        4,
        2,
        1
    ]
}
```


</details>
<details>
<summary><code><b>Rennen</b></code><code>(Abbildung eines Rennens)</code></summary>


##### Membervariablen
> | Datentyp | Name | Beschreibung | Required |
> |----------------|--------------|-----------------------|--------------|
> | String          | id  | uniqe, auto generated   | yes  |
> | String          | name  | N/A   | yes  |
> | String          | ort  | N/A   | yes  |
> | List< Integer >          | ergebnis  | N/A   | yes  |

##### Example JSON POST
```json
{
    "name":"Rally Monte Carlo",
    "ort":"Monto Carlo",
    "ergebnis":[
        11,
        22,
        33,
        44,
        55,
        66,
        77,
        88,
        99
    ]
}
```

##### Example JSON PUT
```json
{
	"id":"d4d472b0-5a87-40e6-89ff-1541f7c75048",
    "name":"Rally Monte Carlo",
    "ort":"Monto Carlo",
    "ergebnis":[
        11,
        22,
        33,
        44,
        55,
        66,
        77,
        88,
        99
    ]
}
```

</details>
<details>
<summary><code><b>Driver</b></code><code>(Abbildung eines Fahrer)</code></summary>


##### Membervariablen
> | Datentyp | Name | Beschreibung | Required |
> |----------------|--------------|-----------------------|--------------|
> | Integer          | number  | N/A | yes  |
> | String          | name  | N/A | yes  |
> | String          | team  | N/A   | yes  |

##### Example JSON POST
```json
{
    "number":33,
    "name":"VITUS",
    "team":"BMW"
}
```

##### Example JSON PUT
```json
{
    "number":33,
    "name":"VITUS",
    "team":"BMW"
}
```

</details>

## Verwendung der API

## Diagramme

## Diskussion
