#clean_architecture_example

- [clean architecture example](#clean_architecture_example)
    - [content](#content)
        - [Auth](#Auth)
            - [register](#register)
                - [register request](#register-request)
                - [register response](#register-response)
            - [login](#login)
                - [login request](#login-request)
                - [login response](#login-response)


#content

##this project contains :
- project.api : the controllers and Program.cs
- project.Contracts : the authentication classes
- project.Infra : the infrastructure of the app
- project.Application : the services 
- project.Domain : the domaine layer


project reference :
- api to contract && api to application && to infra 
- infra to application
- application to Domain

##Auth
Authentication
    1. Controller authenticationController in project.api
    2. Authentication Request in project.Contracts
    3. Handle Authentication Service in project.Application

###register

```js
POST  ~/auth/register
```

#register request

```json
{
    "firstname" : "john",
    "lastname" : "Doe",
    "email" : "john@doe.fr",
    "password" : "blablabla"
}
```


#register response

```js
200 OK
```

```json
{
    "id": "dejh987Ggug7898",
    "firstname" : "john",
    "lastname" : "Doe",
    "email" : "john@doe.fr",
    "token" : "dleieÇ!ÀHKàç98098"
}
```

###login

```js
POST  ~/auth/login
```

#login-request

```json
{
    "email" : "john@doe.fr",
    "password" : "blablabla"
}
```


#login-response

```js
200 OK
```

```json
{
    "id": "dejh987Ggug7898",
    "firstname" : "john",
    "lastname" : "Doe",
    "email" : "john@doe.fr",
    "token" : "dleieÇ!ÀHKàç98098"
}
```