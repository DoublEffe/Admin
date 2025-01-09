// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const path = window.location.pathname
const container = document.getElementsByClassName('container-fluid')
const div = document.createElement('div')
const ul = document.createElement('ul')
const li = document.createElement('li')
const a = document.createElement('a')
a.innerText = 'Logout'
a.setAttribute('href', '/')
const divClass = 'navbar-collapse collapse d-sm-inline-flex justify-content-end'.split(' ')
const ulClass = 'navbar-nav flex-grow-1 justify-content-sm-end'.split(' ')
const liClass = 'nav-item'.split(' ')
const aClass = 'nav-link text-dark'.split(' ')
div.classList.add(...divClass)
ul.classList.add(...ulClass)
li.classList.add(...liClass)
a.classList.add(...aClass)
li.appendChild(a)
ul.appendChild(li)
div.appendChild(ul)


if (path === '/Home' || path === '/Add' || path === '/Update'){
  container[0].appendChild(div)
}