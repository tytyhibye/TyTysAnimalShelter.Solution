<div style="display: flex; justify-content: center"><img src="https://i.ibb.co/yRxgxM8/Animal-Shelter-Logo.png"/></div>

### _Created by Tyler Bates_

## Description

TyTy's Animal Shelter is a locally hosted API application built in C#/.NET core 2.2 utilizing token authentication and swagger documentation. Registered users can view existing listings of animals up for adoption and have the ability to add new listings. Each listing includes the animal's Name, Species, Gender, Age, A brief Description, and an optional image url. Users can filter their searches to return only specified animals and have the ability to delete listings once the animal has been adopted.
<hr />

## _Setup/Installation Requirements_ 

## To Host the API Server:

1. Clone this projects repository into your local directory following [these](https://www.linode.com/docs/development/version-control/how-to-install-git-and-clone-a-github-repository/) instructions.

2. Open the now local project folder with [VSC](https://code.visualstudio.com/Download) or an equivalent

3. Download [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/install/runtime?pivots=os-windows) then enter the following command in the terminal to confirm installation (2.2 or higher)
```sh
dotnet -- version
``` 
4. Still in the command line, enter the following two commands:
```sh
dotnet tool install -g 
```
```
dotnet-script
```
5. Download [ASP.NET Core](https://dotnet.microsoft.com/download) to enable live viewing on a local server

6. Open the repository, navigate to the containing folder of the project & Enter the following command to confirm build stability 

```sh
dotnet build 
```

7. Within that same containing folder enter the following to open a live server w/auto updated viewing
```sh
dotnet watch run
``` 

**The server is now live!**

<hr />

## To Access and Use Swagger UI:

While the server is running, enter the following url into your browser:
```
http://localhost:5000/swagger
```

Welcome to Swagger! Here you have the same capabilites as the [Postman](#postMan) application.
### Swagger Functionality Includes:
* **POST** requests to _user_ database to retrieve authentication token
* **GET** requests to _animal_ database to return all/specific listings
* **PUT** requests to edit an existing listing
* **POST** requests to add or delete a database listing

<hr />

<div id="mySql">

## MySQL Installation & Configuration:
1. Download the [MySQL Community Server DMG file](https://dev.mysql.com/downloads/file/?id=484914) with the _"No thanks, just start my download"_ link.
2. On the configuration page of the installer select the following options:
* Use legacy password encryption
* Set your password
3. Open your terminal and enter the command:
```
'export PATH="/usr/local/mysql/bin:$PATH"' >> ~/.bash_profile
```
4. Download the [MySQL Workbench DMG file](https://dev.mysql.com/downloads/file/?id=484391)
5. Open Local Instance 3306 with the password you set.
6. Within the project directory, create a file called "appsettings.json" and populate it with the following code:
```sh
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=animal_shelter;uid=root;pwd=[YOUR PASSWORD GOES HERE];"
  },
  "AppSettings": {
    "Secret": "[INSERT 128 BIT SECRET STRING/PHRASE HERE]"
  }
}
```
7. Next, initiate a data migration by entering the following into your terminal:
```
dotnet ef migrations add DATABASE
```
8. Once this successfully employs, enter the following to update the data tables to correlate with the project models:
```
dotnet ef database update
```
9. You should now be able to view the full project database in MySQL Workbench.
<hr />

</div>

<div id="postMan">

## Postman Installation & Configuration:

Postman is a resource for testing API calls, follow these steps to utilize this program:
1. Download [Postman](https://www.postman.com/downloads/). (Sign up is _not_ required).
2. Once the project API is live on _localhost:5000_, open Postman.
3. To get your authorization token, make a **POST** request to _localhost:5000/api/users/authenticate_. The **Body** of the request will include the login information I've provided for you in the _users_ data table in [MySQL Workbench](#mySql).

<div style="display: flex; justify-content: center"><img src="https://i.ibb.co/6gRmVRk/post-rq.jpg"></div>

4. Click **Send**, your login information and Token will be displayed below:

<div style="display: flex; justify-content: center"><img src="https://i.ibb.co/Lrt3rKR/token.jpg"></div>

5. To use your Token for various **GET** requests, change the authorization type to _Bearer Token_ by selecting it on the following dropdown menu:

<div style="display: flex; justify-content: center"><img src="https://i.ibb.co/JQ7T1pC/get.jpg"></div>

6. Next, simply enter your token into the designated field on the right.

<div style="display: flex; justify-content: center"><img src="https://i.ibb.co/61XrFPL/token2.jpg"></div>

You now have full access to the API!

You can filter your search using the following parameter keys:
* _Name_
* _Species_
* _Gender_
* _Age_

_Search Example:_
```sh
http://localhost:5000/api/animals/?name=mr.meowgi
```

</div>
<hr />

## Technology Used

## <a href="https://en.wikipedia.org/wiki/C_Sharp_%28programming_language%29">C#</a>
## <a href="https://en.wikipedia.org/wiki/.NET_Core">.NET Core</a>
## <a href="https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1">ASP.NET Core MVC</a>
## <a href="https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/entity-sql-language">Entity</a>
## <a href="https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.1&tabs=visual-studio">Identity</a>
## <a href="https://www.postman.com/">Postman</a>
## <a href="https://github.com/swagger-api">Swagger</a>
## <a href="https://www.mysql.com/products/workbench/">MySQL</a>

<hr />

## Logistics / Specs

|Behavior|Input|Output|
|-----|-----|-----|
|User can access Swagger UI index on running server|"/swagger"|"localhost.5000/swagger/index.html"|
|User can search existing animals by Name via GET request|"Key:Name, Value:Jennifur"|"5000/?name=jennifur"|
|User can search existing animals by Species via GET request|"Key:Species, Value:Cat"|"5000/?Species=cat"|
|User can search existing animals by Gender via GET request|"Key:Gender, Value:Female"|"5000/?Gender=female"|
|User can search existing animals by Age via GET request|"Key:Age, Value:5"|"5000/?Age=5"|
|User can add animal via Postman POST request | "{New Entry Information}"|"5000/animals/{animalId}"|
|User can edit extising animal information via PUT request|"{Edited Entry Information}"|"5000/animals/{animalId}"|
|User can delete existing animals via POST request|"{Animal Id} to be Deleted"|"5000/animals/{animalId}"|

<hr />

## Legal

#### MIT License

### Copyright (c) 2020 Tyler Bates @ Epicodus

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.