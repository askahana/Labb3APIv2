# Person API
## Description
This is an API for fetching people's interests and their associated web links.

## Base url
https://localhost:7180/api/Person

## Endpoints
GET /api/Person
Returns a list of peole and its interest and weblinks.

-Response
 -PersonID
 -FirstName
 -LastName
 -Tel
 -Interest
  -InterestID
  -Title
  -Description
  -Link
    -LinkID,
    -LinkAddress
    
*Example

{
    "personId": 1,
    "firstName": "Bob",
    "lastName": "Dylan",
    "tel": "8888888",
    "interest": [
     {
        "interestId": 1,
        "title": "Music",
        "description": "Playing guitar",
        "link": []
      }
    ]
  },
