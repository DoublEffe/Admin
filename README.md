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
      <a href="#come-usare">Usage</a>
      <ul>
        <li><a href="#home">Home</a>
        <li><a href="#insegnante">Insegnante</a>
      </ul>
    </li>
   <li><a href="#license">License</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## Spiegazione progetto
Questo progetto permette ad un admin di gestire i dipendenti e i loro badge, scrivere sui badge le informazioni necessarie affinchè i lettori alle porte possano garantire l'accesso a chi è abilitato.
<p align="right">(<a href="#readme-top">torna all'inizio</a>)</p>



### Built With

La pagina web è stata sviluppata usando Razor per il frontend e .net core 9 per il backend.
Bootstrap per gestire l'aspetto grafico.
Firebase per l'autenticazione e AtlasDB per il database.

* [![Razor][]][]
* [![Bootstrap][t]][]
* [![.net core][]][]
* [![Firebase][]][]
* [!MonfoDB][]][]



<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Come Usare

La prima cosa che si vede all'apertura è la pagina di login dove si dovranno immettere email, password e se non si ha un account si può passare alla pagina di registrazione che ha una struttura simile.

![Login screen shoot](https://github.com/DoublEffe/school/blob/main/images/login.png)



### Home

La sezione Studente è divisa in due parti: 

* selezione delle materie per accedere agli esercizi.

![student main page](https://github.com/DoublEffe/school/blob/main/images/studente1.png)

* una volta selezionata la materia la pagina ci mostrerà gli esercizi associati ad essa assegnati dall'insegnante.

![student exercise page](https://github.com/DoublEffe/school/blob/main/images/studente1-1.png)

* chat con IA.

![student chat](https://github.com/DoublEffe/school/blob/main/images/studente2.png)



### Insegnante

La sezione Insegnante è divisa in tre parti:

* sezione principale dove compare la lista delle classi tenute dall'insegnante.

![teacher main page](https://github.com/DoublEffe/school/blob/main/images/insegnante1.png)

* una volta selezionata la classela pagina ci mostrerà le risposte date dagli studenti.

![teacher exercise page](https://github.com/DoublEffe/school/blob/main/images/insegnante1-1.png)

* assegnazione esercizi per materie e classe.

  ![teacher assign page](https://github.com/DoublEffe/school/blob/main/images/insegnante2.png)

* pagina di statistiche per tema.

![teacher statistics page](https://github.com/DoublEffe/school/blob/main/images/insegnate3.png)


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
