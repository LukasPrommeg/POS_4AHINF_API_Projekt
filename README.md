# POS_4AHINF_API_Projekt
# RaceAPI 1.0
RaceAPI

## Version: 1.0

**Contact information:**  
lukas.prommegger@htl-saalfelden.at  

**License:** [Apache 2.0](http://www.apache.org/licenses/LICENSE-2.0.html)

[Find out more about Swagger](http://swagger.io)
### /pet

#### PUT
##### Summary:

Update an existing pet

##### Description:

Update an existing pet by Id

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Successful operation |
| 400 | Invalid ID supplied |
| 404 | Pet not found |
| 405 | Validation exception |

##### Security

| Security Schema | Scopes | |
| --- | --- | --- |
| petstore_auth | write:pets | read:pets |

#### POST
##### Summary:

Add a new pet to the store

##### Description:

Add a new pet to the store

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Successful operation |
| 405 | Invalid input |

##### Security

| Security Schema | Scopes | |
| --- | --- | --- |
| petstore_auth | write:pets | read:pets |

### /pet/{petId}

#### GET
##### Summary:

Find pet by ID

##### Description:

Returns a single pet

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| petId | path | ID of pet to return | Yes | long |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | successful operation |
| 400 | Invalid ID supplied |
| 404 | Pet not found |

##### Security

| Security Schema | Scopes | |
| --- | --- | --- |
| api_key | | |
| petstore_auth | write:pets | read:pets |

#### POST
##### Summary:

Updates a pet in the store with form data

##### Description:



##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| petId | path | ID of pet that needs to be updated | Yes | long |
| name | query | Name of pet that needs to be updated | No | string |
| status | query | Status of pet that needs to be updated | No | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 405 | Invalid input |

##### Security

| Security Schema | Scopes | |
| --- | --- | --- |
| petstore_auth | write:pets | read:pets |

#### DELETE
##### Summary:

Deletes a pet

##### Description:

delete a pet

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| api_key | header |  | No | string |
| petId | path | Pet id to delete | Yes | long |

##### Responses

| Code | Description |
| ---- | ----------- |
| 400 | Invalid pet value |

##### Security

| Security Schema | Scopes | |
| --- | --- | --- |
| petstore_auth | write:pets | read:pets |
