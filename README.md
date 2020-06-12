<div style="display: flex; justify-content: center"><img src="https://i.ibb.co/yRxgxM8/Animal-Shelter-Logo.png"/></div>

### _Created by Tyler Bates_

## _Description_

TyTy's Animal Shelter is API access application where the user can view existing animals up for adoption or add new ones. Each entry includes the animal's Name, Species, Age, A brief Description, an image url and a date they arrived. Users can search the database for animals using either Name, Species, or Age. Only registered and authorized users have access to editing and/or deleting entries in the API.


## _Setup/Installation Requirements_ 

1. Clone this projects repository into your local directory following [these](https://www.linode.com/docs/development/version-control/how-to-install-git-and-clone-a-github-repository/) instructions.

2. Open the now local project folder with [VSC](https://code.visualstudio.com/Download) or an equivalent

3. Download [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/install/runtime?pivots=os-windows) then enter the following command in the terminal to confirm installation (2.2 or higher)
```sh
dotnet -- version
``` 
4. Still in the command line, enter
```sh
dotnet tool install -g 
dotnet-script
```
5. Download [ASP.NET Core](https://dotnet.microsoft.com/download) to enable live viewing on a local server

6. Open the repository, navigate to the containing folder of the project & Enter the following command to confirm build stability 

```sh
dotnet run build 
```

7. Within that same containing folder enter the following to open a live server w/auto updated viewing
```sh
dotnet watch run
``` 
8. Go to your browser and enter the following url:

```sh
http://localhost:5004
```
### To Access the Swagger UI:
Add the following to the url of the local host:
```
http://localhost:5004/swagger
```
### MySQL Installation & Configuration:
1. Download the MySQL Community Server DMG file [here](https://dev.mysql.com/downloads/file/?id=484914) with the "No thanks, just start my download" link.
2. On the configuration page of the installer select the following options:
* Use legacy password encryption
* Set your password
3. Open the terminal and enter the command:
*'export PATH="/usr/local/mysql/bin:$PATH"' >> ~/.bash_profile
4. Download the MySQL Workbench DMG file [here](https://dev.mysql.com/downloads/file/?id=484391)
5. Open Local Instance 3306 with the password you set.
6. Within the project directory, create a file called "appsettings.json" and fill it with the following code:
```sh
"AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=animal_shelter;uid=root;pwd=[YOUR PASSWORD GOES HERE];"
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
9. You should now be able to navigate through the full functionality of the project.

### Postman Installation & Configuration

Postman is another resource for testing API calls, follow these steps to utilize this program:
1. Download [Postman](https://www.postman.com/downloads/). Sign up is _not_ required.
2. Once the project is hosting to local server 5000, open Postman.
3. To get your authorization token, make a **POST** request to _localhost:5000/api/users/authenticate_. The **Body** of the request will include the login information I've provided for you in the _users_ data table in MySQL Workbench.

<div style="display: flex; justify-content: center"><img src="https://i.ibb.co/6gRmVRk/post-rq.jpg"></div>

4. If sent correctly, your login information and Token will be displayed below like this:

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

## _Technology Used_

## <a href="https://en.wikipedia.org/wiki/C_Sharp_%28programming_language%29">C#</a>
## <a href="https://en.wikipedia.org/wiki/.NET_Core">.NET Core</a>
## <a href="https://www.postman.com/">Postman</a>
## <a href="https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/entity-sql-language">Entity</a>
## <a href="https://github.com/swagger-api">Swagger</a>
## <a href="https://www.mysql.com/products/workbench/">MySQL Workbench</a>

## _Specs_

|Behavior|Input|Output|
|-----|-----|-----|
|User is greeted and given option to register as new user or login as existing user|"home"|"localhost.5000/"|
|User can search existing animals by Name|"Herman"|"5000/?name=herman"|
|User can search existing animals by Species|"Cat"|"5000/?Species=cat"|
|User can search existing animals by Age|"5"|"5000/?Age=5"|
|User can add animal via form submission |"Add New Animal"|"5000/animals/{animalId}"|
|User can edit extising animal information|"Edit Listing"|"5000/edit/{animalId}"|
|User can delete existing animals|"Delete Listing"|"5000/animals/{animalId}/delete"|


## _Legal_

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