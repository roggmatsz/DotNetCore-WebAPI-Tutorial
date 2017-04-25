# DotNetCore-WebAPI-Tutorial

## What is it?
It is the result of following [this tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-vsc) on WebAPI
for .Net Core.

## But why though?
I want to further consolidate my understanding of both C#, .Net Core, and to spend time working with Entity Framework. I "published it" here as a convenience to myself,
since I do development on a Win10 machine at home and a MacBook Pro on the go. 

## What does it do?
Nothing terribly fancy. You can create, update, and delete todos using the following URL scheme: 
- Create: POST, domain:port/api/todo/ ; Todo JSON definition in body.
- Read: GET, domain:port/api/todo/[id]
- Read All: GET, domain:port/api/todo
- Update: PUT, domain:port/api/todo/[id] ; Todo JSON definition in body.
- Delete: DELETE, domain:port/api/todo/[id]
