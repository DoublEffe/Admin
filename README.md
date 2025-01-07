<a name="readme-top"></a>


<!-- PROJECT LOGO -->
<br />
<div align="center">
 
  <h3 align="center">Admin</h3>
  <img src="https://github.com/DoublEffe/school/blob/main/images/tabler_school.svg" width="100" height="100">
  <p align="center">
    Web page to manage employee badges.
    <br />
    <a href="https://github.com/DoublEffe/school/blob/main/README.md"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://school-uzyr.onrender.com">Demo</a>
    ·
    <a href="https://github.com/DoublEffe/school/issues">Report bug</a>
    ·
    <a href="https://github.com/DoublEffe/school/issues">Request feature</a>
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
        <li><a href="#insegnante">Insegnante</a>
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

* [![Razor][]][]
* [![Bootstrap][t]][]
* [![.net core][]][]
* [![Firebase][]][]
* [!MonfoDB][]][]
* [!Python][]][]



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
2. Create an account on Atlas Mongo DB
3. Obtain your ip and the Raspberry Pi one
4. Save your data obtained in previous points on env file
   
 
5. Run the web page local
  ```sh
  dotnet run
  ```


<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- USAGE EXAMPLES -->
## Usage

The first thing you will see is the login page, if you don't have one there is a link beneath the login button this will lead to register page wich has similar structure.

![Login screen shoot](https://github.com/DoublEffe/school/blob/main/images/login.png)



### Home

In this page we will see the add button for adding new employee, and the the list of all employee.
Each employee has three buttons save the employee data to the badge, update the employee data and delete the employee.


![student main page](https://github.com/DoublEffe/school/blob/main/images/studente1.png)


### Add/Update 

In this page there is a form wich will add or update the employee they are very similar.

![teacher main page](https://github.com/DoublEffe/school/blob/main/images/insegnante1.png)


<p align="right">(<a href="#readme-top">back to top</a>)</p>

## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>




<!-- MARKDOWN LINKS & IMAGES -->
[Angular.io]: https://angular.io/
[Angular-url]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white
[Angular-design-kit]: https://img.shields.io/badge/Angular%20Design%20Kit-8A2BE2
[Angular-material.io]: https://design-angular-kit.vercel.app/design-angular-kit#/info/welcome
[Laravel]: https://img.shields.io/badge/Laravel-DD0031?style=for-the-badge&logo=laravel&logoColor=white
[laravel]: https://laravel.com/
[postGreSQL]: https://img.shields.io/badge/PostgreSQl-DD0031?style=for-the-badge&logo=postgresql&logoColor=white
[postgresql]: https://www.postgresql.org/
