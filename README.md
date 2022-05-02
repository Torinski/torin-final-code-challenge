# torin-final-code-challenge

## How To Run

The solution file for the project is torin_launchpad_backend_codechallenge.sln inside the folder of the same name. How to run each section of the challenge is detailed below.

### Steps 1 Through 6

The entire LaunchpadCodeChallenge.API project can be run using the docker compose as the startup project. The endpoints are described in further detail in the next section.

### Step 7 And Step 8

Both the list iteration and the TESTModule methods can be tested or observed by using ConsoleApp1 as the startup project. The recursive list iteration method is located in the
QuestionClass.cs class, and the TESTModule method is written directly in Program.cs. 

### Step 9

The AWS Lambda Project can be tested using the AWSLambda1.Test project. The lambda function that catches a DynamoDbEvent and logs the Id of updated DynamoDb entries is located in the 
AWSLambda1 project, while the tests are located in the AWSLambda1.Test project. 

## API Endpoints

### GET

http://localhost:35000/api/employees,

http://localhost:35000/api/employees/department/{departmentId}

#### GET /api/employees

Retrieves the list of employees from the example test data.

**Response**
```
[
    {
        "id": "8acf5ae0-320e-418a-aea8-222222222222",
        "firstName": "John",
        "lastName": "Doe",
        "jobTitle": "Accountant",
        "address": "123 Made Up St",
        "departmentName": "Accounting"
    },
    {
        "id": "8acf5ae0-320e-418a-aea8-333333333333",
        "firstName": "Jane",
        "lastName": "Doe",
        "jobTitle": "Accountant",
        "address": "127 Made Up St",
        "departmentName": "Accounting"
    },
    {
        "id": "8acf5ae0-320e-418a-aea8-444444444444",
        "firstName": "James",
        "lastName": "Doe",
        "jobTitle": "Marketer",
        "address": "300 Made Up St",
        "departmentName": "Martketing"
    }
]
```

#### GET /api/employees/department/{departmentId}

Retrieves the list of employees that work within a specific department

**Parameters**
Guid departmentId: The id of the desired department

**Response**
```
// Using departmentId "8acf5ae0-320e-418a-aea8-111111111111"
[    
    {
        "id": "8acf5ae0-320e-418a-aea8-444444444444",
        "firstName": "James",
        "lastName": "Doe",
        "jobTitle": "Marketer",
        "address": "300 Made Up St",
        "departmentName": "Martketing"
    }
]
```