# clean_architecture_example

this project contains :
- project.api : the controllers and Program.cs
- project.Contracts : the authentication classes
- project.Infra : the infrastructure of the app
- project.Application : the services 
- project.Domain : the domaine layer


project reference :
- api to contract && api to application && to infra 
- infra to application
- application to Domain

endpoints and handle :
*Authentication
    1. POST  ~/auth/register 
    2. POST  ~/auth/login
    3. Controller authenticationController in project.api
    4. Authentication Request in project.Contracts
    5. Handle Authentication Service in project.Application


