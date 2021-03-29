# Angular 10 - C# .NET 5 Web API - Character Calculator - Online Character Count Tool Application with Angular 10 and .NET 5 Web API [Year of Development: 2017 and 2021]

About the application technologies and operation:

### Technologies:

- Programming Language: C# - TypeScript
- FrontEnd Side: Angular CLI 10.2.0 (Node: 14.5.0)
- BackEnd Side: .NET 5 (Web API)
- Descriptive Language: HTML5
- Style Description Language: SCSS (Bootstrap 4.6.0)
- Other used modul FrontEnd Side:
  - rxjs (^6.6.0)
  - fortawesome/angular-fontawesome (^0.7.0)
  - fortawesome/fontawesome-svg-core (^1.2.34)
  - fortawesome/free-solid-svg-icons (^5.15.2)
  - ngx-bootstrap (^6.2.0)
  - ngx-toastr (^13.2.0)
- Other used modul BackEnd Side:
  - EntityFrameworkCore (v5.0.4)
  - MediatR (v9.0.0)
  - NLog (v4.11.0)
  - Swagger (v5.6.3)

### BackEnd Application solution structure:

- **Application.Web**:
  - This is the Web API Layer.
  - Includes IoC DI Registers, with separate configuration files.
  - Includes each extension for Web API (for example: Middlewares, Hosts, etc).
  - Includes Middleware for Global Error Handling.
  - Includes configuration settings for the Swagger.
  - Includes configuration settings for NLog.
- **Application.DataAccessLayer**:
  - Includes the DataBase Contexts _(Write and Read Contexts)_.
  - Includes every DataBase Entities.
  - Includes Extensions for DataBase Context _(you can see more information about this in: WordsCounterDbContextExtension.InitDatabase method)_.
  - Includes generated Database Migrations.
- **Application.Core**:
  - This project includes all elements that can be used by any point in the application.
  - This project does not include any business logic.
  - Includes the general application configuration keys and models.
  - Includes the general global error handling constants, models, enums and exceptions.
  - Includes Command and Query interfaces for MediatR.
  - Includes static datasets _(for example: content types)_.
- **Application.BusinessLogicLayer**:
  - This project includes the Business Logic.
  - The business logic can be divided into modules.
  - The module folders contain the following: Commands- Querys with Handlers, Dtos, Services with Interfaces and Request- Response Models for Web API endpoints.
  - Includes the Command and Query abstractions for MediatR.

### FrontEnd Application solution structure:

- **./src/app/core**:
  - This folder includes all elements that can be used by any point in the application.
  - The central services, interceptors and third party tools are registered here. (for exapmle: inetrceptor for global error handling or ToastrModule, etc.).
  - Includes the general global error handling constants, models, enums and interceptors.
  - Includes the third party tools constants.
  - Includes the data models for routing.
  - Includes the core module.
- **./src/app/modules**:
  - Include all interface used to display business logic.
- **./src/app/shared**:
  - Includes every font-awesome icons that the application uses.
  - Includes the header container and components furthermore services.
  - Includes the footer container.
  - Includes the ribbon toastr container, animations and services.
  - Includes the shared module.
- **./src/app**:
  - Includes the app routing module.
    - All modules are registered here using the lazy loading method.
  - Includes the app component html file.
    - All shared components and router-outlet are embedded here.
  - Includes the app component styles.
  - Includes the app component typescript file.
  - Includes the app module.
    - The shared and core modules are registered here.

### Installation/ Configuration:

1. **[BackEnd]** Restore necessary Packages on the selected project, run the following command in **PM Console**

   ```
   Update-Package -reinstall
   ```

2. **[FrontEnd]** If you do not already have the Angular CLI installed on your computer, so run the following command in CMD

   ```
   npm install -g @angular/cli
   ```

3. **[FrontEnd]** Restore necessary node_modules, so run the following command in GIT Bash Console in the application WordsCounter-FrontEnd root directory

   ```
   npm install --force
   ```

4. **[FrontEnd]** Start the application client side, so run the following command in GIT Bash Console in the application WordsCounter-FrontEnd root directory

   ```
   ng serve
   ```

5. **[BackEnd]** And launch the application BackEnd side!

6. After launching the app, you can access the app at the following URL

   ```
   http://localhost:4200/
   ```

### About the application:

**What Is This?**

Character Counter is an online character count calculator tool, which is simple to use.

**How Is It Used?**

You can copy and paste your text with the characters to count in the text area above, or you can type your characters and words into the text area.
The counter will be updated instantly, displaying:

- **Amount of Characters**
- **Amount of Characters without spaces**
- **Words**
- **Sentences**
- **Paragraphs**
- **Alpha Numeric Characters**
- **Numeric Characters**
- **Alpha Characters**
- **Unique Words**
- **Short- and Long Words**

in your text, not to mention that the:

- **Keyword Density (TOP 10)**
- **Keyword Density**

are also displayed.
