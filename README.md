# Person API
## Description
This is an API for fetching people's interests and their associated web links.

## Base url
https://localhost:7180/api/Person

## Endpoints
GET /api/Person
Returns a list of peole and its interest and weblinks.

Get / api/ Person/ {id}
Returns information about a specific person, including their interests and web links, based on the person's ID.

Put/ api/ Person/ {id}


***
1. Hämta alla personer [GET /api/Person]

**Response**
 - PersonID
 - FirstName
 - LastName
 - Tel
 - Interest
  - InterestID
  - Title
  - Description
  - Link
    - LinkID
    - LinkAddress

**Example**

[
  {
    "personId": 1,
    "firstName": "Bob",
    "lastName": "Dylan",
    "tel": "234455",
    "interest": [
      {
        "interestId": 1,
        "title": "Music",
        "description": "Playing guitar",
        "link": [
          {
            "linkId": 1,
            "linkAddress": "https://www.bobdylan.com/"
          }
        ]
      }
    ]
  },

2. Hämta alla intressen som är kopplade till en specifik person / 3. Hämta alla länkar som är kopplade till en specifik person

GET /api/Person/{id} , this takes personId as parameter.

You can get the same response as above.

4. Koppla en person till ett nytt intresse

Put/api/Person( {id}, this takes personId as parameter.

**Request**
{
  "personId": 1,

  "tel": "234455",
    "interest": [
{
"interestId": 2
}    
  ]
}

**Response**

{
  "personId": 1,
  "firstName": "Bob",
  "lastName": "Dylan",
  "tel": "234455",
  "interest": [
    {
      "interestId": 1,
      "title": "Music",
      "description": "Playing guitar",
      "link": [
        {
          "linkId": 1,
          "linkAddress": "https://www.bobdylan.com/"
        }
      ]
    },
    {
      "interestId": 2,
      "title": "Art",
      "description": "Painting",
      "link": null
    }
  ]
}

5. Lägga in nya länkar för en specifik person och ett specifikt intresse
