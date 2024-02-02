# Eau Claire's Salon Management System

#### This project acts as a client relations management system for a hair salon that keeps track of which clients are assigned to stylists.

Created by: [github.com/mejia-dev](https://github.com/mejia-dev)


## Technologies Used

* C#
* ASP.NET / MVC
* MySQL
* Razor


## Description

This project utilizes ASP.NET to allow manager keep track of clients and stylists. The project is backed by an included database schema.

Features:
* Allows user to set up stylists and attach clients to each of the stylists.


## 1 - Setup/Installation Prerequisite Requirements
This section will cover how to install the .NET SDK, MySQL Community Server, and MySQL Workbench. If you already have these applications installed and running at at least version 8.0, proceed to the section [Project Setup Requirements](#2---project-setup-requirements) section below.

### Prerequisite A: .NET SDK Installation

##### Step 1: Download .NET SDK
* Download the .NET 6 SDK (Software Development Kit). To view all download options for the .NET 6 SDK, visit this page. Or, click on any of the following links for an immediate download from Microsoft:

  For [Windows](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.402-windows-x64-installer)

  For [Macs with Apple Chip](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.402-macos-arm64-installer)

  For [Macs with Intel Chip](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.402-macos-x64-installer)


##### Step 2: Install the SDK
* Open the file. This will launch an installer which will walk you through installation steps. Use the default settings the installer suggests.


##### Step 3: Test Installation
* Confirm the installation is successful. First, restart your command line shell (Terminal or GitBash) if it's already open, and then run the command "dotnet --version" (without quotes). You should see a version number as a response.


### Prerequisite B: MySQL Workbench 

#### MacOS Instructions:

##### MacOS Step 1: Download the MySQL Community Server Installer
* Start by downloading the MySQL Community Server .dmg file from the MySQL Community Server page:

  For [Catalina and above, AND an M2 chip](https://dev.mysql.com/downloads/file/?id=518602)

  For [Catalina and above, AND an M1 chip](https://dev.mysql.com/downloads/file/?id=508094)

  For [Catalina and above, AND an Intel chip](https://dev.mysql.com/downloads/file/?id=508095)

  For [High Sierra or Mojave](https://dev.mysql.com/downloads/file/?id=484914)


##### MacOS Step 2: Install MySQL Community Server
* Launch the installer. Accept all prompts until you reach the Configuration page. Once you've reached Configuration, select or set the following options (use default if not specified):

  * Use Legacy Password Encryption.
  * Set password to a password of your choosing. This password will become necessary later for project setup.
  * Select "Finish".


##### MacOS Step 3: Configure Environment Variables
* Open the terminal to set your environment variables using either of the following commands. When finished, close all terminal windows.

  * For bash users:
    ```bash
    echo 'export PATH="/usr/local/mysql/bin:$PATH"' >> ~/.bash_profile
    ```

  * For zsh users:
    ```bash
    echo 'export PATH="/usr/local/mysql/bin:$PATH"' >> ~/.zshrc
    ```


##### MacOS Step 4: Test Installation (MySQL Community Server)
* From a new terminal window, attempt to login to mysql to confirm it is configured properly.
  Substitue "YOUR_PASSWORD_HERE" for the password you set during installation.

  ```bash
  mysql -uroot -pYOUR_PASSWORD_HERE
  ```
  There will be an intro message, and the prompt should change to: `mysql> `. This confirms that mysql is installed and everything is working as expected.
  If you instead receive a `mysql: command not found` error, attempt to uninstall any versions of the applications that are previously installed, then follow this installation guide again.


##### MacOS Step 5: Download MySQL Workbench
* Download the MySQL Workbench .dmg file from the MySQL Workbench page:

  For [Big Sur or above](https://dev.mysql.com/downloads/file/?id=507344)

  For Catalina, you will need to do a few more steps, since there is no readily available download page for the Workbench version required. Follow these steps:
  * Navigate to the workbench download archives by clicking [this link](https://downloads.mysql.com/archives/workbench/). There will be two drop-down menus, one for "Product Version" and the other for "Operating System".
  * For "Product Version", select "8.0.23"
  * For "Operating System", select "macOS".
  * Next, select "Download" for the package called "macOS (x86, 64-bit), DMG Archive".

  For [High Sierra or Mojave](https://dev.mysql.com/downloads/file/?id=484391)

  
##### MacOS Step 6: Install MySQL Workbench
* Run the installer for the MySQL Workbench and install it to the Applications folder. Accept all defaults.


##### MacOS Step 7: Test Installation (MySQL Workbench)
* Launch the MySQL Workbench.
  Once opened, select the "Local instance 3306" server. You will need to enter the password you set in the installation steps for MySQL Community Server. If it connects, you're all set!




#### Windows 10/11 Instructions:

##### Windows Step 1: Download the MySQL Web Installer
* Download the MySQL Web Installer from the [MySQL Downloads](https://downloads.mysql.com/archives/get/p/25/file/mysql-installer-web-community-8.0.19.0.msi) page. 


##### Windows Step 2: Install the MySQL Web Programs
* Follow along with the installer as described below. If a step is not specifically listed, accept the defaults.

  * Select "Yes" if prompted to update.
  * Accept license terms.
  * Choose "Custom" setup type.
  * In the "Select Products and Features" menu, choose the following:
    * Check the box titled "Enable the Select Features page to customize product features".
    * Under *MySQL Servers > MySQL Server > MySQL Server 8.0*, select "MySQL Server 8.0.19" (or latest available version).
    * Under *Applications > MySQL Workbench > MySQL Workbench 8.0*, select "MySQL Workbench 8.0.19" (or latest available version).
  * Select "Next", then "Execute". Wait for download and installation. This can take some time.
  * Continue through the following Configuration steps:
    * Set "High Availability" to "Standalone".
    * Set "Type and Networking" to "Defaults are OK".
    * Set "Authentication Method" to "Use Legacy Authentication Method".
    * Set password to a password of your choosing. This password will become necessary later for project setup.
    * Set "Windows Service" to "Defaults are OK". Ensure that the following options are selected:
      * "Configure MySQL Server as a Windows Service".
      * "Start the MySQL Server at System Startup".
      * "Run Windows Service" should be set to "Standard System Account".
  * Complete the installation as prompted.


##### Windows Step 3: Configure Environment Variables
* The terminal (CLI, PowerShell, and GitBash) now need to be configured to recognize the mysql command. This can be done through changing the environment variables.

  * Press the **Windows** key and **R** key simultaneously to bring up the Run prompt. 
  * In the run prompt, type in `sysdm.cpl`, then press Enter.
  * In the System Properties window that appears, navigate to the "Advanced" tab, then select "Environment Variables...".
    * In the Environment Variables window, under the "System Variables" section, double-click on the "Path" variable to launch it's editing window.
      * In the editing window, select the "New" button in the top right, then enter the installation path of the MySQL Server. 
      For most installations, this should be `C:\Program Files\MySQL\MySQL Server 8.0\bin`, but may vary depending on the version installed.
      * When finished, select "OK".
    * Select "OK".
  * Select "Apply", then select "OK".


##### Windows Step 4: Test Installation (MySQL Community Server)
* From a new PowerShell window, attempt to login to mysql to confirm it is configured properly.
  Substitue "YOUR_PASSWORD_HERE" for the password you set during installation.

  ```powershell
  mysql -uroot -pYOUR_PASSWORD_HERE.
  ```

  There will be an intro message, and the prompt should change to: `mysql> `. This confirms that mysql is installed and everything is working as expected.
  If you instead receive a `The term 'mysql' is not recognized as the name of a cmdlet, function, script file, or operable program` error, double-check that the environment variables were set up correctly. If all else fails, attempt to uninstall any versions of the applications that are previously installed, then follow this installation guide again.


##### Windows Step 5: Test Installation (MySQL Workbench)
* Finally, open MySQL Workbench and select the Local instance 3306 server. You will need to enter the password you set during installation. If it connects, you're all set!




## 2 - Project Setup Requirements

#### Step 1: Clone Repo
* Clone this repository to your desktop by running the following command from your Git Bash console:
  ```bash
   git clone https://github.com/mejia-dev/hair-salon.git
   ```

#### Step 2: Import .sql File
* The SQL database file must now be imported into the MySQL Workbench so that the project can be run.

  * Launch the MySQL Workbench and open the instance you'd like to use (usually the default at localhost:3306).
    * From the Navigator pane (usually on the left), select the Administration tab, then select "Data Import/Restore" from the list of options in the Management section.
    * In the Administration page that appears, select the following options: 
      * Under the "Import Options" section, select "Import from Self-Contained File". 
        * From the project's root directory, select the file ending in `.sql` to be imported.
      * Under "Default Schema to be Imported To", select "New...".
        * Name the schema `aaron-mejia`, then select "OK".
      * Select the "Start Import" button. If the button is not visible, expand the window, or use the Start Import button on the "Import Progress" tab instead.
    * From the Navigator pane, select the Schemas tab.
      * Right-click anywhere in the pane and select "Refresh All".
      * Confirm that the new schema appears. If it fails to appear, go through these steps again. **The schema is required for the project to work.**
    

#### Step 3: Create appsettings.json
* This project requires a file titled `appsettings.json` residing in the project directory (not the root directory).
  * Navigate to the project directory:
    ```bash
    cd hair-salon/HairSalon
    ```
  * Create the file:
    ```bash
    touch appsettings.json
    ```
  * Using a text editor of your choice, modify the file to include the following JSON data:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=aaron-mejia;uid=YOUR_USERNAME_HERE;pwd=YOUR_PASSWORD_HERE;"
      }
    }
    ```

    Please note that the DefaultConnection string is essentially broken up into five distinct lines. Replace data from the template as needed for your environment.
    * `Server=localhost;`
    * `Port=3306;`
    * `database=aaron-mejia;` (this should not be changed)
    * `uid=YOUR_USERNAME_HERE;`
    * `pwd=YOUR_PASSWORD_HERE;`


## 3 - Run the Project
* Navigate to the project directory, and to the project subfolder:
  ```bash
  cd hair-salon/HairSalon
  ```

* Run the following command to install dependencies:
  ```bash
  dotnet restore
  ```

* Run the project using:
  ```bash
  dotnet run
  ```



## Known Bugs

* none


## Original Prompt:
You've been referred by Pierre to his friend Claire who is the owner of a hair salon called Eau Claire's Salon. She has contracted you out to create an MVC web application to help her manage her employees (stylists) and their clients. Claire should be able to add a list of stylists working at the salon, and for each stylist, add clients who see that stylist. The stylists have specific specialties, so each client can only see (belong to) a single stylist.

#### User Stories
* As the salon owner, I need to be able to see a list of all stylists.
* As the salon owner, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
* As the salon owner, I need to add new stylists to our system when they are hired.
* As the salon owner, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.


## License

MIT License

Copyright (c) 2023 github.com/mejia-dev

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
