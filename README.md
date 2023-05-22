## Softwaredesign


## Beschreibung der Software


## API Beschreibung

### Rennserie
<details>
 <summary><code>POST</code> <code><b>/addSeries</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | None      |  required | object (JSON or YAML)   | N/A  |


##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |
> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |
> | `405`         | `text/html;charset=utf-8`         | None                                                                |

</details>
<details>

 <summary><code>GET</code> <code><b>/getSeries</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>GET</code> <code><b>/{Name}</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>GET</code> <code><b>/getSeriesNames</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>DELETE</code> <code><b>/{Name}/delete</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>

### Rennen
<details>

 <summary><code>POST</code> <code><b>/{Serie}/addResult</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>GET</code> <code><b>/{Serie}/getResults</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>GET</code> <code><b>/{Serie}/getResult/{id}</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>PUT</code> <code><b>/{Serie}/updateResult</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>POST</code> <code><b>/addSeries</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>DELETE</code> <code><b>/{Serie}/deleteResult/{id}</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>

### Drivers
<details>

 <summary><code>POST</code> <code><b>/{Serie}/addDriver</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>GET</code> <code><b>/{Serie}/getDrivers</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>GET</code> <code><b>/{Serie}/getDriver/{Nr}</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>PUT</code> <code><b>/{Serie}/updateDriver</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>DELETE</code> <code><b>/{Serie}/deleteDriver/{Nr}</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>


<details>

 <summary><code>GET</code> <code><b>/{Serie}/getStandings</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>
<details>

 <summary><code>GET</code> <code><b>/{Serie}/getPunkteSystem</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>

<details>

 <summary><code>GET</code> <code><b>/state</b></code> <code>(overwrites all in-memory stub and/or proxy-config)</code></summary>

  

##### Parameters

  

> | name      |  type     | data type               | description                                                           |

> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|

> | None      |  required | object (JSON or YAML)   | N/A  |

  
  

##### Responses

  

> | http code     | content-type                      | response                                                            |

> |---------------|-----------------------------------|---------------------------------------------------------------------|

> | `201`         | `text/plain;charset=UTF-8`        | `Configuration created successfully`                                |

> | `400`         | `application/json`                | `{"code":"400","message":"Bad Request"}`                            |

> | `405`         | `text/html;charset=utf-8`         | None                                                                |

  

</details>


## Verwendung der API


## (Diagramme)


## Diskussion


## Quellen

