<a name="readme-top"></a>


<!-- PROJECT LOGO -->
<br />
<div align="center">
 
  <h3 align="center">ADMIN</h3>
  <img src="https://github.com/DoublEffe/Admin/blob/main/images/logo.jpg" width="100" height="100">
  <p align="center">
    Web page to manage employee badges.
    <br />
    <a href="https://github.com/DoublEffe/Admin/blob/main/README.md"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    ·
    <a href="https://github.com/DoublEffe/Admin/issues">Report bug</a>
    ·
    <a href="https://github.com/DoublEffe/Admin/issues">Request feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About the Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li>
      <a href="#usage">Usage</a>
      <ul>
        <li><a href="#home">Home</a>
        <li><a href="#add-update">Add/Update</a>
      </ul>
    </li>
   <li><a href="#license">License</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About the Project
This web page will provide the admin with a list of all employee, add new ones. 
Also for every employee will be possible to update info delete the employee and trasfer the data to the badge so that the employee can access the restricted areas.
This project provides also two scripts that allow you to use a Raspberry pi and an rc522 reader for badge managment.
<p align="right">(<a href="#readme-top">back to the top</a>)</p>



### Built With

The web page is developed using Razor for frontpage and .NET Core for backend.
Bootstrap graphical purpose.
Firebase for authentication and Atlas Mongo DB for database.
Python for the Raspberry scripts.

* [![Razor][razor badge]][razor]
* [![Bootstrap][bootstrap badge]][bootstrap]
* [![.net core][net core badge]][net core]
* [![Firebase][firebase badge]][firebase]
* [![MonfoDB][mongo badge]][mongo]
* [![Python][python badge]][python]



<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Getting Started

This project is not deployed yet so you can launch it only in local.

### Prerequisites

* You will need .Net Core 9.

* Raspberry Pi ( i ahve a model 3B+ but I think everything will work with newer models).
  
* RC 522 reader.

* Firebase account.

* Atlas Mongo DB account.
  

### Installation

1. Create an account on Firebase
   * after creating an acoount go to authentication section and abilitate it then abilitate email/password. In the settings section get id projects and key api web.
3. Create an account on Atlas Mongo DB
   * create new cluster then new database, click on connect choose driver then c#/.net install the driver with dotnet and get the connectionUri string.
   * from coonect find the string also for python you will need it in Raspberry Pi.
5. Obtain your ip and the Raspberry Pi one
6. python libraries FastApi e pi-rc522.
   ```sh
    pip install "fastapi[standard]"
    pip install pi-rc522
    pip install "pymongo[srv]"
   ```
7. Create an .env file and save your data obtained in previous points on it
   * put every info obtained in the right section. 
8. Install the required Nuget packages.
    ```sh
    dotnet add package FirebaseAuthentication.net
    dotnet add package DotNetEnv
    dotnet add package AspNetCoreHero.ToastNotification
    dotnet add package MongoDB.Driver
    ```
9. Run the web page local
    ```sh
    dotnet run
    ```


<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- USAGE EXAMPLES -->
## Usage

The first thing you will see is the login page, if you don't have one there is a link beneath the login button this will lead to register page wich has similar structure.

![Login screen shoot](https://github.com/DoublEffe/Admin/blob/main/images/login.png)



### Home

In this page we will see the add button for adding new employee, and the the list of all employee.
Each employee has three buttons save the employee data to the badge, update the employee data and delete the employee.


![student main page](https://github.com/DoublEffe/Admin/blob/main/images/home.png)


### Add-Update 

In this page there is a form wich will add or update the employee they are very similar.

![teacher main page](https://github.com/DoublEffe/Admin/blob/main/images/add.png)


<p align="right">(<a href="#readme-top">back to top</a>)</p>

## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>




<!-- MARKDOWN LINKS & IMAGES -->
[net core]: https://dotnet.microsoft.com/it-it/download/dotnet/9.0  
[net core badge]: https://img.shields.io/badge/NET%20CORE%209-DD0031?style=for-the-badge&logo=dotnet&logoColor=white&logoSize=auto
[razor badge]: https://img.shields.io/badge/RAZOR-DD0031?style=for-the-badge&logoColor=white
[razor]: https://learn.microsoft.com/it-it/aspnet/core/mvc/views/razor?view=aspnetcore-9.0
[bootstrap badge]: https://img.shields.io/badge/BOOTSTRAP-DD0031?style=for-the-badge&logo=bootstrap&logoColor=white&logoSize=auto
[bootstrap]: https://getbootstrap.com/
[firebase]: https://console.firebase.google.com/
[firebase badge]: https://img.shields.io/badge/FIREBASE-DD0031?style=for-the-badge&logo=firebase&logoColor=white&logoSize=auto
[mongo badge]: https://img.shields.io/badge/ATLAS%20MONGO%20DB-DD0031?style=for-the-badge&logo=mongodb&logoColor=white&logoSize=auto
[mongo]: https://www.mongodb.com/products/platform/atlas-database
[python]: https://www.python.org/
[python badge]: https://img.shields.io/badge/PYTHON-DD0031?style=for-the-badge&logo=python&logoColor=white&logoSize=auto
